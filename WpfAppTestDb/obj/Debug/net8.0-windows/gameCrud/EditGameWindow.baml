   M S B A M L   `   `   `  ����G  CWpfAppTestDb, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WpfAppTestDb.gameCrudWpfAppTestDb.gameCrud  5   	   *    $WpfAppTestDb.gameCrud.EditGameWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:WpfAppTestDb.gameCrud     5   	   -   5          �Name$  EditWind��5
   	    � Title$ EditGameWindow��5   	   $	��720��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�5	   	    � DataContext 5   	   ��  �� RelativeSource �� *Self+.��5      � -   5         �Name$ MainEditGameGrid��5   !    � ShowGridLines$ False��6    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      $��50 �6   6*    � ColumnDefinitions 5   
   �� 5      $��80 �6   6,   �� 5      6!   �� 5      $��75 �6   6,   �� 5      6!   �� 5      $��60 �6   6,   .+�5    
   �� -   5        	 ��Name$	 
btnTestBtn��5    .   $��0��6   $��6��6!   $��5q�6B   .��6f   TEST6l   �� 5!   
   $��0��6   $��0��6$   $��Right=�61   $��Center=�6M   Name:6p   �� 5"   
   -   5        
 ��Name$
 
txtBoxName��5"   F   $��1��6   $��0��6"   $��5q�6/   $��50��6:   $��Center=�6Z   6~   �� 5#   
   $��0��6   $��1��6$   $��Right=�61   $��Center=�6M   Description:6w   �� 5$   
   -   5        $
 
txtBoxDesc��5$   K   $��1��6   $��1��6"   $��3��6/   $��5q�6@    �� AcceptsReturn$
 True��6_    �� TextWrapping$
 Wrap=�6t   " �� VerticalScrollBarVisibility$
 Auto=�6�    �� 	IsEnabled$
 True��6�    � Language$ ru-ru�6�   .��6�   5%   
   �� 5&   
   $��2��6   $��0��6$   $��5q�61   $��Right=�6<   $��Center=�6X   Genre:6}   &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ 
dtGrdGenre��5'   �   $��3��6   $��0��6#   $��2��60   $��5q�6A   $	��Top=�6L   "   VerticalScrollBarVisibility$
 Auto=�6d      
IsReadOnly$
 True��6�      AutoGenerateColumns$ False��6�      Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6<      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+6H     5*      $ Title��6>   $	 100 6M    6%   �� *Name+6M   5,      �� 5-   
   $��2��6   $��2��6$   $��5q�61   $��Center=�6<   $��Right=�6W   
Publisher:6�   �� 5.   
   -   5         ��Name$ tbSelectedPub��5.   r   $��3��6   $��2��6$   $��5q�61   $��Center=�6<   $
��Left=�6W   selected Publisher6�   �� 50   
   $��2��6   $��3��6$   $��5q�61   $��Center=�6<   $��Right=�6W   
Developer:6�   �� 51   
   -   5        $ tbSelectedDev��51   r   $��3��6   $��3��6$   $��5q�61   $��Center=�6<   $
��Left=�6W   selected Dev6�   �� 53   
   $��4��6   $��0��6%    �� Orientation$ 
Horizontal=�62   $
��Left=�6K   $��5q�6f   .+�54      �� -	   5        $	 btnAddGenre��54       $��2q�6   $��5q�65   {�6[   �� *Some+.��6v   +6{   �� 55      -
   5        $	 btnDelGenre��55       $��2q�6   $��5q�65   .��6[   -6`   56      �� 58   
   $��4��6   $��2��6%   $ 
Horizontal=�62   $
��Left=�6K   $��5q�6f   .+�59      �� -   5        $	 	btnAddPub��59       $��2q�6   $��5q�63   .��6W   +6Z   �� 5:      -   5        $	 	btnDelPub��5:       $��2q�6   $��5q�63   .��6W   -6Z   5;      �� 5=   
   $��4��6   $��3��6%   $ 
Horizontal=�62   $
��Left=�6K   $��5q�6f   .+�5>      �� -   5        $	 	btnAddDev��5>       $��2q�6   $��5q�63   .��6W   +6Z   �� 5?      -   5        $	 	btnDelDev��5?       $��2q�6   $��5q�63   .��6W   -6Z   5@      �� 5B      $��2��6   $��4��6*   $��5q�67   $��Center=�6B   $��Right=�6]   	Platform:6�     5C   
   -   5        $ 	dtGrdPlat��5C   o   $��3��6   $��4��6#   $��5q�60   $��2��6;   $
 Auto=�6L   $ False��6�    5D        5E      $ ID��6<   $ 50 6H    6%   �� *Id+6H     5F      $ Title��6>   $	 100 6M    6%   �� *Name+6M   5H      �� 5J   
   $��4��6   $��4��6%   $ 
Horizontal=�62   $
��Left=�6K   $��5q�6f   .+�5K      �� -   5        $	 btnAddPlatform��5K       $��2q�6   $��5q�68   .��6a   +6d   �� 5L      -   5        $	 btnDelPlatform��5L       $��2q�6   $��5q�68   .��6a   -6d   5M      �� 5Q   
   $��1��6   $��6��6%   $��3��62   $��5q�6F   $ 
Horizontal=�6Q   $��Center=�6j   .+�5R      �� -   5        $	 btnOk��5R       $��5q�6   $��50��6/   $��5q�6:   .��6G   Ok6K   �� 5S      -   5        $	 	btnCancel��5S       $��5q�6   $��50��63   $��5q�6>   .��6b   Cancel6j   5T      �� 5U   
   $��0��6   $��4��6$   $��Center=�61   $��Center=�6L   $��5q�6i   
Rel Year6~   �� 5V   
   -   5        $
 	tbRelYear��5V   :   $��1��6   $��4��6"   $��5q�6/   $��40��6M   $��Center=�6Y    �� 	MaxLength$ 4��6�   6�   5W      5X      