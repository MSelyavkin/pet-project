   M S B A M L   `   `   `  ����E  ASqlCompare, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SqlCompare.WindowsSqlCompare.Windows  5   	   &     SqlCompare.Windows.ConnectWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SqlCompare.Windows     5   	     � Title$<  6Подключение к базе данных Oracle��5   	   $	��260��62   $	��700��6?    � 
ResizeMode$ NoResize=�6K    � 	Resources 5	       �� Source�� 5
   
   $ ConnectWindowStyle.xaml?�6   %    .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��4* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   ��    lblStyle#��[  6   $��0��62   $��0��6?   .��6O   	Хост:6V   �� 5   
   #��[  6   $��1��62   $��0��6?   .��6O   Имя базы:6Z   �� 5   
   #��[  6   $��2��62   $��0��6?   .��6O   Пользователь:6^   �� 5   
   #��[  6   $��3��62   $��0��6?   .��6O   Пароль:6X   �� 5    
   #��[  6   $��4��62   $��0��6?   .��6O   #!Таблица с планами:6c   �� 5!   
   -   5         ��Name$ 	tblStatus��5!      $��5��6'   $��0��64   $��2��6D   6Z   �� 5#   
   -   5         ��Name$ tbHost��5#      $��0��6"   $��1��6/   .��6?   	LOCALHOST6J   �� 5$   
   -   5        $ tbDbName��5$      $��1��6$   $��1��61   6C   �� 5%   
   -   5        $ tbUser��5%      $��2��6"   $��1��6/   6A   G� 5&   
   -   5         G�Name$ 
tbPassword��5&      $��3��6*   $��1��67   6I   �� 5'   
   -   5        $ tbPlanTableName��5'      $��4��6+   $��1��68   .��6H   
PLAN_TABLE6T   �� 5)   
     lblRightColStyle#��[ 6   $��0��6:   $��2��6G   .��6W   	Порт:6^   �� 5*   
   -   5        $ tbPort��5*      $��0��6"   $��3��6/   .��6?   15216E   �� 5,   
   -   5        	 ��Name$	 btnTest��5,      $��5��69   $��2��6F   .��6V   
Тест6\   �� 5-   
   -	   5        $	 
btnConnect��5-      $��5��6>   $��3��6K   .��6[   OK6_   5/      50      