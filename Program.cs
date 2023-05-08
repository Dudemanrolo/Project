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
            Console.WriteLine("Welcome User ");
            bool done = false;
            while (done!= true)
            {
                
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Please enter a command: ");
                Console.WriteLine(" 0: Quit, 1: Manage Daily Opperations, 2: View Reservations of a Specific Day, 3: Add/Remove/Edit Reservation Menu, 4: Display All Reservations");
                try
                {
                    int UserCommand = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
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
                        case 4:
                            int totalDays = 1;
                            foreach (ReservationDay i in MainResSystem.days)
                            {
                                Console.WriteLine($"#{totalDays}: {i.MonthNumber}/{i.DayNumber}");
                                i.DisplayReservations();
                                totalDays += 1;
                            }

                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("an Error Has Occured, Please try again");
                }
                
                
                       



                }
            }
        }
    }