using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class ReservationSystem
    {
        public List<ReservationDay> days = new List<ReservationDay>();
        public void AddReservationDay()
        {
            this.DisplayAllReservations();
            //Runs DisplayAllReservatiuons to show the user what values currently exist
            Console.WriteLine("Enter the Month number of the Date you'd like to add");
            int monthNumber = Convert.ToInt32(Console.ReadLine());
            //Asks user what month they want to add a reservation day for and then sets it to 
            Console.WriteLine("Enter the Day number of the Date you'd like to add");
            int dayNumber = Convert.ToInt32(Console.ReadLine());
            //Asks user what day they want to add a reservation day for and then sets it to 
            this.days.Add(new ReservationDay(monthNumber, dayNumber));
            //Creates a new ReservationDay useing the previous input
            Console.WriteLine("Entry has been added");
            this.DisplayAllReservations();
            //Displays all of the current reservations for the user
        }
        public void AddReservationDay(int x, int y)
        {
            this.days.Add(new ReservationDay(x,y));
        }
        //Void method for creating a new reservation day
        public void DisplayAllReservations()
        {
            int totalDays = 1;
            foreach (ReservationDay i in this.days)
            {
                Console.WriteLine($"#{totalDays}: {i.MonthNumber}/{i.DayNumber}");
                i.DisplayReservations();
                totalDays += 1;
            }
            //foreach loop that displays the reservation information each index
        }
        //Method for displaying all of the current reservation days
        public void RemoveReservationDay()
        {
            try
            {
                this.DisplayAllReservations();
                Console.WriteLine("Enter the Month of the Date to be removed");
                int month = Convert.ToInt32(Console.ReadLine());
                //Asks user what month they want to remove a reservation day from and then sets it to month
                Console.WriteLine("Enter the Day of the Date to be removed");
                int day = Convert.ToInt32(Console.ReadLine());
                //Asks user what day they want to remove a reservation day from and then sets it to day
                int Index = days.FindIndex(x => x.MonthNumber == month && x.DayNumber == day);
                //Finds the Index of the reservation using the given month and day
                this.days.RemoveAt(Index);
                //Removes the reservation at the given index
                Console.WriteLine("Entry has been deleted");
                this.DisplayAllReservations();
                //Displays all reservations so the user can see the change
            } catch (Exception e)
            
            {
                Console.WriteLine("An Error has Occured");
            }
            //catch for any non valid inputs
        }
        //Void method for removing a specific reservation day
        public ReservationDay AccessElement(int Index)
        {
            return this.days.ElementAt(Index);
        }
        //Getter to access the ReservationDay List
        public void dailyOperationUI()
        {
            bool done = false;
            while (done != true)
            {
                Console.WriteLine("Please Enter the Operation you would like to preform");
                Console.WriteLine("0: Quit, 1: Add Day, 2: Remove Day");
                int userInput =  Convert.ToInt32(Console.ReadLine());
                //Asks the user what they want to do next and sets the input to userInput
                switch (userInput)
                {
                    case 0:
                        Console.WriteLine("Returning to Previous Menu...");
                        done = true;
                        break;
                    //If user input is 0 then ends the loop
                    case 1:
                        this.AddReservationDay();
                        break;
                    //If user input is 1 then calls the AddReservationDay method

                    case 2:
                        this.RemoveReservationDay();
                        break;
                        //If user input is 2 then calls the RemoveReservationDayInput

                }
                //switch to determine what the user wants to do next

            }
        }
        public void IndividualDayViewUI()
        {
            try
            {
                bool done = false;
                while (done != true)
                {
                    try
                    {
                        Console.WriteLine("Enter the Month of the Day You Would Like to see");
                        int month = Convert.ToInt32(Console.ReadLine());
                        //Asks user what month they want to see a reservation day from and then sets it to month
                        Console.WriteLine("Enter the Day You Would Like to See");
                        int day = Convert.ToInt32(Console.ReadLine());
                        //Asks user what day they want to see a reservation day from and then sets it to day
                        this.days.ElementAt(days.FindIndex(x => x.MonthNumber == month && x.DayNumber == day)).DisplayReservations();
                        //Displays the reservation information on the given day
                        Console.WriteLine("Would You Like To view Another Date? 0: No 1: Yes");
                        int userinput = Convert.ToInt32(Console.ReadLine());
                        //Asks the user if they want to see another day and sets the input to userinput
                        if (userinput == 0)
                        {
                            done = true;
                        }
                        //If the user answers with 0 then ends loop if 1 then repeats again
                    } catch (Exception e)
                    {
                        Console.WriteLine("Error Has Occured, Please Try Again");
                    }
                    //catch for any non valid inputs

                }

            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("An Error has Occured");;
            }
            //catch for any non valid inputs
        }
        //Void method for displaying the user view for individual day changes


        public void ReservationMenuUI()
        {
            bool done = false;
            while (done != true) {
                int userInput = 0;
                this.DisplayAllReservations();
                //Displays all current reservations for the user to see
                Console.WriteLine("Would you Like to: ");
                Console.WriteLine("0: Quit 1: Add a New Reservation, 2: Remove a Reservation, 3: Edit a Reservation");
                userInput = Convert.ToInt32(Console.ReadLine());
                //Asks the user what they want to do and then sets input to userInput
                int month;
                int day;
                switch (userInput)
                {
                       case 0:
                        done = true;
                       break;
                        //If userinput is 0 then ends loop

                      case 1:
                        Console.WriteLine("Enter the Month Number of the Reservation you would like to add");
                        month = Convert.ToInt32(Console.ReadLine());
                        //Asks user what month they want to add a reservation to and then sets it to month
                        Console.WriteLine("Enter the Day Number of the Reservation you would like to add");
                        day = Convert.ToInt32(Console.ReadLine());
                        //Asks user what day they want to add a reservation to and then sets it to day
                        if (days.Exists(x => x.MonthNumber == month && x.DayNumber == day))
                        {
                            this.days.ElementAt(days.FindIndex(x => x.MonthNumber == month && x.DayNumber == day)).AddReservation();

                        }
                        //Uses user input to run the AddReservation method as long as the reservation day exists
                        else 
                        {
                            this.days.Add(new ReservationDay(month, day));
                            this.days.ElementAt(days.FindIndex(x => x.MonthNumber == month && x.DayNumber == day)).AddReservation();
                        }
                        //If the reservation day does not already exist, then creates it and runs the AddReservation method

                      break;
                        //If user input is 1 then adds a new reservation


                      case 2:
                        Console.WriteLine("Enter the Month Number of the Reservation you would like to Remove");
                        month = Convert.ToInt32(Console.ReadLine());
                        //Asks user what month they want to remove a reservation from and then sets it to month
                        Console.WriteLine("Enter the Day Number of the Reservation you would like to Remove");
                        day = Convert.ToInt32(Console.ReadLine());
                        //Asks user what day they want to remove a reservation from and then sets it to day

                        if (days.Exists(x => x.MonthNumber == month && x.DayNumber == day))
                        {
                            this.days.ElementAt(days.FindIndex(x => x.MonthNumber == month && x.DayNumber == day)).RemoveReservation();

                        }
                        //If the reservation day exists then runs the RemoveReservation method
                        else
                        {
                            Console.WriteLine("This Day of Operations Does Not Exist");
                        }
                        //If the reservation day does not exist then notifies the user
                        break;
                        //If the user input is 2 then removes a reservation


                      case 3:
                        Console.WriteLine("Enter the Month Number of the Reservation you would like to Edit:");
                        month = Convert.ToInt32(Console.ReadLine());
                        //Asks user what month they want to edit a reservation from and then sets it to month
                        Console.WriteLine("Enter the Day Number of the Reservation you would like to Edit:");
                        day = Convert.ToInt32(Console.ReadLine());
                        //Asks user what day they want to edit a reservation from and then sets it to day
                        if (days.Exists(x => x.MonthNumber == month && x.DayNumber == day))
                        {
                            this.days.ElementAt(days.FindIndex(x => x.MonthNumber == month && x.DayNumber == day)).EditReservation();

                        }
                        //If the reservation day exists then runs the edit reservation method
                        else
                        {
                            Console.WriteLine("This Day of Operations Does Not Exist");
                        }
                        //If the reservation day does not exist then notifies the user
                        break;
                        //If the user input is 3 then edits a reservation
                }
                //Switch to give the user options on what to do next
            }
        }
    }

}

