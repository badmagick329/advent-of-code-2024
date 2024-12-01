namespace AdventOfCode.Console.Day1;

class LocationList
{
    public List<int> LocationIds { get; init; }
    private List<int> SortedIds { get; init; }
    public int Count => LocationIds.Count;

    public LocationList(List<int> locationIds)
    {
        LocationIds = locationIds;
        SortedIds = LocationIds.OrderByDescending(id => id).ToList();
    }

    public int GetSmallestAndRemove()
    {
        var smallest = SortedIds.Last();
        SortedIds.Remove(smallest);
        return smallest;
    }

    public override string ToString()
    {
        return string.Join("\n", LocationIds);
    }
}
