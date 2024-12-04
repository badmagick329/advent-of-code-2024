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
        // foreach (var matchCoord in wordBoard.MatchedCoordinatesList)
        // {
        //     System.Console.WriteLine(matchCoord);
        // }
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
