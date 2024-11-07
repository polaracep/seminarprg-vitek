using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter a number: ");
            var number = Convert.ToInt32(Console.ReadLine());
            var fact = Factorial_Rec(number);
            Console.WriteLine(number +"! = " + fact);
            Console.ReadKey();


        }
        

        public static int Factorial_Rec(int num)
        {
            if (num == 0) 
            { 
            return 1;
            }else
            {
                return num * Factorial_Rec(num-1);
            }




        }
    }
}
