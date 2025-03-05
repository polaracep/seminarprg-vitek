using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
        
            int a = 0;
            int Fact = 0;
            int Fib = 0;
            string userImput;
            bool userinputCheck = true;
            bool userInputValid;
            while (true)
            {
                Console.Write("enter a number: ");
                userImput = Console.ReadLine();
                userInputValid = int.TryParse(userImput, out a);
                while (userInputValid == false)
                { 
                    Console.WriteLine("repeat input");
                    userImput = Console.ReadLine();
                    userInputValid = int.TryParse(userImput, out a);
                    if (userInputValid == true)
                    {
                        Fact = Factorial_Rec(a);
                        Fib = Fibonacci_Rec(a);
                    }
                }
                    Fact = Factorial_Rec(a);
                    Fib = Fibonacci_Rec(a);


                Console.WriteLine(userImput + "! = " + Fact + "\n" + userImput + ". člen ve fibonacciho posloupnosti se rovná " + Fib);
                Console.WriteLine("chceš pokračovat? (y/n)");
                
             
             
                
            }
            

        }
        public static int Factorial_Rec(int num1)
        {
            if (num1 == 0 || num1 == 1)
            {
                return 1;
            }
            else { return num1 * Factorial_Rec(num1 - 1); }
        }
        public static int Fibonacci_Rec(int num2)
        {
            if(num2 == 0)
            {
                return 1;
            }
            else if(num2 == 1)
            {
                return 1;
            }
            else { return (Fibonacci_Rec(num2 - 1) + Fibonacci_Rec(num2 - 2)); }
        }
    }
}
