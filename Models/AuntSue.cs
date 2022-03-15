namespace AdventOfCode2015.Models
{
    public readonly record struct AuntSue(int Number)
    {
        public Dictionary<string, int> Items { get; } = new Dictionary<string, int>();
    }
}