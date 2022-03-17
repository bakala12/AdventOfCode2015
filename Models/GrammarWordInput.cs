namespace AdventOfCode2015.Models
{
    public readonly record struct GrammarWordInput(Grammar Grammar, string[] Word);

    public readonly record struct Production(string From, string[] To);

    public readonly record struct Grammar(string[] Symbols, Production[] Productions);
}