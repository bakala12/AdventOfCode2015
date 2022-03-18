using AdventOfCode2015.Input;

namespace AdventOfCode2015.Days
{
    public class Day25 : AocDay<(int, int)>
    {
        public Day25(IInputParser<(int, int)> inputParser) : base(inputParser)
        {
        }

        protected override void Part1((int, int) input)
        {
            var (row, column) = input;
            int diagNum = row + column - 1;
            long itemNum = diagNum * (diagNum - 1) / 2 + column;
            long code = 20151125;
            for(int i = 1; i < itemNum; i++)
                code = (code * 252533) % 33554393;
            Console.WriteLine(code);
        }

        protected override void Part2((int, int) input)
        {
            Console.WriteLine("AoC 2015 done!");
        }
    }
}