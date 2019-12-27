using System;
using System.Linq;

namespace Dice
{
    internal class GamePlayer
    {
        private readonly DiceRoll diceRoll = new DiceRoll();
        private readonly HandEvaluater _handEvaluator = new HandEvaluater();

        private int _rollCount = 0;
        private int _diceAmount = 0;

        /// <summary>
        /// Plays a game of dice.
        /// Let's the user choose how many 6-sided dice to roll, and prints the results and sum.
        /// </summary>
        public void PlayDice()
        {
            while (true)
            {
                _diceAmount = InputManager.AskForNumberOfDice();
                if (_diceAmount == 0)
                {
                    break;
                }

                diceRoll.RollDice(_diceAmount);

                diceRoll.PrintDice();

                Console.WriteLine();
                Console.WriteLine($"Sum: {diceRoll.Sum}");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Plays a game of Yatzee.
        /// </summary>
        public void PlayYahtzee()
        {
            _diceAmount = 5;

            while (true) // Allow rerolls
            {
                diceRoll.RollDice(_diceAmount);
                ++_rollCount;

                Console.WriteLine();
                Console.WriteLine($"Roll {_rollCount} of 3!");

                diceRoll.PrintDice();

                var results = _handEvaluator.EvaluateHand(diceRoll.Dice.Select(d => d.Value).ToList());

                Console.WriteLine($"Sum: {diceRoll.Sum}");
                foreach (var result in results)
                {
                    Console.WriteLine($"Scoring option {result.Name} with score {result.Score}.");
                }

                if (_rollCount > 2)
                {
                    Console.WriteLine($"Turn is over. Press any key to start next turn.");
                    Console.ReadKey();
                    _rollCount = 0;
                    diceRoll.Dice.Clear();
                    continue;
                }

                // Present dice for eval
                while (true)
                {
                    Console.WriteLine("\nToggle a die to retain by entering its number, or type 'r' to roll.");
                    string input = Console.ReadLine();
                    if (input == "r")
                    {
                        break;
                    }

                    if (!int.TryParse(input, out int diceNumber)
                        || diceNumber < 1
                        || diceNumber > diceRoll.Dice.Count)
                    {
                        Console.WriteLine($"Invalid input: {input}.");
                        continue;
                    }

                    --diceNumber; // move to 0 index for array deref
                    diceRoll.Dice[diceNumber].Keep = !diceRoll.Dice[diceNumber].Keep;
                    diceRoll.PrintDice();
                }
            }
        }
    }
}
