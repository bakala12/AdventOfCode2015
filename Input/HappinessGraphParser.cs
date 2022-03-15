using AdventOfCode2015.Models;

namespace AdventOfCode2015.Input
{
    public class HappinessGraphParser : IInputParser<HappinessGraph>
    {
        public HappinessGraph ParseInput(string input)
        {
            var graph = new HappinessGraph();
            foreach(var line in input.Split(Environment.NewLine))
            {
                var s = line.Split();
                var units = int.Parse(s[3]);
                var e = new HappinessGraph.Edge(s[0], s[10].Trim('.'), s[2] == "gain" ? units : -units);
                if(!graph.Edges.ContainsKey(e.From))
                    graph.Edges[e.From] = new List<HappinessGraph.Edge>();
                graph.Edges[e.From].Add(e);
            }
            return graph;
        }
    }
}