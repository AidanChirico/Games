using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public class Straight : YahtzeeHandBase
    {
        private int _straightLength;
        private int _score;

        public Straight(int straightLength)
        {
            _straightLength = straightLength;
            switch (straightLength)
            {
                case 5:
                    Name = "Large Straight";
                    _score =  40;
                    break;
                case 4:
                    Name = "Small Straight";
                    _score = 30;
                    break;
                default:
                    throw new InvalidOperationException("The Yahtzee hand straight must consist of four or more consecutive dice.");
            }
        }

        protected override int DetectHandImpl(IReadOnlyList<int> dice)
        {
            dice = dice.OrderBy(r => r).ToArray();

            int currentStraight = 1;
            
            for (int i = 0; i < dice.Count - 1; i++)
            {
                if (dice[i] + 1 == dice[i + 1])
                {
                    currentStraight++;

                    if (currentStraight >= _straightLength)
                    {
                        return _score;
                    }
                }
                else if (dice[i] == dice[i + 1])
                {
                    continue;
                }
                else
                {
                    currentStraight = 1;
                }
            }

            return 0;
        }
    }
}
