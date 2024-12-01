namespace AdventOfCode.Console.Day1;

class LocationList
{
    public List<int> LocationIds { get; init; }
    private int indexForSmallest = 0;
    public int Count => LocationIds.Count;

    public LocationList(List<int> locationIds)
    {
        LocationIds = locationIds;
        LocationIds.Sort();
    }

    public int GetSmallest()
    {
        return LocationIds[indexForSmallest++];
    }

    public int CalculateSimilarityScoreWith(LocationList otherList)
    {
        var similarities = CalculateSimilaritiesWith(otherList);
        List<int> similiarityMultiples = [];
        for (int i = 0; i < similarities.Count; i++)
        {
            similiarityMultiples.Add(LocationIds[i] * similarities[i]);
        }
        return similiarityMultiples.Sum();
    }

    private List<int> CalculateSimilaritiesWith(LocationList otherList)
    {
        List<int> similarities = [];
        foreach (var locationId in LocationIds)
        {
            similarities.Add(otherList.ContainsCount(locationId));
        }
        return similarities;
    }

    public int ContainsCount(int number)
    {
        var firstIndex = LocationIds.FindIndex(id => id == number);
        if (firstIndex == -1)
        {
            return 0;
        }
        int count = 0;

        for (int i = firstIndex; i < LocationIds.Count; i++)
        {
            if (LocationIds[i] != number)
            {
                break;
            }
            count++;
        }

        return count;
    }

    public override string ToString()
    {
        return string.Join("\n", LocationIds);
    }
}
