using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulačka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter a number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("enter a number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("enter a variable name: ");
            string variablename = Console.ReadLine();
            string operátor;
            
        }
        static string Getmathmethode(int methodenum)
        {
            string methode;
            switch (methodenum)
            {
            
                case 1:
                    methode = "+";
                   break;
                case "minus":
                    methode = "+";
                    break;
                case "dělení":
                    methode = "+";
                    break;
                case "násobení":
                    methode = "+";
                    break;
                case "mocnění":
                    methode = "+";
                    break;
                case "odmocnění":
                    methode = "+";
                    break;
                case "":
                    methode = "+";
                    break;
                default: Console.WriteLine("neznámá operace");
                    Console.ReadLine();
                    return methode;
            }
        }
    }
}
