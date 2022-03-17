using AdventOfCode2015.Models;

namespace AdventOfCode2015.Input
{
    public class GrammarWordInputParser : IInputParser<GrammarWordInput>
    {
        public GrammarWordInput ParseInput(string input)
        {
            var symbols = new List<string>();
            var productions = new List<Production>();
            var lines = input.Split(Environment.NewLine);
            string line;
            int i = 0;
            while((line = lines[i++]) != string.Empty)
            {
                var split = line.Split(" => ");
                var from = split[0];
                if(!symbols.Contains(from))
                    symbols.Add(from);
                var to = ReadProducts(split[1]).ToArray();
                productions.Add(new Production(from, to));
            }
            return new GrammarWordInput(new Grammar(symbols.ToArray(), productions.ToArray()), ReadProducts(lines[i]).ToArray());
        }

        private static List<string> ReadProducts(string products)
        {
            var list = new List<string>();
            int i = 0;
            while(i < products.Length)
            {
                if(char.IsUpper(products[i]))
                {
                    if(i + 1 < products.Length && char.IsLower(products[i+1]))
                    {
                        list.Add($"{products[i]}{products[i+1]}");
                        i += 2;
                    }
                    else 
                        list.Add(products[i++].ToString());
                }
            }
            return list;
        }
    }
}