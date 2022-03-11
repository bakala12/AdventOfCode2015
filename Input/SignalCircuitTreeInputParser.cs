using AdventOfCode2015.Models;

namespace AdventOfCode2015.Input
{
    public class SignalCircuitTreeInputParser : IInputParser<Dictionary<string, SignalCircuitNode>>
    {
        public Dictionary<string, SignalCircuitNode> ParseInput(string input)
        {
            var split = input.Split(Environment.NewLine);
            bool changes = true;
            var nodes = new Dictionary<string, SignalCircuitNode>();
            while(changes)
            {
                changes = false;
                foreach(var line in split)
                {
                    var s = line.Split(" -> ");
                    var res = s[1];
                    if(!nodes.ContainsKey(res))
                    {
                        var left = s[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if(left.Length == 1) // 1 -> a || a -> b
                        {
                            if(TryGet(left[0], nodes, out var ln))
                            {
                                if(int.TryParse(left[0], out int _))
                                    nodes[res] = new SignalCircuitLeafNode(res, ln!.ProvideSignal());
                                else
                                    nodes[res] = new SignalCircuitBasedNode(res, ln!);
                                changes = true;
                            }
                        }
                        else if(left.Length == 2) // NOT a -> b
                        {
                            if(TryGet(left[1], nodes, out var ln))
                            {
                                nodes[res] = new SignalCircuitNotNode(res, ln!);
                                changes = true;
                            }
                        }
                        else // a OP b -> c where OP is in {OR, AND, LSHIFT, RSHIFT}
                        {
                            if(TryGet(left[0], nodes, out var ln) && TryGet(left[2], nodes, out var rn))
                            {
                                nodes[res] = CreateBinaryNode(res, left[1], ln!, rn!);
                                changes = true;
                            }
                        }
                    }
                }
            }
            return nodes;
        }

        private static bool TryGet(string key, Dictionary<string, SignalCircuitNode> nodes, out SignalCircuitNode? node)
        {
            if(nodes.TryGetValue(key, out node))
                return true;
            if(ushort.TryParse(key, out ushort val))
            {   
                node = new SignalCircuitLeafNode(key, val);
                return true;
            }
            return false;
        }

        private static SignalCircuitNode CreateBinaryNode(string name, string operation, SignalCircuitNode left, SignalCircuitNode right)
        {
            return operation switch 
            {
                "OR" => new SignalCircuitOrNode(name, left, right),
                "AND" => new SignalCircuitAndNode(name, left, right),
                "LSHIFT" => new SignalCircuitLeftShiftNode(name, left, right),
                "RSHIFT" => new SignalCircuitRightShiftNode(name, left, right),
                _ => throw new InvalidOperationException()
            };
        }
    }
}