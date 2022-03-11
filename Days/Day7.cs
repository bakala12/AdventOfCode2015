using AdventOfCode2015.Input;
using AdventOfCode2015.Models;

namespace AdventOfCode2015.Days
{
    public class Day7 : AocDay<Dictionary<string, SignalCircuitNode>>
    {
        public Day7(IInputParser<Dictionary<string, SignalCircuitNode>> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(Dictionary<string, SignalCircuitNode> input)
        {
            Console.WriteLine(input["a"].ProvideSignal());
        }

        protected override void Part2(Dictionary<string, SignalCircuitNode> input)
        {
            var sig = input["a"].ProvideSignal();
            foreach(var n in input)
                n.Value.ResetSignal();
            input["b"].SetSignal(sig);
            Console.WriteLine(input["a"].ProvideSignal());
        }
    }
}