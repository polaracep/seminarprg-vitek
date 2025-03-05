using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rekurze
{
    internal class Program
    {


        /*static void WriteNumber(int number)
        {
            Console.WriteLine(number);
            if (number < Math.Pow(7,7))
            {
                int number2;
                number2 = number - 1;
                  WriteNumber(number + number2);
            }
                
        }*/
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int factorial = Factorial(n);
            //int fibonacci = Fibonacci(n);
            Console.WriteLine(n);
            Console.ReadKey();
        }static int Factorial(int n)
        {

            int i; if (n > 1) {i = n *= (1 - n); }
            return i;
        }
        /*static int Fibonacci(int n)
        {
            return;
        }*/
        
        /*public class MyClass
        {
            // Non-static field.
            public int i;
            // Non-static method.
            public void Method() { }
            // Non-static property.
            public int Prop
            {
                get
                {
                    return 1;
                }
            }
            static void Main(string[] args)
            {
                
                var mc = new MyClass();
                mc.i = 10;
                mc.Method();
                int p = mc.Prop;

            }


        }*/

    }
}
