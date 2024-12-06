using System.Text;

namespace AdventOfCode.Console.Day6;

class Lab
{
    public char[,] Map { get; private set; }
    public (int X, int Y) GuardStartingPosition { get; init; }
    public int XLength { get; init; } = 0;
    public int YLength { get; init; } = 0;

    public Lab(string filename)
    {
        var lines = File.ReadAllLines(filename);
        XLength = lines[0].Length;
        YLength = lines.Length;
        Map = new char[lines[0].Length, lines.Length];

        for (int y = 0; y < YLength; y++)
        {
            var parts = lines[y].ToCharArray();
            for (int x = 0; x < parts.Length; x++)
            {
                if (parts[x] == '^')
                {
                    GuardStartingPosition = (x, y);
                }

                Map[x, y] = parts[x];
            }
        }
    }

    public bool IsOutOfBounds(int x, int y) => x < 0 || x >= XLength || y < 0 || y >= YLength;

    public bool IsObstructed(int x, int y) => !IsOutOfBounds(x, y) && Map[x, y] == '#';

    public void Visit(int x, int y) => Map[x, y] = 'X';

    public int Visits()
    {
        int visits = 0;
        for (int y = 0; y < YLength; y++)
        {
            for (int x = 0; x < XLength; x++)
            {
                if (Map[x, y] == 'X')
                {
                    visits++;
                }
            }
        }
        return visits;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int y = 0; y < YLength; y++)
        {
            for (int x = 0; x < XLength; x++)
            {
                sb.Append(Map[x, y]);
            }
            sb.Append("\n");
        }
        return sb.ToString();
    }
}
