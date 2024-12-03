using System.Text.RegularExpressions;

namespace AdventOfCode.Console.Day3;

public class AocDay3 : AocDay
{
    public override void Part1()
    {
        var result = DoPart1("./src/AdventOfCode.Console/Day3/input.txt");
        System.Console.WriteLine($"Mul result: {result}");
    }

    public override void Part1Test()
    {
        var result = DoPart1("./src/AdventOfCode.Console/Day3/testinput.txt");
        System.Console.WriteLine($"Mul result: {result}");
    }

    private int DoPart1(string filename)
    {
        var matches = Regex.Matches(File.ReadAllText(filename), @"mul\((\d{1,3}),(\d{1,3})\)");
        int mul = 0;
        foreach (Match match in matches)
        {
            mul += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
        }
        return mul;
    }

    public override void Part2()
    {
        throw new NotImplementedException();
    }

    public override void Part2Test()
    {
        throw new NotImplementedException();
    }
}
