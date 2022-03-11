namespace AdventOfCode2015.Models
{
    public record struct LocationGraphEdge(string From, string To, int Distance);

    public record struct LocationGraph(Dictionary<string, List<LocationGraphEdge>> Edges);
}