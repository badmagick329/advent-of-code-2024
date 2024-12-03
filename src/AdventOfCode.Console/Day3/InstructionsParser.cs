namespace AdventOfCode.Console.Day3;

class InstructionsParser
{
    readonly string[] _instructions;
    public int Total { get; private set; }

    public InstructionsParser(string[] instructions)
    {
        _instructions = instructions;
    }

    public int Parse()
    {
        Total = 0;
        bool enabled = true;
        foreach (var instruction in _instructions)
        {
            if (instruction.Length == 7)
            {
                enabled = false;
                continue;
            }

            if (instruction.Length == 4)
            {
                enabled = true;
                continue;
            }
            if (!enabled)
            {
                continue;
            }

            var parts = instruction[4..].Split(",");
            Total += int.Parse(parts[0]) * int.Parse(parts[1][..^1]);
        }
        return Total;
    }
}
