using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace r__p__k
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("napi3 číslo: "); 
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("napi3 číslo: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("napi3 číslo: ");
            int num3 = Convert.ToInt32(Console.ReadLine());

            int reasult = 0;
            string operation_type = "operace";
            switch (operation_type)
            {
                case "dividing":
                     reasult= num1 / num2;
                    break;
                case "násobení":
                    reasult = num1 * num2;
                    break;
                case "sum":
                    reasult = 3;
                    break;
                case "power":
                    reasult = 1;
                    break;
                case "squaring":
                    reasult = 1;
                    break;
                case "":
                    reasult = 1;
                    break;
                case "num 1 factorial":
                    reasult = 1;
                    break;
                case "combination numbers":
                    reasult = 1;
                    break;
                case "násobení":
                    reasult = 1;
                    break;
                case "násobení":
                    reasult = 1;
                    break;
                case "násobení":
                    reasult = 1;
                    break;
                case "násobení":
                    reasult = 1;
                    break;




            }
        }
    }
}
