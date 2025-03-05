using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("type a number: ");
            double a = Math.Sqrt(Convert.ToInt32(Console.ReadLine()));
            Console.Write("type a number: ");
            double b = Math.Sqrt(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine(a * b);
            double c = Convert.ToDouble(Console.ReadLine());

            if (c == 21) 
            {
                Console.WriteLine("vamoos");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("GG");
                Console.ReadLine();
            }
        }
    }
}
