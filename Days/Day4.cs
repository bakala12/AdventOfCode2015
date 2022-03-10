using System.Security.Cryptography;
using System.Text;
using AdventOfCode2015.Input;

namespace AdventOfCode2015.Days
{
    public class Day4 : AocDay<string>
    {
        public Day4(IInputParser<string> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(string input)
        {
            int n = 0;
            bool cont = true;
            using var md5 = MD5.Create();
            do
            {
                n++;
                var hash = ProduceHash(md5, input, n);
                cont = !(hash[0] == 0 && hash[1] == 0 && (hash[2] & 0xF0) == 0);
            } while(cont);
            Console.WriteLine(n);
        }

        protected override void Part2(string input)
        {
            int n = 0;
            bool cont = true;
            using var md5 = MD5.Create();
            do
            {
                n++;
                var hash = ProduceHash(md5, input, n);
                cont = !(hash[0] == 0 && hash[1] == 0 && hash[2] == 0);
            } while(cont);
            Console.WriteLine(n);
        }

        private byte[] ProduceHash(MD5 md5, string baseStr, int number)
        {
            byte[] bytes = Encoding.ASCII.GetBytes($"{baseStr}{number}");
            return md5.ComputeHash(bytes);
        }
    }
}