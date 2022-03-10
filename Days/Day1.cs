using AdventOfCode2015.Input;

namespace AdventOfCode2015.Days
{
    public class Day1 : AocDay<string>
    {
        public Day1(IInputParser<string> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(string input)
        {
            int f = 0;
            foreach(var c in input)
                f += c switch { '(' => 1, ')' => -1, _ => 0 };
            Console.WriteLine(f);
        }

        protected override void Part2(string input)
        {
            int f = 0;
            int i = 0;
            for(; i < input.Length; i++)
            {
                f += input[i] switch { '(' => 1, ')' => -1, _ => 0 };
                if(f < 0)
                    break;
            }
            Console.WriteLine(i+1);
        }
    }
}