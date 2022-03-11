using System.Text.RegularExpressions;
using AdventOfCode2015.Input;

namespace AdventOfCode2015.Days
{
    public class Day8 : AocDay<string[]>
    {
        public Day8(IInputParser<string[]> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(string[] input)
        {
            Console.WriteLine(input.Sum(DifferenceInCodeAndUnEscaped));
        }

        protected override void Part2(string[] input)
        {
            Console.WriteLine(input.Sum(DifferenceInCodeAndEscaped));
        }

        private int DifferenceInCodeAndUnEscaped(string arg)
        {
            return arg.Length - Regex.Unescape(arg.Substring(1, arg.Length-2)).Length;
        }

        private int DifferenceInCodeAndEscaped(string arg)
        {
            return arg.Count(c => c == '\\' || c == '\"') + 2;
        }
    }
}