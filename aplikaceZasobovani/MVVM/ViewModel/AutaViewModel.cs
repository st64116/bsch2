using aplikaceZasobovani.MVVM.Model;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace aplikaceZasobovani.MVVM.ViewModel
{
    class AutaViewModel : INotifyPropertyChanged
    {
        private static readonly object o = new object();
        private ObservableCollection<Auto> auta;
        public ObservableCollection<Auto> Auta
        {
            get { return auta; } 
            set { auta = value; RaisePropertyChanged(nameof(Auta)); } 
        }
        private ObservableCollection<String> sklady;
        public ObservableCollection<String> Sklady 
        { 
            get { return sklady; }
            set { sklady = value; RaisePropertyChanged(nameof(Sklady));} 
        }

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
                Task.Run(() => FilterAuta()); 
            } 
        }

        private Auto _selectedAuto;
        public Auto? SelectedAuto 
        { 
            get { return _selectedAuto; } 
            set { 
                _selectedAuto = value;
                if(_selectedAuto != null)
                    _selectedAuto.PropertyChanged += ViewModelOnPropertyChanged;
                RaisePropertyChanged(nameof(SelectedAuto));
                DeleteCommand.RaiseCanExecuteChanged();
            }
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
        public Visibility SkladNotSelected { get { return skladNotSelected; } set { skladNotSelected = value; RaisePropertyChanged(nameof(SkladNotSelected)); } }


        public AutaViewModel()
        {
            Sklady = new ObservableCollection<String>();
            Auta = new ObservableCollection<Auto>();
            DeleteCommand = new MyIcommand(OnDelete, CanDelete);
            AddCommand = new MyIcommand(OnAdd, CanAdd);
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

        private async Task FilterAuta() {
            lock (o)
            {
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var col = db.GetCollection<Auto>("Auta");

                    ObservableCollection<Auto> _auta = new ObservableCollection<Auto>();
                    col.FindAll().Where(x => x.SkladId == SelectedSklad).ToList().ForEach(x => _auta.Add(x));

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        SkladNotSelected = Visibility.Hidden;
                        SkladyLoading = Visibility.Hidden;
                        Auta = _auta;
                    });
                }
            }


        }

        private async Task Add(Auto a)
        {
            lock (o)
            {
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var col = db.GetCollection<Auto>("Auta");
                    col.Insert(a);
                    col.EnsureIndex(x => x.AutoId);
                }
            }
        }

        private async Task Delete(Auto auto)
        {
            lock (o)
            {
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var col = db.GetCollection<Auto>("Auta");
                    col.Delete(new LiteDB.BsonValue(auto.AutoId));
                }
            }
        }

        private async Task Update(Auto a)
        {
            lock (o)
            {
                using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
                {
                    var col = db.GetCollection<Auto>("Auta");
                    col.Update(a);
                }
            }
        }

        public MyIcommand DeleteCommand { get; set; }

        private void OnDelete()
        {
            Delete(SelectedAuto);
            Auta.Remove(SelectedAuto);
        }

        private bool CanDelete()
        {
            return SelectedAuto != null;
        }

        public MyIcommand AddCommand { get; set; }

        private void OnAdd()
        {
            Auto a = new Auto("Brand", "Spz", null,SelectedSklad);
            Add(a);
            Auta.Add(a);
        }

        private bool CanAdd()
        {
            return SelectedSklad != null;
        }

        private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (SelectedAuto != null) { Update(SelectedAuto); }
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
