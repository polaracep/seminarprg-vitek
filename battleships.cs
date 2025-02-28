using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleshipfunkce
{
    internal class Program
    {
        static (int, int) GetCoordinates(ref int x, ref int y)
        {
            string userInputX;
            string userInputY;
            Console.WriteLine("Enter X coordiante");
            userInputX = Console.ReadLine();
            

            while(!int.TryParse(userInputX, out x) || x < 0 || x > 9)
            {
                if(x < 0)
                {
                    Console.WriteLine("too low, repeat input");
                    userInputX = Console.ReadLine();

                }
                else if (x > 9)
                {
                    Console.WriteLine("too high, repeat input");
                    userInputX = Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("nigga what, repeat input");
                    userInputX = Console.ReadLine();
                }
                
            }
            Console.WriteLine("Enter Y coordiante");
            userInputY = Console.ReadLine();
            while (!int.TryParse(userInputY, out y))
            {
                if (y < 0)
                {
                    Console.WriteLine("too low, repeat input");
                    userInputX = Console.ReadLine();

                }
                else if (y > 9)
                {
                    Console.WriteLine("too high, repeat input");
                    userInputX = Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("nigga what, repeat input");
                    userInputX = Console.ReadLine();
                }
            }
            return (x, y);
        }
        
        static int GetShipLenght(ref int shiplenght )
        {
            string shipType;
            Console.WriteLine("type in which ship do you want to place (aircraftcarrier/cruiser/battleship/submarine/toredosubmarine)");
            shipType = Console.ReadLine();

            while (true)
            {
                switch (shipType)
                {
                    
                    case "aircraftcarrier":
                        shiplenght = 5;
                        break;
                    case "cruiser":
                        shiplenght = 3;
                        break;
                    case "battleship":
                        shiplenght = 4;
                        break;
                    case "submarine":
                        shiplenght = 3;
                        break;
                    case "toredosubmarine":
                        shiplenght = 5;
                        break;
                    default: Console.WriteLine("repeat user input"); break; 
                }
                break;
            }
            return shiplenght;
        }

        static void Main(string[] args)
        {
            int x = 0;
            int y = 0;
            
            int shipLenght = 0;
            GetShipLenght(ref shipLenght);
            GetCoordinates(ref x, ref y);
            //value of x and value of y
            Console.WriteLine("" + x + " " + y);
            Console.WriteLine(shipLenght);
            Console.ReadKey();  

        }
    }
}
