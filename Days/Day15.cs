using AdventOfCode2015.Input;
using AdventOfCode2015.Models;

namespace AdventOfCode2015.Days
{
    public class Day15 : AocDay<List<Ingredient>>
    {
        public Day15(IInputParser<List<Ingredient>> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(List<Ingredient> input)
        {
            Console.WriteLine(FindBestRecipe(input, 0, 100, new int[input.Count]));
        }

        protected override void Part2(List<Ingredient> input)
        {
            Console.WriteLine(FindBestRecipe(input, 0, 100, new int[input.Count], 500));
        }

        private static int FindBestRecipe(List<Ingredient> ingredients, int current, int remaining, int[] quantities, int? calloriesLimit = null)
        {
            if(current == ingredients.Count)
                return ScoreCookie(ingredients, quantities, calloriesLimit);
            int best = int.MinValue;
            for(int i = remaining; i >= 0; i--)
            {
                quantities[current] = i;
                best = Math.Max(best, FindBestRecipe(ingredients, current+1, remaining-i, quantities, calloriesLimit));
            }
            return best;
        }

        private static int ScoreCookie(List<Ingredient> ingredients, int[] quantities, int? calloriesLimit)
        {
            if(calloriesLimit.HasValue && ingredients.Select((s,i) => s.Calories * quantities[i]).Sum() != calloriesLimit.Value)
                return 0;
            var prop = new int[4];
            for(int i = 0; i < quantities.Length; i++)
            {
                prop[0] += quantities[i] * ingredients[i].Capacity;
                prop[1] += quantities[i] * ingredients[i].Durability;
                prop[2] += quantities[i] * ingredients[i].Flavour;
                prop[3] += quantities[i] * ingredients[i].Texture;
            }
            return prop.Aggregate(1, (a, i) => a * Math.Max(i, 0));
        }
    }
}