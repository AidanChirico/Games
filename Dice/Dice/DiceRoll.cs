using System;
using System.Collections.Generic;
using System.Linq;

namespace Dice
{
    internal class DiceRoll
    {
        private readonly HandEvaluater _handEvaluator = new HandEvaluater();
        private readonly Random _rand = new Random();
        private readonly string[] _asciiDice;
        private List<TrackedDice> _dice = new List<TrackedDice>(0);
        private int _rollCount = 0;
        private int _diceAmount = 0;

        public int Sum => _dice.Sum(x => x.Value);


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

        /// <summary>
        /// Plays a game of dice.
        /// Let's the user choose how many 6-sided dice to roll, and prints the results and sum.
        /// </summary>

        public void PlayDice()
        {
            while (true)
            {
                _diceAmount = AskForNumberOfDice();

                if (_diceAmount == 0)
                {
                    break;
                }

                RollDice(_diceAmount);

                for (int i = 0; i < _dice.Count; i++)
                {
                    PrintDice(i + 1, _dice[i]);
                }

                Console.WriteLine();
                Console.WriteLine($"Sum: {Sum}");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Plays a game of Yatzee.
        /// Warning: This game is incomplete and may have a few bugs.
        /// </summary>
        public void PlayYahtzee()
        {
            _diceAmount = 5;

            while (true) // Allow rerolls
            {
                if (_rollCount == 0)
                {
                    if (_diceAmount == 0)
                    {
                        break;
                    }

                    RollDice(_diceAmount);
                }

                RollDice(_diceAmount);
                ++_rollCount;

                Console.WriteLine();
                Console.WriteLine($"Roll {_rollCount} of 3!");

                for (int i = 0; i < _dice.Count; i++)
                {
                    PrintDice(i + 1, _dice[i]);
                }

                var results = _handEvaluator.EvaluateHand(_dice.Select(d => d.Value).ToList());

                Console.WriteLine($"Sum: {Sum}");
                foreach (var result in results)
                {
                    Console.WriteLine($"Scoring option {result.Name} with score {result.Score}.");
                }

                if (_rollCount > 2)
                {
                    _rollCount = 0;
                    _dice.Clear();
                    continue;
                }

                while (true)
                {
                    Console.WriteLine("\nToggle a die to retain by entering its number, or type 'r' to roll.");
                    string input = Console.ReadLine();
                    if (input == "r")
                    {
                        break;
                    }

                    if (!int.TryParse(input, out int diceNumber) || diceNumber < 1 || diceNumber > _dice.Count)
                    {
                        Console.WriteLine($"Invalid input: {input}.");
                        continue;
                    }

                    --diceNumber;
                    _dice[diceNumber].Keep = !_dice[diceNumber].Keep;
                    for (int i = 0; i < _dice.Count; i++)
                    {
                        PrintDice(i + 1, _dice[i]);
                    }
                }
            }
        }

        private int AskForNumberOfDice()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a number of dice to roll, or 'q' to quit:");
                string input = Console.ReadLine();

                if (input == "q")
                {
                    return 0;
                }

                if (!int.TryParse(input, out int result))
                {
                    Console.WriteLine($"Invalid input: {result}!");
                    continue;
                }

                if (result < 1 || result > 100)
                {
                    Console.WriteLine("Ammount of dice must be between 1 and 100.");
                    continue;
                }

                return result;
            }
        }

        private void RollDice(int numberOfDice)
        {
            var newRoll = new List<TrackedDice>(numberOfDice);
            foreach (var die in _dice)
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

            _dice = newRoll;
        }

        internal void PrintDice(int number, TrackedDice dice)
        {
            char isKept = dice.Keep ? 'x' : ' ';
            Console.WriteLine(string.Format(_asciiDice[dice.Value - 1], number, isKept));
        }
    }
}
