   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      	 Sales,   &Sales.Views.SaleViews.SaleUpdateWindow   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      R NMahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   (   "MahApps.Metro.Controls.MetroWindow   Language$  ar-EG�5   	    � Title$* $تعديل فاتورة مبيعات��5	   	   $	��600��5
   	   $
��1000��5   	    � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5   	      ShowTitleBar .    ControlBorderBrush#���   5      $��RightToLeft=�5   	    � DataContext 5   	   �� *
SaleUpdate+  Locator �� Source# [  � 	Resources 5       �� MergedDictionaries	 �� Source�� 5   
    5      �� 5      $	 ..\..\Skins\MainSkin.xaml?�6%   %    5      .��5      � 
 � RowDefinitions
 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $
��1.5* �6   �� 5       $��4* �6   �� 5!      $��2* �6   �� 5"      $��1* �6   .+�5%   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   .+�5&      ��   TextBlockAddUpdateStyle#��[ 6   $	��5,0q�6I   العميل6^   �� 5'      $	��300��6   $	��5,0q�6#   {�.    TextBoxStyle#��[ 6m   ��6C   �� *SelectedSale.Client.Name+6�   �� 5(      #��[ 6   $	��5,0q�6I   التاريخ6_   (  "System.Windows.Controls.DatePicker  5)      $	��5,0q�6   $��Center=�6&   $	��300��6A     DatePickerStyle#��[ 6x      SelectedDate 6M   �� *SelectedSale.Date+6�   5*      �� 5,   
   $ 
Horizontal=�6   $��1��6.   .+�5.      �� #��[ 6   $	��5,0q�6I   المندوب6_   �� 5/      $	��300��6   $	��5,0q�6%    �� SelectedValuePath$ ID��51       �� DisplayMemberPath$
 Name��60    �� 
IsEditable .   ComboBoxStyle#��[ 52   x   ��5/   2   �� *Salespersons+ �� SelectedItem 50      �� *SelectedSalesperson+ �� SelectedValue 52      �� *SelectedSale.SalespersonID+ �� UpdateSourceTrigger$ PropertyChanged=�53      55      �� 57   
   -   5        $
��pnl1��57      $ 
Horizontal=�6!   $��2��6:   .+�58      �� $��0q�6z     MetroCircleButtonStyle#���  6�   $	��5,0q�59       +� FocusedElement 58      ��  �� ElementName$ 
PriceFocus����6U   �� *BrowseCategories+.��5:      .  (MahApps.Metro.IconPacks.PackIconOcticons  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconOcticonsKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]   Kind$ Browser=�6-   $��40��6<   $��40��6H   5;      �� 5<      $	��5,0q�6   $	��120��6#   $��40��6/   $��16(�6;   $
��Bold"�6I   $��calibri)�6[   {�.  $��Center=�6�   *   $MahApps.Metro.Controls.TextBoxHelper   UseFloatingWatermark .    AutoWatermark .    	Watermark$ الشركة��5>      ��6E   �� *NewSaleCategory.Company+" �� ValidatesOnNotifyDataErrors . $ PropertyChanged=��� 5?      $	��5,0q�6   $	��250��6#   $��40��6/   $��16(�6;   $
��Bold"�6I   $��calibri)�6[   {�.  $��Center=�6�    .  . $ 
الصنف��5A      ��6D   �� *NewSaleCategory.Category+ . $ PropertyChanged=�*   $MahApps.Metro.Controls.NumericUpDown  5C      -   5        $��
PriceFocus��5C   %      HideUpDownButtons . $
��Left=�6P   $	��5,0q�6r   $	��100��6   $��40��6�   $��16(�6�   $
��Bold"�6�   $��Veranda)�6�      Minimum$
 0.01Q�6�   $��Center=�6�    .  . $ 
السعر��5E         Value 6D   �� *NewSaleCategory.Price+ . $ PropertyChanged=� J� InputBindings 5F      �� 5G      
 �� Key$ Enter��6D    �� Command 6!   ��   �� Path$  	AddToBill�6D   5I        5K       . $
��Left=�6>   $	��5,0q�6`   $	��100��6m   $��40��6y   $��16(�6�   $
��Bold"�6�   $��Veranda)�6�   $
 0.01Q�6�   $��Center=�6�    .  . $ الكمية��5M       6E   �� *NewSaleCategory.Qty+ . $ PropertyChanged=� 5N      �� 5O      $ Enter��6D    6!   �� $  	AddToBill�6D   5Q      �� 5T      -   5        $
��btn1��5T      $��0q�6?   #���  6S   $	��5,0q�5U      ��5T   !   �� *	AddToBill+.��5V      ,  &MahApps.Metro.IconPacks.PackIconEntypo  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconEntypoKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]!   Kind$! 	AddToList=�6+   $��40��6<   $��40��6H   5W      5X      � 5Y   
   $��3��6   " � ColumnDefinitions" 5Z      �� 5[      $��8* �6#   �� 5\      $��2* �6#   .+�5_      &	   System.Windows.Controls.DataGrid	  $��0��6   $	��5,0q�6'   # 	  HeadersVisibility$	# All=�5b      $ 	  SelectionUnit$$ FullRow=�5c      % J� IsManipulationEnabled% .  & 	  CanUserDeleteRows& .  ' 	  CanUserAddRows' .  ( 	  AutoGenerateColumns( .  ��5`      �� *SaleCategories+ 5a      �� *SelectedSaleCategory+) 	  Columns) 5h      0
  *System.Windows.Controls.DataGridTextColumn
  5i      ,  &System.Windows.Controls.DataGridColumn*   
