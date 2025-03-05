using System;
using System.Linq;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cycle = 0;
            int[] array1 = { 1, 2, 3, 7 };
            Random rnd = new Random();
            int rng = rnd.Next(0, 10);
            /*while (cycle < 10)
            {

                rng = rnd.Next(0, 5);
                Console.WriteLine(array1[rng]);
                
                cycle++;
            }*/
            
            Console.WriteLine("\n");


            //TODO 1: Vytvoř integerové pole a naplň ho pěti libovolnými čísly.
            int[] array2 = { 7, 69, 420, 42, 13 };

            //TODO 2: Vypiš do konzole všechny prvky pole, zkus jak klasický for, kde i využiješ jako index v poli, tak foreach.
            for (int i = 0; i < array2.Length; i++)
            {
                Console.WriteLine(array2[i]);
            }
            Console.WriteLine("\n");
            Console.WriteLine("vypsani foreach");
            foreach (int num in array2) //pro kazdy neco v necem
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("\n");
            //TODO 3: Spočti sumu všech prvků v poli a vypiš ji uživateli.
            int sum = 0;
            for (int i = 0; i < array2.Length; i++)
            {
                sum += array2[i];
                
            }
            Console.WriteLine("součet arraye se rovná :" + sum);
            Console.WriteLine("\n");



            //TODO 4: Spočti průměr prvků v poli a vypiš ho do konzole.
            double average;
            average = (double)sum / (array1.Length + 1);
            Console.WriteLine("průměr arraye se rovná :"+ average);
            Console.WriteLine("\n");


            //TODO 5: Najdi maximum v poli a vypiš ho do konzole.
            int max;
            int max2 = array2[0];
            max = array2.Max(x => x);
           
            for (int i = 1;i < array2.Length; i++)
            {
                if (array2[i] > max2);
                {
                max = array2[i];
                
                }
            }
            Console.WriteLine("max arraye se rovná :" + max);
            Console.WriteLine("max arraye se rovná :" + max2);
            Console.WriteLine("\n");
            //TODO 6: Najdi minimum v poli a vypiš ho do konzole.
            int min;
            int min2 = array2[0];
            min = array2.Min(x => x);
            for (int i = 1; i < array2.Length; i++)
            {
                if (array2[i] < min2);
                {
                    max = array2[i];

                }
            }
            Console.WriteLine("min arraye se rovná :" + min);
            Console.WriteLine("min arraye se rovná :" + min2);
            
            Console.WriteLine("\n");

            //TODO 7: Vyhledej v poli číslo, které zadá uživatel, a vypiš index nalezeného prvku do konzole.

            int index;
            bool foundNumber = true;
            Console.Write("zadej číslo: ");
            int userInput = Convert.ToInt32((string) Console.ReadLine());
            for (int i = 0; i < userInput; i++)
            {
                if (userInput == array2[i])
                {
                    Console.WriteLine("Cislo nalezeno na indexu " + i);
                    foundNumber = true;
                    break;
                    
                }
            }
            if (!foundNumber)
            {
                Console.WriteLine("num not found");
            }

            //TODO 8: Přepiš pole na úplně nové tak, že bude obsahovat 100 náhodně vygenerovaných čísel od 0 do 9.
            int[] array3 = new int[100];
            for (int i = 0;i < array3.Length; i++)
            {
                array3[i] = rnd.Next(0, 10);
                Console.Write(array3[i] + ", ");
            }
            Console.WriteLine("\n");
            //TODO 9: Spočítej kolikrát se každé číslo v poli vyskytuje a spočítané četnosti vypiš do konzole.
            int[] counts = new int[10];
            foreach(int num in array3)
            {
                counts[num]++;
            }
            for (int i = 0;i < counts.Length; i++)
            {
                Console.WriteLine("cetnosti cislce" + i + ": " + counts[i]);
            }

            //TODO 10: Vytvoř druhé pole, do kterého zkopíruješ prvky z prvního pole v opačném pořadí.
            int[] array4 = new int[100];
            for (int i = 0;i < array3.Length; i++) 
            {
                array4[i] = array3[i];


            }
            foreach (int num in array4) //pro kazdy neco v necem
            {
                Console.WriteLine(num + ", ");
            }
            Array.Copy(array3.Reverse().ToArray(), array4, array3.Length);
            //Zkus is dál hrát s polem dle své libosti. Můžeš třeba prohodit dva prvky, ukládat do pole prvky nějaké posloupnosti (a pak si je vyhledávat) nebo cokoliv dalšího tě napadne

            Console.ReadKey();
        }
    }
}