// Задача 2: Классы для животных

using System;
using System.Collections.Generic;
using System.Linq;

namespace dotNET_module_4_practice
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public abstract string Type { get; }
        public abstract double CalculateFoodQuantity();
    }

    public class Carnivore : Animal
    {
        public override string Type => "Хищник";

        public override double CalculateFoodQuantity()
        {
            // Расчет количества пищи для хищника
            return 0.2; // Пример
        }
    }

    public class Omnivore : Animal
    {
        public override string Type => "Всеядное животное";

        public override double CalculateFoodQuantity()
        {
            // Расчет количества пищи для всеядного
            return 0.3; // Пример
        }
    }

    public class Herbivore : Animal
    {
        public override string Type => "Травоядное животное";

        public override double CalculateFoodQuantity()
        {
            // Расчет количества пищи для травоядного
            return 0.1; // Пример
        }
    }
}

