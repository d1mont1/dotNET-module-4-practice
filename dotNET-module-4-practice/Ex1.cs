// Задача 1: Структура "student" и упорядочивание студентов

using System;
using System.Linq;

namespace dotNET_module_4_practice
{
    public struct Student
    {
        public string FullName;
        public string GroupNumber;
        public int[] Grades;

        public double GetAverageGrade()
        {
            return Grades.Average();
        }
    }
}
