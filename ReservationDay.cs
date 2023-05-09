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
        List<Reservation> DailyOperations = new List<Reservation>();
        //List for tracking each reservation
        public int MonthNumber { get; set; }
        //Getter and setter for MonthNumber
        public int DayNumber { get; set; }
        //Getter and setter for DayNumber
        private static int IdNumber = 00000;
        //Default IdNumber
       public ReservationDay(int Month, int Day)
        {
            this.MonthNumber = Month;
            this.DayNumber = Day;
            
        }
        //Element for adding a specific reservation day to the ReservationDay list
        public void AddReservation(int Id, string FirstName, string LastName, string PartySize, string TimeOfRequest)
        {
            this.DailyOperations.Add(new Reservation(Id, FirstName, LastName, PartySize, TimeOfRequest));
        }
        //Void method for adding a reservation given Id, FirstName, LastName, PartySize, and TimeOfRequest
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
               //Comments above are nessesary to resolve unexpected inputs
                DailyOperations.Add(new Reservation(Id, FirstName, LastName, PartySize, TimeOfRequest));
                //Adds a new reservaation with the inputted information
                Console.WriteLine("Successfully Added a New Reservation");
                Console.WriteLine("");
                Console.WriteLine("");
                this.DisplayReservations();
                //Displays all reservations for the user to see
                Console.WriteLine("");
                Console.WriteLine("");
            }
            //try for adding a new reservation
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("An Error Has Occured, Please try again");
            }
            //Catch for all non valid inputs

        }
        public void DisplayReservations()
        {
            Console.WriteLine($"{"ID:",-7}{"First Name:",-17}{"Last Name:",-22}{"Party Size:",-27}{"Time of Request:",-32}");
            foreach (var i in DailyOperations) 
            {
                i.DisplayRes();
            }
            //foreach loop that dispays all reservations
        }
        //Void method for displaying all reservations
        public void EditReservation()
        {
            bool done = false;
            this.DisplayReservations();
            //Displays all reservations so that user can tell which reservation they want to edit
            Console.WriteLine("Enter the ID shown Above of the Reservation you would like to edit: ");
            int userEditID = Convert.ToInt32(Console.ReadLine());
            //Asks the user for the ID of which reservation to edit and sets input to userEditID
            int userInput;
            try
            {
                while (done != true)
                {
                    Console.WriteLine("Enter the Number of the Value you would like to edit: ");
                    Console.WriteLine(" 0: Exit 1: First Name, 2: Last Name, 3: Party Size, 4: Time of Request, 5: Notes, 6: Phone Number");
                    userInput = Convert.ToInt32(Console.ReadLine());
                    //Gives the user several options of what they want to do and sets the input to userInput
                    switch (userInput)
                    {
                        case 0:
                            done = true;
                            break;
                            //If userInput is 0 then ends the loop
                        case 1:
                            Console.WriteLine("Enter the New Value: ");
#pragma warning disable CS8601 // Possible null reference assignment.
                            DailyOperations.ElementAt(userEditID - 1).FirstName = Console.ReadLine();
#pragma warning restore CS8601 // Possible null reference assignment.
                            Console.WriteLine("Succeeded to Edit Reservation");
                            Console.WriteLine("");
                            break;
                        //If userInput is 1 then asks for new first name and sets the FirstName to that value
                        case 2:
                            Console.WriteLine("Enter the New Value: ");
#pragma warning disable CS8601 // Possible null reference assignment.
                            DailyOperations.ElementAt(userEditID - 1).LastName = Console.ReadLine();
#pragma warning restore CS8601 // Possible null reference assignment.
                            Console.WriteLine("Succeeded to Edit Reservation");
                            Console.WriteLine("");
                            break;
                        //If userInput is 2 then asks for new last name and sets the LastName to that value

                        case 3:
                            Console.WriteLine("Enter the New Value: ");
#pragma warning disable CS8601 // Possible null reference assignment.
                            DailyOperations.ElementAt(userEditID - 1).PartySize = Console.ReadLine();
#pragma warning restore CS8601 // Possible null reference assignment.
                            Console.WriteLine("Succeeded to Edit Reservation");
                            Console.WriteLine("");
                            break;
                        //If userInput is 3 then asks for new party size and sets the PartySize to that value

                        case 4:
                            Console.WriteLine("Enter the New Value: ");
#pragma warning disable CS8601 // Possible null reference assignment.
                            DailyOperations.ElementAt(userEditID - 1).TimeofRequest = Console.ReadLine();
#pragma warning restore CS8601 // Possible null reference assignment.
                            Console.WriteLine("Succeeded to Edit Reservation");
                            Console.WriteLine("");
                            break;
                        //If userInput is 4 then asks for new reservation time and sets the TimeofRequest to that value

                        case 5:
                            Console.WriteLine("Enter the New Value: ");
                            DailyOperations.ElementAt(userEditID - 1).Notes = Console.ReadLine();
                            Console.WriteLine("");
                            break;
                        //If userInput is 5 then asks for new notes and sets the Notes to that value

                        case 6:
                            Console.WriteLine("Enter the New Value: ");
                            DailyOperations.ElementAt(userEditID - 1).PhoneNumber = Console.ReadLine();
                            Console.WriteLine("");
                            break;
                            //If userInput is 6 then asks for new phone number and sets the PhoneNumber to that value

                    }
                    //Switch for deciding what to do with user input

                }
             } catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("An Error Has Occured, Please try Again");
            }
            //Catch for any non valid inputs

            }
                
        

        public void RemoveReservation()
        {
            this.DisplayReservations();
            //Displays reservation information so that user can see what they want to change
            Console.WriteLine("Enter the ID of the Reservation you would like to remove:");
            int removalID = Convert.ToInt32(Console.ReadLine());
            //Asks the user for what the ID is of the reservation they want to edit and sets it to removalID
            DailyOperations.RemoveAt(DailyOperations.FindIndex(x => x.IDnumber == removalID ));
            //Finds the reservation from the list and removes it at that index
            Console.WriteLine("Successfully Removed the Reservation");
            this.DisplayReservations();
            //Displays the reservations so that the user can see with the reservation removed
        }
        //Void method for removing a reservation
    }
}
