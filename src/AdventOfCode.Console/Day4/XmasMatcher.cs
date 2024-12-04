namespace AdventOfCode.Console.Day4;

class XmasMatcher
{
    private readonly char[] _readChars = new char[4];
    private int idx = 0;
    private int _direction = 1;
    private readonly char[] _searchChars = ['X', 'M', 'A', 'S'];
    public MatchState State { get; private set; } = MatchState.None;

    public void Read(char c)
    {
        switch (c)
        {
            case 'X'
            or 'S' when State != MatchState.InProgress:
                StartReading(c);
                State = MatchState.InProgress;
                break;

            case 'X'
            or 'M'
            or 'A'
            or 'S' when State == MatchState.InProgress:
                ContinueReading(c);
                if (IsDoneReading())
                    State = MatchDetected() ? MatchState.Successful : MatchState.None;
                break;

            default:
                State = MatchState.None;
                break;
        }
    }

    private void StartReading(char c)
    {
        if (c == 'X')
        {
            idx = 0;
            _direction = 1;
        }
        else
        {
            idx = 3;
            _direction = -1;
        }
        ResetReadChars();
        _readChars[idx] = c;
    }

    private void ContinueReading(char c)
    {
        idx += _direction;
        _readChars[idx] = c;
    }

    private bool IsDoneReading()
    {
        return (idx == 0 && _direction == -1) || (idx == 3 && _direction == 1);
    }

    private bool MatchDetected()
    {
        return _readChars.SequenceEqual(_searchChars);
    }

    private void ResetReadChars()
    {
        for (int i = 0; i < _readChars.Length; i++)
        {
            _readChars[i] = '.';
        }
    }
}

enum MatchState
{
    None,
    InProgress,
    Successful,
}
