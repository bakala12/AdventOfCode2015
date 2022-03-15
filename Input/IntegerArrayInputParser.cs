namespace AdventOfCode2015.Input
{
    public class IntegerArrayInputParser : IInputParser<int[]>
    {
        public int[] ParseInput(string input)
        {
            return input.Split(Environment.NewLine).Select(int.Parse).ToArray();
        }
    }
}