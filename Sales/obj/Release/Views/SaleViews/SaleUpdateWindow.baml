   M S B A M L   `   `   `  ���� U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  	 Sales,   &Sales.Views.SaleViews.SaleUpdateWindow   HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  R NMahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     (   "MahApps.Metro.Controls.MetroWindow   Language$  ar-EG� � Title$* $تعديل فاتورة مبيعات��$	��600��$
��1000�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�   ShowTitleBar .    ControlBorderBrush#���   $��RightToLeft=� � DataContext �� *
SaleUpdate+  Locator �� Source# [  � 	Resources  �� MergedDictionaries	 �� Source��  �� $	 ..\..\Skins\MainSkin.xaml?�%    .��� 
 � RowDefinitions
 �� $��1* ��� $��1* ��� $
��1.5* ��� $��4* ��� $��2* ��� $��1* �.+���  �� Orientation$ 
Horizontal=�$��0��.+���   TextBlockAddUpdateStyle#��[ $	��5,0q�العميل�� $	��300��$	��5,0q�{�.    TextBoxStyle#��[ ���� *SelectedSale.Client.Name+�� #��[ $	��5,0q�التاريخ(  "System.Windows.Controls.DatePicker  $	��5,0q�$��Center=�$	��300��  DatePickerStyle#��[    SelectedDate �� *SelectedSale.Date+�� $ 
Horizontal=�$��1��.+��� #��[ $	��5,0q�المندوب�� $	��300��$	��5,0q� �� SelectedValuePath$ ID�� �� DisplayMemberPath$
 Name�� �� 
IsEditable .   ComboBoxStyle#��[ ���� *Salespersons+ �� SelectedItem �� *SelectedSalesperson+ �� SelectedValue �� *SelectedSale.SalespersonID+ �� UpdateSourceTrigger$ PropertyChanged=��� -   $
��pnl1��$ 
Horizontal=�$��2��.+��� $��0q�  MetroCircleButtonStyle#���  $	��5,0q� +� FocusedElement ��  �� ElementName$ 
PriceFocus������ *BrowseCategories+.��.  (MahApps.Metro.IconPacks.PackIconOcticons  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconOcticonsKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]   Kind$ Browser=�$��40��$��40���� $	��5,0q�$	��120��$��40��$��16(�$
��Bold"�$��calibri)�{�.  $��Center=�*   $MahApps.Metro.Controls.TextBoxHelper   UseFloatingWatermark .    AutoWatermark .    	Watermark$ الشركة������ *NewSaleCategory.Company+" �� ValidatesOnNotifyDataErrors . $ PropertyChanged=��� $	��5,0q�$	��250��$��40��$��16(�$
��Bold"�$��calibri)�{�.  $��Center=� .  . $ 
الصنف������ *NewSaleCategory.Category+ . $ PropertyChanged=�*   $MahApps.Metro.Controls.NumericUpDown  -   $��
PriceFocus��   HideUpDownButtons . $
��Left=�$	��5,0q�$	��100��$��40��$��16(�$
��Bold"�$��Veranda)�   Minimum$
 0.01Q�$��Center=� .  . $ 
السعر��   Value �� *NewSaleCategory.Price+ . $ PropertyChanged=� J� InputBindings �� 
 �� Key$ Enter�� �� Command ��   �� Path$  	AddToBill�   . $
��Left=�$	��5,0q�$	��100��$��40��$��16(�$
��Bold"�$��Veranda)�$
 0.01Q�$��Center=� .  . $ الكمية�� �� *NewSaleCategory.Qty+ . $ PropertyChanged=� �� $ Enter�� �� $  	AddToBill��� -   $
��btn1��$��0q�#���  $	��5,0q����� *	AddToBill+.��,  &MahApps.Metro.IconPacks.PackIconEntypo  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconEntypoKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]!   Kind$! 	AddToList=�$��40��$��40��� $��3��" � ColumnDefinitions" �� $��8* ��� $��2* �.+�&	   System.Windows.Controls.DataGrid	  $��0��$	��5,0q�# 	  HeadersVisibility$	# All=�$ 	  SelectionUnit$$ FullRow=�% J� IsManipulationEnabled% .  & 	  CanUserDeleteRows& .  ' 	  CanUserAddRows' .  ( 	  AutoGenerateColumns( .  ���� *SaleCategories+ �� *SelectedSaleCategory+) 	  Columns) 0
  *System.Windows.Controls.DataGridTextColumn
  ,  &System.Windows.Controls.DataGridColumn*   
IsReadOnly* . +   Header$+ الشركة��,   Width5  /System.Windows.Controls.DataGridLengthConverter$
, 1.5*   ColumnHeaderStyle-   HeaderStyle#- [ 1  +System.Windows.Controls.DataGridBoundColumn.   Binding. �� *	Company+
  * . $+ 
الصنف��$, 3* #- [ . �� *
Category+
  * . $+ 
السعر��$, 1* #- [ . �� *Price+
  * . $+ الكمية��$, 1* #- [ . �� *Qty+
  * . $+ الإجمالى��$
, 1.5* #- [ . �� *
PriceTotal+/ �� StringFormat$/ {0:0.00;(0.00)}��4  .System.Windows.Controls.DataGridTemplateColumn  $+ 
تعديل��$, 0.75* #- [ 0   CellTemplate0 �� .R��� #���  $��0q����� *DataContext.Edit+1 �� RelativeSource1 �� 2 �� AncestorType"2  .��  $
! Edit=�  $+ حذف��$, 0.75* #- [ 0 �� .R��� #���  $��0q����� *DataContext.Delete+1 �� "2  .��.  (MahApps.Metro.IconPacks.PackIconMaterial  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]3   Kind$3 DeleteForever=�����   MetroDataGrid4 �� BasedOn#4 [ 5 �� 
TargetType"5 	 .��� 6 �� Property 6 �@	 AlternatingRowBackground 	 GrayBrush107 �� Value#7 � 	 	  $��1��$	��5,0q�$8 �� IsSynchronizedWithCurrentItem$
8 TrueY�$	# All=�$$ FullRow=�% .  & .  ' .  ( .  ���� *	OldPrices+ �� *SelectedOldPrice+ d� 9 d� MouseAction$9 LeftDoubleClicke� �� *SelectPrice+: �� CommandParameter: �� *
OldPrices/+) 
  * . $+ 
السعر��$, 1* #- [ . �� *Price+  $+ اختيار��$
, 0.5* #- [ 0 �� .R��� #���  $��0q����� *DataContext.SelectPrice+1 �� "2  .��  $3 SelectInverse=����� #4 [ "5 	 .���  6 �@	 AlternatingRowBackground#7 � 	 � $��4��
 �� $��1* ��� $��1* �" �� $��1* ��� $��2* ��� $��1* ��� $��2* ��� $��1* ��� $��2* �.+��� $��0��$��0��#��[ إجمالى الفاتورة  -   $��Price��$��0��$��1��$	��5,0q�{�.  $	��200�� 
 NumericUpDownStyle#��[
  �� *SelectedSale.Price+ . $ PropertyChanged=��� $��0��$��2��#��[ الرصيد السابق  $��0��$��3��{�.  $	��200��#��[
  �� *SelectedSale.OldDebt+$ PropertyChanged=��� #��[ $��0��$��4��إجمالى المطلوب  $��0��$��5��$	��200��{�.  #��[
  �� *SelectedSale.PriceTotal+$ PropertyChanged=��� #��[ $��1��$��0��المدفوع نقداً  -   $��CashPaid��$��1��$��1��$	��200��#��[
  �� *SelectedSale.CashPaid+ . $ PropertyChanged=��� #��[ $��1��$��2��
الخصم  -   $��DiscountPaid��$ 0Q�$��1��$��3��$	��200��#��[
  �� *SelectedSale.DiscountPaid+ . $ PropertyChanged=��� #��[ $��1��$��4��المتبقى  $��1��$��5��{�.  $	��200��#��[
  �� *SelectedSale.NewDebt+ . $ PropertyChanged=��� $��Center=�$��Center=�$ 
Horizontal=�$��5��.+��� -   $
��btn2��$��30��  SquareButtonStyle#��[ $	��100������ *Save+ �� $ Focus��.���� $ 
Horizontal=�.+��� $��حفظ��  TextBlockStyle#��[ $
��10,0q�,  &MahApps.Metro.IconPacks.PackIconModern  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconModernKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]];   Kind$
; Save=��� $
��20,0q�#��[ ���� *Report+.  (System.Windows.Interactivity.Interaction<   Triggers< /  )System.Windows.Interactivity.EventTrigger  =   	EventName$= 
MouseEnter��.  (System.Windows.Interactivity.TriggerBase>   Actions.> 6  0System.Windows.Interactivity.InvokeCommandAction  ?   Command? �� *
ShowReport+  $= 
MouseLeave��.>   ? �� *
HideReport+