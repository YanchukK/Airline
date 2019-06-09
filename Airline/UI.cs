using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    class UI
    {
        readonly Airline airline;

        public UI(Airline airline)
        {
            this.airline = airline;
        }

        private readonly string flightNumber = "Flight number: ",
            terminal = "Terminal (one letter): ",
            gate = "Gate: ",
            city = "City: ",
            chooseStatus = "Choose the status",
            priceBusinessClass = "Price for business class: ",
            priceEconomyClass = "Price for economy class: ",
            arrival = "Arrival: ",
            departure = "Departure: ",
            arrivalsOrDepartures = "Does the plane arrivals or departures?\n1. Arrival\n2. Departure",
            enterParameters = "Enter the required parameters",
            noSuchNumber = "There is no such number",
            strFirstname = "Firstname: ",
            strLastname = "Lastname: ",
            strNationality = "Nationality: ",
            strPassport = "Passport: ",
            strBirthday = "Birthday: ",
            chooseSex = "Choose sex\n1. Man\n2. Women\n",
            chooseClass = "Choose class\n1. Business\n2. Economy\n",
            inputDollars = "Input price in dollars (Please, use ','. For example 8,5)";

        private readonly string[] menu =
        {
            "Menu:",
            "1. Create flight",
            "2. Delete flight",
            "3. Edit flight",
            "4. View all flights",
            "5. Add passenger",
            "6. Delet passenger",
            "7. Edit passenger",
            "8. View all flight’s passengers",
            "9. Search passengers",
            "10. View all flights with the price of economy ticket"
        };
        
        public void DisplayAvailableFeatures()
        {
            while (true)
            {
                Console.WriteLine(string.Join(Environment.NewLine, menu));
                Console.Write("\n>");

                string selection = Console.ReadLine();
                if (int.TryParse(selection, out int number))
                {
                    switch (number)
                    {
                        case 1:
                            CreateFlight();
                            break;

                        case 2:
                            airline.DisplayOnlyCityAndNumber();
                            DeleteFlight();
                            break;

                        case 3:
                            airline.DisplayOnlyCityAndNumber();
                            EditFlight();
                            break;

                        case 4:
                            airline.DisplayFlights();
                            break;

                        case 5:
                            airline.DisplayOnlyCityAndNumber();
                            AddPassenger();
                            break;

                        case 6:
                            Console.Write(strPassport);
                            string passportForDelete = ConvertToString();
                            if (airline.ConsistPassenger(passportForDelete))
                                airline.DeletePassenger(passportForDelete);
                            else
                                Console.WriteLine("Passenger does not exist");
                            break;

                        case 7:
                            EditPassenger();
                            break;

                        case 8:
                            airline.DisplayOnlyCityAndNumber();
                            Console.Write(flightNumber);
                            int flightNum = ConvertToInt();
                            if (airline.IsFlightConsist(flightNum))
                                airline.DisplayPassengers(flightNum);
                            else
                                Console.WriteLine("Flight does not exist");
                            break;
                        case 9:
                            SearchPassengers();
                            break;

                        case 10:
                            Console.WriteLine(inputDollars);
                            double dollars = ConvertToDouble();
                            airline.DisplayFlightsPriceLowerThan(dollars);
                            break;

                        default:
                            Console.WriteLine(noSuchNumber);
                            break;
                    }
                }
                else
                    break;
            }
        }

        private void CreateFlight()
        {
            Console.WriteLine(arrivalsOrDepartures);
            string isArrival = Console.ReadLine();
            bool isAirplaneArrival = false;
            if (isArrival.Equals("1") || isArrival.Equals("2"))
                isAirplaneArrival = isArrival.Equals("1") ? true : false;

            Console.Write(isAirplaneArrival ? arrival : departure);
            DateTime arrivalOrDeparture = ConvertToDate();

            Console.Write(flightNumber);
            int intFlightNumber = ConvertToInt();

            Console.Write(city);
            string cityForCreate = ConvertToString();

            Console.Write(terminal);
            char terminalForCreate = ConvertToChar();

            Console.Write(gate);
            int gateForCreate = ConvertToInt();

            Console.WriteLine(chooseStatus);
            airline.DisplayStatus();
            int status = ConvertToInt();

            Console.Write(priceBusinessClass);
            double priceBusiness = ConvertToDouble();

            Console.Write(priceEconomyClass);
            double priceEconomy = ConvertToDouble();

            airline.AddFlight(arrivalOrDeparture, isAirplaneArrival, intFlightNumber, cityForCreate,
                              terminalForCreate, gateForCreate, status, priceBusiness, priceEconomy);
        }

        private void DeleteFlight()
        {
            Console.Write(flightNumber);
            string strflightNumberForDeleting = Console.ReadLine();
            if (int.TryParse(strflightNumberForDeleting, out int flightNumberForDeleting))
            {
                if (airline.IsFlightConsist(flightNumberForDeleting))
                    airline.DeleteFlight(flightNumberForDeleting);
                else
                    Console.WriteLine(noSuchNumber);
            }
            else
                Console.WriteLine(noSuchNumber);
        }

        private void EditFlight()
        {
            Console.Write(flightNumber);

            string strflightNumberForEdeting = Console.ReadLine();
            if (int.TryParse(strflightNumberForEdeting, out int flightNumberForEdeting))
            {
                if (airline.IsFlightConsist(flightNumberForEdeting))
                {
                    Console.WriteLine(enterParameters);
                    Console.WriteLine(arrivalsOrDepartures);
                    string isArrivalEdit = Console.ReadLine();
                    bool isAirplaneArrivalEdit = false;
                    if (isArrivalEdit.Equals("1") || isArrivalEdit.Equals("2"))
                        isAirplaneArrivalEdit = isArrivalEdit.Equals("1") ? true : false;

                    Console.Write(isAirplaneArrivalEdit ? arrival : departure);
                    string arrivalOrDepartureEdit = Console.ReadLine();

                    Console.Write(flightNumber);
                    string flightNumberEdit = Console.ReadLine();

                    Console.Write(city);
                    string cityEdit = Console.ReadLine();

                    Console.Write(terminal);
                    string terminalEdit = Console.ReadLine();

                    Console.Write(gate);
                    string gateEdit = Console.ReadLine();

                    Console.WriteLine(chooseStatus);
                    airline.DisplayStatus();
                    string statusEdit = Console.ReadLine();

                    Console.Write(priceBusinessClass);
                    string priceBusinessEdit = Console.ReadLine();

                    Console.Write(priceEconomyClass);
                    string priceEconomyEdit = Console.ReadLine();

                    airline.EditFlight(flightNumberForEdeting, flightNumberEdit, arrivalOrDepartureEdit,
                                       isArrivalEdit, cityEdit, terminalEdit, gateEdit,
                                       statusEdit, priceBusinessEdit, priceEconomyEdit);
                }
                else
                    Console.WriteLine(noSuchNumber);
            }
            else
                Console.WriteLine(noSuchNumber);
        }

        private void AddPassenger()
        {
            Console.WriteLine(flightNumber);
            string strFlightNumberForPassenger = Console.ReadLine();
            if (int.TryParse(strFlightNumberForPassenger, out int flightNumberForPassenger))
            {
                if (airline.IsFlightConsist(flightNumberForPassenger))
                {
                    Console.Write(strFirstname);
                    string firstname = ConvertToString();

                    Console.Write(strLastname);
                    string lastname = ConvertToString();

                    Console.Write(strNationality);
                    string nationality = ConvertToString();

                    Console.Write(strPassport);
                    string passport = ConvertToString();

                    Console.Write(strBirthday);
                    DateTime birthday = ConvertToDate();

                    Console.Write(chooseSex);
                    string strSex = Console.ReadLine();
                    int sex = 1;
                    if (strSex.Equals("1") || strSex.Equals("2"))
                        sex = strSex.Equals("1") ? 1 : 2;

                    Console.Write(chooseClass);
                    string strClass = Console.ReadLine();
                    int intClass = 1;
                    if (strClass.Equals("1") || strClass.Equals("2"))
                        intClass = strClass.Equals("1") ? 1 : 2;

                    airline.AddPassenger(flightNumberForPassenger, firstname,
                                         lastname, nationality, passport, birthday, sex, intClass);
                }
                else
                    Console.WriteLine(noSuchNumber);
            }
            else
                Console.WriteLine(noSuchNumber);
        }

        private void EditPassenger()
        {
            Console.Write(strPassport);
            string passportForEditing = ConvertToString();
            if (airline.ConsistPassenger(passportForEditing))
            {
                Console.WriteLine(enterParameters);

                Console.Write(strFirstname);
                string firstname = Console.ReadLine();

                Console.Write(strLastname);
                string lastname = Console.ReadLine();

                Console.Write(strNationality);
                string nationality = Console.ReadLine();

                Console.Write(strPassport);
                string passport = Console.ReadLine();

                Console.Write(strBirthday);
                string birthday = Console.ReadLine();

                Console.Write(chooseSex);
                string strSex = Console.ReadLine();
                int sex = 0;
                if (strSex.Equals("1") || strSex.Equals("2"))
                    sex = strSex.Equals("1") ? 1 : 2;

                Console.Write(chooseClass);
                string strClass = Console.ReadLine();
                int intClass = 0;
                if (strClass.Equals("1") || strClass.Equals("2"))
                    intClass = strClass.Equals("1") ? 1 : 2;

                airline.EditPassenger(passportForEditing, firstname, lastname,
                                   nationality, passport, birthday, sex, intClass);
            }
            else
                Console.WriteLine("Passenger does not exist");
        }

        private void SearchPassengers()
        {
            Console.WriteLine(enterParameters);

            Console.Write(strFirstname);
            string firstnameForFind = Console.ReadLine();

            Console.Write(strLastname);
            string lastnameForFind = Console.ReadLine();

            Console.Write(flightNumber);
            string flightnumberForFind = Console.ReadLine();

            Console.Write(strPassport);
            string passportForFind = Console.ReadLine();

            airline.DisplayPassengersWithParameters(firstnameForFind, lastnameForFind,
                                                    flightnumberForFind, passportForFind);
        }

        private string ConvertToString()
        {
            string value;
            do
            {
                string data = Console.ReadLine();
                if (!string.IsNullOrEmpty(data))
                {
                    value = data;
                    break;
                }
                else
                    Console.Write("Try again: ");
            } while (true);

            return value;
        }


        private int ConvertToInt()
        {
            int value;
            do
            {
                string data = Console.ReadLine();
                if (int.TryParse(data, out value))
                    break;
                else
                    Console.Write("Try again: ");
            } while (true);

            return value;
        }
        private double ConvertToDouble()
        {
            double value;
            do
            {
                string data = Console.ReadLine();
                if (double.TryParse(data, out value))
                    break;
                else
                    Console.Write("Try again: ");
            } while (true);

            return value;
        }
        private char ConvertToChar()
        {
            char value;
            do
            {
                string data = Console.ReadLine();
                if (char.TryParse(data, out value))
                    break;
                else
                    Console.Write("Try again: ");
            } while (true);

            return value;
        }

        private DateTime ConvertToDate()
        {
            DateTime date;
            do
            {
                string dataTime = Console.ReadLine();
                if (DateTime.TryParse(dataTime, out date))
                    break;
                else
                    Console.Write("Try again: ");
            } while (true);

            return date;
        }
    }
}
