
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace _2D_Array_Playground
{
    internal class Program
    {

        static void SetArrayToDefault(int[,] array2D)
        {
            for (int i = 1; i < array2D.GetLength(0)+1; i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    array2D[i-1, j] = i; 
                }
                
            }
            
            
        }
        static void Print2DArray(int[,] arrayToPrint)
        {
            for (int i = 0; i < arrayToPrint.GetLength(0); i++)
            {
                for (int j = 0; j < arrayToPrint.GetLength(1); j++)
                {
                    Console.Write(arrayToPrint[i, j] + ", ");
                }

                Console.Write("\n");
            }
        }

        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové 2D pole velikosti 5 x 5, naplň ho čísly od 1 do 25 a vypiš ho do konzole (5 řádků po 5 číslech).
            int[,] array = new int[5, 5];

            SetArrayToDefault(array);
            Print2DArray(array);
            Console.WriteLine();



            //TODO 2: Vypiš do konzole n-tý řádek pole, kde n určuje proměnná nRow.
            int nRow = 0;
            Console.WriteLine(nRow + ". řádek");
            for(int j = 0;j < array.GetLength(1); j++)
            {
                Console.Write(array[nRow, j] + ", ");
            }
            Console.WriteLine();
            Console.WriteLine();
            //TODO 3: Vypiš do konzole n-tý sloupec pole, kde n určuje proměnná nColumn.
            int nColumn = 0;
            Console.WriteLine(nRow + ". sloupec");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write(array[nColumn, i] + "\n ");
            }
            Console.WriteLine();
            Console.WriteLine();
            //TODO 4: Prohoď prvek na souřadnicích [xFirst, yFirst] s prvkem na souřadnicích [xSecond, ySecond] a vypiš celé pole do konzole po prohození.
            //Nápověda: Budeš potřebovat proměnnou navíc, do které si uložíš první z prvků před tím, než ho přepíšeš druhým, abys hodnotou prvního prvku potom mohl přepsat druhý
            int xFirst, yFirst, xSecond, ySecond, temp;
            Console.WriteLine("Které na jakych souradkach číslo chces prohodit?");
            xFirst = 2;//Convert.ToInt32(Console.ReadLine());
            yFirst = 2;//Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("za ktere?");
            xSecond = 3;// Convert.ToInt32(Console.ReadLine());
            ySecond = 3;//Convert.ToInt32(Console.ReadLine());
            temp = array[xFirst, yFirst];
            array[xFirst, yFirst] = array[xSecond, ySecond];
            array[xSecond, ySecond] = temp;
            Print2DArray(array);
            SetArrayToDefault(array);

            //TODO 5: Prohoď n-tý řádek v poli s m-tým řádkem (n je dáno proměnnou nRowSwap, m mRowSwap) a vypiš celé pole do konzole po prohození.
            Console.WriteLine("který řádek chces prohodit?");
            int nRowSwap = 2;//Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("za ktery?");
            int mRowSwap = 3;// Convert.ToInt32(Console.ReadLine());
            for (int j = 0;j < array.GetLength(1);j++)
            {
                temp = array[nRowSwap, j];
                array[nRowSwap, j] = array[mRowSwap, j];
                array[mRowSwap, j] = temp;
            }
            Print2DArray(array);
            SetArrayToDefault(array);
            //TODO 6: Prohoď n-tý sloupec v poli s m-tým sloupcem (n je dáno proměnnou nColSwap, m mColSwap) a vypiš celé pole do konzole po prohození.
            int nColSwap;
            int mColSwap;
            Console.WriteLine("který sloupec chces prohodit?");
            nColSwap = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("za sloupec?");
            mColSwap = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < array.GetLength(0); i++)
            {
                temp = array[i, nColSwap];
                array[i, nColSwap] = array[i, mColSwap];
                array[i, mColSwap] = temp;
            }
            Print2DArray(array);
            SetArrayToDefault(array);

            //TODO 7: Otoč pořadí prvků na hlavní diagonále (z levého horního rohu do pravého dolního rohu) a vypiš celé pole do konzole po otočení.
            for (int i = 0;i < array.GetLength(0) %2; i++)
            {
                temp = array[i, i];
                array[i, i] = array[array.GetLength(0) - 1 - i, array.GetLength(1) - 1 - i];
                array[array.GetLength(0) - 1 - i, array.GetLength(1) - 1 - i] = temp;
            }
            Print2DArray(array);
            SetArrayToDefault(array);

            //TODO 8: Otoč pořadí prvků na vedlejší diagonále (z pravého horního rohu do levého dolního rohu) a vypiš celé pole do konzole po otočení.
            for (int i = 4; i > array.GetLength(0) % 2; i--)
            {
                temp = array[i, i];
                array[i, i] = array[i + 1 - array.GetLength(0) , array.GetLength(1) + 1 - i];
                array[i + 1 - array.GetLength(0), array.GetLength(1) + 1 - i] = temp;
            }
            Print2DArray(array);
            SetArrayToDefault(array);

            Console.ReadKey();
        }
    }
}
