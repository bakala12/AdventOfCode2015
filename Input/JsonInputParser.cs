using Newtonsoft.Json.Linq;

namespace AdventOfCode2015.Input
{
    public class JsonInputParser : IInputParser<JObject>
    {
        public JObject ParseInput(string input)
        {
            return JObject.Parse(input);
        }
    }
}