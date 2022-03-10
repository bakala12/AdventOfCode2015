using AdventOfCode2015.Input;
using AdventOfCode2015.Models;

namespace AdventOfCode2015.Days
{
    public class Day6 : AocDay<LightBulbAction[]>
    {
        public Day6(IInputParser<LightBulbAction[]> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(LightBulbAction[] input)
        {
            bool[,] grid = new bool[1000,1000];
            foreach(var action in input)
            {
                for(int i = action.From.X; i <= action.To.X; i++)
                    for(int j = action.From.Y; j <= action.To.Y; j++)
                        grid[i,j] = action.ActionType switch
                        {
                            LightBulbActionType.TurnOn => true,
                            LightBulbActionType.TurnOff => false,
                            LightBulbActionType.Toggle => !grid[i,j],
                            _ => grid[i,j]
                        };
            }
            Console.WriteLine(grid.OfType<bool>().Count(b => b));
        }

        protected override void Part2(LightBulbAction[] input)
        {
            int[,] grid = new int[1000,1000];
            foreach(var action in input)
            {
                for(int i = action.From.X; i <= action.To.X; i++)
                    for(int j = action.From.Y; j <= action.To.Y; j++)
                        grid[i,j] = action.ActionType switch
                        {
                            LightBulbActionType.TurnOn => grid[i,j] + 1,
                            LightBulbActionType.TurnOff => Math.Max(grid[i,j]-1, 0),
                            LightBulbActionType.Toggle => grid[i,j] + 2,
                            _ => grid[i,j]
                        };
            }
            Console.WriteLine(grid.OfType<int>().Sum());
        }
    }
}