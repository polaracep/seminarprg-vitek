using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    internal class Student
    {
        public int year;
        public int ID;
        public Dictionary<string, List<int>> subjects = new Dictionary<string, List<int>>();
        public string name;

        public Student(int year, string name)
        {
            this.year = year;
            this.name = name;
            Random rng = new Random();
            ID = rng.Next(10000, 99999);
            subjects = new Dictionary<string, List<int>>();
        }

        public void AddSubject(string subject)
        {
            subjects.Add(subject, new List<int>());
        }
        public void AddGrade (int grade, string subject)
        {
            if (subjects.ContainsKey(subject))
            {
                subjects[subject].Add(grade);
            }
            
        }
        public void CalculateSubjectGrade(string subject)
        {
            double gradeSum = 0;
            double gradeValueSum = 0;
            if (subjects.ContainsKey(subject))
            {
                
                for (int i = 0; i < subjects[subject].Count; i++)
                {
                    gradeSum = gradeSum + 1;
                    gradeValueSum = gradeValueSum + subjects[subject][i];
                }
            }
            Console.WriteLine(gradeValueSum / gradeSum);
        }
        public void CaculateTotalGrade(int ID)
        {

        }
    }

}
