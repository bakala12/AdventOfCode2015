namespace AdventOfCode2015.Input;

public interface IInputParser<TParsedInput>
{
    TParsedInput ParseInput(string input);
}
