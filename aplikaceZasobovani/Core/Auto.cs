using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikaceZasobovani.Core
{
    internal class Auto
    {
        public string Brand { get; }
        public string Spz { get; set; }

        public Zamestnanec Zamestnanec { get; set; }

        public Auto(string brand, string spz, Zamestnanec zamestnanec)
        {
            Brand = brand;
            Spz = spz;
            Zamestnanec = zamestnanec;
        }
    }
}
