   M S B A M L   `   `   `  ���� U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  	 Sales*   $Sales.Views.SaleViews.SaleShowWindow   HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  R NMahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  فاتورة مبيعات��$	��560��$
��1000�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�(   "MahApps.Metro.Controls.MetroWindow   ShowTitleBar .    ControlBorderBrush#���   $��RightToLeft=� � WindowState �� *State+ � DataContext �� *
SaleShow+  Locator �� Source# [  � 	Resources  �� MergedDictionaries	 �� Source��  �� $	 ..\..\Skins\MainSkin.xaml?�%    .��� 
 � RowDefinitions
 �� $��1* ��� $��1* ��� $��4* ��� $��2* ��� $��1* �.+���  �� Orientation$ 
Horizontal=�$��0��.+���   TextBlockAddUpdateStyle#��[ $	��5,0q�العميل�� $	��300��$	��5,0q�{�.    TextBoxStyle#��[ ���� *SelectedSale.Client.Name+�� #��[ $	��5,0q�التاريخ(  "System.Windows.Controls.DatePicker  {�.  $	��5,0q�$��Center=�$	��300��  DatePickerStyle#��[    SelectedDate �� *SelectedSale.Date+�� $ 
Horizontal=�$��1��.+��� #��[ $	��5,0q�المندوب�� $	��300��$	��5,0q�{�.  #��[ ���� *SelectedSale.Salesperson.Name+&   System.Windows.Controls.DataGrid  $��2��$	��5,0q�   HeadersVisibility$	 All=�   SelectionUnit$ FullRow=� J� IsManipulationEnabled .     CanUserDeleteRows .     CanUserAddRows .     AutoGenerateColumns .  ���� *SaleCategories+ �� SelectedItem �� *SelectedSaleCategory+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ الشركة��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 1.5*   ColumnHeaderStyle   HeaderStyle# [ 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	Company+   . $ 
الصنف��$ 3* # [  �� *
Category+   . $ 
السعر��$ 1* # [  �� *Price+   . $ الكمية��$ 1* # [  �� *Qty+   . $ الإجمالى��$
 1.5* # [  �� *
PriceTotal+ �� StringFormat$ {0:0.00;(0.00)}������   MetroDataGrid �� BasedOn# [  �� 
TargetType"  .���  �� Property  �@ AlternatingRowBackground  GrayBrush10 �� Value# �  � $��3��
 �� $��1* ��� $��1* � � ColumnDefinitions �� $��1* ��� $��2* ��� $��1* ��� $��2* ��� $��1* ��� $��2* �.+��� $��0��$��0��#��[ إجمالى الفاتورة*   $MahApps.Metro.Controls.NumericUpDown  -   $��Price��$��0��$��1��$	��5,0q�{�.  $	��200��  NumericUpDownStyle#��[     Value  �� *SelectedSale.Price+"! �� ValidatesOnNotifyDataErrors! . " �� UpdateSourceTrigger$" PropertyChanged=��� $��0��$��2��#��[ الرصيد السابق  $��0��$��3��{�.  $	��200��#��[   �� *SelectedSale.OldDebt+$" PropertyChanged=��� #��[ $��0��$��4��إجمالى المطلوب  $��0��$��5��$	��200��{�.  #��[   �� *SelectedSale.PriceTotal+$" PropertyChanged=��� #��[ $��1��$��0��المدفوع نقداً  -   $��CashPaid��{�.  $��1��$��1��$	��200��#��[   �� *SelectedSale.CashPaid+! . $" PropertyChanged=��� #��[ $��1��$��2��
الخصم  -   $��DiscountPaid��{�.  #   Minimum$# 0Q�$��1��$��3��$	��200��#��[   �� *SelectedSale.DiscountPaid+! . $" PropertyChanged=��� #��[ $��1��$��4��المتبقى  $��1��$��5��{�.  $	��200��#��[   �� *SelectedSale.NewDebt+! . $" PropertyChanged=��� $��Center=�$��Center=�$ 
Horizontal=�$��4��.+��� $��0,0,20,0q�$��Client�� 	 SquareButtonStyle#��[	 $	��150��$��30������ *Print+.���� $ 
Horizontal=�.+��� $��طباعة عادية�� 
 TextBlockStyle#��[
 $
��10,0q�1	  +MahApps.Metro.IconPacks.PackIconFontAwesome	  �
  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconFontAwesomeKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]$ 
  Kind$$ Print=��� $��0,0,20,0q�$��Location��#��[	 $	��150��$��30������ *Print+.���� $ 
Horizontal=�.+��� $��طباعة مواقع��#��[
 $
��10,0q�	  $$ Print=�#   MahApps.Metro.Controls.Badged  $	��100��   ControlzEx.BadgedEx%   Badge% �� *
RecallsQty+.���� $	��100��$��30��#��[	 ���� *
ShowRecall+.���� $ 
Horizontal=�.+��� $��المرتجعات��$	��5,0q�#��[
 ,  &MahApps.Metro.IconPacks.PackIconEntypo  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconEntypoKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]&   Kind$
& Back=��� $
��20,0q�#��[ ���� *Report+.  (System.Windows.Interactivity.Interaction'   Triggers' /  )System.Windows.Interactivity.EventTrigger  (   	EventName$( 
MouseEnter��.  (System.Windows.Interactivity.TriggerBase)   Actions.) 6  0System.Windows.Interactivity.InvokeCommandAction  *   Command* �� *
ShowReport+  $( 
MouseLeave��.)   * �� *
HideReport+