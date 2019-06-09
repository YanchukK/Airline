using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    class Program
    {
        static void Main(string[] args)
        {
            Airline airline = new Airline();

            airline.AddFlight(Convert.ToDateTime("20.07.2015 18:30:25"), true, 270, "Paris", 'D', 26, 5, 20.3, 5.6);
            airline.AddPassenger(270, "Jane", "Smith", "American", "AB123517", Convert.ToDateTime("25/03/1996"), 2, 2);
            airline.AddPassenger(270, "Alex", "Smith", "British", "DB127517", Convert.ToDateTime("17.03.1998"), 1, 2);
            airline.AddPassenger(270, "Maria", "Livesy", "Ukraine", "AC123517", Convert.ToDateTime("24/08/1991"), 2, 2);

            airline.AddFlight(Convert.ToDateTime("01.05.2019"), true, 54, "Rome", 'C', 15, 1, 5.8, 57.6);
            airline.AddPassenger(54, "Aaron", "Livesy", "British", "passport", Convert.ToDateTime("24/08/1991"), 1, 1);
            airline.AddPassenger(54, "Robert", "Sugden", "British", "passWord", Convert.ToDateTime("16.04.1970"), 1, 1);

            airline.AddFlight(Convert.ToDateTime("14.12.2018 18:30:25"), false, 14, "Barcelona", 'A', 7, 7, 6, 99);
            airline.AddPassenger(14, "Karolina", "Dingle", "Italian", "16750224", Convert.ToDateTime("6/8/1997"), 2, 2);
            airline.AddPassenger(14, "Adam", "Lambert", "American", "americanidol", Convert.ToDateTime("29.01.1987"), 1, 1);

            UI ui = new UI(airline);
            ui.DisplayAvailableFeatures();
        }
    }
}
