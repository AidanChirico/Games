using System.Collections.Generic;
using System.Linq;

namespace Dice
{
    public class HandEvaluater
    {
        private readonly List<YahtzeeHandBase> _hands;
        
        public HandEvaluater()
        {
            _hands = new List<YahtzeeHandBase>
            {
                new XOfAKind(3),
                new XOfAKind(4),
                new Yahtzee(),
                new FullHouse(),
                new Straight(4),
                new Straight(5),
                new Chance(),
                new LikeFaces(1),
                new LikeFaces(2),
                new LikeFaces(3),
                new LikeFaces(4),
                new LikeFaces(5),
                new LikeFaces(6),
            };
        }
        public IReadOnlyList<TrackedHand> EvaluateHand(IReadOnlyList<int> dice)
        {
            var options = new List<TrackedHand>(_hands.Count);

            foreach (var hand in _hands)
            {
                options.Add(new TrackedHand(hand.Name, hand.DetectHand(dice)));
            }

            if (options.Any(d => d.Score != 0))
            {
                options = options.Where(d => d.Score != 0).ToList();
            }

            return options;
        }
    }
}
