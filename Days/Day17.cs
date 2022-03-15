using AdventOfCode2015.Input;

namespace AdventOfCode2015.Days
{
    public class Day17 : AocDay<int[]>
    {
        public Day17(IInputParser<int[]> inputParser) : base(inputParser)
        {
            _combinations = Array.Empty<int>();
        }

        private int[] _combinations;

        protected override void Part1(int[] input)
        {
            _combinations = new int[input.Length];
            Console.WriteLine(FindNumberOfCombinationsThatSumsTo(150, input, _combinations).Sum());
        }

        protected override void Part2(int[] input)
        {
            Console.WriteLine(_combinations.FirstOrDefault(i => i > 0));
        }

        private static int[] FindNumberOfCombinationsThatSumsTo(int sum, int[] items, int[] combinations, int containers = 0, int pos = 0, int currentSum = 0)
        {
            if(pos == items.Length)
            {
                if(currentSum == sum)
                    combinations[containers-1]++;
                return combinations;
            }
            FindNumberOfCombinationsThatSumsTo(sum, items, combinations, containers, pos+1, currentSum);
            FindNumberOfCombinationsThatSumsTo(sum, items, combinations, containers+1, pos+1, currentSum + items[pos]);
            return combinations;
        }
    }
}