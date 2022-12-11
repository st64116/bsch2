using aplikaceZasobovani.MVVM.Model;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace aplikaceZasobovani.MVVM.ViewModel
{
    internal class SkladViewModel
    {
        public ObservableCollection<Sklad> Sklady { get; set; }

        public async Task Load()
        {
            using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
            {
                var col = db.GetCollection<Sklad>("Sklady");

                //testovací data
                //if (col.Count() < 100)
                //{
                //for (int i = 0; i < 100; i++)
                //{
                //    Sklad sklad = new Sklad("Spain"+i, "prague", "nova", "56", "485487");
                //    col.Insert(sklad);
                //}
                //}

                ObservableCollection<Sklad> sklady = new ObservableCollection<Sklad>();
                col.FindAll().ToList().ForEach(x => sklady.Add(x));
                Sklady = sklady;
            }
        }


        public async Task Add()
        {
            using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
            {
                var col = db.GetCollection<Sklad>("Sklady");
                col.Insert(new Sklad("", "", "", "", ""));
                col.EnsureIndex(x => x.Country);
            }
        }

        public async Task Delete(Sklad sklad)
        {
            using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
            {
                var col = db.GetCollection<Sklad>("Sklady");
                col.Delete(new LiteDB.BsonValue(sklad.SkladId));
            }
        }

        public async Task Update(Sklad sklad)
        {
            using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
            {
                var col = db.GetCollection<Sklad>("Sklady");
                col.Update(sklad);
            }
        }

        public SkladViewModel()
        {
            Load();
            DeleteCommand = new MyIcommand(OnDelete, CanDelete);
            AddCommand = new MyIcommand(OnAdd, CanAdd);
            UpdateCommand = new MyIcommand(OnUpdate, CanUpdate);
        }

        public MyIcommand DeleteCommand { get; set; }

        private Sklad selectedSklad;
        public Sklad SelectedSklad { get { return selectedSklad; } set { selectedSklad = value; DeleteCommand.RaiseCanExecuteChanged(); } }

        private void OnDelete()
        {
            Delete(SelectedSklad);
            Sklady.Remove(SelectedSklad);
        }

        private bool CanDelete()
        {
            return SelectedSklad != null;
        }

        public MyIcommand AddCommand { get; set; }

        private void OnAdd()
        {
            Add();
            Sklady.Add(new Sklad("", "", "", "", ""));
        }

        private bool CanAdd()
        {
            return true;
        }
        public MyIcommand UpdateCommand { get; set; }

        private void OnUpdate() {
            Update(selectedSklad);
        }

        private bool CanUpdate() => true;


        //private void textchangedeventhandler(object sender, textchangedeventargs args)
        //{
        //    if (selectedsklad != null)
        //    {
        //        update(selectedsklad);
        //    }
        //}
    }
}
