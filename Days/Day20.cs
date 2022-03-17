using AdventOfCode2015.Input;

namespace AdventOfCode2015.Days
{
    public class Day20 : AocDay<int>
    {
        public Day20(IInputParser<int> inputParser) : base(inputParser)
        {
        }

        protected override void Part1(int input)
        {
            Console.WriteLine(DeliverPresentsIterator().TakeWhile(p => p <= input).Count()+1);
        }

        protected override void Part2(int input)
        {
            Console.WriteLine(DeliverPresentsIterator2().TakeWhile(p => p <= input).Count()+1);
        }

        private IEnumerable<int> DeliverPresentsIterator()
        {
            int house = 1;
            while(true)
            {
                int presents = 0;
                for(int d1 = 1; d1 * d1 <= house; d1++)
                {
                    if(house % d1 == 0)
                    {
                        presents += d1;
                        if(d1 * d1 != house)
                            presents += house / d1;    
                    }
                }
                yield return 10*presents;
                house++;
            }
        }

        private IEnumerable<int> DeliverPresentsIterator2()
        {
            int house = 1;
            List<int> delivers = new List<int>();
            delivers.Add(0);
            while(true)
            {
                delivers.Add(50);
                int presents = 0;
                for(int d1 = 1; d1 * d1 <= house; d1++)
                {
                    if(house % d1 == 0)
                    {
                        if(delivers[d1] > 0)
                        {
                            presents += d1;
                            delivers[d1]--;
                        }
                        if(d1 * d1 != house && delivers[house / d1] > 0)
                        {
                            presents += house / d1;
                            delivers[house / d1]--;
                        }
                    }
                }
                yield return 11 * presents;
                house++;
            }
        }
    }
}