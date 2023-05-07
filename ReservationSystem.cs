using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class ReservationSystem
    {
        List<ReservationDay> days = new List<ReservationDay>();
        //List for creating and storing individual reservation days
        public void AddReservationDay(int monthNumber, int dayNumber)
        {
            days.Add(new ReservationDay(monthNumber, dayNumber));
        }
        //Void method for adding a resevation day to the list. Uses the monthNumber and dayNumber to identify which days are open
        public void DisplayDaysOfOperation()
        {
            int totalDays = 1;
           foreach (var i in days)
            {
                Console.WriteLine($"#{totalDays}: {i.MonthNumber}/{i.DayNumber}");
                totalDays += 1;
            }
           //foreach loop that counts each day of each month that is open
        }
        //Void Method that displays the total days of operation
        public void RemoveReservationDay()
        {
          Console.WriteLine("Enter the Month of the Date to be removed");
          int month = Convert.ToInt32(Console.ReadLine());
            //Uses user input to determine which month has the day that needs to be removed
          Console.WriteLine("Enter the Day of the Date to be removed");
          int day = Convert.ToInt32(Console.ReadLine());
            //Uses user input to determine the day in the month that needs to be removed
          int Index =  days.FindIndex(x => x.MonthNumber == month && x.DayNumber == day);
          days.RemoveAt(Index);
            //Finds and then removes the previosly specified date
          Console.WriteLine("Entry has been deleted");
        }
        //Void method that prompts the user with questions in order to removve a reservation day
    }
}