IsReadOnly* . +   Header$+ الشركة��6<   ,   Width5  /System.Windows.Controls.DataGridLengthConverter$
, 1.5* 6L     ColumnHeaderStyle-   HeaderStyle#- [ 6Z   1  +System.Windows.Controls.DataGridBoundColumn.   Binding. 6�   �� *	Company+
  5j      * . $+ 
الصنف��6<   $, 3* 6K   #- [ 6W   . 6�   �� *
Category+
  5k      * . $+ 
السعر��6<   $, 1* 6K   #- [ 6W   . 6�   �� *Price+
  5l      * . $+ الكمية��6<   $, 1* 6L   #- [ 6X   . 6�   �� *Qty+
  5m      * . $+ الإجمالى��6<   $
, 1.5* 6N   #- [ 6\   . 6�   �� *
PriceTotal+/ �� StringFormat$/ {0:0.00;(0.00)}��4  .System.Windows.Controls.DataGridTemplateColumn  5n      $+ 
تعديل��6.   $, 0.75* 6=   #- [ 6K   0   CellTemplate0 5o      �� 5p      .R�5q   "   �� #���  5r   h   $��0q�6�   ��5q   )   �� *DataContext.Edit+1 �� RelativeSource1 �� 2 �� AncestorType"2  .��5s   &     $
! Edit=�6?   5t   #   5u      5w        5x      $+ حذف��6.   $, 0.75* 6;   #- [ 6I   0 5y      �� 5z      .R�5{   "   �� #���  5|   g   $��0q�6�   ��5{   *   �� *DataContext.Delete+1 �� "2  .��5}   &   .  (MahApps.Metro.IconPacks.PackIconMaterial  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]3   Kind$3 DeleteForever=�6A   5~   #   5      5�      ��5�      �� 5�        MetroDataGrid4 �� BasedOn#4 [ 6   5 �� 
TargetType"5 	 5�      .�5�      �� 6 �� Property 6 �@	 AlternatingRowBackground 	 GrayBrush107 �� Value#7 � 	 5�      5�      5�      	  5�      $��1��6   $	��5,0q�6'   $8 �� IsSynchronizedWithCurrentItem$
8 TrueY�5�      $	# All=�5�      $$ FullRow=�5�      % .  & .  ' .  ( .  ��5�      �� *	OldPrices+ 5�      �� *SelectedOldPrice+ 5�      d� 5�      9 d� MouseAction$9 LeftDoubleClicke�5�       5�      �� *SelectPrice+: �� CommandParameter: 6-   �� *
OldPrices/+) 5�      
  5�      * . $+ 
