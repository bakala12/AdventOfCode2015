using AdventOfCode2015.Input;

namespace AdventOfCode2015.Days
{
    public class Day24 : AocDay<int[]>
    {
        public Day24(IInputParser<int[]> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(int[] input)
        {
            var desiredWeight = input.Sum() / 3;
            int best = int.MaxValue;
            Console.WriteLine(FindSleighGroups(desiredWeight, input, new bool[input.Length], 0, 0, 0, ref best).Item2);
        }

        protected override void Part2(int[] input)
        {
            var desiredWeight = input.Sum() / 4;
            int best = int.MaxValue;
            Console.WriteLine(FindSleighGroups(desiredWeight, input, new bool[input.Length], 0, 0, 0, ref best).Item2);
        }

        private static (int, long) FindSleighGroups(int desiredWeight, int[] items, bool[] inFirstGroup, int pos, int currentSum, int currentCount, ref int bestCount)
        {
            if(currentCount > bestCount || currentSum > desiredWeight)
                return (int.MaxValue, long.MaxValue);
            if(pos == items.Length)
            {
                if(currentSum == desiredWeight)
                {
                    return (currentCount, items.Select((item, ind) => inFirstGroup[ind] ? item : 1).Aggregate(1L, (a, i) => a * i));
                }
                return (int.MaxValue, long.MaxValue);
            }
            int bestC = int.MaxValue;
            long bestScore = long.MaxValue;
            foreach(var b in BoolValues)
            {
                inFirstGroup[pos] = b;
                var (count, score) = FindSleighGroups(desiredWeight, items, inFirstGroup, pos+1, currentSum + (b ? items[pos] : 0), currentCount + (b ? 1 : 0), ref bestCount);
                if(count < bestC)
                {
                    bestC = count;
                    bestScore = score;
                }
                if(count == bestC && score < bestScore)
                    bestScore = score;
            }
            return (bestC, bestScore);
        }

        private static readonly bool[] BoolValues = new [] { false, true };

        private static bool CanDivideInTwo(int desiredWeight, int[] items, bool[] inFirstGroup, int pos, int currentSum)
        {
            if(pos == items.Length)
                return currentSum == desiredWeight;
            if(currentSum > desiredWeight)
                return false;
            if(inFirstGroup[pos])
                return CanDivideInTwo(desiredWeight, items, inFirstGroup, pos+1, currentSum);
            return CanDivideInTwo(desiredWeight, items, inFirstGroup, pos+1, currentSum + items[pos]) || 
                CanDivideInTwo(desiredWeight, items, inFirstGroup, pos+1, currentSum);
        }
    }
}