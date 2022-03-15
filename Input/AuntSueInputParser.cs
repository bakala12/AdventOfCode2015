using AdventOfCode2015.Models;

namespace AdventOfCode2015.Input
{
    public class AuntSueInputParser : IInputParser<List<AuntSue>>
    {
        public List<AuntSue> ParseInput(string input)
        {
            var list = new List<AuntSue>();
            int i = 1;
            foreach(var line in input.Split(Environment.NewLine))
            {
                var s = line.Split(new char[]{ ' ', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var sue = new AuntSue(i++);
                list.Add(sue);
                for(int j = 3; j < s.Length; j += 2)
                    sue.Items.Add(s[j-1], int.Parse(s[j]));
            }
            return list;
        }
    }
}