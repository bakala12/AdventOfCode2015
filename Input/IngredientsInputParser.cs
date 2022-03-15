using AdventOfCode2015.Models;

namespace AdventOfCode2015.Input
{
    public class IngredientsInputParser : IInputParser<List<Ingredient>>
    {
        public List<Ingredient> ParseInput(string input)
        {
            var list = new List<Ingredient>();
            foreach(var line in input.Split(Environment.NewLine))
            {
                var s = line.Split();
                list.Add(new Ingredient(s[0].Trim(':'), int.Parse(s[2].Trim(',')), int.Parse(s[4].Trim(',')), int.Parse(s[6].Trim(',')), int.Parse(s[8].Trim(',')), int.Parse(s[10])));
            }
            return list;
        }
    }
}