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
        throw new NotImplementedException();
    }

    public override void Part2Test()
    {
        throw new NotImplementedException();
    }

    private static IEnumerable<Report> ReportsFromFile(string filename)
    {
        return File.ReadAllLines(filename).Select(line => new Report(line));
    }
}
