using System.Transactions;
using System.Xml.Linq;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReservationSystem MainResSystem = new ReservationSystem();
            MainResSystem.AddReservationDay(0, 0);
            MainResSystem.AccessElement(0).AddReservation(0,"Benjamin", "Smith", 0, "0:00");
            Console.WriteLine("Welcome User ");
            MainResSystem.DisplayDaysOfOperation();
            bool done = false;
            while (done!= true)
            {
                Console.WriteLine("Please enter a command: ");
                Console.WriteLine(" 0: Quit, 1: Manage Daily Opperations, 2: View Reservations of a Specific Day, 3: Add/Remove/Edit Reservation Menu");
                int UserCommand = Convert.ToInt32(Console.ReadLine());

              
                switch (UserCommand)
                {
                    case 0:
                        done = true;
                        break;
                    case 1:
                        MainResSystem.dailyOperationUI();
                        break;
                        
                    case 2:
                        MainResSystem.IndividualDayViewUI();
                        break;
                    case 3:
                        MainResSystem.ReservationMenuUI();
                    break;
                       



                }
            }
        }
    }
}