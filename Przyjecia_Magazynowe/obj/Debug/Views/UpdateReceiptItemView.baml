   M S B A M L   `   `   `  ����O  KPrzyjecia_Magazynowe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Przyjecia_Magazynowe.ViewsPrzyjecia_Magazynowe.Views  5      6    0Przyjecia_Magazynowe.Views.UpdateReceiptItemView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Przyjecia_Magazynowe.Views     5      
�������.��5	      �   � ColumnDefinitions  5
   
   �� 5      �� 5      $	��600 �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��28(�6   $��Wróć��6   ��6.   �� * NavigateReceiptDocumentCommand+�� 5   
   $��1��6      	ViewTitle#��[  6$   $	��32 (�6G   $��Edycja pozycji dokumentu��6V   �� 5   
   $��1��6   $��1��6"    �� TextAlignment$ Center=�6/   $��Center=�6F   $��28(�6h   ��6v   �� *ReceiptItem.ProductName+�� 5   
   $��1��6   $��2��6"   $ Center=�6/   $��Center=�6F   $��28(�6h   ��6v   �� *ReceiptItem.Unit+�� 5   
   $��1��6   $��3��6"   $ Center=�6/   $��Center=�6F   $��28(�6h   ��6v   �� *ReceiptItem.Quantity+ �� UpdateSourceTrigger$ PropertyChanged=� �� StringFormat$ N4���� 5   
   $��1��6   $��4��6#    �� 
IsEditable .  w� TextPath$ Symbol��6o   $��Center=�6�   $��Center=�6�    �� DisplayMemberPath$ Symbol��6   �� SelectedValuePath$ Id��6.  $��28(�6�  ��60   �� *ReceiptDocumentsView+	 �� Text	 6�   �� *
FilterText+$ PropertyChanged=�
 �� SelectedValue
 6E  �� *ReceiptItem.ReceiptDocumentId+ �� Mode$ TwoWay=�6�  �� 5   
   $��1��6   $��5��6!   $��36(�6.   $��Zapisz��6<   ��6M   �� *UpdateReceiptItemCommand+5      5       