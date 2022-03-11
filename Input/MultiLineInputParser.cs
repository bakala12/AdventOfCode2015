namespace AdventOfCode2015.Input;

public class MultiLineInputParser : IInputParser<string[]>
{
    public string[] ParseInput(string input)
    {
        return input.Split(Environment.NewLine);
    }
}
