using AdventOfCode2015.Models;

namespace AdventOfCode2015.Input
{
    public class LocationGraphInputParser : IInputParser<LocationGraph>
    {
        public LocationGraph ParseInput(string input)
        {
            var edges = new Dictionary<string, List<LocationGraphEdge>>();
            foreach(var line in input.Split(Environment.NewLine))
            {
                var l = line.Split();
                string from = l[0];
                string to = l[2];
                int dist = int.Parse(l[4]);
                if(!edges.ContainsKey(from))
                    edges[from] = new List<LocationGraphEdge>();
                if(!edges.ContainsKey(to))
                    edges[to] = new List<LocationGraphEdge>();
                edges[from].Add(new LocationGraphEdge(from, to, dist));
                edges[to].Add(new LocationGraphEdge(to, from, dist));
            }
            return new LocationGraph(edges);
        }
    }
}