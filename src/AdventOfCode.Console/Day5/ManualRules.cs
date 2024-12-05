namespace AdventOfCode.Console.Day5;

class ManualRules
{
    public List<string> Rules { get; private set; } = [];

    public void AddRule(string rule)
    {
        Rules.Add(rule);
    }

    public bool ManualIsCorrect(int[] manual)
    {
        return Rules
            .Select(rule => RuleIsObserved(rule, manual))
            .All(ruleIsObserved => ruleIsObserved == true);
    }

    private static bool RuleIsObserved(string rule, int[] manual)
    {
        var pages = rule.Split("|").Select(r => int.Parse(r)).ToArray();
        int beforePage = pages[0];
        int afterPage = pages[1];

        if (!(manual.Contains(beforePage) && manual.Contains(afterPage)))
        {
            return true;
        }

        bool afterPageEncountered = false;
        foreach (var page in manual)
        {
            if (page == afterPage)
            {
                afterPageEncountered = true;
            }

            if (page == beforePage)
            {
                return !afterPageEncountered;
            }
        }

        throw new Exception("erm..");
    }
}
