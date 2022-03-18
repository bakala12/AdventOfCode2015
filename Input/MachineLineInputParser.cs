namespace AdventOfCode2015.Input
{
    public class MachineLineInputParser : IInputParser<(int, int)>
    {
        public (int, int) ParseInput(string input)
        {
            var s = input.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            return (int.Parse(s[15]), int.Parse(s[17]));
        }
    }
}