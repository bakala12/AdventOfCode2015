using AdventOfCode2015.Input;
using AdventOfCode2015.Models;

namespace AdventOfCode2015.Days
{
    public class Day22 : AocDay<BossStatistics>
    {
        public Day22(IInputParser<BossStatistics> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(BossStatistics input)
        {
            int bestMana = int.MaxValue;
            Console.WriteLine(SimulateFight(true, 50, 500, input.HitPoints, input.Damage, 0, 0, 0, 0, ref bestMana, false));
        }

        protected override void Part2(BossStatistics input)
        {
            int bestMana = int.MaxValue;
            Console.WriteLine(SimulateFight(true, 50, 500, input.HitPoints, input.Damage, 0, 0, 0, 0, ref bestMana, true));
        }

        private int SimulateFight(bool playerToMove, int playerHp, int playerMana, int bossHp, int bossDamage, int shieldCount, int poisonCount, int rechargeCount, int manaSpent, ref int bestMana, bool hardMode)
        {
            if(bossHp <= 0)
            {
                bestMana = Math.Min(bestMana, manaSpent);
                return manaSpent;
            }
            if(manaSpent >= bestMana)
                return manaSpent;
            int playerArmor = 0;
            if(shieldCount > 0)
            {
                shieldCount--;
                playerArmor += 7;
            }
            if(poisonCount > 0)
            {
                poisonCount--;
                bossHp -= 3;
            }
            if(rechargeCount > 0)
            {
                rechargeCount--;
                playerMana += 101;
            }
            if(bossHp <= 0)
            {
                bestMana = Math.Min(bestMana, manaSpent);
                return manaSpent;
            }
            if(playerToMove)
            {
                if(hardMode)
                    playerHp--;
                if(playerHp <= 0)
                    return int.MaxValue;
                int minimalManaToWin = int.MaxValue;
                foreach(var spell in GetAvailableSpells(playerMana, shieldCount, poisonCount, rechargeCount))
                {
                    var (bossHp1, playerHp1, shieldCount1, poisonCount1, rechargeCount1) = CastSpell(spell, bossHp, playerHp, shieldCount, poisonCount, rechargeCount);
                    var cost = SimulateFight(!playerToMove, playerHp1, playerMana - spell.ManaCost, bossHp1, bossDamage, shieldCount1, poisonCount1, rechargeCount1, manaSpent + spell.ManaCost, ref bestMana, hardMode);
                    if(cost < minimalManaToWin)
                        minimalManaToWin = cost;
                }
                return minimalManaToWin;
            }
            else
            {
                var dmg = Math.Max(1, bossDamage - playerArmor);
                playerHp -= dmg;
                if(playerHp <= 0)
                    return int.MaxValue;
                return SimulateFight(!playerToMove, playerHp, playerMana, bossHp, bossDamage, shieldCount, poisonCount, rechargeCount, manaSpent, ref bestMana, hardMode);
            }
        }

        private readonly record struct Spell(string Name, int ManaCost, Predicate<(int, int, int)> CanBeCasted, int EffectTurns);

        private static Spell[] AvailableSpells = new Spell[]
        {
            new Spell("Magic Missile", 53, x => true, 0),
            new Spell("Drain", 73, x => true, 0),
            new Spell("Shield", 113, x => x.Item1 == 0, 6),
            new Spell("Poison", 173, x => x.Item2 == 0, 6),
            new Spell("Recharge", 229, x => x.Item3 == 0, 5)
        };

        private IEnumerable<Spell> GetAvailableSpells(int playerMana, int shieldCount, int poisonCount, int rechargeCount)
        {
            return AvailableSpells.Where(s => s.ManaCost <= playerMana && s.CanBeCasted((shieldCount, poisonCount, rechargeCount)));
        }

        private (int, int, int, int, int) CastSpell(Spell spell, int bossHp, int playerHp, int shieldCount, int poisonCount, int rechargeCount)
        {
            switch(spell.Name)
            {
                case "Magic Missile":
                    bossHp -= 4;
                    break;
                case "Drain":
                    bossHp -= 2;
                    playerHp += 2;
                    break;
                case "Shield":
                    shieldCount = spell.EffectTurns;
                    break;
                case "Poison":
                    poisonCount = spell.EffectTurns;
                    break;
                case "Recharge":
                    rechargeCount = spell.EffectTurns;
                    break;
            }
            return (bossHp, playerHp, shieldCount, poisonCount, rechargeCount);
        }
    }
}