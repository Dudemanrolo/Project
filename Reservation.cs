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
        public int PartySize { get; set; }
        //Getter and setter for PartySize
        public string TimeofRequest { get; set; }
        //Getter and setter for TimeOfRequest
        public string? Notes { get; set; }
        //Getter and setter for Notes

        public string? PhoneNumber { get; set; }
        //Getter and setter for PhoneNumber

        public Reservation(int Id, string FName, string Lname, int Psize, string TORequest)
        {
            this.IDnumber = Id;
            this.FirstName = FName;
            this.LastName = Lname;
            this.PartySize = Psize;
            this.TimeofRequest = TORequest;
            
        }
        //Object for a specific reservation that keeps track of Id, FName, Lname, Psize, TORequest
        public void DisplayRes()
        {
            Console.WriteLine($"{this.IDnumber}      {this.FirstName}      {this.LastName}      {this.PartySize}      {this.TimeofRequest} ");
            if (this.Notes != null)
            {
                Console.Write(this.Notes);
            }
            if (this.PhoneNumber != null)
            {
                Console.Write($"  {this.PhoneNumber}");
            }
        }
        //Void method that will display IDnumber, FirstName, LastName, PartySize, and TimeOfRequest as well as Notes and PhoneNumber as long as they are not null
    

    }
}
