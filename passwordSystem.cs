using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class passwordSystem
    {
        private List<string> username = new List<string>();
        private List<string> password = new List<string>();
        //Lists to store all of teh usernames and passwords in the system
        public passwordSystem(string username, string password)
        {
            this.username.Add(username);
            this.password.Add(password);
        }
        //Object for creating a new password

        public void SignIn()
        {
            bool Authenticate = false;
            while (Authenticate != true)
            {
                try
                {
                    Console.WriteLine("Enter Your User Name:");
                    string username = Console.ReadLine();
                    //Asks the user for their username and then sets it to username
                    Console.Clear();
                    Console.WriteLine("Enter Your Password:");
                    string password = Console.ReadLine();
                    //Asks the user for their password and then sets it to password
                    Console.Clear();
                    if (this.username.Exists(x => x == username))
                    {
                        int index = this.username.FindIndex(x => x == username);
                        if (this.password.ElementAt(index) == password)
                        {
                            Authenticate = true;
                        }
                        //If both the userrname and password entered match that of the database, then the user is authenticated
                        else
                        {
                            Console.WriteLine("Your Password or Username is Incorrect");
                        }
                        //else in case if the user has a valid username but the wrong password
                    }
                    //if statement to determine if the username and password are in the system
                    else
                    {
                        Console.WriteLine("Your Password or Username is Incorrect");
                    }
                    //else to tell the user that their information is wrong
                }
                catch (Exception e)
                {
                    Console.WriteLine("An Error Has Occured, Please Try Again.");
                }
                //catch for any non valid inputs
            }
        }
        //Void method for SignIn
        //User must sign in in order to access and other program functions0
        public void addUser()
        {
            try
            {
                Console.WriteLine("Enter Your Desired UserName:");
                string username = Console.ReadLine();
                //Asks the user for desired username and then sets it to username
                Console.WriteLine("Enter Your Desired Password:");
                string password = Console.ReadLine();
                //Asks the user for desired password and then sets it to password
                if (this.username.Contains(username) != true)
                {
                    this.username.Add(username);
                    this.password.Add(password);
                    Console.WriteLine("User successfully Added...returning to previous menu");

                }
                //Creates a new username and password as long as the username is not already in the system
            }
            catch (Exception e)
            {
                Console.WriteLine("An Error Has Occured, Please Try Again");
            }
            //catch for any non valid inputs
        }
        //Void method for adding a user to the system

    }
}
