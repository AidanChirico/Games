using System;
using System.Collections.Generic;
using System.Linq;

namespace Dice
{
    public class LikeFaces : YahtzeeHandBase
    {
        private int _face;

        public LikeFaces(int face)
        {
            _face = face;

            switch (_face)
            {
                case 1:
                    Name = "Ones";
                    break;
                case 2:
                    Name = "Twos";
                    break;
                case 3:
                    Name = "Threes";
                    break;
                case 4:
                    Name = "Fours";
                    break;
                case 5:
                    Name = "Fives";
                    break;
                case 6:
                    Name = "Sixes";
                    break;
                default:
                    throw new InvalidOperationException($"The catagory {_face}s is not suported by a 6-sided die used for Yahtzee.");
            }
        }

        protected override int DetectHandImpl(IReadOnlyList<int> dice)
        {
            return dice.Where(d => d == _face).Sum();
        }
    }
}
