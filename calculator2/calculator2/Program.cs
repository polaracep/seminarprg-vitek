using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        double num1 = 0;
        double num2 = 0;
        double num3 = 0;
        static void Main(string[] args)
        {
            /*
              * ZADANI
              * Vytvor program ktery bude fungovat jako kalkulacka. Kroky programu budou nasledujici:
              * 1) Nacte vstup pro prvni cislo od uzivatele (vyuzijte metodu Console.ReadLine() - https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=netframework-4.8.
              * 2) Zkonvertuje vstup od uzivatele ze stringu do integeru - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number.
              * 3) Nacte vstup pro druhe cislo od uzivatele a zkonvertuje ho do integeru. (zopakovani kroku 1 a 2 pro druhe cislo)
              * 4) Nacte vstup pro ciselnou operaci. Rozmysli si, jak operace nazves. Muze to byt "soucet", "rozdil" atd. nebo napr "+", "-", nebo jakkoliv jinak.
              * 5) Nadefinuj integerovou promennou result a prirad ji prozatimne hodnotu 0.
              * 6) Vytvor podminky (if statement), podle kterych urcis, co se bude s cisly dit podle zadane operace
              *    a proved danou operaci - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements.
              * 7) Vypis promennou result do konzole
              * 
              * Rozsireni programu pro rychliky / na doma (na poradi nezalezi):
              * 1) Vypis do konzole pred nactenim kazdeho uzivatelova vstupu co po nem chces (aby vedel, co ma zadat)
              * 2) a) Kontroluj, ze uzivatel do vstupu zadal, co mel (cisla, popr. ciselnou operaci). Pokud zadal neco jineho, napis mu, co ma priste zadat a program ukoncete.
              * 2) b) To same, co a) ale misto ukonceni programu opakovane cti vstup, dokud uzivatel nezada to, co ma
              *       - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement
              * 3) Umozni uzivateli zadavat i desetinna cisla, tedy prekopej kalkulacku tak, aby umela pracovat s floaty
              */
            double num1 = 0;
            double num2 = 0;
            double num3 = 0; //nasledné proměné
            string hexValue;
            double methodCalled = 0; //proměná které 
            double result = 0;
            bool wannaContinue = true;
            bool userAnswerCheck1 = true;
            bool userAnswerCheck2 = true;
            bool userAnswerCheck3 = true;
            bool userAnswerCheck4 = true; //zkouska zda-li uzivatel zadal spravny imput
            string userAnswer2;
            string userAnswer3 = "o";
            Console.WriteLine("swiching on... press enter to continue");
            Console.ReadKey();
            while (wannaContinue = true)
            {


                if (userAnswer3 == "o")
                {


                    Console.Write("\nzadej první číslo: ");
                    num1 = Convert.ToDouble(Console.ReadLine());


                    while (userAnswerCheck2 = true)
                    {
                        Console.Write("chceš přidat další číslo? (y/n)");
                        string userDecision1 = Console.ReadLine();
                        if (userDecision1 == "y")
                        {
                            userAnswerCheck2 = false;
                            Console.Write("napiš další číslo: ");
                            num2 = Convert.ToDouble(Console.ReadLine());

                            while (userAnswerCheck3 = true)
                            {
                                Console.Write("chceš přidat ještě jedno číslo? (y/n)");
                                string userDecision2 = Console.ReadLine();
                                if (userDecision2 == "y")
                                {
                                    userAnswerCheck3 = false;
                                    Console.Write("Napiš další číslo: ");
                                    num3 = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("vyber jednu z metod:\n\n1) součet všech čísešl\n2) první dvě čísla násobená třetím \n3) první dvě čísla dělená třetím \n4) zkusit zdali trojce čísel odpovídá stranám prvoúhlého troúhelníku\n5) první číslo mocněné druhým \n6) vzdálenost bodu od počátku soustavy souřadnic v trojrozměrném prostou\n\n");
                                    methodCalled = Convert.ToInt32(Console.ReadLine());

                                    switch (methodCalled)
                                    {
                                        case 1:
                                            result = num1 + num2 + num3;
                                            break;
                                        case 2:
                                            result = (num1 + num2) * num3;
                                            break;
                                        case 3:
                                            result = (num1 + num2) / 3;
                                            break;
                                        case 4:
                                            if (Math.Pow(num1, 2) + Math.Pow(num2, 2) == Math.Pow(num3, 2) || (Math.Pow(num1, 2) + Math.Pow(num3, 2) == Math.Pow(num2, 2) || (Math.Pow(num2, 2) + Math.Pow(num3, 2) == Math.Pow(num1, 2))))
                                            {
                                                Console.WriteLine("troúhelník je pravoúhlý");
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine("troúhelník není pravoúhlý");
                                                Console.ReadKey();
                                            }
                                            break;
                                        case 5:
                                            result = Math.Pow(num1, num2);
                                            break;
                                        case 6:
                                            result = Math.Sqrt(Math.Pow(num1, 2) + Math.Pow(num2, 2) + Math.Pow(num3, 2));
                                            break;

                                    }
                                    Console.WriteLine(result);
                                    Console.ReadKey();


                                }
                                else if (userDecision2 == "n")
                                {
                                    userAnswerCheck3 = false;
                                    Console.Write("vyber jednu z metod:\n\n1) sčítání\n2) odčítaní\n3) násobení\n4) dělení\n5) první číslo mocněné druhým \n6) vzdálenost bodu od počátku soustavy souřadnic v dvojrozměrném prostoru \n7) logaritmus čísla 1 o základu čísla 2\n8) sinus\n");
                                    methodCalled = Convert.ToInt32(Console.ReadLine());
                                    switch (methodCalled)
                                    {
                                        case 1:
                                            result = num1 + num2;
                                            userAnswerCheck3 = false;
                                            break;
                                        case 2:
                                            result = num1 - num2;
                                            userAnswerCheck3 = false;
                                            break;
                                        case 3:
                                            result = num1 * num2;
                                            userAnswerCheck3 = false;
                                            break;
                                        case 4:
                                            result = num1 / num2;
                                            userAnswerCheck3 = false;
                                            break;
                                        case 5:
                                            result = Math.Pow(num1, num2);
                                            userAnswerCheck3 = false;
                                            break;
                                        case 6:
                                            result = Math.Sqrt(num1 + num2);
                                            userAnswerCheck3 = false;
                                            break;
                                        case 7:
                                            result = Math.Log(num1, num2);
                                            userAnswerCheck3 = false;
                                            break;
                                        case 8:
                                            result = Math.Sin(num1);
                                            userAnswerCheck3 = false;
                                            break;



                                    }

                                }
                                else
                                {
                                    userAnswerCheck3 = true;
                                    Console.WriteLine("wrong user imput");
                                    Console.ReadKey();

                                }
                            }
                            Console.WriteLine(result);
                            Console.ReadKey();

                        }
                        else if (userDecision1 == "n")
                        {
                            userAnswerCheck2 = false;
                            Console.Write("napis jedno z cisel 1-5 pro vyber jedne metody\n\n1) 2 na ntou\n2) odmocnění zadaného čísla\n3) sin\n4) cos\n5) převod na hexadecimalni soustavu \n\n");
                            methodCalled = Convert.ToInt32(Console.ReadLine());
                            switch (methodCalled)
                            {
                                case 1:
                                    result = Math.Pow(2, num1);
                                    userAnswerCheck3 = false;
                                    break;
                                case 2:
                                    result = Math.Sqrt(num1);
                                    userAnswerCheck3 = false;
                                    break;
                                case 3:
                                    result = Math.Sin(num1);
                                    userAnswerCheck3 = false;
                                    break;
                                case 4:
                                    result = Math.Cos(num1);
                                    userAnswerCheck3 = false;
                                    break;
                                case 5:
                                    userAnswerCheck3 = false;
                                    Console.WriteLine("výsledek je " + result);
                                    hexValue = Convert.ToInt64(result).ToString("X");
                                    Console.WriteLine("výsledek v hexadecimální soustavě je " + hexValue);
                                    break;
                            }
                            Console.WriteLine(result);
                            Console.ReadKey();
                        }
                        else
                        {
                            userAnswerCheck2 = true;
                            Console.WriteLine("wrong user imput");
                            Console.ReadKey();

                        }
                    }



                    Console.WriteLine(result);
                    Console.ReadKey();

                }
                else if (userAnswer3 == "s")
                {

                    double ans = result;
                    Console.Write("napiš číslo: ");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("napis jedno z cisel 1-9 pro vyber jedne metody\n\n1) přičítání\n2) odčítání\n3) násobení\n4) dělení\n5) umocnění na druhou\n6) umocnění zadaným číslem\n7) odmocnění\n8) převod na hexadecimalni soustavu\n\n");
                    methodCalled = Convert.ToInt32(Console.ReadLine());
                    switch (methodCalled)
                    {
                        case 1:
                            result = ans + num1;
                            userAnswerCheck3 = false;
                            break;
                        case 2:
                            result = ans - num1;
                            userAnswerCheck3 = false;
                            break;
                        case 3:
                            result = ans * num1;
                            userAnswerCheck3 = false;
                            break;
                        case 4:
                            result = ans / num1;
                            userAnswerCheck3 = false;
                            break;
                        case 5:
                            result = Math.Pow(ans, 2);
                            userAnswerCheck3 = false;
                            break;
                        case 6:
                            result = Math.Pow(ans, num1);
                            userAnswerCheck3 = false;
                            break;
                        case 7:
                            result = Math.Sqrt(ans);
                            userAnswerCheck3 = false;
                            break;
                        case 8:
                            userAnswerCheck3 = false;
                            Console.WriteLine("výsledek je " + result);
                            hexValue = Convert.ToInt64(result).ToString("X");
                            Console.WriteLine("prozatimni výsledek v hexadecimální soustavě je " + hexValue);
                            break;



                    }
                    Console.WriteLine(result);
                    Console.ReadKey();

                }
                else
                {

                    Console.WriteLine("wrong user imput\n");
                    Console.ReadKey();
                    wannaContinue = false;

                }



                while (userAnswerCheck4 = true)
                {
                    Console.Write("chces pokracovat (y/n)");
                    string useranswer2 = Console.ReadLine();
                    if (useranswer2 == "y")
                    {
                        userAnswerCheck4 = false;
                        Console.Write("chces pokracovat s výsledkem nebo od začátku (s/o)");
                        userAnswer3 = Console.ReadLine();
                        wannaContinue = true;

                    }
                    else if (useranswer2 == "n")
                    {
                        userAnswerCheck4 = false;
                        wannaContinue = false;

                    }
                    else
                    {
                        userAnswerCheck4 = true;
                        Console.WriteLine("wrong user imput\n");
                        Console.ReadKey();
                        wannaContinue = false;

                    }
                }



            }




        }







    }
}
