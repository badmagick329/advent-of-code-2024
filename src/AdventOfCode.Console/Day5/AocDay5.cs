namespace AdventOfCode.Console.Day5;

class AocDay5 : AocDay
{
    public override void Part1()
    {
        var contraption = new SafetyManualOrderCheckingContraptionThing(
            "./src/AdventOfCode.Console/Day5/input.txt"
        );
        contraption.DetermineCorrectManualIndices();
        var sum = contraption.CorrectIndices.Select(i => contraption.MiddlePageFor(i)).Sum();
        System.Console.WriteLine($"Sum: {sum}");
    }

    public override void Part1Test()
    {
        var contraption = new SafetyManualOrderCheckingContraptionThing(
            "./src/AdventOfCode.Console/Day5/testinput.txt"
        );
        contraption.DetermineCorrectManualIndices();
        var sum = contraption.CorrectIndices.Select(i => contraption.MiddlePageFor(i)).Sum();
        System.Console.WriteLine($"Sum: {sum}");
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
