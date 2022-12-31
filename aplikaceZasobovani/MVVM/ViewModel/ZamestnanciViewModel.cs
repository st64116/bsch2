using aplikaceZasobovani.MVVM.Model;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace aplikaceZasobovani.MVVM.ViewModel
{
    class ZamestnanciViewModel : INotifyPropertyChanged
    {
        private static readonly object o = new object();
        private ObservableCollection<Zamestnanec> zamestnanci;
        public ObservableCollection<Zamestnanec> Zamestnanci 
        { 
            get { return zamestnanci; } 
            set { zamestnanci = value; RaisePropertyChanged(nameof(Zamestnanci));} 
        }
        private ObservableCollection<String> sklady;
        public ObservableCollection<String> Sklady 
        {
            get { return sklady; } 
            set { sklady = value; RaisePropertyChanged(nameof(Sklady)); } 
        }

        private Visibility skladyLodaing = Visibility.Hidden;
        public Visibility SkladyLoading
        {
            get { return skladyLodaing; }
            set
            {
                skladyLodaing = value;
                RaisePropertyChanged(nameof(SkladyLoading));
            }
        }

        private Visibility skladNotSelected = Visibility.Visible;
        public Visibility SkladNotSelected {
            get { return skladNotSelected; }
            set { 
                skladNotSelected = value;
                RaisePropertyChanged(nameof(SkladNotSelected));
            } }


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
                else
                {
                    SkladyLoading = Visibility.Hidden;
                    SkladNotSelected = Visibility.Visible;
                }
                AddCommand.RaiseCanExecuteChanged();
                Task.Run(()=> FilterZamestnance()); 
            } }

        private Zamestnanec _selectedZamestnanec;
        public Zamestnanec? SelectedZamestnanec {
            get { return _selectedZamestnanec; }
            set {
                _selectedZamestnanec = value;
                if (_selectedZamestnanec != null)
                    _selectedZamestnanec.PropertyChanged += ViewModelOnPropertyChanged;
                RaisePropertyChanged(nameof(SelectedZamestnanec));
                DeleteCommand.RaiseCanExecuteChanged();
            } }

        public ZamestnanciViewModel()
        {
            DeleteCommand = new MyIcommand(OnDelete, CanDelete);
            AddCommand = new MyIcommand(OnAdd, CanAdd);
            Sklady = new ObservableCollection<String>();
            Zamestnanci = new ObservableCollection<Zamestnanec>();
            Task.Run(() => Load());
            var id = App.Current.Properties["SkladId"];
            if (id != null) { SelectedSklad = id.ToString(); }
        }


        private async Task Load()
        {
            lock (o)
            {
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var sklady = db.GetCollection<Sklad>("Sklady");
                    ObservableCollection<String> _sklady = new ObservableCollection<string>();
                    sklady.FindAll().ToList().ForEach(s => _sklady.Add(s.SkladId.ToString()));
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Sklady = _sklady;
                    });
                }
            }

        }

        private async Task FilterZamestnance()
        {
            lock (o)
            {
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var col = db.GetCollection<Zamestnanec>("Zamestnanci");

                    ObservableCollection<Zamestnanec> _zamestnanci = new ObservableCollection<Zamestnanec>();
                    col.FindAll().Where(x => x.SkladId == SelectedSklad).ToList().ForEach(x => _zamestnanci.Add(x));

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        SkladNotSelected = Visibility.Hidden;
                        SkladyLoading = Visibility.Hidden;
                        Zamestnanci = _zamestnanci;
                    });
                }
            }
        }

        public async Task Add(Zamestnanec z)
        {

            lock (o)
            {
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var col = db.GetCollection<Zamestnanec>("Zamestnanci");
                    col.Insert(z);
                    col.EnsureIndex(x => x.ZamestnanecId);
                }
            }
        }

        public async Task Delete(Zamestnanec z)
        {
            lock (o)
            {
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var col = db.GetCollection<Zamestnanec>("Zamestnanci");
                    col.Delete(new LiteDB.BsonValue(z.ZamestnanecId));
                }
            }
        }

        public async Task Update(Zamestnanec z)
        {
            lock (o)
            {
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var col = db.GetCollection<Zamestnanec>("Zamestnanci");
                    col.Update(z);
                }
            }
        }

        public MyIcommand DeleteCommand { get; set; }

        private void OnDelete()
        {
            Delete(SelectedZamestnanec);
            Zamestnanci.Remove(SelectedZamestnanec);
        }

        private bool CanDelete()
        {
            return SelectedZamestnanec != null;
        }

        public MyIcommand AddCommand { get; set; }

        private void OnAdd()
        {
            Zamestnanec z = new Zamestnanec("FirstName", "LastName", 25,"email", SelectedSklad);
            Add(z);
            Zamestnanci.Add(z);
        }

        private bool CanAdd()
        {
            return SelectedSklad != null;
        }

        private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (SelectedZamestnanec != null) { Update(SelectedZamestnanec); }
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
