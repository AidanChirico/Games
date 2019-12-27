using System;
using System.Collections.Generic;
using System.Linq;

namespace Dice
{
    /// <summary>
    /// Detects a 3 of a kind or a 4 of a kind.
    /// </summary>
    public class XOfAKind : YahtzeeHandBase
    {
        private readonly int _expectedLength;

        public XOfAKind(int expectedLength)
        {
            _expectedLength = expectedLength;
            switch (expectedLength)
            {
                case 3:
                    Name = "Three of A Kind";
                    break;

                case 4:
                    Name = "Four of A Kind";
                    break;

                default:
                    throw new InvalidOperationException($"{expectedLength} of a kind is not supported by this hand.");
            }
        }

        protected override int DetectHandImpl(IReadOnlyList<int> dice)
        {
            bool hasHand = dice
                .GroupBy(d => d)
                .Select(g => g.Count())
                .Where(r => r >= _expectedLength)
                .Any();

            return hasHand ? dice.Sum() : 0;
        }
    }
}
