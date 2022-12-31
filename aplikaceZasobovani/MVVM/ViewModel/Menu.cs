using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace aplikaceZasobovani.MVVM.ViewModel
{
    internal class Menu
    {


        private static object currentViewModel = new SkladViewModel();
        public static object CurrentViewModel { get { return currentViewModel; } set { currentViewModel = value; NotifyStaticPropertyChanged("CurrentViewModel"); } }


        public static MyIcommand SetSkladyViewCommand = new MyIcommand(SetSkladyVeiw, CanExecute);
        public static MyIcommand SetAutaViewCommand = new MyIcommand(SetAutaVeiw, CanExecute);
        public static MyIcommand SetPobockyViewCommand = new MyIcommand(SetPobockyVeiw, CanExecute);
        public static MyIcommand SetZamestnanciViewCommand = new MyIcommand(SetZamestnanciVeiw, CanExecute);

        public Menu()
        {
        }

        private static void SetSkladyVeiw()
        {
            CurrentViewModel = new SkladViewModel();
        }
        private static void SetAutaVeiw()
        {
            CurrentViewModel = new AutaViewModel();
        }
        private static void SetPobockyVeiw()
        {
            CurrentViewModel = new PobockyViewModel();
        }
        private static void SetZamestnanciVeiw()
        {
            CurrentViewModel = new ZamestnanciViewModel();
        }

        private static bool CanExecute() => true;

        public static event PropertyChangedEventHandler StaticPropertyChanged;

        private static void NotifyStaticPropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
    }
}
