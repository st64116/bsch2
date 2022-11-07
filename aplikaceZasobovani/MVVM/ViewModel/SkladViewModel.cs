using aplikaceZasobovani.MVVM.Model;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                //if (col.Count() < 10) {
                //    for (int i = 0; i < 10; i++) {
                //        Sklad sklad = new Sklad("Spain", "prague", "nova", "56", "485487");
                //        col.Insert(sklad);
                //    }
                //}

                ObservableCollection<Sklad> sklady = new ObservableCollection<Sklad>();

                col.FindAll().ToList().ForEach(x => sklady.Add(x)) ;
                Sklady = sklady;
            }
        }


        public async Task Add(Sklad sklad) {
            using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
            {
                var col = db.GetCollection<Sklad>("Sklady");
                col.Insert(sklad);
            }
        }

        public async Task Delete(Sklad sklad)
        {
            using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
            {
                var col = db.GetCollection<Sklad>("Sklady");
                col.Delete(new BsonValue(sklad));
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

    }
}
