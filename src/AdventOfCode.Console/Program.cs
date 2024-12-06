namespace AdventOfCode.Console;

using System;
using System.Diagnostics;

class Program
{
    public static void Main(string[] args)
    {
        var day = GetDay(args);
        Console.WriteLine($"Day {day}");
        var aocDay = FromNumber(day);

        Announce("Running part 1 test");
        RunWithStopwatch(aocDay.Part1Test);

        Announce("Running part 1");
        RunWithStopwatch(aocDay.Part1);

        Announce("Running part 2 test");
        RunWithStopwatch(aocDay.Part2Test);

        Announce("Running part 2");
        RunWithStopwatch(aocDay.Part2);
    }

    static int GetDay(string[] args)
    {
        Debug.Assert(args.Length == 1);
        return args.Length == 1
            ? Convert.ToInt32(args[0])
            : throw new ArgumentException("No day argument provided");
    }

    static AocDay FromNumber(int num)
    {
        return num switch
        {
            1 => new Day1.AocDay1(),
            2 => new Day2.AocDay2(),
            3 => new Day3.AocDay3(),
            4 => new Day4.AocDay4(),
            5 => new Day5.AocDay5(),
            6 => new Day6.AocDay6(),
            _ => throw new ArgumentException("Invalid day number"),
        };
    }

    static void Announce(string annoucement)
    {
        Console.WriteLine($"\n{annoucement}");
        Console.WriteLine("-------------------");
    }

    static void RunWithStopwatch(Action action)
    {
        var start = Stopwatch.StartNew();
        action();
        start.Stop();
        Console.WriteLine($"Elapsed time: {start.ElapsedMilliseconds}ms");
    }
}
