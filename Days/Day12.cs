using AdventOfCode2015.Input;
using Newtonsoft.Json.Linq;

namespace AdventOfCode2015.Days
{
    public class Day12 : AocDay<JObject>
    {
        public Day12(IInputParser<JObject> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(JObject input)
        {
            Console.WriteLine(SumNumbers(input));
        }

        protected override void Part2(JObject input)
        {
            Console.WriteLine(SumNumbers2(input));
        }

        private static int SumNumbers(JToken token)
        {
            int sum = 0;
            switch(token.Type)
            {
                case JTokenType.Object:
                    foreach(var p in ((JObject)token).Properties())
                        sum += SumNumbers(p.Value);
                    break;
                case JTokenType.Array:
                    foreach(var e in ((JArray)token).Values())
                        sum += SumNumbers(e);
                    break;
                case JTokenType.Integer:
                    sum += token.Value<int>();
                    break;
                case JTokenType.Property:
                    sum += SumNumbers(((JProperty)token).Value);
                    break;
            }
            return sum;
        }
    
        private static int SumNumbers2(JToken token)
        {
            int sum = 0;
            switch(token.Type)
            {
                case JTokenType.Object:
                    foreach(var p in ((JObject)token).Properties())
                    {
                        sum += SumNumbers2(p.Value);
                        if(p.Value.Type == JTokenType.String && p.Value.Value<string>() == "red")
                            return 0;
                    }    
                    break;
                case JTokenType.Array:
                    foreach(var e in ((JArray)token).Children())
                        sum += SumNumbers2(e);
                    break;
                case JTokenType.Integer:
                    sum += token.Value<int>();
                    break;
                case JTokenType.Property:
                    sum += SumNumbers2(((JProperty)token).Value);
                    break;
            }
            return sum;
        }
    }
}