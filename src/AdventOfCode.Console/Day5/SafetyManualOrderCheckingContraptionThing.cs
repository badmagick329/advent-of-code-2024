namespace AdventOfCode.Console.Day5;

class SafetyManualOrderCheckingContraptionThing
{
    public List<int> CorrectIndices { get; private set; } = [];
    public List<int[]> SafetyManuals { get; private set; } = [];
    private readonly ManualRules _manualRules = new();

    public SafetyManualOrderCheckingContraptionThing(string filename)
    {
        var readingRulesActive = true;
        foreach (var line in File.ReadAllLines(filename))
        {
            if (string.IsNullOrEmpty(line))
            {
                readingRulesActive = false;
                continue;
            }

            if (readingRulesActive)
            {
                _manualRules.AddRule(line);
                continue;
            }

            SafetyManuals.Add(line.Split(",").Select(page => int.Parse(page)).ToArray());
        }
    }

    public void DetermineCorrectManualIndices()
    {
        for (int i = 0; i < SafetyManuals.Count; i++)
        {
            if (_manualRules.ManualIsCorrect(SafetyManuals[i]))
            {
                CorrectIndices.Add(i);
            }
        }
    }

    public int MiddlePageFor(int manualIndex) =>
        SafetyManuals[manualIndex][SafetyManuals[manualIndex].Length / 2];
}
