namespace AdventOfCode2015.Input
{
    public class BooleanGridInputParser : IInputParser<bool[,]>
    {
        public bool[,] ParseInput(string input)
        {
            var lines = input.Split(Environment.NewLine);
            var tab = new bool[lines.Length, lines[0].Length];
            for(int i = 0; i < lines.Length; i++)
                for(int j = 0; j < lines[i].Length; j++)
                    tab[i,j] = lines[i][j] == '#';
            return tab;
        }
    }
}