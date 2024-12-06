namespace AdventOfCode.Console.Day6;

class AocDay6 : AocDay
{
    public override void Part1()
    {
        var lab = new Lab("./src/AdventOfCode.Console/Day6/input.txt");
        var guard = new Guard(lab);
        guard.TraverseLab();
        System.Console.WriteLine($"Visits: {lab.Visits()}");
    }

    public override void Part1Test()
    {
        var lab = new Lab("./src/AdventOfCode.Console/Day6/testinput.txt");
        var guard = new Guard(lab);
        guard.TraverseLab();
        System.Console.WriteLine($"Visits: {lab.Visits()}");
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
