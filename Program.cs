using System.Transactions;
using System.Xml.Linq;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            //Changes text to green because it looks cooler
            passwordSystem Security = new passwordSystem("Master", "1234");
            //Creates a example username and password
            ReservationSystem MainResSystem = new ReservationSystem();
            MainResSystem.AddReservationDay(0, 0);
            //Adds default reservation day
            Console.WriteLine("Welcome User ");
            Security.SignIn();
            //Opens sign in screen for user
            //User cannot access any information until sign in is complete
            bool done = false;
            while (done != true)
            {
                Console.Clear();
                MainResSystem.DisplayAllReservations();
                //Shows all of the reservations so that the user can decide what they want to do with the system
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Please enter a command: ");
                Console.WriteLine(" 0: Quit, 1: Manage Daily Opperations, 2: Filter Entries To One Day, 3: Add/Remove/Edit Reservation Menu, 4: Add New User ");
                //Options for what the user wants to do
                try
                {
                    int UserCommand = Convert.ToInt32(Console.ReadLine());
                    //Stores user input in UserCommand
                    Console.Clear();
                    switch (UserCommand)
                    {
                        case 0:
                            done = true;
                            break;
                        //If user input is 0 then quits program
                        case 1:
                            MainResSystem.dailyOperationUI();
                            break;
                        //If user input is 1 then calls the dailyOperationsUI

                        case 2:
                            MainResSystem.IndividualDayViewUI();
                            break;
                        //If user input is 2 then calls the IndividualDayViewUI

                        case 3:
                            MainResSystem.ReservationMenuUI();
                            break;
                        //If user input is 3 then calls trhe ReservationMenuUI

                        case 4:
                            Security.addUser();
                            break;
                            //If user input is 4 then calls the addUser method

                    }
                    //try for each expected user input to determine which function should be used
                }
                catch (Exception e)
                {
                    Console.WriteLine("an Error Has Occured, Please try again");
                }
                //catch for any input that is not 0-4

            }
        }
    }
}
