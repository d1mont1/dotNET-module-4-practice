// Задача 4: Система "Автобаза"

using System;
using System.Collections.Generic;
using System.Linq;

namespace dotNET_module_4_practice
{
    public class Car
    {
        public string Model { get; set; }
        public string Driver { get; set; }
        public string Status { get; set; }

        public Car(string model, string driver)
        {
            Model = model;
            Driver = driver;
            Status = "Свободен";
        }
    }

    public class Dispatcher
    {
        private List<Car> cars = new List<Car>();

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public void AssignDriver(string driverName, string carModel)
        {
            var car = cars.FirstOrDefault(c => c.Model == carModel && c.Status == "Свободен");
            if (car != null)
            {
                car.Driver = driverName;
                car.Status = "Занят";
            }
            else
            {
                Console.WriteLine("Нет свободных машин для водителя.");
            }
        }

        public void ReportRepair(string carModel)
        {
            var car = cars.FirstOrDefault(c => c.Model == carModel);
            if (car != null)
            {
                car.Status = "Ремонт";
            }
        }

        public void SuspendDriver(string driverName)
        {
            var driverCars = cars.Where(c => c.Driver == driverName).ToList();
            foreach (var car in driverCars)
            {
                car.Driver = "";
                car.Status = "Свободен";
            }
        }
    }
}