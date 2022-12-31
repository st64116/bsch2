using aplikaceZasobovani.MVVM.Model;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace aplikaceZasobovani.MVVM.ViewModel
{
    internal class SkladViewModel : INotifyPropertyChanged
    {
        private static readonly object o = new object();

        private ObservableCollection<Sklad> sklady;
        public ObservableCollection<Sklad> Sklady 
        { 
            get { return sklady; } 
            set 
            {
                sklady = value;
                RaisePropertyChanged(nameof(Sklady));
            } 
        }

        private Visibility skladyLodaing = Visibility.Visible;
        public Visibility SkladyLoading { get { return skladyLodaing; } set { skladyLodaing = value; RaisePropertyChanged(nameof(SkladyLoading)); } }

        public SkladViewModel()
        {
            DeleteCommand = new MyIcommand(OnDelete, CanDelete);
            AddCommand = new MyIcommand(OnAdd, CanAdd);
            Sklady = new ObservableCollection<Sklad>();
            Task.Run(() => Load());
            //Thread t = new Thread( new ThreadStart(Load));

        }

        public async void Load()
        {
                lock (o)
                {
                    using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                    {
                        var col = db.GetCollection<Sklad>("Sklady");

                        //testovací data
                        if (col.Count() < 10)
                        {
                            for (int i = 0; i < 100; i++)
                            {
                                Sklad sklad = new Sklad("Czech Republic" + i, "Prague", "Nova", "56", "485487");
                                col.Insert(sklad);
                            }

                            var pobocky = db.GetCollection<Pobocka>("Pobocky");
                            //pobocky
                            foreach (var sklad in col.FindAll().ToList())
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    pobocky.Insert(new Pobocka("Country" + i, "City" + i, "Street" + i, "HouseNumber", "Zip", sklad.SkladId.ToString()));
                                }
                            }

                            var zamestnanci = db.GetCollection<Zamestnanec>("Zamestnanci");
                            //zamestnanci
                            foreach (var sklad in col.FindAll().ToList())
                            {
                                for (int i = 0; i < 10; i++)
                                {
                                    zamestnanci.Insert(new Zamestnanec("FirstName" + i, "LastName" + i, i * 20, "email", sklad.SkladId.ToString()));
                                }
                            }

                            var auta = db.GetCollection<Auto>("Auta");
                            //auta
                             foreach (var sklad in col.FindAll().ToList())
                             {
                                zamestnanci.FindAll().Where(x => x.SkladId == sklad.SkladId.ToString()).ToList().ForEach(x => {
                                    auta.Insert(new Auto("brand", "spz", x.ZamestnanecId.ToString(), sklad.SkladId.ToString()));
                                });
                                auta.Insert(new Auto("brand", "spz", null, sklad.SkladId.ToString()));
                                auta.Insert(new Auto("brand", "spz", null, sklad.SkladId.ToString()));
                             }

                        }

                        ObservableCollection<Sklad> _sklady = new ObservableCollection<Sklad>();
                        col.FindAll().ToList().ForEach(x => _sklady.Add(x));
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            Sklady = _sklady;
                            SkladyLoading = Visibility.Hidden;
                        });
                    }
                }

        }


        public async Task Add(Sklad s)
        {
            lock (o)
            {
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var col = db.GetCollection<Sklad>("Sklady");
                    col.Insert(s);
                    col.EnsureIndex(x => x.Country);
                }
            }
        }

        public async Task Delete(Sklad sklad)
        {
            lock (o)
            {
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var col = db.GetCollection<Sklad>("Sklady");
                    col.Delete(new LiteDB.BsonValue(sklad.SkladId));
                }
            }
        }

        public async Task Update(Sklad sklad)
        {
            lock (o)
            {
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var col = db.GetCollection<Sklad>("Sklady");
                    col.Update(sklad);
                }
            }
        }
 
        private Sklad selectedSklad;
        public Sklad SelectedSklad 
        {
            get { return selectedSklad; } 
            set {
                selectedSklad = value;
                if(selectedSklad != null)
                    selectedSklad.PropertyChanged += ViewModelOnPropertyChanged;
                RaisePropertyChanged("SelectedSklad");
                DeleteCommand.RaiseCanExecuteChanged();  
            } 
        }

        public MyIcommand DeleteCommand { get; set; }
        private void OnDelete()
        {
            Delete(SelectedSklad);
            Sklady.Remove(SelectedSklad);
        }

        private bool CanDelete()
        {
            return selectedSklad != null;
        }

        public MyIcommand AddCommand { get; set; }

        private void OnAdd()
        {
            Sklad s = new Sklad("Country", "City", "Street", "House number", "ZIP");
            Add(s);
            Sklady.Add(s);
        }

        private bool CanAdd()
        {
            return true;
        }


        private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (selectedSklad != null) { Update(selectedSklad); }
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
