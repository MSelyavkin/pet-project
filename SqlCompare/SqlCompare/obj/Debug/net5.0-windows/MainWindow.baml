   M S B A M L   `   `   `  ����E  ASqlCompare, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SqlCompare
SqlCompare  5   	   9!clr-namespace:SqlCompare.ControlsSqlCompare.Controls  5   	       SqlCompare.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SqlCompare     5   	   5control!clr-namespace:SqlCompare.Controls     5   	   -   5          �Name$  
BaseWindow��5
   	    � Title$ Sql Compare��5	   	   $	��620��6   $	��800��6*    � 	Resources 5       �� Source�� 5   
   $ 
Style.xaml?�6   %    .��5      � -   5         �Name$ gridMain��5       � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      -   5         ��Name$ mainWorkspace��5      65   �� 5      -   5        $ amountStrip��5      $
��Auto �61   6A   �� 5      -   5        $ 
startStrip��5      $
��Auto �60   6@    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   .+�5    
   o� $
��Auto��6   $	��Top=�6   $��6��65   .@�5!      m� -   5        $��Подключение��5!      6H   m� 5"      -   5        $��Очистить всё��5"      6G   5#      �� 5%   
   -   5         ��Name$ scroll��5%      $��1��6'   $��0��64   $��6��6D   .��5&      �� -	   5        	 ��Name$	 workingArea��5&      5'      5(      �� 5+   
   -
   5        
 ��Name$
 btnAdd��5+         	forBtnAdd#��[  66   $��2��6Z   $��0��6g   $��6��6w   .��6�   +6�   �� 5-   
   $��3��6   $��3��6"   $��2��62   .+�5.      �� .��6   0.Искать лучшее решение по:6/   	� 5/      -   5         	�Name$ rbTime��5/       d� 	IsChecked$
 TrueY�6*   .��6;   времени6D   	� 50      -   5        $ rbMemory��50      .��6,   памяти64   51      �� 52   
   -   5        $
 btnStart��52      ${�false��6:   $��3��6L   $��5��6Y     btnStyle#��[ 6i   .��6�   Запустить6�   55      58      