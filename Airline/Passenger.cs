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
            public enum Sex
            {
                Man = 1,
                Woman
            }

            public enum Class
            {
                Business = 1,
                Economy
            }

            public class Passenger
            {
                public string Firstname { get; private set; }
                public string Lastname { get; private set; }
                public string Nationality { get; private set; }
                public string Passport { get; private set; }
                public DateTime Birthday { get; private set; }
                public Sex Sex { get; private set; }
                public Class Ticket { get; private set; }

                public Passenger(string firstname, string lastname, string nationality,
                                 string passport, DateTime birthday, int sex, int ticket)
                {
                    this.Firstname = firstname;
                    this.Lastname = lastname;
                    this.Nationality = nationality;
                    this.Passport = passport;
                    this.Birthday = birthday;
                    this.Sex = (Sex)sex;
                    this.Ticket = (Class)ticket;
                }

                public void Edit(string firstname, string lastname, string nationality,
                                 string passport, string birthday, int sex, int ticket)
                {
                    if (!(string.IsNullOrEmpty(firstname)))
                    {
                        this.Firstname = firstname;
                    }

                    if (!(string.IsNullOrEmpty(lastname)))
                    {
                        this.Lastname = lastname;
                    }

                    if (!(string.IsNullOrEmpty(nationality)))
                    {
                        this.Nationality = nationality;
                    }

                    if (!(string.IsNullOrEmpty(passport)))
                    {
                        this.Passport = passport;
                    }

                    if (!(string.IsNullOrEmpty(birthday)))
                    {
                        if (DateTime.TryParse(birthday, out DateTime dateTimeBirthday))
                            this.Birthday = dateTimeBirthday;
                    }

                    if (sex != 0)
                    {
                        this.Sex = (Sex)sex;
                    }

                    if (ticket != 0)
                    {
                        this.Ticket = (Class)ticket;
                    }
                }

                public void Display()
                {
                    Console.WriteLine($"Firstname:\t{Firstname}");
                    Console.WriteLine($"Lastname:\t{Lastname}");
                    Console.WriteLine($"Nationality:\t{Nationality}");
                    Console.WriteLine($"Passport:\t{Passport}");
                    Console.WriteLine($"Birthday:\t{Birthday}");
                    Console.WriteLine($"Sex:\t\t{Sex}");
                    Console.WriteLine($"Ticket:\t\t{Ticket}");
                    Console.WriteLine();
                }
            }
        }
    }
}
