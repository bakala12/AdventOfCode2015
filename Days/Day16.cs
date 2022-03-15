using AdventOfCode2015.Input;
using AdventOfCode2015.Models;

namespace AdventOfCode2015.Days
{
    public class Day16 : AocDay<List<AuntSue>>
    {
        public Day16(IInputParser<List<AuntSue>> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(List<AuntSue> input)
        {
            for(int i = 0; i < input.Count; i++)
            {
                if(input[i].Items.All(it => it.Value == RememberedItems[it.Key]))
                {
                    Console.WriteLine(input[i].Number);
                    return;
                }
            }
        }

        protected override void Part2(List<AuntSue> input)
        {
            for(int i = 0; i < input.Count; i++)
            {
                if(input[i].Items.All(it => ComparingRules[it.Key](it.Value, RememberedItems[it.Key])))
                {
                    Console.WriteLine(input[i].Number);
                    return;
                }
            }
        }

        private static readonly Dictionary<string, int> RememberedItems = new Dictionary<string, int>
        {
            {"children", 3},
            {"cats", 7},
            {"samoyeds", 2},
            {"pomeranians", 3},
            {"akitas", 0},
            {"vizslas", 0},
            {"goldfish", 5},
            {"trees", 3},
            {"cars", 2},
            {"perfumes", 1}
        };
    
        private static readonly Dictionary<string, Func<int, int, bool>> ComparingRules = new Dictionary<string, Func<int, int, bool>>
        {
            {"children", (x,y) => x == y},
            {"cats", (x,y) => x > y},
            {"samoyeds", (x,y) => x == y},
            {"pomeranians", (x,y) => x < y},
            {"akitas", (x,y) => x == y},
            {"vizslas", (x,y) => x == y},
            {"goldfish", (x,y) => x < y},
            {"trees", (x,y) => x > y},
            {"cars", (x,y) => x == y},
            {"perfumes", (x,y) => x == y}
        };
    }
}