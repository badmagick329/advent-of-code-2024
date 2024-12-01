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
        Console.WriteLine("\nRunning part 1 test");
        Console.WriteLine("-------------------");
        aocDay.Part1Test();
        Console.WriteLine("\nRunning part 1");
        Console.WriteLine("-------------------");
        aocDay.Part1();
        Console.WriteLine("\nRunning part 2 test");
        Console.WriteLine("-------------------");
        aocDay.Part2Test();
        Console.WriteLine("\nRunning part 2");
        Console.WriteLine("-------------------");
        aocDay.Part2();
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
            _ => throw new ArgumentException("Invalid day number"),
        };
    }
}
