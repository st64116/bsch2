   M S B A M L   `   `   `  ????M  IaplikaceZasobovani, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:aplikaceZasobovaniaplikaceZasobovani  5   	   K*clr-namespace:aplikaceZasobovani.MVVM.ViewaplikaceZasobovani.MVVM.View  5   	   U/clr-namespace:aplikaceZasobovani.MVVM.ViewModel!aplikaceZasobovani.MVVM.ViewModel  5   	   #    aplikaceZasobovani.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:aplikaceZasobovani     5   	   <views*clr-namespace:aplikaceZasobovani.MVVM.View     5   	   E	viewModel/clr-namespace:aplikaceZasobovani.MVVM.ViewModel     5   	   
??????   ? WindowStyle$
  none=?5   	    ? 
ResizeMode$ CanResizeWithGrip=?5   	    ? Title$ Aplikace zásobování??5   	   $	??500??6%   $	??800??62    ? DataContext 5      5  /aplikaceZasobovani.MVVM.ViewModel.MainViewModel  5   
   6$    ? 	Resources 5      ,  &aplikaceZasobovani.MVVM.ViewModel.Menu   Menu??%   &	          5   
   6   5      .??5      ?? ???#22383D ?? CornerRadius$ 20??6"   ._?5   
   ?  ? ColumnDefinitions 5      ?? 5      $	??100 ?6#   ?? 5      $??1* ?6#    ? RowDefinitions 5      ?? 5      $??30 ?6    6.   ?? 5      $??1* ?6    6.   .+?5       ? ???#0C1416$??0??6(   $??0??65   ? 5!      -   5        ???#0C1416$??0??5!   B   $??1??6O   .+?5"      ??  ?? Orientation$ 
Horizontal=?6   $??Right=?66   
???   ?.+?5#      ?? -   5        $??30??5#      $??30??5$      $
??🗕??5%      $??20(?5&      $??0,0,0,5q?5'      
?????? 
???????$??0q?5*      5,      ?? 5-      -   5        $??30??5-      $??30??5.      $	??□??5/      $??20(?50      
?????? 
???????$??0q?53      54   4   ?? 55      -   5        $??30??55      $??30??56      $	??╳??57      $??15(?58      
?????? 
???????$??0q?5;      5=      5>      5?      ?? 5F      $	??100??6   ???#070A0A$??0??5H      $??1??6-   .+?5I      ?? $#??./images/truck-icon-light.png??6   $??60??6?   $??
15,15,15,5q?6K   6a   	? 5J        MenuBtnTheme#??[ 6   $??Sklady??5K      $??40??5L      
???????$??14(?5N      	 d? 	IsChecked$
	 TrueY?5O      ??5P      ?? 
   SetSkladyViewCommand ?? Source# Z
 6j   	? 5Q      #??[ 6   $??Pobočky??5R      $??40??5S      
???????$??14(?5U      ??5V      ??    SetPobockyViewCommand# Z 6k   	? 5W      #??[ 6   $
??Auta??5X      $??40??5Y      
???????$??14(?5[      ??5\      ??    SetAutaViewCommand# Z 6h   	? 5]      #??[ 6   $??Zaměstnanci??5^      $??40??5_      
???????$??14(?5a      ??5b      ??     SetZamestnanciViewCommand# Z 5c      5d      ?? 5g      $??1??6?   $??1??6?   ??6   ?? # [   ?? Path$ CurrentViewModel? ?? Mode$ OneWay=? ?? UpdateSourceTrigger$ PropertyChanged=? 5h       ?? DataType6  0aplikaceZasobovani.MVVM.ViewModel.SkladViewModel,   &aplikaceZasobovani.MVVM.View.SkladView5  /aplikaceZasobovani.MVVM.ViewModel.AutaViewModel+   %aplikaceZasobovani.MVVM.View.AutaView<  6aplikaceZasobovani.MVVM.ViewModel.ZamestnanciViewModel2   ,aplikaceZasobovani.MVVM.View.ZamestnanciView8	  2aplikaceZasobovani.MVVM.ViewModel.PobockyViewModel.
   (aplikaceZasobovani.MVVM.View.PobockyView??%@  (??       5i   #   *, +)(?? 7     5l   #   *, +)(?? n     5o   #   *, +)(?? ?     5r   #   *,	 +)?? 5i      "  6#   .R?5j        6-   5k      ?? 5l      "  6#   .R?5m        6+   5n      ?? 5o      "  6#   .R?5p        62   5q      ?? 5r      " 	 6#   .R?5s      
  6.   5t      5u      5v      5z      5{      5|      