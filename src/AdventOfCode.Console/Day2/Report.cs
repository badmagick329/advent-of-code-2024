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
        for (int i = 1; i < Levels.Length; i++)
        {
            if (!ChangeIsSafe(Levels[i - 1], Levels[i]))
            {
                return i - 1;
            }
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
        return Enumerable
            .Range(1, Levels.Length - 1)
            .Select(i => Levels[i].CompareTo(Levels[i - 1]))
            .FirstOrDefault(comp => comp != 0) switch
        {
            < 0 => true,
            > 0 => false,
            _ => null,
        };
    }

    public override string ToString() => string.Join(" ", Levels);
}
