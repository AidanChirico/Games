using Dice.UserInput;
using System;

namespace Dice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Aidan's games in C#!");

            var gamePlayer = new GamePlayer();
            MainMenu mainMenu;

            do
            {
                mainMenu = InputManager.PresentMainMenu();
                switch (mainMenu)
                {
                    case MainMenu.Dice:
                        gamePlayer.PlayDice();
                        break;

                    case MainMenu.Yahtzee:
                        gamePlayer.PlayYahtzee();
                        break;
                }
            } while (mainMenu != MainMenu.Quit);

            Console.WriteLine();
            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }
    }
}