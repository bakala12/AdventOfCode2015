using AdventOfCode2015.Models;

namespace AdventOfCode2015.Input
{
    public class BossStatisticsInputParser : IInputParser<BossStatistics>
    {
        public BossStatistics ParseInput(string input)
        {
            int hp = 0, damage = 0, armor = 0;
            foreach(var line in input.Split(Environment.NewLine))
            {
                var s = line.Split(": ");
                int v = int.Parse(s[1]);
                switch(s[0])
                {
                    case "Hit Points":
                        hp = v;
                        break;
                    case "Damage":
                        damage = v;
                        break;
                    case "Armor":
                        armor = v;
                        break;
                }
            }
            return new BossStatistics(hp, damage, armor);
        }
    }
}