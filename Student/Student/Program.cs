using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student Student1 = new Student(9, "Greg");
            Student Student2 = new Student(8, "Kevin");
            string subjectToAdd;
            int gradeToAdd;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("napiš předmět který bys chtěl přidělit studentovi");
                subjectToAdd = Console.ReadLine();
                Student1.AddSubject(subjectToAdd);
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Přidej známku: ");
                    gradeToAdd = Convert.ToInt32(Console.ReadLine());
                    Student1.AddGrade(gradeToAdd, subjectToAdd);
                }
            }
            Console.WriteLine("u kter0ho předmětu chceš vypočítat průměr:");
            subjectToAdd = Console.ReadLine();
            Student1.CalculateSubjectGrade(subjectToAdd);
            Console.ReadKey();
        }

        /* Vytvoř třídu Student, kterou budeme reprezentovat studenta
 *    Přidej třídě Student proměnné - year pro aktuální ročník studenta
 *                                  - id pro identifikační číslo studenta
 *                                  - subjects pro seznam předmětů studenta (bude to slovník (https://www.geeksforgeeks.org/c-sharp-dictionary-with-examples/),
 *                                    který bude mít jako klíč string a jako hodnotu List (https://www.geeksforgeeks.org/c-sharp-list-class/) známek)
 *                                  - name pro jméno studenta
 *    Přidej třídě Student čtyři funkce - AddSubject, která jako vstupní parametr přijme název předmětu a přidá nový klíč do subjects
 *                                      - AddGrade, která jako vstupní parametr přijme název předmětu a známku a přidá podle názvu předmětu další známku danému předmětu
 *                                      - CalculateSubjectGrade, která jako stupní parametr přijme název předmětu a spočítá průměrnou známku na vysvědčení z daného předmětu
 *                                      - CaculateTotalGrade, která spočítá studijní průměr (průměr všech známek)
 *    Přidej třídě Student konstruktor, který bude přijímat dva parametry - jméno a ročník studenta
 *                                                                        - Při jeho zavolání nastav jméno a ročník podle vstupních parametrů, id vygeneruj podobně jako accountNumber
 *                                                                          ve tříde BankAccount, a subjects nastav na nový prázdný List
 * 
 * 3) BONUS - Až vytvoříš Student, přidej možnost mít u známek váhy. Způsob nechám na tobě, možností je víc. Můžeš celou třídu překopat na známky pouze s váhou, a nebo můžeš zachovat
 *            možnost přidávat známky bez váhy s tím, že ty budou mít nějakou výchozí váhu automaticky, a přidáš varianty funkcí na přidávání známek s váhou
         */
    }
}
