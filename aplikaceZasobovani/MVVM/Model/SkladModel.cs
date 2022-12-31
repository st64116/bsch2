using LiteDB;
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

        public ObjectId SkladId { get; set; }

        public string Country { get { return country; } set { country = value; RaisePropertyChanged("Country"); } }

        public string City { get { return city; } set { city = value; RaisePropertyChanged("City"); } }

        public string Street { get { return street; } set { street = value; RaisePropertyChanged("Street"); } }

        public string HouseNumber { get { return houseNumber; } set { houseNumber = value; RaisePropertyChanged("HouseNumber"); } }

        public string Zip { get { return zip; } set { zip = value; RaisePropertyChanged("Zip"); } }

        public Sklad(string country, string city, string street, string houseNumber, string zip)
        {
            Country = country;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            Zip = zip;
            //Auta = new List<Auto>();
            //Zamestnanci = new List<Zamestnanec>();
            //Pobocky= new List<Pobocka>();
        }

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