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
        public void AddReservationDay(int monthNumber, int dayNumber)
        {
            days.Add(new ReservationDay(monthNumber, dayNumber));
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

    }
}
