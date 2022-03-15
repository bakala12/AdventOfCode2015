using AdventOfCode2015.Input;
using AdventOfCode2015.Models;

namespace AdventOfCode2015.Days
{
    public class Day14 : AocDay<List<ReindeerDetails>>
    {
        public Day14(IInputParser<List<ReindeerDetails>> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(List<ReindeerDetails> input)
        {
            int time = 2503;
            Console.WriteLine(input.Select(r => DistanceAtTime(r, time).Item2).Max());
        }

        protected override void Part2(List<ReindeerDetails> input)
        {
            var points = input.ToDictionary(e => e.Name, e => 0);
            for(int t = 1; t <= 2503; t++)
            {
                var distances = input.Select(r => DistanceAtTime(r, t)).ToArray();
                var maxDist = distances.Max(di => di.Item2);
                foreach(var n in distances.Where(di => di.Item2 == maxDist).Select(di => di.Item1))
                    points[n]++;
            }
            Console.WriteLine(points.Values.Max());
        }

        private static (string, int) DistanceAtTime(ReindeerDetails r, int time)
        {
            int cycles = time / (r.FlyTime + r.RestTime);
            int nextTime = time % (r.FlyTime + r.RestTime);
            return (r.Name, (cycles*r.FlyTime + Math.Min(nextTime, r.FlyTime))*r.DistancePerSecond);
        }
    }
}