using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikaceZasobovani.MVVM.Model
{
    internal class PobockaModel
    {
    }

    internal class Pobocka : INotifyPropertyChanged
    {
        public ObjectId PobockaId { get; set; }
        private string country;
        public string Country { get { return country; } set { country = value; RaisePropertyChanged(nameof(Country)); } }
        private string city;
        public string City { get { return city; } set { city = value; RaisePropertyChanged(nameof(City)); } }
        private string street;
        public string Street { get { return street; } set { street = value; RaisePropertyChanged(nameof(Street)); } }

        private string houseNumber;
        public string HouseNumber { get { return houseNumber; } set { houseNumber = value; RaisePropertyChanged(nameof(HouseNumber)); } }
        private string zip;
        public string Zip { get { return zip; } set { zip = value; RaisePropertyChanged(nameof(Zip)); } }
        private string skladId;
        public String SkladId { get { return skladId; } set { skladId = value; RaisePropertyChanged(nameof(SkladId)); } }
        public Pobocka(string country, string city, string street, string houseNumber, string zip, String sklad)
        {
            Country = country;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            Zip = zip;
            SkladId = sklad;
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
