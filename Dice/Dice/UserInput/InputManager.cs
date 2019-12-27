using Dice.UserInput;
using System;

namespace Dice
{
    internal static class InputManager
    {
        public static MainMenu PresentMainMenu()
        {
            while (true)
            {
                Console.WriteLine("Type the name of the game (Dice, Yahtzee) to play, or 'q' to quit.");

                string mainMenuInput = Console.ReadLine();

                if (StringComparer.OrdinalIgnoreCase.Equals(mainMenuInput, "dice"))
                {
                    return MainMenu.Dice;
                }
                else if (StringComparer.OrdinalIgnoreCase.Equals(mainMenuInput, "yahtzee"))
                {
                    return MainMenu.Yahtzee;
                }
                else if (StringComparer.OrdinalIgnoreCase.Equals(mainMenuInput, "q"))
                {
                    return MainMenu.Quit;
                }
                else
                {
                    Console.WriteLine($"Unexpected input \"{mainMenuInput}\".");
                }
            }
        }

        internal static int AskForNumberOfDice()
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

        internal static void AskForDiceToKeep(DiceRoll diceRoll)
        {
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

        internal static bool DetectQuit()
        {
            return Console.ReadKey().Key == ConsoleKey.Q;
        }
    }
}