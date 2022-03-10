using AdventOfCode2015.Input;
using AdventOfCode2015.Models;

namespace AdventOfCode2015.Days
{
    public class Day2 : AocDay<Present[]>
    {
        public Day2(IInputParser<Present[]> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(Present[] input)
        {
            Console.WriteLine(input.Sum(p => p.PaperNeeded));
        }

        protected override void Part2(Present[] input)
        {
            Console.WriteLine(input.Sum(p => p.RibonNeeded));
        }
    }
}