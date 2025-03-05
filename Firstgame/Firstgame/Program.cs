using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firstgame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            Console.WriteLine("Hi player please choose your name");
            string name = Console.ReadLine();
            player newPlayer = new player(name);
            Console.WriteLine("Hi player please choose what do you want to do\nb for blackjack \ns for stop playing");
            userInput = Console.ReadLine().ToLower();
            bool continuePlaying = true;
            while (continuePlaying)
            {
                switch (userInput)
                {
                    case "b":
                        PlayBlackjack(newPlayer);
                        break;
                    case "s":
                        continuePlaying = false;
                        break;
                    default:
                        Console.WriteLine("wrong user input\n");
                        break;
                }
                if (continuePlaying)
                {
                    Console.WriteLine("\nDo you want to play another game? (y/n): ");
                    userInput = Console.ReadLine().ToLower();

                    if (userInput == "n")
                    {
                        continuePlaying = false;
                    }
                }
            }
            Console.WriteLine("\nThank you for playing! Goodbye.");
        }

        private static void PlayBlackjack(player player)
        {
            blackjack blackjackGame = new blackjack(player);
            blackjackGame.DealInitialCards();
            blackjackGame.ShowCards();
            bool playerTurn = true;
            while (playerTurn)
            {
                Console.WriteLine("\nWould you like to [Hit] or [Stand]?");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);  // Capture key input

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    blackjackGame.PlayerHit();
                    if (player.CalculatehandValueBlackjack() > 21)
                    {
                        Console.WriteLine("\nYou busted!");
                        playerTurn = false;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Spacebar)
                {
                    blackjackGame.PlayerStand();
                    playerTurn = false;
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please press Enter for [Hit] or Space for [Stand].");
                }
            }

            blackjackGame.DealerTurn();
            blackjackGame.DeterminewhoWon();
        }


    }

}
