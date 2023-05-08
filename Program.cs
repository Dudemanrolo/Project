using System.Transactions;
using System.Xml.Linq;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            passwordSystem Security = new passwordSystem("Master","1234");
            ReservationSystem MainResSystem = new ReservationSystem();
            MainResSystem.AddReservationDay(0, 0);
            Console.WriteLine("Welcome User ");
            Security.SignIn();
            bool done = false;
            while (done!= true)
            {
                Console.Clear();
                MainResSystem.DisplayAllReservations();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Please enter a command: ");
                Console.WriteLine(" 0: Quit, 1: Manage Daily Opperations, 2: Filter Entries To One Day, 3: Add/Remove/Edit Reservation Menu, 4: Add New User ");
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
                            Security.addUser();
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