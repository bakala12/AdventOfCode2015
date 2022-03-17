using AdventOfCode2015.Input;
using AdventOfCode2015.Models;

namespace AdventOfCode2015.Days
{
    public class Day19 : AocDay<GrammarWordInput>
    {
        public Day19(IInputParser<GrammarWordInput> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(GrammarWordInput input)
        {
            var allStrings = new HashSet<string>();
            for(int i = 0; i < input.Word.Length; i++)
            {
                var begin = i > 0 ? string.Join("", input.Word[Range.EndAt(i)]) : string.Empty;
                var end = i < input.Word.Length-1 ? string.Join("", input.Word[Range.StartAt(i+1)]): string.Empty;
                foreach(var production in input.Grammar.Productions.Where(p => p.From == input.Word[i]))
                {
                    var converted = string.Join("", production.To);
                    var str = string.Concat(begin, converted, end);
                    if(!allStrings.Contains(str))
                        allStrings.Add(str);
                }
            }
            Console.WriteLine(allStrings.Count);
        }

        protected override void Part2(GrammarWordInput input)
        {
            var word = input.Word;
            var orderedProductions = PrepareProductions(input.Grammar.Productions);
            bool found = false;
            Console.WriteLine(WrapToStart(word.ToList(), orderedProductions, 0, ref found));
        }

        private static int WrapToStart(List<string> word, Dictionary<string, List<Production>> orderedProductions, int steps, ref bool solutionFound)
        {
            if(solutionFound)
                return int.MaxValue;
            if(word.Count == 1 && word[0] == "e")
            {
                solutionFound = true;
                return steps;
            }
            int min = int.MaxValue;
            for(int w = word.Count - 1; w >= 0; w--)
            {
                var c = word[w];
                if(solutionFound)
                    break;
                if(!orderedProductions.ContainsKey(c))
                    continue;
                foreach(var p in orderedProductions[c])
                {
                    if(TryMatchEnd(word, p, w))
                    {
                        UnapplyProduction(word, p, w);
                        min = Math.Min(min, WrapToStart(word, orderedProductions, steps+1, ref solutionFound));
                        ReapplyProduction(word, p, w);
                    }
                }
            }
            return min;
        }

        private static Dictionary<string, List<Production>> PrepareProductions(Production[] productions)
        {
            return productions.GroupBy(p => p.To[p.To.Length-1]).ToDictionary(k => k.Key, k => k.OrderByDescending(pp => pp.To.Length).ToList());
        }

        private static bool TryMatchEnd(List<string> word, Production p, int lastIndex)
        {
            if(lastIndex < p.To.Length - 1)
                return false;
            for(int n = p.To.Length-1; n >= 0; n--)
                if(p.To[n] != word[lastIndex + 1 - p.To.Length + n])
                    return false;
            return true;
        }

        private static void UnapplyProduction(List<string> word, Production p, int lastIndex)
        {
            for(int k = 0; k < p.To.Length; k++)
                word.RemoveAt(lastIndex-k);
            word.Insert(lastIndex - p.To.Length + 1, p.From);
        }

        private static void ReapplyProduction(List<string> word, Production p, int lastIndex)
        {
            word.RemoveAt(lastIndex - p.To.Length + 1);
            for(int k = 0; k < p.To.Length; k++)
                word.Insert(lastIndex - p.To.Length + 1 + k, p.To[k]);
        }
    }
}