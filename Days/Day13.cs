using AdventOfCode2015.Input;
using AdventOfCode2015.Models;

namespace AdventOfCode2015.Days
{
    public class Day13 : AocDay<HappinessGraph>
    {
        public Day13(IInputParser<HappinessGraph> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(HappinessGraph input)
        {
            var visited = input.Edges.Keys.ToDictionary(e => e, e => false);
            var first = input.Edges.Keys.First();
            visited[first] = true;
            Console.WriteLine(FindBestCycle(input, visited, 0, first, first));
        }

        protected override void Part2(HappinessGraph input)
        {
            input.Edges["You"] = new List<HappinessGraph.Edge>();
            Part1(input);
        }

        private static int FindBestCycle(HappinessGraph graph, Dictionary<string, bool> visited, int currentCost, string first, string last)
        {
            if(visited.All(v => v.Value))
                return currentCost + graph.Edges[last].FirstOrDefault(e => e.To == first).Value + graph.Edges[first].FirstOrDefault(e => e.To == last).Value;
            int max = int.MinValue;
            foreach(var v in visited)
            {
                if(!v.Value)
                {
                    visited[v.Key] = true;
                    max = Math.Max(max, FindBestCycle(graph, visited, currentCost + graph.Edges[last].FirstOrDefault(e => e.To == v.Key).Value + graph.Edges[v.Key].FirstOrDefault(e => e.To == last).Value, first, v.Key));
                    visited[v.Key] = false;
                }
            }
            return max;
        }
    }
}