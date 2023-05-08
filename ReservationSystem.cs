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
        List<ReservationDay> days = new List<ReservationDay>();
        public void AddReservationDay()
        {
            Console.WriteLine("Enter the Month number of the Date you'd like to add");
            int monthNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Day number of the Date you'd like to add");
            int dayNumber = Convert.ToInt32(Console.ReadLine());
            this.days.Add(new ReservationDay(monthNumber, dayNumber));
            Console.WriteLine("Entry has been added");
            this.DisplayDaysOfOperation(); 
        }
        public void AddReservationDay(int x, int y)
        {
            this.days.Add(new ReservationDay(x,y));
        }
        public void DisplayDaysOfOperation()
        {
            int totalDays = 1;
           foreach (var i in days)
            {
                Console.WriteLine($"#{totalDays}: {i.MonthNumber}/{i.DayNumber}");
                totalDays += 1;
            }
        }
        public void RemoveReservationDay()
        {
            try
            {
                Console.WriteLine("Enter the Month of the Date to be removed");
                int month = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Day of the Date to be removed");
                int day = Convert.ToInt32(Console.ReadLine());
                int Index = days.FindIndex(x => x.MonthNumber == month && x.DayNumber == day);
                this.days.RemoveAt(Index);
                Console.WriteLine("Entry has been deleted");
                this.DisplayDaysOfOperation();
            } catch (Exception e)
            {
                Console.WriteLine("An Error has Occured");
            }
        }
        public ReservationDay AccessElement(int Index)
        {
            return this.days.ElementAt(Index);
        }
        public void dailyOperationUI()
        {
            bool done = false;
            while (done != true)
            {
                Console.WriteLine("Please Enter the Operation you would like to preform");
                Console.WriteLine("0: Quit, 1: Add Day, 2: Remove Day");
                int userInput =  Convert.ToInt32(Console.ReadLine());
                switch (userInput)
                {
                    case 0:
                        Console.WriteLine("Returning to Previous Menu...");
                        done = true;
                        break;
                    case 1:
                        this.AddReservationDay();
                        break;

                    case 2:
                        this.RemoveReservationDay();
                        break;
                        

                           
                }

            }
        }
        public void IndividualDayViewUI()
        {
            try
            {
                this.DisplayDaysOfOperation();
                Console.WriteLine("Enter the Index of the Day you would like to view reservations of");
                int userInput = Convert.ToInt32(Console.ReadLine());
                this.days.ElementAt(userInput - 1).DisplayReservations();
            }
            catch (Exception e)
            {
                Console.WriteLine("An Error has Occured");;
            }

         }
        public void ReservationMenuUI()
        {
            bool done = false;
            while (done != true) {
                int userInput = 0;
                Console.WriteLine("Would you Like to: ");
                Console.WriteLine("0: Quit 1: Add a New Reservation, 2: Remove a Reservation, 3: Edit a Reservation");
                userInput = Convert.ToInt32(Console.ReadLine());
                int month;
                int day;
                switch (userInput)
                {
                       case 0:
                        done = true;
                       break;

                      case 1:
                        Console.WriteLine("Enter the Month Number of the Reservation you would like to add");
                        month = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Day Number of the Reservation you would like to add");
                        day = Convert.ToInt32(Console.ReadLine());
                        if (days.Exists(x => x.MonthNumber == month && x.DayNumber == day))
                        {
                            this.days.ElementAt(days.FindIndex(x => x.MonthNumber == month && x.DayNumber == day)).AddReservation();

                        }
                        else 
                        {
                            Console.WriteLine("This Day of Operations Does Not Exist");
                        }

                      break;
                      case 2:
                        Console.WriteLine("Enter the Month Number of the Reservation you would like to Remove");
                        month = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Day Number of the Reservation you would like to Remove");
                        day = Convert.ToInt32(Console.ReadLine());
                        if (days.Exists(x => x.MonthNumber == month && x.DayNumber == day))
                        {
                            this.days.ElementAt(days.FindIndex(x => x.MonthNumber == month && x.DayNumber == day)).RemoveReservation();

                        }
                        else
                        {
                            Console.WriteLine("This Day of Operations Does Not Exist");
                        }
                        break;
                      case 3:
                        Console.WriteLine("Enter the Month Number of the Reservation you would like to Edit:");
                        month = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Day Number of the Reservation you would like to Edit:");
                        day = Convert.ToInt32(Console.ReadLine());
                        this.days.ElementAt(days.FindIndex(x => x.MonthNumber == month && x.DayNumber == day)).EditReservation();
                      break;
                        
                }
            }
        }
    }

}

