using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int playerbudget = 1000;
            int compbudget = 1000;
            Console.Write("state a stake: ");
            int playerstake = Convert.ToInt32(Console.ReadLine());
            Random rng = new Random();
            int currentround = 0;
            int roll;
            bool wannacontinue = true;
            while (wannacontinue = true)
            {
                bool betvalidity = false;
                
                roll = playerstake;
                while (roll > 1)
                {
                    
                    if (currentround % 2 == 0) //hraje uzivatel
                    {
                        Console.WriteLine("stiskni enter pro rollnuti 1 - " + roll);

                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            roll = rng.Next(1, playerstake + 1);
                            Console.WriteLine();
                            if (roll == 1)
                            {
                                Console.WriteLine("player lost, good luck next time");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("stiskni enter pro rollnuti 1 - " + roll);
                    }
                



                    currentround++;
                }
                if (currentround % 2 == 0)
                {
                    playerbudget += playerstake;
                    compbudget -= playerstake;
                    Console.WriteLine("player budged is :" + playerbudget + "\ncomputer budget is: " + compbudget);
                    Console.ReadKey();
                }
                else
                {
                    playerbudget -= playerstake;
                    compbudget += playerstake;
                    Console.WriteLine("player budged is :" + playerbudget + "\ncomputer budget is: " + compbudget);
                    Console.ReadKey();
                }
                Console.Write("wanna continue? (y/n) ");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    wannacontinue = true;
                }else if (answer == "n")
                {
                    wannacontinue = false;
                }else 
                {
                    Console.WriteLine("ses kokot?\nplayer loses all money");
                    playerbudget = 0;
                    Console.ReadKey();
                    wannacontinue = false;

                }
            }
        }
    }
}
