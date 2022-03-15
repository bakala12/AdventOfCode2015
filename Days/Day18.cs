using AdventOfCode2015.Input;

namespace AdventOfCode2015.Days
{
    public class Day18 : AocDay<bool[,]>
    {
        public Day18(IInputParser<bool[,]> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(bool[,] input)
        {
            Console.WriteLine(MakeSteps(100, Copy(input)));
        }

        protected override void Part2(bool[,] input)
        {
            Console.WriteLine(MakeSteps(100, input, true));
        }

        private static int MakeSteps(int steps, bool[,] current, bool cornerAlwaysOn = false)
        {
            int height = current.GetLength(0);
            int width = current.GetLength(1);
            var next = new bool[height, width];
            for(int s = 0; s < steps; s++)
            {
                Iteration(current, next, height, width);
                if(cornerAlwaysOn)
                {
                    next[0,0] = next[0,width-1] = next[height-1,0] = next[height-1,width-1] = true;
                }
                var tmp = current;
                current = next;
                next = tmp;
            }
            return CountTurnedOn(current, height, width);
        }

        private static void Iteration(bool[,] current, bool[,] next, int height, int width)
        {
            for(int i = 0; i < height; i++)
                for(int j = 0; j < width; j++)
                {
                    int c = CountTurnedNeighbours(current, height, width, i, j);
                    next[i,j] = (current[i,j] && (c == 2 || c == 3)) || (!current[i,j] && c == 3);
                }
        }

        private static int CountTurnedNeighbours(bool[,] tab, int height, int width, int i, int j)
        {
            int c = 0;
            for(int ii = -1; ii <= 1; ii++)
                for(int jj = -1; jj <= 1; jj++)
                    if(ii != 0 || jj != 0)
                        if(i+ii >= 0 && i+ii < height && j+jj >= 0 && j+jj < width && tab[i+ii,j+jj])
                            c++;
            return c;
        }

        private static int CountTurnedOn(bool[,] tab, int height, int width)
        {
            int c = 0;
            for(int i = 0; i < height; i++)
                for(int j = 0; j < width; j++)
                    if(tab[i,j]) c++;
            return c;
        }

        private static bool[,] Copy(bool[,] tab)
        {
            int height = tab.GetLength(0);
            int width = tab.GetLength(1);
            var copy = new bool[height,width]; 
            for(int i = 0; i < height; i++)
                for(int j = 0; j < width; j++)
                    copy[i,j] = tab[i,j];
            return copy;
        }
    }
}