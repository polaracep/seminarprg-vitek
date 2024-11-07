using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lists_1_
{
    class Program
    {


        static void PrintList(List<string> foodlist)
        {
            foreach (string food in foodlist)
            {
                Console.WriteLine(food);
            }
        }
        static void Main(string[] args)
        {
            string userInput;
            List<string> favoriteFood = new List<string>();
            favoriteFood.Add("banana");
            favoriteFood.Add("smazak");
            favoriteFood.Add("barbequebaconburger");
            PrintList(favoriteFood);
            Console.WriteLine();
            
            bool chcespokracovat = true;
            while (chcespokracovat == true)
            {
                Console.WriteLine("Chces neco pridat nebo odebrat?\n(add/rem) pokud ano\n(ne) pokud ne");
                string userDecesion = Console.ReadLine();
                
                switch (userDecesion)
                {
                    case "add":
                        Console.WriteLine("Na jakou pozici v listu a co chces pridat? (odpovědi rozděl mezerou)");
                        userInput = Convert.ToString(Console.ReadLine());
                        string[] arguments = userInput.Split(' ');
                        switch (favoriteFood.Contains(Convert.ToString(arguments[1])))
                        {
                            case true:
                                Console.WriteLine("daný list už tohle jídlo obsahuje");
                                break;
                            case false:
                                favoriteFood.Insert(Convert.ToInt32(arguments[0]), Convert.ToString(arguments[1]));
                                Console.WriteLine();
                                PrintList(favoriteFood);
                                break;
                            
                        }
                        break;
                            
                        

                    case "rem":
                            Console.WriteLine("Co chces odebrat?");
                            userInput = Console.ReadLine();

                            switch (favoriteFood.Contains(userInput))
                            {
                                case true:
                                    int foodNumber = favoriteFood.IndexOf(userInput);
                                    favoriteFood.RemoveAt(foodNumber);
                                    Console.WriteLine();
                                    PrintList(favoriteFood);
                                    break;
                                case false:
                                    Console.WriteLine("tohle jídlo se v daném listě/listu nenachází");
                                    break;
                                
                            }        
                        
                        break;
                    case "ne": //stopuje cyklus
                        chcespokracovat = false;
                        break;
                    default:
                        Console.WriteLine("wrong user input");
                        break;

                        
                        
                }
               
                Console.ReadKey();
            
            }
           
        }
    }
}
