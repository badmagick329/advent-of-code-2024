namespace AdventOfCode.Console.Day4;

public record struct Coordinate(int X, int Y);

class MatchedCoordinates
{
    public Coordinate[] Coordinates { get; set; } = new Coordinate[4];

    public override bool Equals(object? obj)
    {
        if (obj is MatchedCoordinates other)
        {
            for (int i = 0; i < Coordinates.Length; i++)
            {
                if (Coordinates[i] != other.Coordinates[i])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    public static bool operator ==(MatchedCoordinates p1, MatchedCoordinates p2)
    {
        return p1.Equals(p2);
    }

    public static bool operator !=(MatchedCoordinates p1, MatchedCoordinates p2)
    {
        return !p1.Equals(p2);
    }

    public override int GetHashCode()
    {
        return Coordinates[0].GetHashCode()
            ^ Coordinates[1].GetHashCode()
            ^ Coordinates[2].GetHashCode()
            ^ Coordinates[3].GetHashCode();
    }

    public override string ToString()
    {
        return $"({Coordinates[0].X}, {Coordinates[0].Y}), ({Coordinates[1].X}, {Coordinates[1].Y}), ({Coordinates[2].X}, {Coordinates[2].Y}), ({Coordinates[3].X}, {Coordinates[3].Y})";
    }
}
