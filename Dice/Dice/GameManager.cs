using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    class GameManager
    {
        internal int AskForNumberOfDice()
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
