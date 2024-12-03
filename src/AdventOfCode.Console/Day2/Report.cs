using System.Diagnostics;

namespace AdventOfCode.Console.Day2;

class Report
{
    public int[] Levels { get; private set; }
    public bool? Desc { get; private set; }

    public Report(int[] levels)
    {
        Levels = levels;
        Debug.Assert(Levels.Length > 1);
        Desc = IsDesc();
    }

    public Report(string levels)
    {
        Levels = levels.Split().Select(n => int.Parse(n)).ToArray();
        Debug.Assert(Levels.Length > 1);
        Desc = IsDesc();
    }

    public bool IsSafe()
    {
        return UnsafeOnIndex() == -1;
    }

    public bool IsSafePart2()
    {
        var unsafeIndex = UnsafeOnIndex();
        if (unsafeIndex == -1)
        {
            return true;
        }

        var origReport = new Report(Levels);
        RemoveIndexFromLevels(unsafeIndex);
        var safe = IsSafe();
        if (safe)
        {
            return true;
        }

        Levels = origReport.Levels;
        Desc = origReport.Desc;
        unsafeIndex = UnsafeOnIndex2();
        RemoveIndexFromLevels(unsafeIndex);
        return IsSafe();
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

    private int UnsafeOnIndex2()
    {
        var prev = Levels[0];
        for (int i = 1; i < Levels.Length; i++)
        {
            if (!ChangeIsSafe(prev, Levels[i]))
            {
                return i;
            }
            prev = Levels[i];
        }
        return -1;
    }

    private void RemoveIndexFromLevels(int index)
    {
        int[] newLevels = new int[Levels.Length - 1];
        for (int i = 0; i < Levels.Length; i++)
        {
            if (i == index)
            {
                continue;
            }
            newLevels[i > index ? i - 1 : i] = Levels[i];
        }
        Levels = newLevels;
        Desc = IsDesc();
    }

    private bool ChangeIsSafe(int current, int next)
    {
        if (!Desc.HasValue)
        {
            return false;
        }
        var change = Desc.Value ? current - next : next - current;
        // System.Console.WriteLine($"Change: {change}");
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
