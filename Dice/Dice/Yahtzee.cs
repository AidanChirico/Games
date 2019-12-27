using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public class Yahtzee : YahtzeeHandBase
    {
        public Yahtzee()
        {
            Name = "Yahtzee";
        }

        protected override int DetectHandImpl(IReadOnlyList<int> dice)
        {
            bool has5 = dice
                .GroupBy(d => d)
                .Select(g => g.Count())
                .Where(r => r >= 5)
                .Any();

            return has5 ? 50 : 0;
        }
    }
}
