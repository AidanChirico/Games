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
                    Console.WriteLine();
                    Console.WriteLine($"Turn is over. Press enter to start next turn or press q to quit Yahtzee.");

                    _rollCount = 0;
                    diceRoll.Dice.Clear();

                    if (InputManager.DetectQuit())
                    {
                        break;
                    }
                    continue;
                }

                // Present dice for eval
                InputManager.AskForDiceToKeep(diceRoll);
            }
        }
    }
}
