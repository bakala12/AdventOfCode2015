using AdventOfCode2015.Models;

namespace AdventOfCode2015.Input;

public class LightBulbActionInputParser : IInputParser<LightBulbAction[]>
{
    public LightBulbAction[] ParseInput(string input)
    {
        return Parse(input).ToArray();
    }

    private IEnumerable<LightBulbAction> Parse(string input)
    {
        foreach(var line in input.Split('\n'))
        {
            var s = line.Split();
            if(line.StartsWith("toggle"))
                yield return new LightBulbAction(ParseTuple(s[1]), ParseTuple(s[3]), LightBulbActionType.Toggle);
            else if(line.StartsWith("turn on"))
                yield return new LightBulbAction(ParseTuple(s[2]), ParseTuple(s[4]), LightBulbActionType.TurnOn);
            else if(line.StartsWith("turn off"))
                yield return new LightBulbAction(ParseTuple(s[2]), ParseTuple(s[4]), LightBulbActionType.TurnOff);
        }
    }

    private static (int,int) ParseTuple(string str)
    {
        var s = str.Split(',');
        return (int.Parse(s[0]), int.Parse(s[1]));
    }
}
