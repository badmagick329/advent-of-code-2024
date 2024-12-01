using System.Diagnostics;

namespace AdventOfCode.Console.Day1;

public class AocDay1 : AocDay
{
    public override void Part1()
    {
        RunPart1("./src/AdventOfCode.Console/Day1/input1.txt");
    }

    public override void Part1Test()
    {
        RunPart1("./src/AdventOfCode.Console/Day1/testinput1.txt");
    }

    private static void RunPart1(string filename)
    {
        var locationLists = LocationListsFromInputFile(filename);
        Debug.Assert(locationLists.Count == 2);
        var firstLocationList = locationLists[0];
        var secondLocationList = locationLists[1];
        Debug.Assert(firstLocationList.Count == secondLocationList.Count);

        List<Pair> pairs = [];
        for (int i = 0; i < firstLocationList.Count; i++)
        {
            pairs.Add(
                new Pair
                {
                    First = firstLocationList.GetSmallestAndRemove(),
                    Second = secondLocationList.GetSmallestAndRemove(),
                }
            );
        }
        var totalDistance = pairs.Select(p => p.Distance).Sum();
        System.Console.WriteLine($"Total distance: {totalDistance}");
    }

    public override void Part2()
    {
        RunPart2("./src/AdventOfCode.Console/Day1/input2.txt");
    }

    public override void Part2Test()
    {
        RunPart2("./src/AdventOfCode.Console/Day1/testinput2.txt");
    }

    private void RunPart2(string filename)
    {
        throw new NotImplementedException();
    }

    private static List<LocationList> LocationListsFromInputFile(string filename)
    {
        var inputLines = File.ReadAllLines(filename);
        List<int> numbersForFirstList = [];
        List<int> numbersForSecondList = [];

        foreach (var line in inputLines)
        {
            var parts = line.Split();
            for (int i = 0; i < parts.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(parts[i]))
                {
                    continue;
                }
                if (i % 2 == 0)
                {
                    numbersForFirstList.Add(Convert.ToInt32(parts[i]));
                }
                else
                {
                    numbersForSecondList.Add(Convert.ToInt32(parts[i]));
                }
            }
        }
        return [new LocationList(numbersForFirstList), new LocationList(numbersForSecondList)];
    }
}
