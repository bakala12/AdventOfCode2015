namespace AdventOfCode2015.Models
{
    public class HappinessGraph
    {
        public record struct Edge(string From, string To, int Value);

        public Dictionary<string, List<Edge>> Edges = new Dictionary<string, List<Edge>>();
    }
}