using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Reservation
    {
        public int IDnumber { get; set; }
        //Getter and setter for IDnumber
        public string FirstName { get; set; }
        //Getter and setter for FirstName
        public string LastName { get; set; }
        //Getter and setter for LastName
        public string PartySize { get; set; }
        //Getter and setter for PartySize
        public string TimeofRequest { get; set; }
        //Getter and setter for TimeofRequest
        public string? Notes { get; set; }
        //Getter and setter for Note
        public string? PhoneNumber { get; set; }
        //Getter and setter for PhoneNumber


        public Reservation(int Id, string FName, string Lname, string Psize, string TORequest)
        {
            this.IDnumber = Id;
            this.FirstName = FName;
            this.LastName = Lname;
            this.PartySize = Psize;
            this.TimeofRequest = TORequest;
            
        }
        //Object for creating each individual reservation with an input of Id, Fname, Lname, Psize, and TORequest
        public void DisplayRes()
        {
            Console.WriteLine($"{this.IDnumber,-12}{this.FirstName,-17}{this.LastName,-22}{this.PartySize,-27}{this.TimeofRequest,-32} ");
            //Displays IDnumber, FirstName, LastName, PartySize, and TimeofRequest
            if (this.Notes != null)
            {
                Console.Write(this.Notes);
            }
            //Displays notes if there are any
            if (this.PhoneNumber != null)
            {
                Console.Write($"  {this.PhoneNumber}");
            }
            //Displays a phone number if there is one
        }
        //Method for displaying various reservation information

    }
}
