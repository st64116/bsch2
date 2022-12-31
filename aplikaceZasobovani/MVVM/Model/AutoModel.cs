using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikaceZasobovani.MVVM.Model
{
    internal class AutoModel
    {
    }

    internal class Auto
    {
        public ObjectId AutoId { get; set; }

        private string brand;
        public string Brand { get { return brand; } set { brand = value; RaisePropertyChanged("Brand"); } }

        private string spz;
        public string Spz { get { return spz; } set { spz = value; RaisePropertyChanged("Spz"); } }

        private string? skladId;
        public string? SkladId { get { return skladId; } set { skladId = value; RaisePropertyChanged("SkladId"); } }

        private string? zamestnanecId;
        public string? ZamestnanecId { get { return zamestnanecId; } set { zamestnanecId = value; RaisePropertyChanged("ZamestnanecId"); } }

        public Auto(string brand, string spz, string? zamestnanecId, string skladId)
        {
            Brand = brand;
            Spz = spz;
            ZamestnanecId = zamestnanecId;
            SkladId = skladId;
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
