   M S B A M L   `   `   `  ����O  KPrzyjecia_Magazynowe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Przyjecia_Magazynowe.ViewsPrzyjecia_Magazynowe.Views  5      ?    9Przyjecia_Magazynowe.Views.ContractorReceiptDocumentsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Przyjecia_Magazynowe.Views     5      
�������.��5	      �   � ColumnDefinitions  5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      $��50 �6   �� 5      �� 5      �� 5      .+�5   
   �� $��1��6   $��5��6$      	ViewTitle#��[  68   $&�� Dokumenty przyjęcia kontrahenta��6[   �� 5   
   $��1��6   $��2��6!   $��Wyszukaj po symbolu��65   $��10q�6P    �� TextAlignment$ Center=�6\   $��20(�6s   �� 5   
   $��2��6   $��1��6"   $��4��6/   ��6C   �� *
FilterText+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��28(�6   $��Wróć��6   ��6.   �� *NavigateContractorsCommand+�� 5   
   -   5        $��2��5      $��3��6    $��0��61   $��6��6A   ��6U   �� * ContractorReceiptDocumentsView+ �� SelectedItem 6�   �� *SelectedReceiptDocument+ �� Mode$ TwoWay=� �� View 5      �� 5       .P�5!      �� $
��Data��6%    �� Width$	 265��63    �� DisplayMemberBinding 6?   �� *Date+	 �� HeaderContainerStyle	 5"      �� 5#      
 �� 
TargetType"
 ��6$   .�5$   "   ��  �� Property � �� �� Value$
 Left=�6O   5%      5'      �� 5(      $��Symbol��6%   $	 265��65    6A   �� *Symbol+	 5)      �� 5*      "
 ��6$   .�5+   "   ��  � ��$
 Left=�6O   5,      5.      �� 5/      $��Ilość przedmiotów��6%   $	 265��6@    6L   �� *
ItemsCount+	 50      �� 51      "
 ��6$   .�52   "   ��  � ��$
 Left=�6O   53      55      56      58      59      5:      