using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace AdventOfCode.Console.Day5;

public record struct PageRule(int Before, int After);

class ManualRules
{
    public List<PageRule> Rules { get; private set; } = [];

    public void AddRule(string rule)
    {
        var parts = rule.Split("|").Select(r => int.Parse(r)).ToArray();
        Rules.Add(new PageRule(parts[0], parts[1]));
    }

    public bool ManualIsCorrect(int[] manual)
    {
        return Rules
            .Select(rule => RuleIsObserved(rule, manual))
            .All(ruleIsObserved => ruleIsObserved == true);
    }

    private static bool RuleIsObserved(PageRule rule, int[] manual)
    {
        if (!(manual.Contains(rule.Before) && manual.Contains(rule.After)))
        {
            return true;
        }

        bool afterPageEncountered = false;
        foreach (var page in manual)
        {
            if (page == rule.After)
            {
                afterPageEncountered = true;
            }

            if (page == rule.Before)
            {
                return !afterPageEncountered;
            }
        }

        throw new Exception("erm..");
    }

    public void FixManualInPlace(int[] manual)
    {
        var numberOfFixes = 0;
        var iterations = 0;
        do
        {
            numberOfFixes = Rules
                .Select(r => ApplyRuleAndReturnTrueIfApplied(r, manual))
                .Count(result => result == true);
            iterations++;
            if (iterations > 100)
            {
                throw new Exception("Too many fix iterations");
            }
        } while (numberOfFixes > 0);
    }

    private bool ApplyRuleAndReturnTrueIfApplied(PageRule rule, int[] manual)
    {
        var brokenAt = RuleIsBrokenAt(rule, manual);
        if (brokenAt is null)
        {
            return false;
        }

        (var beforeIndex, var afterIndex) = brokenAt.Value;
        Swap(beforeIndex, afterIndex, manual);
        return true;
    }

    private static (int, int)? RuleIsBrokenAt(PageRule rule, int[] manual)
    {
        if (!(manual.Contains(rule.Before) && manual.Contains(rule.After)))
        {
            return null;
        }

        int afterPagePosition = -1;
        for (int i = 0; i < manual.Length; i++)
        {
            if (manual[i] == rule.After)
            {
                afterPagePosition = i;
            }

            if (manual[i] == rule.Before)
            {
                if (afterPagePosition == -1)
                {
                    return null;
                }
                return (i, afterPagePosition);
            }
        }

        throw new Exception("erm..");
    }

    private static void Swap(int i, int j, int[] manual)
    {
        (manual[j], manual[i]) = (manual[i], manual[j]);
    }
}
