using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    class Chance : YahtzeeHandBase
    {
        public Chance()
        {
            Name = "Chance";
        }

        protected override int DetectHandImpl(IReadOnlyList<int> dice)
        {
            return dice.Sum();
        }
    }
}
