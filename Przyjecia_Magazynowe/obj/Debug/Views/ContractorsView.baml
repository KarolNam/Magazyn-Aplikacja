   M S B A M L   `   `   `  ����O  KPrzyjecia_Magazynowe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Przyjecia_Magazynowe.ViewsPrzyjecia_Magazynowe.Views  5      0    *Przyjecia_Magazynowe.Views.ContractorsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Przyjecia_Magazynowe.Views     5      
�������.��5	      �   � ColumnDefinitions  5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      $��50 �6   �� 5      �� 5      �� 5      .+�5   
   �� $��1��6   $��3��6$      	ViewTitle#��[  68   $��Kontrahenci��6[   �� 5   
   $��1��6   $��2��6!   $��Wyszukaj po nazwie��65   $��10q�6O    �� TextAlignment$ Center=�6[   $��20(�6r   �� 5   
   $��2��6   $��1��6"   $��4��6/   ��6C   �� *
FilterText+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��28(�6   $��Wróć��6   ��6.   �� *NavigateHomeCommand+�� 5   
   $��4��6   $��28(�6!   $��Dodaj��6/   ��6?   �� *!NavigateCreateContractorCommand+�� 5   
   $��5��6   $��28(�6!   $��Edytuj��6/   ��6@   �� *UpdateContractorCommand+�� 5    
   -   5        $��2��5       $��3��6    $��0��61   $��6��6A   ��6U   �� *ContractorsView+ �� SelectedItem 6}   �� *SelectedContractor+ �� Mode$ TwoWay=� �� View 5!      �� 5"      .P�5#      �� $��Symbol��6%    �� Width$	 250��65    �� DisplayMemberBinding 6A   �� *Symbol+	 �� HeaderContainerStyle	 5$      �� 5%      
 �� 
TargetType"
 ��6$   .�5&   "   ��  �� Property � �� �� Value$
 Left=�6O   5'      5)      �� 5*      $��Nazwa��6%   $	 550��64    6@   �� *Name+	 5+      �� 5,      "
 ��6$   .�5-   "   ��  � ��$
 Left=�6O   5.      50      51      53      54      55      