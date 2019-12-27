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
    }
}
