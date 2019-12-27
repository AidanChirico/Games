using System;

namespace Dice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to dice in C#!");
            Console.WriteLine();

            var gamePlayer = new GamePlayer();
            string gameToPlay;
            bool continuePlaying = true;

            while (continuePlaying)
            {
                Console.WriteLine("Select a game to play or press q to quit the application.\nCurrently, we have Dice and Yahtzee.");

                gameToPlay = Console.ReadLine();

                Console.WriteLine();

                switch (gameToPlay)
                {
                    case "Dice":
                        gamePlayer.PlayDice();
                        break;
                    case "Yahtzee":
                        gamePlayer.PlayYahtzee();
                        break;
                    case "q":
                        continuePlaying = false;
                        break;
                }
            }

            Console.WriteLine("Application has quit. Press any key to close.");
            Console.ReadKey();
        }
    }
}