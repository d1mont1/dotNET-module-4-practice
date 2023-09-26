using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNET_module_4_practice;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задача 1: Структура "student" и упорядочивание студентов /////////////////////////////////////

            // Заполните массив "students" данными о студентах

            Student[] students = new Student[3];

            students[0] = new Student
            {
                FullName = "Иванов Иван Иванович",
                GroupNumber = "Группа 101",
                Grades = new int[] { 5, 4, 5, 4, 5 }
            };

            students[1] = new Student
            {
                FullName = "Петров Петр Петрович",
                GroupNumber = "Группа 102",
                Grades = new int[] { 4, 3, 4, 3, 4 }
            };

            students[2] = new Student
            {
                FullName = "Сидоров Сидор Сидорович",
                GroupNumber = "Группа 103",
                Grades = new int[] { 5, 5, 5, 5, 5 }
            };

            // Упорядочьте студентов по среднему баллу
            students = students.OrderBy(student => student.GetAverageGrade()).ToArray();

            // Выведите фамилии и номера групп студентов с оценками 4 или 5
            foreach (var student in students)
            {
                if (student.Grades.All(grade => grade >= 4))
                {
                    Console.WriteLine($"Фамилия: {student.FullName}, Группа: {student.GroupNumber}");
                }
            }

            // Задача 2: Классы для животных /////////////////////////////////////

            // Заполните список "animals" объектами разных типов животных

            List<Animal> animals = new List<Animal>();

            animals.Add(new Carnivore { Name = "Лев" });
            animals.Add(new Carnivore { Name = "Тигр" });
            animals.Add(new Omnivore { Name = "Медведь" });
            animals.Add(new Omnivore { Name = "Человек" });
            animals.Add(new Herbivore { Name = "Зебра" });
            animals.Add(new Herbivore { Name = "Коала" });

            // Упорядочьте животных по убыванию количества пищи и по имени
            animals = animals.OrderByDescending(animal => animal.CalculateFoodQuantity())
                            .ThenBy(animal => animal.Name)
                            .ToList();

            // Выведите информацию о животных
            foreach (var animal in animals)
            {
                Console.WriteLine($"Идентификатор: {Guid.NewGuid()}, Имя: {animal.Name}, Тип: {animal.Type}, Количество потребляемой пищи: {animal.CalculateFoodQuantity()} кг.");
            }

            // Выведите первые 5 имен животных
            var firstFiveNames = animals.Take(5).Select(animal => animal.Name);
            Console.WriteLine($"Первые 5 имен: {string.Join(", ", firstFiveNames)}");

            // Выведите последние 3 идентификатора животных
            var lastThreeIds = animals.Skip(Math.Max(0, animals.Count() - 3)).Select(_ => Guid.NewGuid());
            Console.WriteLine($"Последние 3 идентификатора: {string.Join(", ", lastThreeIds)}");

            // Задача 3: Класс "Домашняя библиотека" /////////////////////////////////////

            Library library = new Library();

            // Добавьте книги в библиотеку
            library.AddBook(new Book("Книга 1", "Автор 1", 2020));
            library.AddBook(new Book("Книга 2", "Автор 2", 2019));
            library.AddBook(new Book("Книга 3", "Автор 1", 2021));

            // Поиск книги по автору
            List<Book> booksByAuthor = library.SearchByAuthor("Автор 1");
            foreach (var book in booksByAuthor)
            {
                Console.WriteLine($"Название: {book.Title}, Автор: {book.Author}, Год издания: {book.Year}");
            }

            // Удаление книги по названию
            library.RemoveBook("Книга 2");

            // Сортировка книг по названию
            List<Book> sortedBooks = library.SortByTitle();
            foreach (var book in sortedBooks)
            {
                Console.WriteLine($"Название: {book.Title}, Автор: {book.Author}, Год издания: {book.Year}");
            }

            // Задача 4: Система "Автобаза" /////////////////////////////////////

            Dispatcher dispatcher = new Dispatcher();

            // Добавьте автомобили в автобазу
            dispatcher.AddCar(new Car("Модель 1", ""));
            dispatcher.AddCar(new Car("Модель 2", ""));
            dispatcher.AddCar(new Car("Модель 3", ""));

            // Назначьте водителя автомобилю
            dispatcher.AssignDriver("Водитель 1", "Модель 1");

            // Сделайте заявку на ремонт автомобиля
            dispatcher.ReportRepair("Модель 2");

            // Отстраните водителя от работы
            dispatcher.SuspendDriver("Водитель 1");

            // Задача 5: Система "Железнодорожная касса" /////////////////////////////////////

            TicketSystem ticketSystem = new TicketSystem();

            // Добавьте поезда в систему
            ticketSystem.AddTrain(new Train("123", "Станция1", "Станция2", 50.0));
            ticketSystem.AddTrain(new Train("456", "Станция2", "Станция3", 60.0));
            ticketSystem.AddTrain(new Train("789", "Станция1", "Станция3", 70.0));

            // Поиск доступных поездов
            List<Train> availableTrains = ticketSystem.SearchTrains("Станция1", "Станция3");

            // Бронирование билета
            ticketSystem.BookTicket("Пассажир1", "123", DateTime.Now);

            // Расчет общей стоимости билетов для пассажира
            double totalPrice = ticketSystem.CalculateTotalPrice("Пассажир1");

            // Задача 6: Система "Платежи"

            PaymentSystem paymentSystem = new PaymentSystem();

            // Создайте банковские аккаунты и кредитные карты и добавьте их в систему

            // Выполните платеж между аккаунтами
            paymentSystem.MakePayment("123456", "789012", 100.0);

            // Заблокируйте кредитную карту
            paymentSystem.BlockCreditCard("1234-5678-9012-3456");

        }
    }
}
