using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp7
{
    internal class ReservationDay
    {
        List<Reservation> DailyOperations = new List<Reservation>();
        //Creates a new list to track each reservation
        public int MonthNumber { get; set; }
        //Getter and setter for MonthNumber
        public int DayNumber { get; set; }
        //Getter and setter for DayNumber
        private static int IdNumber = 00000;
        //Default variable for IdNumber
       public ReservationDay(int Month, int Day)
        {
            this.MonthNumber = Month;
            this.DayNumber = Day;
            
        }
        //Object that inputs the Month and Day into the list
        public void AddReservation( string FirstName, string LastName, int PartySize, string TimeOfRequest)
        {
            int Id = IdNumber + 1;
            IdNumber += 1;
            DailyOperations.Add(new Reservation(Id, FirstName, LastName, PartySize, TimeOfRequest));

        }
        //Void method for adding a reservation using FirstName, LastName, PartySize, and TimeOfRequest
        public void DisplayReservations()
        {
            Console.WriteLine("ID#      First Name:      Last Name:      Party Size:      Time of Request: ");
            foreach (var i in DailyOperations) 
            {
                i.DisplayRes();
            }
            //foreach loop that uses the DisplayRes method to show each reservation in DailyOperations
        }
        //Void method for displaying all of the reservations
        public void EditReservation()
        {
            int userinput = -1;
            Console.WriteLine("Which reservation would you like to edit? ");
            int userEditID = Convert.ToInt32(Console.ReadLine())-1;
            //User is prompted with question and then response-1 is stored in userEditID
            while (userinput != 0) 
            {
                Console.WriteLine("Enter the Number of the Value you would like to edit: ");
                Console.WriteLine(" 0: Exit 1: First Name, 2: Last Name, 3: Party Size, 4: Time of Request, 5: Notes, 6: Phone Number");
                userinput = Convert.ToInt32(Console.ReadLine());
                //User is prompted with question and then response is stored in userinput
                if (userinput == 1) {
                    Console.WriteLine("Enter the New Value: ");
                    DailyOperations.ElementAt(userEditID).FirstName = Console.ReadLine();
                    //If the userinput = 1 then the user is asked to enter a new value that will be stored in the FirstName of the DailyOperations Element
                } else if (userinput == 2 ){
                    Console.WriteLine("Enter the New Value: ");
                    DailyOperations.ElementAt(userEditID).LastName = Console.ReadLine();
                    //If the userinput = 2 then the user is asked to enter a new value that will be stored in the LastName of the DailyOperations Element
                }
                else if (userinput == 3) {
                        Console.WriteLine("Enter the New Value: ");
                        DailyOperations.ElementAt(userEditID).PartySize= Convert.ToInt32(Console.ReadLine());
                    //If the userinput = 3 then the user is asked to enter a new value that will be stored in the PartySize of the DailyOperations Element
                }
                else if (userinput == 4)
                {
                    Console.WriteLine("Enter the New Value: ");
                    DailyOperations.ElementAt(userEditID).TimeofRequest = Console.ReadLine();
                    //If the userinput = 4 then the user is asked to enter a new value that will be stored in the TimeofRequest of the DailyOperations Element
                }
                else if (userinput == 5)
                {
                    Console.WriteLine("Enter the New Value: ");
                    DailyOperations.ElementAt(userEditID).Notes = Console.ReadLine();
                    //If the userinput = 5 then the user is asked to enter a new value that will be stored in the Notes of the DailyOperations Element
                }
                else if (userinput == 6)
                {
                    Console.WriteLine("Enter the New Value: ");
                    DailyOperations.ElementAt(userEditID).PhoneNumber = Console.ReadLine();
                    //If the userinput = 6 then the user is asked to enter a new value that will be stored in the PhoneNumber of the DailyOperations Element
                }
                else
                {
                    Console.WriteLine("Failed to Update Reservation");
                }
                //If 1-6 is not entered then the user is told that it failed to update the reservation
                Console.WriteLine("Succeeded to Edit Reservation");

            }
            //Void method for editing a reservation using a user input of numbers 1-6
        }

        public void RemoveReservation()
        {
            this.DisplayReservations();
            Console.WriteLine("Enter the ID of the Reservation you would like to remove:");
            int removalID = Convert.ToInt32(Console.ReadLine());
            //User is promted to enter a ID number, which is then stored in removalID
            DailyOperations.RemoveAt(DailyOperations.FindIndex(x => x.IDnumber == removalID ));
            //Reservation is removed from DailyOperations at the index of the removalID
        }
        //Void method for removing a reservation
    }
}
