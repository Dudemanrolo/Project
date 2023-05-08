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
        List<Reservation> DailyOperations = new List<Reservation>(); // TEST More test
        public int MonthNumber { get; set; }
        public int DayNumber { get; set; }
        private static int IdNumber = 00000;
       public ReservationDay(int Month, int Day)
        {
            this.MonthNumber = Month;
            this.DayNumber = Day;
            
        }
        public void AddReservation(int Id, string FirstName, string LastName, string PartySize, string TimeOfRequest)
        {
            this.DailyOperations.Add(new Reservation(Id, FirstName, LastName, PartySize, TimeOfRequest));
        }
        public void AddReservation()
        {
            try
            {
                int Id = IdNumber + 1;
                IdNumber += 1;
                Console.WriteLine("Enter the First Name of the Person who Made a Reservation:");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string FirstName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("Enter the Last Name of the Person who Made a Reservation:");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string LastName = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("Enter the Size of the Party for the Reservation:");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string PartySize = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                Console.WriteLine("Enter the The Time Requested for the Reservation:");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string TimeOfRequest = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                DailyOperations.Add(new Reservation(Id, FirstName, LastName, PartySize, TimeOfRequest));
                Console.WriteLine("Successfully Added a New Reservation");
                Console.WriteLine("");
                Console.WriteLine("");
                this.DisplayReservations();
                Console.WriteLine("");
                Console.WriteLine("");
            }
            catch
            {
                
            }

        }
        public void DisplayReservations()
        {
            Console.WriteLine($"{"ID:",-5}{"First Name:",-15}{"Last Name:",-20}{"Party Size:",-25}{"Time of Request:",-30}");
            foreach (var i in DailyOperations) 
            {
                i.DisplayRes();
            }
        }
        public void EditReservation()
        {
            bool done = false;
            this.DisplayReservations();
            Console.WriteLine("Enter the ID shown Above of the Reservation you would like to edit: ");
            int userEditID = Convert.ToInt32(Console.ReadLine());
            int userInput;
            try
            {
                while (done != true)
                {
                    Console.WriteLine("Enter the Number of the Value you would like to edit: ");
                    Console.WriteLine(" 0: Exit 1: First Name, 2: Last Name, 3: Party Size, 4: Time of Request, 5: Notes, 6: Phone Number");
                    userInput = Convert.ToInt32(Console.ReadLine());
                    switch (userInput)
                    {
                        case 0:
                            done = true;
                            break;
                        case 1:
                            Console.WriteLine("Enter the New Value: ");
#pragma warning disable CS8601 // Possible null reference assignment.
                            DailyOperations.ElementAt(userEditID - 1).FirstName = Console.ReadLine();
#pragma warning restore CS8601 // Possible null reference assignment.
                            Console.WriteLine("Succeeded to Edit Reservation");
                            Console.WriteLine("");
                            break;
                        case 2:
                            Console.WriteLine("Enter the New Value: ");
#pragma warning disable CS8601 // Possible null reference assignment.
                            DailyOperations.ElementAt(userEditID - 1).LastName = Console.ReadLine();
#pragma warning restore CS8601 // Possible null reference assignment.
                            Console.WriteLine("Succeeded to Edit Reservation");
                            Console.WriteLine("");
                            break;
                        case 3:
                            Console.WriteLine("Enter the New Value: ");
#pragma warning disable CS8601 // Possible null reference assignment.
                            DailyOperations.ElementAt(userEditID - 1).PartySize = Console.ReadLine();
#pragma warning restore CS8601 // Possible null reference assignment.
                            Console.WriteLine("Succeeded to Edit Reservation");
                            Console.WriteLine("");
                            break;
                        case 4:
                            Console.WriteLine("Enter the New Value: ");
#pragma warning disable CS8601 // Possible null reference assignment.
                            DailyOperations.ElementAt(userEditID - 1).TimeofRequest = Console.ReadLine();
#pragma warning restore CS8601 // Possible null reference assignment.
                            Console.WriteLine("Succeeded to Edit Reservation");
                            Console.WriteLine("");
                            break;
                        case 5:
                            Console.WriteLine("Enter the New Value: ");
                            DailyOperations.ElementAt(userEditID - 1).Notes = Console.ReadLine();
                            Console.WriteLine("");
                            break;
                        case 6:
                            Console.WriteLine("Enter the New Value: ");
                            DailyOperations.ElementAt(userEditID - 1).PhoneNumber = Console.ReadLine();
                            Console.WriteLine("");

                            break;
                    }



                }
             } catch (Exception e)
            {
                Console.WriteLine("An Error Has Occured, Please try Again");
            }

            }
                
            
        

        public void RemoveReservation()
        {
            this.DisplayReservations();
            Console.WriteLine("Enter the ID of the Reservation you would like to remove:");
            int removalID = Convert.ToInt32(Console.ReadLine());
            DailyOperations.RemoveAt(DailyOperations.FindIndex(x => x.IDnumber == removalID ));
            Console.WriteLine("Successfully Removed the Reservation");
            this.DisplayReservations();
        }
    }
}
