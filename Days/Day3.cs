using AdventOfCode2015.Input;

namespace AdventOfCode2015.Days
{
    public class Day3 : AocDay<string>
    {
        public Day3(IInputParser<string> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(string input)
        {
            var locationCount = new HashSet<(int,int)>();
            var loc = (0,0);
            foreach(var c in input)
            {
                if(!locationCount.Contains(loc))
                    locationCount.Add(loc);
                var (x,y) = loc;
                loc = c switch
                {
                    '<' => (x-1, y),
                    '>' => (x+1, y),
                    '^' => (x, y+1),
                    'v' => (x, y-1),
                    _ => loc
                };
            }
            if(!locationCount.Contains(loc))
                locationCount.Add(loc);
            Console.WriteLine(locationCount.Count);
        }

        protected override void Part2(string input)
        {
            var locationCount = new HashSet<(int,int)>();
            var loc = new [] {(0,0), (0,0) };
            int i = 0;
            foreach(var c in input)
            {
                if(!locationCount.Contains(loc[i]))
                    locationCount.Add(loc[i]);
                var (x,y) = loc[i];
                loc[i] = c switch
                {
                    '<' => (x-1, y),
                    '>' => (x+1, y),
                    '^' => (x, y+1),
                    'v' => (x, y-1),
                    _ => loc[i]
                };
                i = (i+1) % 2;
            }
            for(int k = 0; k < 2; k++)
                if(!locationCount.Contains(loc[k]))
                    locationCount.Add(loc[k]);
            Console.WriteLine(locationCount.Count);
        }
    }
}