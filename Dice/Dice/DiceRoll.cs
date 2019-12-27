using System;
using System.Collections.Generic;
using System.Linq;

namespace Dice
{
    internal class DiceRoll
    {

        private static readonly string[] _asciiDice;
        private readonly Random _rand = new Random();

        public List<TrackedDice> Dice { get; set; } = new List<TrackedDice>(0);

        public int Sum => Dice.Sum(x => x.Value);

        static DiceRoll()
        {
            _asciiDice = new[]
            {
                "{0} -----------\n{1} |         |\n  |    o    |\n  |         |\n  -----------",
                "{0} -----------\n{1} |      o  |\n  |         |\n  |  o      |\n  -----------",
                "{0} -----------\n{1} |      o  |\n  |    o    |\n  |  o      |\n  -----------",
                "{0} -----------\n{1} |  o   o  |\n  |         |\n  |  o   o  |\n  -----------",
                "{0} -----------\n{1} |  o   o  |\n  |    o    |\n  |  o   o  |\n  -----------",
                "{0} -----------\n{1} |  o   o  |\n  |  o   o  |\n  |  o   o  |\n  -----------",
            };
        }

        internal void RollDice(int numberOfDice)
        {
            var newRoll = new List<TrackedDice>(numberOfDice);
            foreach (var die in Dice)
            {
                if (die.Keep)
                {
                    newRoll.Add(die);
                }
            }

            for (int i = newRoll.Count; i < numberOfDice; ++i)
            {
                newRoll.Add(new TrackedDice(_rand.Next(1, 7)));
            }

            Dice = newRoll;
        }

        internal void PrintDice()
        {
            int number = 1;

            foreach (var die in Dice)
            {
                char isKept = die.Keep ? 'x' : ' ';
                Console.WriteLine(_asciiDice[die.Value - 1], number, isKept);

                number++;
            }
        }
    }
}
