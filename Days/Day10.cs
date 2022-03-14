using System.Text;
using AdventOfCode2015.Input;

namespace AdventOfCode2015.Days
{
    public class Day10 : AocDay<string>
    {
        public Day10(IInputParser<string> inputParser) : base(inputParser)
        {
        }

        private string Part1Result = string.Empty;

        protected override void Part1(string input)
        {
            Part1Result = DoIterations(input, 40).ToString();
            Console.WriteLine(Part1Result.Length);
        }

        protected override void Part2(string input)
        {
            Console.WriteLine(DoIterations(Part1Result, 10).Length);
        }

        private StringBuilder DoIterations(string input, int count)
        {
            var sb = new StringBuilder(input);
            for(int i = 0; i < count; i++)
                sb = Iteration(sb);
            return sb;
        }

        private StringBuilder Iteration(StringBuilder element)
        {
            var newElement = new StringBuilder();
            int count = 1;
            char last = element[0];
            for(int i = 1; i < element.Length; i++)
            {
                var c = element[i];
                if(c == last)
                    count++;
                else
                {
                    newElement.Append($"{count}{last}");
                    last = c;
                    count = 1;
                }
            }
            if(count > 0)
                newElement.Append($"{count}{last}");
            return newElement;
        }
    }
}