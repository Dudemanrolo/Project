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
        public passwordSystem(string username, string password)
        {
            this.username.Add(username);
            this.password.Add(password);
        }
        public void SignIn()
        {
            bool Authenticate = false;
            while (Authenticate != true)
            {
                try
                {
                    Console.WriteLine("Enter Your User Name:");
                    string username = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Enter Your Password:");
                    string password = Console.ReadLine();
                    Console.Clear();
                    if (this.username.Exists(x => x == username))
                    {
                        int index = this.username.FindIndex(x => x == username);
                        if (this.password.ElementAt(index) == password)
                        {
                            Authenticate = true;
                        }
                        else
                        {
                            Console.WriteLine("Your Password or Username is Incorrect");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your Password or Username is Incorrect");
                    }
                } catch ( Exception e)
                {
                    Console.WriteLine("An Error Has Occured, Please Try Again.");
                }
            }
        }
        public void addUser()
        {
            try
            {
                Console.WriteLine("Enter Your Desired UserName:");
                string username = Console.ReadLine();
                Console.WriteLine("Enter Your Desired Password:");
                string password = Console.ReadLine();
                if (this.username.Contains(username) != true)
                {
                    this.username.Add(username);
                    this.password.Add(password);
                    Console.WriteLine("User successfully Added...returning to previous menu");

                }
            } catch (Exception e)
            {
                Console.WriteLine("An Error Has Occured, Please Try Again");
            }
        }

    }
}
