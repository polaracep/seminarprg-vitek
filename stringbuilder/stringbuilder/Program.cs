using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace stringbuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("gg");
            sb.Append(" wp");
            Console.WriteLine(sb.ToString());
            
            sb.Replace(" ", " 777 ");
            Console.WriteLine(sb.ToString());
            Console.ReadLine();
        }
    }
}
