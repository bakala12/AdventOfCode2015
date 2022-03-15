using AdventOfCode2015.Models;

namespace AdventOfCode2015.Input
{
    public class ReindeerDetailsInputParser : IInputParser<List<ReindeerDetails>>
    {
        public List<ReindeerDetails> ParseInput(string input)
        {
            var list = new List<ReindeerDetails>();
            foreach(var line in input.Split(Environment.NewLine))
            {
                var s = line.Split();
                list.Add(new ReindeerDetails(s[0], int.Parse(s[3]), int.Parse(s[6]), int.Parse(s[13])));
            }
            return list;
        }
    }
}