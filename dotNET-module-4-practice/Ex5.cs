// Задача 5: Система "Железнодорожная касса"

using System;
using System.Collections.Generic;
using System.Linq;

namespace dotNET_module_4_practice
{
    public class Train
    {
        public string TrainNumber { get; set; }
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public double Price { get; set; }

        public Train(string trainNumber, string departureStation, string arrivalStation, double price)
        {
            TrainNumber = trainNumber;
            DepartureStation = departureStation;
            ArrivalStation = arrivalStation;
            Price = price;
        }
    }

    public class Ticket
    {
        public string PassengerName { get; set; }
        public string TrainNumber { get; set; }
        public DateTime DepartureTime { get; set; }

        public Ticket(string passengerName, string trainNumber, DateTime departureTime)
        {
            PassengerName = passengerName;
            TrainNumber = trainNumber;
            DepartureTime = departureTime;
        }
    }

    public class TicketSystem
    {
        private List<Train> trains = new List<Train>();
        private List<Ticket> tickets = new List<Ticket>();

        public void AddTrain(Train train)
        {
            trains.Add(train);
        }

        public List<Train> SearchTrains(string departureStation, string arrivalStation)
        {
            return trains.Where(train =>
                train.DepartureStation == departureStation && train.ArrivalStation == arrivalStation).ToList();
        }

        public void BookTicket(string passengerName, string trainNumber, DateTime departureTime)
        {
            var train = trains.FirstOrDefault(t => t.TrainNumber == trainNumber && t.Price > 0);
            if (train != null)
            {
                tickets.Add(new Ticket(passengerName, trainNumber, departureTime));
            }
        }

        public double CalculateTotalPrice(string passengerName)
        {
            return tickets.Where(ticket => ticket.PassengerName == passengerName)
                          .Sum(ticket => trains.First(t => t.TrainNumber == ticket.TrainNumber).Price);
        }
    }
}