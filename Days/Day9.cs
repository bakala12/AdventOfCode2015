using AdventOfCode2015.Input;
using AdventOfCode2015.Models;

namespace AdventOfCode2015.Days
{
    public class Day9 : AocDay<LocationGraph>
    {
        public Day9(IInputParser<LocationGraph> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(LocationGraph input)
        {
            Console.WriteLine(FindMinPath(input));
        }

        protected override void Part2(LocationGraph input)
        {
            var g = new LocationGraph(input.Edges.ToDictionary(k => k.Key, k => k.Value.Select(e => new LocationGraphEdge(e.From, e.To, -e.Distance)).ToList()));
            Console.WriteLine(-FindMinPath(g));
        }

        private int FindMinPath(LocationGraph graph)
        {
            int min = int.MaxValue;
            foreach(var s in graph.Edges.Keys)
            {
                var v = graph.Edges.Keys.ToDictionary(k => k, k => false);
                v[s] = true;
                min = Math.Min(min, FindMinPath(graph, v, s, 0));
            }
            return min;
        }

        private int FindMinPath(LocationGraph graph, Dictionary<string, bool> visited, string last, int currentCost)
        {
            if(visited.All(b => b.Value))
                return currentCost;
            int min = int.MaxValue;
            foreach(var e in graph.Edges[last])
            {
                if(!visited[e.To])
                {
                    visited[e.To] = true;
                    min = Math.Min(FindMinPath(graph, visited, e.To, currentCost + e.Distance), min);
                    visited[e.To] = false;
                }
            }
            return min;
        }
    }
}