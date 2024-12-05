namespace AdventOfCode.Console.Day4;

class AocDay4 : AocDay
{
    public override void Part1()
    {
        var wordBoard = new WordBoard(
            File.ReadAllLines("./src/AdventOfCode.Console/Day4/input.txt")
        );
        wordBoard.ReadBoard();
        System.Console.WriteLine($"Total matches: {wordBoard.MatchedCoordinatesList.Count}");
    }

    public override void Part1Test()
    {
        var wordBoard = new WordBoard(
            File.ReadAllLines("./src/AdventOfCode.Console/Day4/testinput.txt")
        );
        wordBoard.ReadBoard();
        System.Console.WriteLine($"Total matches: {wordBoard.MatchedCoordinatesList.Count}");
    }

    public override void Part2()
    {
        var wordBoard = new WordBoard2(
            File.ReadAllLines("./src/AdventOfCode.Console/Day4/input.txt")
        );
        wordBoard.ReadBoard();
        System.Console.WriteLine($"Total matches: {wordBoard.MasMatchCount}");
    }

    public override void Part2Test()
    {
        var wordBoard = new WordBoard2(
            File.ReadAllLines("./src/AdventOfCode.Console/Day4/testinput2.txt")
        );
        wordBoard.ReadBoard();
        System.Console.WriteLine($"Total matches: {wordBoard.MasMatchCount}");
    }
}
