namespace AdventOfCode.Console.Day1;

class Pair
{
    public int First { get; init; }
    public int Second { get; init; }

    public int Distance => Math.Abs(First - Second);
}
