using System;
using System.Collections.Generic;
using System.Linq;

namespace Dice
{
    internal abstract class YahtzeeHandBase
    {
        public int Score { get; set; }
        public string Name { get; set; }

        public int DetectHand(IReadOnlyList<int> dice)
        {
            if (dice == null || !dice.Any())
            {
                throw new InvalidOperationException("Can not operate with null or empty list.");
            }

            return DetectHandImpl(dice);
        }

        protected abstract int DetectHandImpl(IReadOnlyList<int> dice);
    }
}
