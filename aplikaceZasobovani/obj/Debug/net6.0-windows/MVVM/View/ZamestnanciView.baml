   M S B A M L   `   `   `  ????M  IaplikaceZasobovani, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:aplikaceZasobovani.MVVM.ModelaplikaceZasobovani.MVVM.Model  5      K*clr-namespace:aplikaceZasobovani.MVVM.ViewaplikaceZasobovani.MVVM.View  5      U/clr-namespace:aplikaceZasobovani.MVVM.ViewModel!aplikaceZasobovani.MVVM.ViewModel  5      I)clr-namespace:aplikaceZasobovani.MVVM.VMLaplikaceZasobovani.MVVM.VML  5	      2    ,aplikaceZasobovani.MVVM.View.ZamestnanciView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <data+clr-namespace:aplikaceZasobovani.MVVM.Model     5      <local*clr-namespace:aplikaceZasobovani.MVVM.View     5      E	viewModel/clr-namespace:aplikaceZasobovani.MVVM.ViewModel     5      9vml)clr-namespace:aplikaceZasobovani.MVVM.VML     5	      2  ,aplikaceZasobovani.MVVM.VML.ViewModelLocator    AutoHookedUpViewModel$
  True??5
       ? 	Resources 5       ?? DataType/  )aplikaceZasobovani.MVVM.Model.Zamestnanec ? RowDefinitions ? ColumnDefinitions ?? Path ?? Mode??%&  (??       5      *, +)?? 6
   "  6   .R?5      ? $??5q?6    5      ?? 5      $	??11* ?6$   ?? 5      $	??10* ?6$   ?? 5      $??0* ?6$    5      ?? 5      $??1* ?6'   ?? 5      $??1* ?6'   ?? 5      $??1* ?6'   ?? 5      $??1* ?6'   ?? 5      $??1* ?6'   .+?5      ?? $	??100??5      $??	12,5,13,0q?6'   
???????$??0??6O   $	??Top=?6_   $??3??6w   ??5      ?? $ ZamestnanecId?5   w   ?? 5      $	??100??5      $??	11,5,14,0q?6'   
???????$??1??6O   $	??Top=?6_   $??3??6w   ??5      ?? $ 	FirstName?$ TwoWay=?5   w   ?? 5       $??0,5,3,0q?5!      
???????$??2??6?   $	??Top=?6O   $??3??6g   ??5       ?? $ LastName?$ TwoWay=?5!   g   ?? 5"      $??0,5,3,0q?5#      
???????$??3??6?   $	??Top=?6O   $??3??6g   ??5"      ?? $	 Age?$ TwoWay=?5#   g   ?? 5$      
???????$??4??6K   $	??Top=?6[   $??0,5,0,0q?6s   $??3??6?   ??6   ?? $ Email?6?   5%      5&      5'       ? DataContext 5(      <  6aplikaceZasobovani.MVVM.ViewModel.ZamestnanciViewModel  5)   
   .??5,      ?  5-   
   ?? 5.      $??1* ?6   6,    50   
   ?? 51      $??75 ?6   6*   ?? 52      $??1* ?6   6*   .+?54   
   ?? $??Zamestnanci??6   $??50(?6'   
???????$??Center=?6H   $??Center=?6c   ?? 55   
   
?????????6   ?? $ Zamestnanci.Count?6Q   ? 56   
   $??1??6    57      ?? 58      $??1* ?6#   60   ?? 59      $
??84.5 ?6#   62   ?? 5:      $
??25.5 ?6#   .+?5<      ?? $??
Loading...??6   
???????$??20(?6<   $??2??6?   y?6J   ?? *SkladyLoading+ ?? UpdateSourceTrigger$ PropertyChanged=?6?   ?? 5=      $??Neni vybrán sklad!??6   
???????$??20(?6D   $??0 30 0 0q?6R   $??2??6?   y?6d   ?? *SkladNotSelected+$ PropertyChanged=?6?   ?? 5>      -   5        $??0??5>      $??Visible=?6+   .??5?      ?? 
?????? $??0q?5B      $??Stretch=?5C      ??5?      ?? *Zamestnanci+$ TwoWay=?$ PropertyChanged=?	 ?? SelectedItem	 5@      ?? *SelectedZamestnanec+5C      5D      ?? 5E      $??1??6   $??2??6)   $??5,0,5,0q?6=   $??95??6N   .+?5F      ?? $??Sklad:??6   
???????$??Center=?6=   6\   ?? 5G      $??95??5H      $??0,5,0,5q?5I      ??5G      ?? *Sklady+$ TwoWay=?$ PropertyChanged=?	 5J      ?? *SelectedSklad+$ PropertyChanged=??? 5K      $??Name:??6   
???????$??Center=?6<   6[   ?? 5L      -   5        
 ??Name$

 Name??5L      ??6(   ?? $# SelectedZamestnanec.FirstName?$ TwoWay=?$ PropertyChanged=?6?   ?? 5M      $??Surname:??6   
???????$??Center=?6?   6^   ?? 5N      -   5        $
 Surname??5N      ??6+   ?? $" SelectedZamestnanec.LastName?$ TwoWay=?$ PropertyChanged=?6?   ?? 5O      $
??Age:??6   
???????$??Center=?6;   6Z   ?? 5P      -   5        $	
 Age??5P      ??6'   ?? $ SelectedZamestnanec.Age?$ TwoWay=?$ PropertyChanged=?6?   ?? 5Q      $??Email:??6   
???????$??Center=?6=   6\   ?? 5R      -   5        $
 Email??5R      ??6)   ?? $ SelectedZamestnanec.Email?6[   ?? 5S      $	??Add??6   $??Center=?5U      $	??Top=?5V      $??95??5W      $??0,5,0,5q?5X      ??5T      ?? *
AddCommand+5X      ?? 5Y      $??Delete??6   $??Center=?5[      $	??Top=?5\      $??95??5]      $??0,5,0,5q?5^      ??5Z      ?? *DeleteCommand+5^      5_      5`      5a      5b      