السعر��6<   $, 1* 6K   #- [ 6W   . 6�   �� *Price+  5�      $+ اختيار��6.   $
, 0.5* 6>   #- [ 6K   0 5�      �� 5�      .R�5�   "   �� #���  5�   g   $��0q�6�   ��5�   *   �� *DataContext.SelectPrice+1 �� "2  .��5�   &     $3 SelectInverse=�6A   5�   #   5�      5�      ��5�      �� 5�      #4 [ 6   "5 	 5�      .�5�      ��  6 �@	 AlternatingRowBackground#7 � 	 5�      5�      5�      5�      � 5�   
   $��4��6   
 5�      �� 5�      $��1* �6    �� 5�      $��1* �6    " 5�      �� 5�      $��1* �6#   �� 5�      $��2* �6#   �� 5�      $��1* �6#   �� 5�      $��2* �6#   �� 5�      $��1* �6#   �� 5�      $��2* �6#   .+�5�      �� $��0��6   $��0��6%   #��[ 65   إجمالى الفاتورة6x     5�      -   5        $��Price��5�   C   $��0��6%   $��1��62   $	��5,0q�6P   {�.  $	��200��6o    
 NumericUpDownStyle#��[
 6�    6|   �� *SelectedSale.Price+ . $ PropertyChanged=�6  �� 5�      $��0��6   $��2��6%   #��[ 66   الرصيد السابق6w     5�      $��0��6&   $��3��63   {�.  $	��200��6V   #��[
 6�    6c   �� *SelectedSale.OldDebt+$ PropertyChanged=�6�   �� 5�      #��[ 6   $��0��6I   $��4��6V   إجمالى المطلوب6v     5�      $��0��6&   $��5��63   $	��200��6D   {�.  #��[
 6�    6c   �� *SelectedSale.PriceTotal+$ PropertyChanged=�6�   �� 5�      #��[ 6   $��1��6I   $��0��6V   المدفوع نقداً6u     5�      -   5        $��CashPaid��5�   %   $��1��65   $��1��6B   $	��200��6S   #��[
 6�    6`   �� *SelectedSale.CashPaid+ . $ PropertyChanged=�6�   �� 5�      #��[ 6   $��1��6I   $��2��6V   
الخصم6m     5�      -   5        $��DiscountPaid��5�   %   $ 0Q�69   $��1��6E   $��3��6R   $	��200��6c   #��[
 6�    6p   �� *SelectedSale.DiscountPaid+ . $ PropertyChanged=�6  �� 5�      #��[ 6   $��1��6I   $��4��6V   المتبقى6p     5�      $��1��6&   $��5��63   {�.  $	��200��6U   #��[
 6�    6b   �� *SelectedSale.NewDebt+ . $ PropertyChanged=�6�   5�      �� 5�   
   $��Center=�6   $��Center=�63   $ 
Horizontal=�6N   $��5��6g   .+�5�      �� -   5        $
��btn2��5�      $��30��6"     SquareButtonStyle#��[ 6�   $	��100��6�   ��6.   �� *Save+ 6G   �� $ Focus��.��5�      �� $ 
Horizontal=�6   .+�5�      �� $��حفظ��6!     TextBlockStyle#��[ 6-   $
��10,0q�6U   6e   ,  &MahApps.Metro.IconPacks.PackIconModern  5�      �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconModernKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]];   Kind$
; Save=�6/   5�      5�      �� 5�      $
��20,0q�6   #��[ 6&   ��6W   �� *Report+.  (System.Windows.Interactivity.Interaction<   Triggers< 5�      /  )System.Windows.Interactivity.EventTrigger  5�   
   =   	EventName$= 
MouseEnter��6   .  (System.Windows.Interactivity.TriggerBase>   Actions.> 5�      6  0System.Windows.Interactivity.InvokeCommandAction  ?   Command? 6$   �� *
ShowReport+5�        5�      $= 
MouseLeave��6   .> 5�        ? 6   �� *
HideReport+5�   
   5�      5�      5�      5�      