using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikaceZasobovani.MVVM.Model
{
    internal class SkladModel
    {
    }

    internal class Sklad : INotifyPropertyChanged
    {

        private string country;
        private string city;
        private string street;
        private string houseNumber;
        private string zip;

        public string Country { get { return country; } set { country = value; RaisePropertyChanged(country); } }

        public string City { get { return city; } set { city = value; RaisePropertyChanged(city); } }

        public string Street { get { return street; } set { street = value; RaisePropertyChanged(street); } }

        public string HouseNumber { get { return houseNumber; } set { houseNumber = value; RaisePropertyChanged(houseNumber); } }

        public string Zip { get { return zip; } set { zip = value; RaisePropertyChanged(zip); } }

        public Sklad(string country, string city, string street, string houseNumber, string zip)
        {
            Country = country;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            Zip = zip;
        }
        //List<Auto> Auta { get; set; }
        //List<Zamestnanec> Zamestnanec { get; set; }
        //List<Pobocka> Pobocky { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}