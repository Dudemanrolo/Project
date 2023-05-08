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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PartySize { get; set; }
        public string TimeofRequest { get; set; }
        public string? Notes { get; set; }
        
        public string? PhoneNumber { get; set; }

        public Reservation(int Id, string FName, string Lname, string Psize, string TORequest)
        {
            this.IDnumber = Id;
            this.FirstName = FName;
            this.LastName = Lname;
            this.PartySize = Psize;
            this.TimeofRequest = TORequest;
            
        }
        public void DisplayRes()
        {
            Console.WriteLine($"{this.IDnumber, -12}{this.FirstName, -17}{this.LastName, -22}{this.PartySize, -27}{this.TimeofRequest, -32} ");
            if (this.Notes != null)
            {
                Console.Write(this.Notes);
            }
            if (this.PhoneNumber != null)
            {
                Console.Write($"  {this.PhoneNumber}");
            }
        }

    

    }
}
