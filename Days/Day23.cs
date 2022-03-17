using AdventOfCode2015.Input;

namespace AdventOfCode2015.Days
{
    public class Day23 : AocDay<string[]>
    {
        public Day23(IInputParser<string[]> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(string[] input)
        {
            Console.WriteLine(ExecuteProgram(input));
        }

        protected override void Part2(string[] input)
        {
            Console.WriteLine(ExecuteProgram(input, 1));
        }

        private uint ExecuteProgram(string[] program, uint a = 0)
        {
            int pos = 0;
            var reg = new Dictionary<string, uint>()
            {
                { "a", a },
                { "b", 0 }
            };
            while(0 <= pos && pos < program.Length)
            {
                var line = program[pos];
                var s = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                switch(s[0])
                {
                    case "hlf":
                        reg[s[1]] /= 2;
                        pos++;
                        break;
                    case "tpl":
                        reg[s[1]] *= 3;
                        pos++;
                        break;
                    case "inc":
                        reg[s[1]]++;
                        pos++;
                        break;
                    case "jmp":
                        pos += int.Parse(s[1]);
                        break;
                    case "jie":
                        pos += reg[s[1]] % 2 == 0 ? int.Parse(s[2]) : 1;
                        break;
                    case "jio":
                        pos += reg[s[1]] == 1 ? int.Parse(s[2]) : 1;
                        break;
                }
            }
            return reg["b"];
        }
    }
}