using System.Diagnostics;

namespace AdventOfCode.Console.Day2;

class Report
{
    public int[] Levels { get; set; }

    public Report(string levels)
    {
        Levels = levels.Split().Select(n => int.Parse(n)).ToArray();
    }

    public bool IsSafe()
    {
        Debug.Assert(Levels.Length > 1);
        var desc = Levels[0] - Levels[1] > 0;
        var prev = Levels[0];
        for (int i = 1; i < Levels.Length; i++)
        {
            int change = desc ? prev - Levels[i] : Levels[i] - prev;
            if (change < 1 || change > 3)
            {
                return false;
            }
            prev = Levels[i];
        }
        return true;
    }
}
