using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikaceZasobovani.MVVM.Model
{
    internal class PobockaModel
    {
    }

    internal class Pobocka
    {
        string Country { get; set; }
        string City { get; set; }
        string Street { get; set; }
        string HouseNumber { get; set; }
        string Zip { get; set; }
        Sklad Sklad { get; set; }
        public Pobocka(string country, string city, string street, string houseNumber, string zip, Sklad sklad)
        {
            Country = country;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            Zip = zip;
            Sklad = sklad;
        }
    }
}
