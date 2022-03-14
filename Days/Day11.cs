using AdventOfCode2015.Input;

namespace AdventOfCode2015.Days
{
    public class Day11 : AocDay<char[]>
    {
        public Day11(IInputParser<char[]> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(char[] input)
        {
            do
            {
                IncrementPassword(input);
            } while(!IsValidPassword(input));
            Console.WriteLine(new string(input));
        }

        protected override void Part2(char[] input)
        {
            Part1(input);
        }

        private static void IncrementPassword(char[] password, int pos = 7)
        {
            if(password[pos] == 'z')
            {
                password[pos] = 'a';
                IncrementPassword(password, pos-1);
            }
            else
                password[pos]++;
        }

        private static bool IsValidPassword(char[] password)
        {
            bool correct = false;
            for(int i = 2; i < password.Length; i++)
                if(password[i-2]+1 == password[i-1] && password[i-1]+1 == password[i])
                {
                    correct = true;
                    break;
                }
            if(correct)
            {
                correct = false;
                for(int i = 1; i < password.Length; i++)
                    if(password[i] == password[i-1])
                    {
                        for(int j = i+2; j < password.Length; j++)
                            if(password[j] == password[j-1] && password[j] != password[i])
                            {
                                correct = true;
                                break;
                            }
                    }
            }
            return correct && !password.Any(c => c == 'i' || c == 'l' || c == 'o');
        }
    }
}