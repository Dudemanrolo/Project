using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp7
{
    internal class ReservationDay
    {
        List<Reservation> DailyOperations = new List<Reservation>(); // TEST
        public int MonthNumber { get; set; }
        public int DayNumber { get; set; }
        private static int IdNumber = 00000;
       public ReservationDay(int Month, int Day)
        {
            this.MonthNumber = Month;
            this.DayNumber = Day;
            
        }
        public void AddReservation( string FirstName, string LastName, int PartySize, string TimeOfRequest)
        {
            int Id = IdNumber + 1;
            IdNumber += 1;
            DailyOperations.Add(new Reservation(Id, FirstName, LastName, PartySize, TimeOfRequest));

        }
        public void DisplayReservations()
        {
            Console.WriteLine("ID#      First Name:      Last Name:      Party Size:      Time of Request: ");
            foreach (var i in DailyOperations) 
            {
                i.DisplayRes();
            }
        }
        public void EditReservation()
        {
            int userinput = -1;
            Console.WriteLine("Which reservation would you like to edit? ");
            int userEditID = Convert.ToInt32(Console.ReadLine())-1;
            while (userinput != 0) 
            {
                Console.WriteLine("Enter the Number of the Value you would like to edit: ");
                Console.WriteLine(" 0: Exit 1: First Name, 2: Last Name, 3: Party Size, 4: Time of Request, 5: Notes, 6: Phone Number");
                userinput = Convert.ToInt32(Console.ReadLine());
                if (userinput == 1) {
                    Console.WriteLine("Enter the New Value: ");
                    DailyOperations.ElementAt(userEditID).FirstName = Console.ReadLine();
                } else if (userinput == 2 ){
                    Console.WriteLine("Enter the New Value: ");
                    DailyOperations.ElementAt(userEditID).LastName = Console.ReadLine();
                } else if (userinput == 3) {
                        Console.WriteLine("Enter the New Value: ");
                        DailyOperations.ElementAt(userEditID).PartySize= Convert.ToInt32(Console.ReadLine());
                    }
                else if (userinput == 4)
                {
                    Console.WriteLine("Enter the New Value: ");
                    DailyOperations.ElementAt(userEditID).TimeofRequest = Console.ReadLine();
                }
                else if (userinput == 5)
                {
                    Console.WriteLine("Enter the New Value: ");
                    DailyOperations.ElementAt(userEditID).Notes = Console.ReadLine();
                } else if (userinput == 6)
                {
                    Console.WriteLine("Enter the New Value: ");
                    DailyOperations.ElementAt(userEditID).Notes = Console.ReadLine();
                } else
                {
                    Console.WriteLine("Failed to Update Reservation");
                }
                Console.WriteLine("Succeeded to Edit Reservation");

            }
        }

        public void RemoveReservation()
        {
            this.DisplayReservations();
            Console.WriteLine("Enter the ID of the Reservation you would like to remove:");
            int removalID = Convert.ToInt32(Console.ReadLine());
            DailyOperations.RemoveAt(DailyOperations.FindIndex(x => x.IDnumber == removalID ));
        }
    }
}
