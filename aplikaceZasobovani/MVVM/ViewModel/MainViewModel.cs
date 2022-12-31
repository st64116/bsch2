using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikaceZasobovani.MVVM.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private object currentViewModel;
        public object CurrentViewModel { get { return currentViewModel; } set { currentViewModel = value; RaisePropertyChanged("CurrentViewModel"); } }
        public MainViewModel()
        {
            App.Current.Properties["SkladId"] = null;
            CurrentViewModel = new SkladViewModel();
            SetSkladyViewCommand = new MyIcommand(SetSkladyVeiw,CanExecute);
            SetAutaViewCommand = new MyIcommand(SetAutaVeiw,CanExecute);
            SetPobockyViewCommand = new MyIcommand(SetPobockyVeiw,CanExecute);
            SetZamestnanciViewCommand = new MyIcommand(SetZamestnanciVeiw,CanExecute);
        }


        public MyIcommand SetSkladyViewCommand { get; set; }
        public MyIcommand SetAutaViewCommand { get; set; }
        public MyIcommand SetPobockyViewCommand { get; set; }
        public MyIcommand SetZamestnanciViewCommand { get; set; }
        private void SetSkladyVeiw() {
            CurrentViewModel = new SkladViewModel();
        }
        private void SetAutaVeiw() {
            CurrentViewModel = new AutaViewModel();
        }
        private void SetPobockyVeiw() {
            CurrentViewModel = new PobockyViewModel();
        }
        private void SetZamestnanciVeiw() {
            CurrentViewModel = new ZamestnanciViewModel();
        }

        private bool CanExecute() => true;


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
