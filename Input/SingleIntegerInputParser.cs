namespace AdventOfCode2015.Input
{
    public class SingleIntegerInputParser : IInputParser<int>
    {
        public int ParseInput(string input)
        {
            return int.Parse(input);
        }
    }
}