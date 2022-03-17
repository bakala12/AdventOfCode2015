using AdventOfCode2015.Input;
using AdventOfCode2015.Models;

namespace AdventOfCode2015.Days
{
    public class Day21 : AocDay<BossStatistics>
    {
        private readonly ItemShop _shop;

        public Day21(IInputParser<BossStatistics> inputParser) : base(inputParser)
        {
            _shop = new ItemShop();
        }

        protected override void Part1(BossStatistics input)
        {
            int minCost = int.MaxValue;
            foreach(var w in _shop.Weapons)
                foreach(var a in _shop.Armors)
                    foreach(var r1 in _shop.Rings)
                        foreach(var r2 in _shop.Rings.Where(r => r != r1))
                        {
                            var equipment = w + a + r1 + r2;
                            if(IsPlayerWinSimulateFight(equipment.ToStatistics(100), input) && equipment.Cost < minCost)
                                minCost = equipment.Cost;
                        }
            Console.WriteLine(minCost);
        }

        protected override void Part2(BossStatistics input)
        {
            int maxCost = int.MinValue;
            foreach(var w in _shop.Weapons)
                foreach(var a in _shop.Armors)
                    foreach(var r1 in _shop.Rings)
                        foreach(var r2 in _shop.Rings.Where(r => r != r1))
                        {
                            var equipment = w + a + r1 + r2;
                            if(!IsPlayerWinSimulateFight(equipment.ToStatistics(100), input) && equipment.Cost > maxCost)
                                maxCost = equipment.Cost;
                        }
            Console.WriteLine(maxCost);
        }

        private static bool IsPlayerWinSimulateFight(BossStatistics player, BossStatistics boss)
        {
            int pHp = player.HitPoints;
            int pHit = Math.Max(1, player.Damage - boss.Armor);
            int bossHp = boss.HitPoints;
            int bossHit = Math.Max(1, boss.Damage - player.Armor);
            while(true)
            {
                bossHp -= pHit;
                pHp -= bossHit;
                if(bossHp <= 0)
                    return true;
                if(pHp <= 0)
                    return false;
            }
        }

        public readonly record struct Item(string Name, int Cost, int Damage, int Armor)
        {
            public static Item operator+(Item i1, Item i2)
            {
                return new Item(string.Empty, i1.Cost + i2.Cost, i1.Damage + i2.Damage, i1.Armor + i2.Armor);
            }

            public BossStatistics ToStatistics(int hp)
            {
                return new BossStatistics(hp, Damage, Armor);
            }
        }

        public class ItemShop
        {
            public Item[] Weapons { get; }
            public Item[] Armors { get; }
            public Item[] Rings { get; }
            
            public ItemShop()
            {
                var weapons = @"Weapons:    Cost  Damage  Armor
Dagger        8     4       0
Shortsword   10     5       0
Warhammer    25     6       0
Longsword    40     7       0
Greataxe     74     8       0";

                var armors = @"Armor:      Cost  Damage  Armor
Leather      13     0       1
Chainmail    31     0       2
Splintmail   53     0       3
Bandedmail   75     0       4
Platemail   102     0       5";

                var rings = @"Rings:      Cost  Damage  Armor
Damage+1    25     1       0
Damage+2    50     2       0
Damage+3   100     3       0
Defense+1   20     0       1
Defense+2   40     0       2
Defense+3   80     0       3";
                Weapons = ParseGroup(weapons);
                Armors = ParseGroup(armors, 1);
                Rings = ParseGroup(rings, 2);
            }

            private static Item[] ParseGroup(string itemsStr, int optionals = 0)
            {
                var list = new List<Item>();
                foreach(var line in itemsStr.Split('\n').Skip(1))
                {
                    var s = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    list.Add(new Item(s[0], int.Parse(s[1]), int.Parse(s[2]), int.Parse(s[3])));
                }
                for(int o = 0; o < optionals; o++)
                    list.Add(new Item("Optinal", 0, 0, 0));
                return list.ToArray();
            }
        }
    }
}