using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    partial class Airline
    {
        partial class Flight
        {
            private List<Passenger> passengers = new List<Passenger>();

            public DateTime ArrivalOrDeparture { get; private set; }
            public bool IsAirplaneArrival { get; private set; }
            public int FlightNumber { get; private set; }
            public string City { get; private set; }
            public char Terminal { get; private set; }
            public int Gate { get; private set; }
            public Status Status { get; private set; }
            public double PriceBusiness { get; private set; }
            public double PriceEconomy { get; private set; }

            public Flight(DateTime arrivalOrDeparture, bool isAirplaneArrival, int flightNumber,
                          string city, char terminal, int gate, int status, double priceBusiness,
                          double priceEconomy)
            {
                this.ArrivalOrDeparture = arrivalOrDeparture;
                this.IsAirplaneArrival = isAirplaneArrival;
                this.FlightNumber = flightNumber;
                this.City = city;
                this.Terminal = terminal;
                this.Gate = gate;
                this.Status = (Status)status;
                this.PriceBusiness = priceBusiness;
                this.PriceEconomy = priceEconomy;
            }

            public void Add(string firstname, string lastneme, string nationality,
                            string passport, DateTime birthday, int sex, int ticket)
            {
                Passenger passenger = new Passenger(firstname, lastneme, nationality,
                                    passport, birthday, sex, ticket);

                passengers.Add(passenger);
            }

            public bool Contains(string passport)
            {
                var passenger = (from p in passengers
                                 where p.Passport.Equals(passport)
                                 select p).SingleOrDefault();

                return passengers.Contains(passenger);
            }

            public void DeleteByPassport(string passport)
            {
                var passenger = (from p in passengers
                                 where p.Passport.Equals(passport)
                                 select p).SingleOrDefault();

                passengers.Remove(passenger);
            }

            public void EditPassenger(string passportForFind, string firstname, string lastname, string nationality,
                                      string passport, string birthday, int sex, int intClass)
            {
                var passenger = (from p in passengers
                                 where p.Passport.Equals(passportForFind)
                                 select p).SingleOrDefault();

                passenger.Edit(firstname, lastname, nationality, passport, birthday, sex, intClass);
            }

            public void DisplayFlight()
            {
                Console.WriteLine($"Flight number:\t{FlightNumber}");
                Console.WriteLine($"City:\t\t{City}");
                Console.WriteLine((IsAirplaneArrival ? "Arrival:\t" : "Departure:\t") + ArrivalOrDeparture);
                Console.WriteLine($"Terminal:\t{Terminal}");
                Console.WriteLine($"Gate:\t\t{Gate}");
                Console.WriteLine($"Status:\t\t{Status}");
                Console.WriteLine($"Price for economy: {PriceEconomy}");
                Console.WriteLine($"Price for business: {PriceBusiness}");
                Console.WriteLine();
            }

            public void DisplayOnlyCityAndNumber()
            {
                Console.WriteLine($"{FlightNumber}. {City}");
            }

            public void DisplayPassengers()
            {
                foreach (var item in passengers)
                {
                    item.Display();
                }
            }

            public void DisplayPassengersWithParameters(string firstname, string lastname, string passport)
            {
                var selectedPassengers = (from f in passengers
                                          where f.Firstname.Contains(firstname) &&
                                          f.Lastname.Contains(lastname) &&
                                          f.Passport.Contains(passport)
                                          select f).ToArray();

                List<Passenger> result = new List<Passenger>();
                result.AddRange(selectedPassengers);

                if (result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        item.Display();
                    }
                }
            }
            
            public bool IsPriceLowerThan(double price)
            {
                return PriceEconomy <= price ? true : false;
            }

            public void Edit(string flightNumber, string arrivalOrDeparture, string isArrival,
                               string city, string terminal, string gate, string status,
                               string priceBusiness, string priceEconomy)
            {
                if (!(string.IsNullOrEmpty(flightNumber)))
                {
                    if (int.TryParse(flightNumber, out int intFlightNumber))
                        this.FlightNumber = intFlightNumber;
                }

                if (!(string.IsNullOrEmpty(arrivalOrDeparture)))
                {
                    if (DateTime.TryParse(arrivalOrDeparture, out DateTime dateTime))
                        this.ArrivalOrDeparture = dateTime;
                }

                if (!(string.IsNullOrEmpty(isArrival)))
                {
                    if (isArrival.Equals("1") || isArrival.Equals("2"))
                        this.IsAirplaneArrival = isArrival.Equals("1") ? true : false;
                }

                if (!(string.IsNullOrEmpty(city)))
                {
                    this.City = city;
                }

                if (!(string.IsNullOrEmpty(terminal)))
                {
                    if (char.TryParse(terminal, out char charTerminal))
                        this.Terminal = charTerminal;
                }

                if (!(string.IsNullOrEmpty(gate)))
                {
                    if (int.TryParse(gate, out int intGate))
                        this.Gate = intGate;
                }

                if (!(string.IsNullOrEmpty(status)))
                {
                    if (int.TryParse(gate, out int intStatus))
                    {
                        if (intStatus >= 1 && intStatus <= 9)
                            this.Status = (Status)intStatus;
                    }
                }

                if (!(string.IsNullOrEmpty(priceBusiness)))
                {
                    if (double.TryParse(priceBusiness, out double doublePriceBusiness))
                        this.PriceBusiness = doublePriceBusiness;
                }

                if (!(string.IsNullOrEmpty(priceEconomy)))
                {
                    if (double.TryParse(priceEconomy, out double doublePriceEconomy))
                        this.PriceEconomy = doublePriceEconomy;
                }
            }


        }
    }
}
