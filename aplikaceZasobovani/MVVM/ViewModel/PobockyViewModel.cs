using aplikaceZasobovani.MVVM.Model;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace aplikaceZasobovani.MVVM.ViewModel
{
    class PobockyViewModel : INotifyPropertyChanged
    {
        private static readonly object o = new object();
        private ObservableCollection<Pobocka> pobocky;
        public ObservableCollection<Pobocka> Pobocky { 
            get { return pobocky; } 
            set{ pobocky = value; RaisePropertyChanged(nameof(Pobocky));
            } }

        private ObservableCollection<String> sklady;
        public ObservableCollection<String> Sklady 
        {
            get { return sklady; }
            set { sklady = value; RaisePropertyChanged(nameof(Sklady));} 
        }

        private Visibility skladyLodaing = Visibility.Hidden;
        public Visibility SkladyLoading 
        { 
            get { return skladyLodaing; } 
            set { skladyLodaing = value; RaisePropertyChanged(nameof(SkladyLoading)); } 
        }

        private Visibility skladNotSelected = Visibility.Visible;
        public Visibility SkladNotSelected { get { return skladNotSelected; } set { skladNotSelected = value; RaisePropertyChanged(nameof(SkladNotSelected)); } }


        private String? _selectedSklad;
        public String? SelectedSklad {
            get { return _selectedSklad; }
            set { 
                _selectedSklad = value;
                App.Current.Properties["SkladId"] = value;
                if (value != null && value != "")
                {
                    SkladyLoading = Visibility.Visible;
                    SkladNotSelected = Visibility.Hidden;
                }
                else {
                SkladyLoading = Visibility.Hidden;
                SkladNotSelected = Visibility.Visible;
                }
                AddCommand.RaiseCanExecuteChanged();
                Task.Run(()=> FilterPobocky());
            } }

        private Pobocka _selectedPobocka;
        public Pobocka? SelectedPobocka { get { return _selectedPobocka; } 
            set {
                _selectedPobocka = value;
                if (_selectedPobocka != null)
                    _selectedPobocka.PropertyChanged += ViewModelOnPropertyChanged;
                RaisePropertyChanged(nameof(SelectedPobocka));
                DeleteCommand.RaiseCanExecuteChanged(); } }

        public PobockyViewModel()
        {
            DeleteCommand = new MyIcommand(OnDelete, CanDelete);
            AddCommand = new MyIcommand(OnAdd, CanAdd);
            Sklady = new ObservableCollection<String>();
            Pobocky = new ObservableCollection<Pobocka>();
            Task.Run(() => Load());
            var id = App.Current.Properties["SkladId"];
            if (id != null)
            {
                SelectedSklad = id.ToString();
            }
        }

        private async Task Load()
        {
            lock (o)
            {
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var sklady = db.GetCollection<Sklad>("Sklady");
                    ObservableCollection<String> _sklady = new ObservableCollection<String>();
                    sklady.FindAll().ToList().ForEach(s => _sklady.Add(s.SkladId.ToString()));
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Sklady = _sklady;
                    });
                }
            }

        }

        private async Task FilterPobocky()
        {
            lock (o)
            {
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var col = db.GetCollection<Pobocka>("Pobocky");

                    ObservableCollection<Pobocka> _pobocky = new ObservableCollection<Pobocka>();
                    col.FindAll().Where(x => x.SkladId == SelectedSklad).ToList().ForEach(x => _pobocky.Add(x));
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        SkladNotSelected = Visibility.Hidden;
                        SkladyLoading = Visibility.Hidden;
                        Pobocky = _pobocky;
                    });
                }
            }

        }

        private async Task Add(Pobocka p)
        {
            lock (o)
            {
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var col = db.GetCollection<Pobocka>("Pobocky");
                    col.Insert(p);
                    col.EnsureIndex(x => x.PobockaId);
                }
            }
        }

        private async Task Delete(Pobocka p)
        {
            lock (o)
            {
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var col = db.GetCollection<Pobocka>("Pobocky");
                    col.Delete(new LiteDB.BsonValue(p.PobockaId));
                }
            }
        }

        private async Task Update(Pobocka p)
        {
            lock (o)
            {
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var col = db.GetCollection<Pobocka>("Pobocky");
                    col.Update(p);
                }
            }
        }

        public MyIcommand DeleteCommand { get; set; }

        private void OnDelete()
        {
            Delete(SelectedPobocka);
            Pobocky.Remove(SelectedPobocka);
        }

        private bool CanDelete()
        {
            return SelectedPobocka != null;
        }

        public MyIcommand AddCommand { get; set; }

        private void OnAdd()
        {
            Pobocka p = new Pobocka("Country", "City", "Street", "HouseNumber", "Zip", SelectedSklad);
            Add(p);
            Pobocky.Add(p);
        }

        private bool CanAdd()
        {
            return SelectedSklad != null;
        }

        private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (SelectedPobocka != null) { Update(SelectedPobocka); }
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
