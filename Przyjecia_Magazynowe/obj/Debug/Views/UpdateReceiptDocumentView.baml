   M S B A M L   `   `   `  ����O  KPrzyjecia_Magazynowe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Przyjecia_Magazynowe.ViewsPrzyjecia_Magazynowe.Views  5      :    4Przyjecia_Magazynowe.Views.UpdateReceiptDocumentView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Przyjecia_Magazynowe.Views     5      
�������.��5	      �   � ColumnDefinitions  5
   
   �� 5      �� 5      $	��600 �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��28(�6   $��Wróć��6   ��6.   �� *!NavigateReceiptDocumentsCommand+�� 5   
   $��1��6      	ViewTitle#��[  6$   $!��Edycja dokumentu przyjęcia��6G   �� 5   
   $��1��6   $��1��6"    �� TextAlignment$ Center=�6/   $��Center=�6F   $��36(�6h   ��6v   �� *ReceiptDocument.Symbol+�� 5   
   $��1��6   $��2��6#    �� 
IsEditable .  w� TextPath$
 Name��6j   $��Center=�6�   $��Center=�6�    �� DisplayMemberPath$
 Name��6   �� SelectedValuePath$ Id��6%  $��26(�6�  ��60   �� *ContractorsView+ �� Text 6�   �� *
FilterText+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� SelectedValue	 6<  �� *ReceiptDocument.ContractorId+
 �� Mode$
 TwoWay=�6�  �� 5   
   $��1��6   $��3��6!   $��36(�6.   $��Zapisz��6<   ��6M   �� *UpdateReceiptDocumentCommand+5      5      