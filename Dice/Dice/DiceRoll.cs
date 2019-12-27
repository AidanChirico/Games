using System;
using System.Collections.Generic;
using System.Linq;

namespace Dice
{
    class DiceRoll
    {
        internal List<TrackedDice> Dice { get; set; }

        private readonly Random _rand = new Random();
        private readonly string[] _asciiDice;
        public int Sum => Dice.Sum(x => x.Value);


        public DiceRoll()
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


        internal List<TrackedDice> RollDice(int numberOfDice)
        {
            var newRoll = new List<TrackedDice>(numberOfDice);
            foreach (var die in Dice)
            {
                if (die.Keep)
                {
                    newRoll.Add(die);
                }
            }

            for (int i = newRoll.Count; i < numberOfDice; i++)
            {
                newRoll.Add(new TrackedDice(_rand.Next(1, 7)));
            }

            Dice = newRoll;
            return Dice;
        }

        internal void PrintDice()
        {
            int number = 1;

            foreach (var die in Dice)
            {
                char isKept = die.Keep ? 'x' : ' ';
                Console.WriteLine(string.Format(_asciiDice[die.Value - 1], number, isKept));

                number++;
            }
        }
    }
}
