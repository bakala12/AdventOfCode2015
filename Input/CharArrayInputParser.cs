namespace AdventOfCode2015.Input
{
    public class CharArrayInputParser : IInputParser<char[]>
    {
        public char[] ParseInput(string input)
        {
            return input.ToCharArray();
        }
    }
}