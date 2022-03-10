using AdventOfCode2015.Input;

namespace AdventOfCode2015;

public abstract class AocDay<TParsedInput> : IDay
{
    private IInputParser<TParsedInput> _inputParser;

    protected AocDay(IInputParser<TParsedInput> inputParser)
    {
        _inputParser = inputParser;
    }

    protected abstract int Year { get; }

    protected abstract void Part1(TParsedInput input);
    protected abstract void Part2(TParsedInput input);

    public void Solve(string[] args)
    {
        //var fileContent = File.ReadAllText(inputFilePath);
        var input = _inputParser.ParseInput(string.Empty);
        Part1(input);
        Part2(input);
    }
}
