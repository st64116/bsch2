using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikaceZasobovani.Core
{
    internal class Sklad
    {
        string Country { get; set; }
        string City { get; set; }
        string Street { get; set; }
        string HouseNumber { get; set; }
        string Zip { get; set; }
        List<Auto> Auta { get; set; }
        List<Zamestnanec> Zamestnanec { get; set; }
        List<Pobocka> Pobocky { get; set; }

        public Sklad(string country, string city, string street, string houseNumber, string zip, List<Auto> auta, List<Zamestnanec> zamestnanec, List<Pobocka> pobocky)
        {
            Country = country;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            Zip = zip;
            Auta = auta;
            Zamestnanec = zamestnanec;
            Pobocky = pobocky;
        }
    }
}
