using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aplikaceZasobovani
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void SkladViewControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    aplikaceZasobovani.MVVM.ViewModel.SkladViewModel skladViewModelObject =
        //       new aplikaceZasobovani.MVVM.ViewModel.SkladViewModel();
        //    skladViewModelObject.Load();

        //    //SkladViewControl.DataContext = skladViewModelObject;
        //}

        private void Bar_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {
                DragMove();
            }
        }

        private void BtnMin_Click(object sender, RoutedEventArgs e) {
            Application.Current.MainWindow.WindowState = WindowState.Minimized; 
        }

        private void BtnMax_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
