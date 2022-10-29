using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikaceZasobovani.Core
{
    internal class Zamestnanec
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        public int Age { get; set; }
        string Email { get; set; }
        Auto? Auto { get; set; }

        public Zamestnanec(string firstName, string lastName, int age, string email, Auto? auto)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            Auto = auto;
        }
    }
}
