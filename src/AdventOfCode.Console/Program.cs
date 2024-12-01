namespace AdventOfCode.Console;

using System;
using System.Diagnostics;
using Day1;

class Program
{
    public static void Main(string[] args)
    {
        var day = GetDay(args);
        Console.WriteLine($"Day {day}");
        var aocDay = FromNumber(day);
        aocDay.Part1();
    }

    static ulong GetDay(string[] args)
    {
        Debug.Assert(args.Length == 1);
        ulong dayArg;
        try
        {
            dayArg = Convert.ToUInt64(args[0]);
            return dayArg;
        }
        catch (Exception e)
        {
            throw new ArgumentException("Invalid argument: " + e.Message);
        }
    }

    static AocDay FromNumber(ulong num)
    {
        return num switch
        {
            1 => new AocDay1(),
            _ => throw new ArgumentException("Invalid day number"),
        };
    }
}
