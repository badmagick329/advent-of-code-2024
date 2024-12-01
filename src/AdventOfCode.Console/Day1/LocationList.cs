namespace AdventOfCode.Console.Day1;

class LocationList
{
    public List<int> LocationIds { get; init; }
    private List<int> SortedIds { get; init; }
    public int Count => LocationIds.Count;

    public LocationList(List<int> locationIds)
    {
        LocationIds = locationIds;
        SortedIds = [.. LocationIds.OrderByDescending(id => id)];
    }

    public int GetSmallestAndRemove()
    {
        var smallest = SortedIds.Last();
        SortedIds.Remove(smallest);
        return smallest;
    }

    public int ContainsCount(int number) => LocationIds.Count(id => id == number);

    private List<int> CalculateSimilaritiesWith(LocationList otherList)
    {
        List<int> similarities = [];
        foreach (var locationId in LocationIds)
        {
            similarities.Add(otherList.ContainsCount(locationId));
        }
        return similarities;
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

    public override string ToString()
    {
        return string.Join("\n", LocationIds);
    }
}
