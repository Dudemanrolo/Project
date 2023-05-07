using System.Transactions;
using System.Xml.Linq;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReservationSystem MainResSystem = new ReservationSystem();
            MainResSystem.AddReservationDay(1, 1);
            MainResSystem.AccessElement(0).AddReservation("Benjamin", "Smith", 0, "0:00");
            Console.WriteLine("Welcome User ");
            MainResSystem.DisplayDaysOfOperation();
            bool done = false;
            while (done!= true)
            {
                Console.WriteLine("Please enter What you would like to do: ");
                Console.WriteLine(" 0: Quit, 1: Manage Daily Opperations, 2: View Reservations of a Specific Day");
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
                        Console.WriteLine("Enter the Index of the Day you'd like to remove");
                        break;
                        




                }
            }
        }
    }
}