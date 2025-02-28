using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listy
{
    internal class Program
    {
        static void PrintList(List<string> stringlist)
        {
            foreach (string name in stringlist)
            {
                Console.WriteLine(name);
            }
        }
        static void Main(string[] args)
        {

            //Zaklady
            List<string> mylist = new List<string>();
            mylist.Add("Škoda");
            mylist.Add("Lada");
            mylist.Add("Koenigsegg");
            mylist.Add("Audi");
            mylist.Add("McMurtry");

            PrintList(mylist);
            Console.WriteLine();
            mylist.Remove("Lada");
            PrintList(mylist);
            mylist.RemoveAt(2);
            Console.WriteLine();
            PrintList(mylist);
            while (true)
            {
                Console.WriteLine(":");
                string userInput = Console.ReadLine();
                if (/*v listu exituje hodnota exsistuje automobilka na velky k*/mylist.Exists(carMaker => carMaker.StartsWith(userInput)))
                {
                    Console.WriteLine("V listu je automobilka na " + userInput);
                    break;
                }
                else
                {
                    Console.WriteLine("v listu neni automobilka na " + userInput);
                }
            }
            

            List<string> mylist1 = new List<string>();
            mylist.Add("chicken wings");
            mylist.Add("watermelon");
            mylist.Add("banana");
            mylist.Add("chicken strips");
            mylist.Add("watermelonbananachickenwings");
            while (true)
            {
                Console.WriteLine("chces pridat ci odebrat jidlo?  (add/rem)");
                string userAnswer = Console.ReadLine();
                if (userAnswer == "add")
                {
                    while (true)
                    {
                        Console.WriteLine("kam a co chces pridat? (hodnoty rozdel mezerou): ");
                        string userInput = Console.ReadLine();
                        userInput.Split(' ');
                        if (mylist1.Contains(Convert.ToString(userInput[1])))
                        {

                            Console.WriteLine("list už obsahuje tuto položku");
                            
                        }
                        else
                        {
                            mylist1.Insert(Convert.ToInt32(userInput[0]), Convert.ToString(userInput[1]));
                        }
                        

                        break;
                    }
                   

                } else if (userAnswer == "rem")
                {
                    Console.WriteLine("co a kde chces smazat?:(hodnoty rozdel mezerou) ");
                    string userInput = Console.ReadLine();
                    mylist.Remove(userInput);
                    break;
                }
                

                
            }
            PrintList(mylist1);
            

            Dictionary<string, string> myDict = new Dictionary<string, string>();
            myDict["Wasser"] = "Voda";
            myDict["Bagger"] = "Bagr";
            myDict["Naturwissenschaft"] = "Věda";
            myDict["Bundespräsidenttischwahlwiederholungverschiebung"] = "Voda";

            foreach(KeyValuePair<string, string> translation in myDict)
            {
                string germanWord = translation.Key;
                string czechWord = translation.Value;
                Console.WriteLine("překlad slova" +  germanWord + "do češtiny je " + czechWord);
            }

            while (true)
            {
                Console.WriteLine("key:");
                string userInput = Console.ReadLine();
                if (/*ve slovníku exituje hodnota */myDict.ContainsKey(userInput))
                {
                    Console.WriteLine("V listu je automobilka na " + userInput);
                    break;
                }
                else
                {
                    Console.WriteLine("v listu neni automobilka na " + userInput);
                }
            }

            Console.ReadKey();

            



        }
    }
}
