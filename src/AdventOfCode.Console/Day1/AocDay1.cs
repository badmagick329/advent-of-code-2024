using System.Diagnostics;
using System.Text.RegularExpressions;

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

    private void RunPart1(string filename)
    {
        var locationLists = LocationListsFromInputFile(filename);
        Debug.Assert(locationLists.Count == 2);
        var firstLocationList = locationLists[0];
        var secondLocationList = locationLists[1];
        Debug.Assert(firstLocationList.Count == secondLocationList.Count);

        var totalDistance = 0;
        for (int i = 0; i < firstLocationList.Count; i++)
        {
            totalDistance += Math.Abs(
                firstLocationList.GetSmallest() - secondLocationList.GetSmallest()
            );
        }
        System.Console.WriteLine($"Total distance: {totalDistance}");
    }

    public override void Part2()
    {
        RunPart2("./src/AdventOfCode.Console/Day1/input1.txt");
    }

    public override void Part2Test()
    {
        RunPart2("./src/AdventOfCode.Console/Day1/testinput1.txt");
    }

    private void RunPart2(string filename)
    {
        var locationLists = LocationListsFromInputFile(filename);
        Debug.Assert(locationLists.Count == 2);
        var firstLocationList = locationLists[0];
        var secondLocationList = locationLists[1];
        Debug.Assert(firstLocationList.Count == secondLocationList.Count);
        var similarityScore = firstLocationList.CalculateSimilarityScoreWith(secondLocationList);
        System.Console.WriteLine(similarityScore);
    }

    private List<LocationList> LocationListsFromInputFile(string filename)
    {
        var inputLines = File.ReadLines(filename);

        List<int> numbersForFirstList = [];
        List<int> numbersForSecondList = [];

        inputLines
            .Select(line => Regex.Match(line, @"(\d+)\s+(\d+)"))
            .Select(match =>
                (L: int.Parse(match.Groups[1].Value), R: int.Parse(match.Groups[2].Value))
            )
            .ToList()
            .ForEach(tup =>
            {
                numbersForFirstList.Add(tup.L);
                numbersForSecondList.Add(tup.R);
            });

        return [new LocationList(numbersForFirstList), new LocationList(numbersForSecondList)];
    }
}
