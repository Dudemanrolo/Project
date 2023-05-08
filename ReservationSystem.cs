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
            Console.WriteLine("Enter the Month number of the Date you'd like to add");
            int monthNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Day number of the Date you'd like to add");
            int dayNumber = Convert.ToInt32(Console.ReadLine());
            this.days.Add(new ReservationDay(monthNumber, dayNumber));
            Console.WriteLine("Entry has been added");
            this.DisplayAllReservations(); 
        }
        public void AddReservationDay(int x, int y)
        {
            this.days.Add(new ReservationDay(x,y));
        }
        public void DisplayAllReservations()
        {
            int totalDays = 1;
            foreach (ReservationDay i in this.days)
            {
                Console.WriteLine($"#{totalDays}: {i.MonthNumber}/{i.DayNumber}");
                i.DisplayReservations();
                totalDays += 1;
            }
        }
        public void RemoveReservationDay()
        {
            try
            {
                this.DisplayAllReservations();
                Console.WriteLine("Enter the Month of the Date to be removed");
                int month = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Day of the Date to be removed");
                int day = Convert.ToInt32(Console.ReadLine());
                int Index = days.FindIndex(x => x.MonthNumber == month && x.DayNumber == day);
                this.days.RemoveAt(Index);
                Console.WriteLine("Entry has been deleted");
                this.DisplayAllReservations();
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
                bool done = false;
                while (done != true)
                {
                    try
                    {
                        Console.WriteLine("Enter the Month of the Day You Would Like to see");
                        int month = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Day You Would Like to See");
                        int day = Convert.ToInt32(Console.ReadLine());
                        this.days.ElementAt(days.FindIndex(x => x.MonthNumber == month && x.DayNumber == day)).DisplayReservations();
                        Console.WriteLine("Would You Like To view Another Date? 0: No 1: Yes");
                        int userinput = Convert.ToInt32(Console.ReadLine());
                        if (userinput == 0)
                        {
                            done = true;
                        }
                    } catch (Exception e)
                    {
                        Console.WriteLine("Error Has Occured, Please Try Again");
                    }
                   

                }

            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("An Error has Occured");;
            }

         }
        public void ReservationMenuUI()
        {
            bool done = false;
            while (done != true) {
                int userInput = 0;
                this.DisplayAllReservations();
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
                            this.days.Add(new ReservationDay(month, day));
                            this.days.ElementAt(days.FindIndex(x => x.MonthNumber == month && x.DayNumber == day)).AddReservation();

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
                        if (days.Exists(x => x.MonthNumber == month && x.DayNumber == day))
                        {
                            this.days.ElementAt(days.FindIndex(x => x.MonthNumber == month && x.DayNumber == day)).EditReservation();

                        }
                        else
                        {
                            Console.WriteLine("This Day of Operations Does Not Exist");
                        }
                        break;
                        
                }
            }
        }
    }

}

