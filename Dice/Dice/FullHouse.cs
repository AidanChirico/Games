using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public class FullHouse : YahtzeeHandBase
    {
        public FullHouse()
        {
            Name = "Full House";
        }

        protected override int DetectHandImpl(IReadOnlyList<int> dice)
        {
            int[] diceGroups = dice
                .GroupBy(d => d)
                .Select(g => g.Count())
                .OrderBy(r => r)
                .Where(r => r >= 2)
                .ToArray();

            if (diceGroups.Length == 2
                && diceGroups[0] == 2
                && diceGroups[1] == 3)
            {
                return 25;
            }

            return 0;
        }
    }
}
