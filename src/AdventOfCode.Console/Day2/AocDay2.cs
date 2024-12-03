namespace AdventOfCode.Console.Day2;

public class AocDay2 : AocDay
{
    public override void Part1()
    {
        var safeReportsCount = ReportsFromFile("./src/AdventOfCode.Console/Day2/input1.txt")
            .Select(report => report.IsSafe())
            .Count(s => s == true);
        System.Console.WriteLine($"Safe reports: {safeReportsCount}");
    }

    public override void Part1Test()
    {
        var safeReportsCount = ReportsFromFile("./src/AdventOfCode.Console/Day2/testinput1.txt")
            .Select(report => report.IsSafe())
            .Count(s => s == true);
        System.Console.WriteLine($"Safe reports: {safeReportsCount}");
    }

    public override void Part2()
    {
        var safeReportsCount = ReportsFromFile("./src/AdventOfCode.Console/Day2/input1.txt")
            .Select(report => report.IsSafePart2())
            .Count(s => s == true);
        System.Console.WriteLine($"Safe reports: {safeReportsCount}");
    }

    public override void Part2Test()
    {
        var safeReportsCount = ReportsFromFile("./src/AdventOfCode.Console/Day2/testinput1.txt")
            .Select(report => report.IsSafePart2())
            .Count(s => s == true);
        System.Console.WriteLine($"Safe reports: {safeReportsCount}");
    }

    private static IEnumerable<Report> ReportsFromFile(string filename)
    {
        return File.ReadAllLines(filename).Select(line => new Report(line));
    }
}
