using System.Diagnostics;

namespace AdventOfCode.Console.Day2;

class Report
{
    private int[] _levels;
    public int[] Levels
    {
        get { return _levels; }
        set
        {
            _levels = value;
            Desc = IsDesc();
        }
    }
    public bool? Desc { get; private set; }

    public Report(int[] levels)
    {
        Debug.Assert(levels.Length > 1);
        Levels = levels;
    }

    public Report(string levels)
    {
        Debug.Assert(levels.Length > 1);
        Levels = levels.Split().Select(n => int.Parse(n)).ToArray();
    }

    public bool IsSafe()
    {
        return UnsafeOnIndex() == -1;
    }

    public bool IsSafePart2()
    {
        if (IsSafe())
        {
            return true;
        }

        var originalLevels = Levels;
        for (int i = 0; i < Levels.Length; i++)
        {
            RemoveIndexFromLevels(i);
            if (IsSafe())
            {
                return true;
            }
            Levels = originalLevels;
        }

        return false;
    }

    private int UnsafeOnIndex()
    {
        var prev = Levels[0];
        for (int i = 1; i < Levels.Length; i++)
        {
            if (!ChangeIsSafe(prev, Levels[i]))
            {
                return i - 1;
            }
            prev = Levels[i];
        }
        return -1;
    }

    private void RemoveIndexFromLevels(int index)
    {
        Levels = Levels.Where((_, i) => i != index).ToArray();
    }

    private bool ChangeIsSafe(int current, int next)
    {
        if (!Desc.HasValue)
        {
            return false;
        }
        var change = Desc.Value ? current - next : next - current;
        return change >= 1 && change <= 3;
    }

    private bool? IsDesc()
    {
        bool? desc = null;
        for (int i = 1; i < Levels.Length; i++)
        {
            if (Levels[i] < Levels[i - 1])
            {
                desc = true;
                break;
            }
            else if (Levels[i] > Levels[i - 1])
            {
                desc = false;
                break;
            }
        }
        return desc;
    }

    public override string ToString()
    {
        return string.Join(" ", Levels);
    }
}
