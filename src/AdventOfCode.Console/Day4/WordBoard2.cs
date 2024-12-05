using System.Text;

namespace AdventOfCode.Console.Day4;

class WordBoard2
{
    private readonly char[,] _board;

    public int MatchCount = 0;

    public WordBoard2(string[] lines)
    {
        _board = new char[lines[0].Length, lines.Length];
        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                _board[x, y] = lines[y][x];
            }
        }
    }

    public void ReadBoard()
    {
        for (int y = 0; y < _board.GetLength(1); y++)
        {
            for (int x = 0; x < _board.GetLength(0); x++)
            {
                if (_board[x, y] != 'A')
                {
                    continue;
                }

                var xShapeLtoR = XShapeLtoR(x, y);
                var xShapeRtoL = XShapeRtoL(x, y);
                if (xShapeLtoR is null || xShapeRtoL is null)
                {
                    continue;
                }

                if (ContainsMatch(xShapeLtoR, xShapeRtoL))
                {
                    MatchCount++;
                }
            }
        }
    }

    private char[]? XShapeLtoR(int x, int y)
    {
        if (!XShapeCoordinatesAreWithinBounds(x, y))
        {
            return null;
        }
        return [_board[x - 1, y - 1], _board[x + 1, y + 1]];
    }

    private char[]? XShapeRtoL(int x, int y)
    {
        if (!XShapeCoordinatesAreWithinBounds(x, y))
        {
            return null;
        }
        return [_board[x + 1, y - 1], _board[x - 1, y + 1]];
    }

    private bool XShapeCoordinatesAreWithinBounds(int x, int y)
    {
        return x > 0 && x < _board.GetLength(0) - 1 && y > 0 && y < _board.GetLength(1) - 1;
    }

    private static bool ContainsMatch(char[] part1, char[] part2)
    {
        return ContainsMas(part1) && ContainsMas(part2);
    }

    private static bool ContainsMas(char[] chars)
    {
        return (chars[0] == 'M' && chars[1] == 'S') || (chars[0] == 'S' && chars[1] == 'M');
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int y = 0; y < _board.GetLength(1); y++)
        {
            for (int x = 0; x < _board.GetLength(0); x++)
            {
                sb.Append(_board[x, y]);
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
}
