using System;
using System.Collections.Generic;
using System.Linq;

namespace Dice
{
    public class LikeFaces : YahtzeeHandBase
    {
        private readonly int _face;
        private static readonly IReadOnlyDictionary<int, string> _names = new Dictionary<int, string>
        {
            { 1, "Ones" },
            { 2, "Twos" },
            { 3, "Threes" },
            { 4, "Fours" },
            { 5, "Fives" },
            { 6, "Sixes" },
        };

        public LikeFaces(int face)
        {
            _face = face;

            if (!_names.TryGetValue(face, out string name))
            {
                throw new InvalidOperationException($"The catagory {_face} is not suported by a 6-sided die.");
            }
            Name = name;
        }

        protected override int DetectHandImpl(IReadOnlyList<int> dice)
        {
            return dice.Where(d => d == _face).Sum();
        }
    }
}
