using AdventOfCode2015.Models;

namespace AdventOfCode2015.Input;

public class PresentInputParser : IInputParser<Present[]>
{
    public Present[] ParseInput(string input)
    {
        return Parse(input).ToArray();
    }

    private IEnumerable<Present> Parse(string input)
    {
        foreach(var line in input.Split('\n'))
        {
            var s = line.Split('x');
            yield return new Present(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]));
        }
    }
}
