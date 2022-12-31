using aplikaceZasobovani.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Menu = aplikaceZasobovani.MVVM.ViewModel.Menu;

namespace aplikaceZasobovani.MVVM.View
{
    /// <summary>
    /// Interakční logika pro SkladView.xaml
    /// </summary>
    public partial class SkladView : UserControl
    {
        public SkladView()
        {
             InitializeComponent();
            //this.DataContext = new aplikaceZasobovani.MVVM.ViewModel.SkladViewModel();
        }

        public void ListViewScroll(object sender, System.Windows.Input.MouseWheelEventArgs e) {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void Country_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void AutaClick(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["SkladId"] = ((Button)sender).Tag.ToString();
            Menu.CurrentViewModel = new AutaViewModel();
        }       
        
        private void PobockyClick(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["SkladId"] = ((Button)sender).Tag.ToString();
            Menu.CurrentViewModel = new PobockyViewModel();
        }
        private void ZamestnanciClick(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["SkladId"] = ((Button)sender).Tag.ToString();
            Menu.CurrentViewModel = new ZamestnanciViewModel();
        }

        private void TextBlock_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void Country_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object seznam = FindName("Seznam");
            if (seznam is ScrollViewer) {
                ScrollViewer sv = seznam as ScrollViewer;
                sv.ScrollToBottom();
            }
        }
    }
}