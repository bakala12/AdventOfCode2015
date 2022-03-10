using AdventOfCode2015.Input;

namespace AdventOfCode2015;

public abstract class Aoc2015Day<TParsedInput> : AocDay<TParsedInput>
{
    protected Aoc2015Day(IInputParser<TParsedInput> inputParser) : base(inputParser)
    {
    }

    protected sealed override int Year => 2015;
}