using AdventOfCode2015.Input;

namespace AdventOfCode2015.Days
{
    public class Day5 : AocDay<string[]>
    {
        public Day5(IInputParser<string[]> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(string[] input)
        {
            Console.WriteLine(input.Count(IsNiceStringPart1));
        }

        protected override void Part2(string[] input)
        {
            Console.WriteLine(input.Count(IsNiceStringPart2));
        }

        private static readonly string[] ForbiddenStrings = new [] { "ab", "cd", "pq", "xy" };

        private static readonly string Vowels = "aeiou";

        private bool IsNiceStringPart1(string str)
        {
            int vowelsCount = 0;
            bool twice = false;
            for(int i = 1; i < str.Length; i++)
            {
                if(Vowels.Contains(str[i]))
                    vowelsCount++;
                if(str[i-1] == str[i])
                    twice = true;
                else if(ForbiddenStrings.Contains($"{str[i-1]}{str[i]}"))
                    return false;
            }
            if(Vowels.Contains(str[0]))
                vowelsCount++;
            return twice && vowelsCount >= 3;
        }

        private bool IsNiceStringPart2(string str)
        {
            bool trip = false;
            bool doubel = false;
            for(int k = 1; k < str.Length-1; k++)
            {
                if(str[k-1] == str[k+1] && str[k-1] != str[k])
                    trip = true;
                if(!doubel)
                    for(int j = k+1; j < str.Length - 1; j++)
                        if(str[k-1] == str[j] && str[k] == str[j+1])
                            doubel = true;
            }
            return trip && doubel;
        }
    }
}