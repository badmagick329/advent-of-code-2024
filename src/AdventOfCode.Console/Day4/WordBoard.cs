using System.Text;

namespace AdventOfCode.Console.Day4;

class WordBoard
{
    private readonly char[,] _board;
    private readonly XmasMatcher _xmasMatcher = new();
    private const int _maxLookUp = 4;
    public int MatchCount = 0;

    public WordBoard(string[] lines)
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
                if (_board[x, y] != 'X' && _board[x, y] != 'S')
                {
                    continue;
                }

                var coords = HorizontalLtoR(x, y);
                LookForMatchAndUpdateCount(coords);
                coords = VerticalTtoB(x, y);
                LookForMatchAndUpdateCount(coords);
                coords = DiagonalTLtoBR(x, y);
                LookForMatchAndUpdateCount(coords);
                coords = DiagonalBLtoTR(x, y);
                LookForMatchAndUpdateCount(coords);
            }
        }
    }

    private void LookForMatchAndUpdateCount(List<Coordinate>? coords)
    {
        if (coords is null)
        {
            return;
        }

        var readCoords = new Coordinate[4];
        for (int i = 0; i < coords.Count; i++)
        {
            _xmasMatcher.Read(_board[coords[i].X, coords[i].Y]);
            readCoords[i] = coords[i];
            if (_xmasMatcher.State == MatchState.Successful)
            {
                MatchCount++;
            }
        }
    }

    private List<Coordinate>? HorizontalLtoR(int x, int y)
    {
        if (x > _board.GetLength(0) - _maxLookUp)
        {
            return null;
        }

        var coords = new List<Coordinate>();
        for (int i = 0; i < _maxLookUp; i++)
        {
            coords.Add(new Coordinate(x + i, y));
        }
        return coords;
    }

    private List<Coordinate>? VerticalTtoB(int x, int y)
    {
        if (y > _board.GetLength(1) - _maxLookUp)
        {
            return null;
        }

        var coords = new List<Coordinate>();
        for (int i = 0; i < _maxLookUp; i++)
        {
            coords.Add(new Coordinate(x, y + i));
        }
        return coords;
    }

    private List<Coordinate>? DiagonalTLtoBR(int x, int y)
    {
        if (x > _board.GetLength(0) - _maxLookUp || y > _board.GetLength(1) - _maxLookUp)
        {
            return null;
        }

        var coords = new List<Coordinate>();
        for (int i = 0; i < _maxLookUp; i++)
        {
            coords.Add(new Coordinate(x + i, y + i));
        }
        return coords;
    }

    private List<Coordinate>? DiagonalBLtoTR(int x, int y)
    {
        if (x > _board.GetLength(0) - _maxLookUp || y < _maxLookUp - 1)
        {
            return null;
        }

        var coords = new List<Coordinate>();
        for (int i = 0; i < _maxLookUp; i++)
        {
            coords.Add(new Coordinate(x + i, y - i));
        }
        return coords;
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
