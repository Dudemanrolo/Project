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
            days.Add(new ReservationDay(monthNumber, dayNumber));
            Console.WriteLine("Entry has been added");
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
          Console.WriteLine("Enter the Month of the Date to be removed");
          int month = Convert.ToInt32(Console.ReadLine());
          Console.WriteLine("Enter the Day of the Date to be removed");
          int day = Convert.ToInt32(Console.ReadLine());
          int Index =  days.FindIndex(x => x.MonthNumber == month && x.DayNumber == day);
          days.RemoveAt(Index);
          Console.WriteLine("Entry has been deleted");
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
                Console.WriteLine("Please Enter the Opperation you would like to preform");
                Console.WriteLine("0: Quit, 1: Add Day, 2: Remove Day");
                int userInput =  Convert.ToInt32(Console.ReadLine());
                switch (userInput)
                {
                    case 0:
                        Console.WriteLine("Returning to Previous Menu...");
                        done = false;
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

    }

}
}
