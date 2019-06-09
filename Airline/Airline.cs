using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    partial class Airline
    {
        private readonly List<Flight> flights = new List<Flight>();

        public void AddFlight(DateTime arrivalOrDeparture, bool isAirplaneArrival,
                              int flightNumber, string city, char terminal,
                              int gate, int status, double priceBusiness, double priceEconomy)
        {
            Flight flight = new Flight(arrivalOrDeparture, isAirplaneArrival,
                                       flightNumber, city, terminal, gate, status,
                                       priceBusiness, priceEconomy);
            flights.Add(flight);
        }

        private Flight GetFlightByNumber(int flightNumber)
        {
            return flights.Where(f => f.FlightNumber == flightNumber).FirstOrDefault();
        }
        
        public void DeleteFlight(int flightNumber)
        {
            flights.Remove(GetFlightByNumber(flightNumber));
        }

        public void EditFlight(int flightNumber, string flightNumberEdit, string arrivalOrDeparture, string isAirplaneArrival,
                               string city, string terminal, string gate, string status,
                               string priceBusiness, string priceEconomy)
        {
            GetFlightByNumber(flightNumber).Edit(flightNumberEdit, arrivalOrDeparture, isAirplaneArrival, city,
                                terminal, gate, status, priceBusiness, priceEconomy);
        }
        
        public bool IsFlightConsist(int flightNumber)
        {
            return flights.Contains(GetFlightByNumber(flightNumber));
        }

        public void DisplayFlights()
        {
            foreach (var item in flights)
            {
                item.DisplayFlight();
            }
        }

        public void DisplayOnlyCityAndNumber()
        {
            foreach (var item in flights)
            {
                item.DisplayOnlyCityAndNumber();
            }
        }

        public void DisplayStatus()
        {
            foreach (var item in (Status[])Enum.GetValues(typeof(Status)))
            {
                Console.WriteLine($"{(int)item}. {item}");
            }
        }

        public void DisplayPassengers(int flightNumber)
        {
            GetFlightByNumber(flightNumber).DisplayPassengers();
        }

        public void DisplayPassengersWithParameters(string firstname, string lastname, string flightnumber, string passport)
        {
            if (!(int.TryParse(flightnumber, out int number)))
            {
                if(!(number == 1 || number == 2))
                    number = 0;
            }
            
            if (number != 0)
            {
                var selectedFlight = GetFlightByNumber(number);

                if (selectedFlight != null)
                {
                    selectedFlight.DisplayPassengersWithParameters(firstname, lastname, passport);
                }
            }
            else
            {
                foreach (var item in flights)
                {
                    item.DisplayPassengersWithParameters(firstname, lastname, passport);
                }
            }
        }

        public void DeletePassenger(string passport)
        {
            foreach (var item in flights)
            {
                item.DeleteByPassport(passport);
            }
        }

        public void EditPassenger(string passportForFind, string firstname, string lastname,
                                  string nationality, string passport, string birthday,
                                  int sex, int intClass)
        {
            foreach (var item in flights)
            {
                if(item.Contains(passportForFind))
                    item.EditPassenger(passportForFind,
                                       firstname,
                                       lastname,
                                       nationality,
                                       passport,
                                       birthday,
                                       sex,
                                       intClass);
            }
        }

        public bool ConsistPassenger(string passport)
        {
            bool result = false;

            foreach (var item in flights)
            {
                if (item.Contains(passport))
                    result = true;
            }

            return result;
        }

        public void DisplayFlightsPriceLowerThan(double price)
        {
            foreach (var item in flights)
            {
                if (item.IsPriceLowerThan(price))
                    item.DisplayFlight();
            }
        }

        public void AddPassenger(int flightNumber, string firstname, string lastneme,
                                 string nationality, string passport, DateTime birthday,
                                 int sex, int ticket)
        {
            GetFlightByNumber(flightNumber).Add(firstname, lastneme, nationality, passport, birthday, sex, ticket);
        }
    }
}

