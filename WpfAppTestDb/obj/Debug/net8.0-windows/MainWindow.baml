   M S B A M L   `   `   `  ����G  CWpfAppTestDb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfAppTestDbWpfAppTestDb  5   	       WpfAppTestDb.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfAppTestDb     5   	     � Title$  凸(⊙▂⊙✖ )��5   	   $	��450��6   $	��800��6'    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ mainGameData��5   /      AutoGenerateColumns$ False��6   $��	5 100 5 5q�6E      
IsReadOnly$
 True��6X   "   VerticalScrollBarVisibility$
 Auto=�6j      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6<      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6H   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *Id+6H     5      $ Title��6>   $	 100 6M   	 6%   �� *Name+6M     5      $
 Year��6>   $ 60 6L   	 6%   �� *Year+6L     5      $
 Desc��6>   $	 100 6L   	 6%   �� *Desc+6L   5      �� 5   
   
 �� Orientation$
 
Horizontal=�6   $��50��6.   $��
5,10,5,355q�6:   .+�5      �� -   5         ��Name$ 
btnAddGame��5   R   $��30��6   $��80��6#   $��add game��6.   $��5 5 1 5q�6A   6f   �� 5      -   5        $ 
btnDelGame��5   E   $��28��6   $��0 17 5 5q�6!   $��0 5 5 5q�63   .��6r   
del game6|   �� 5      -   5        $��30��5      $��80��6#   $��Genres��6.   $��5q�6?   6J   �� 5       -   5        $��30��5       $��80��6#   $��
Publishers��6.   $��5q�6C   6N   �� 5!      -   5        $��30��5!      $��80��6#   $��
Developers��6.   $��5q�6C   6N   �� 5"      -   5        $ btnPlatforms��5"      $��30��6+   $��80��69   $��	Platforms��6D   $��5q�6X   6c   5#      5(      5)      