namespace AdventOfCode.Console.Day6;

class Guard
{
    public (int X, int Y) Position { get; private set; }
    public (int X, int Y) MoveDirection { get; private set; }
    public Lab Lab { get; private set; }

    public Guard(Lab lab)
    {
        Lab = lab;
        Position = lab.GuardStartingPosition;
        CharToDirection(lab.Map[Position.X, Position.Y]);
    }

    private void CharToDirection(char c)
    {
        MoveDirection = c switch
        {
            '^' => (0, -1),
            'v' => (0, 1),
            '<' => (-1, 0),
            '>' => (1, 0),
            _ => throw new Exception("Invalid direction"),
        };
    }

    public void TraverseLab()
    {
        Lab.Visit(Position.X, Position.Y);
        Position = NextMoveablePosition();

        while (!Lab.IsOutOfBounds(Position.X, Position.Y))
        {
            Lab.Visit(Position.X, Position.Y);
            Position = NextMoveablePosition();
        }
    }

    private (int X, int Y) NextMoveablePosition()
    {
        var nextPosition = NextPosition();
        int turns = 0;
        while (Lab.IsObstructed(nextPosition.X, nextPosition.Y))
        {
            TurnRight();
            nextPosition = NextPosition();
            if (turns > 4)
            {
                throw new Exception("I'm trapped AAAAAAAAAAAAAAAAAAAAAAAAAAA");
            }
        }
        return nextPosition;
    }

    private (int X, int Y) NextPosition()
    {
        return (Position.X + MoveDirection.X, Position.Y + MoveDirection.Y);
    }

    private void TurnRight()
    {
        switch (MoveDirection)
        {
            case (0, -1):
                MoveDirection = (1, 0);
                break;
            case (1, 0):
                MoveDirection = (0, 1);
                break;
            case (0, 1):
                MoveDirection = (-1, 0);
                break;
            case (-1, 0):
                MoveDirection = (0, -1);
                break;
        }
    }
}
