   M S B A M L   `   `   `  ����@  <Sales, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null-clr-namespace:Sales.HelpersSales.Helpers  5   	   U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   )    #Sales.Views.SaleViews.SaleAddWindow   5      'Helpersclr-namespace:Sales.Helpers  5   	   HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1-Custom http://www.galasoft.ch/mvvmlight  5   	   R NMahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5	   	   R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml    	 5
   	   (  "MahApps.Metro.Controls.MetroWindow   Language$  ar-EG�5   	    � Title$* $إضافة فاتورة مبيعات��5   	   $	��600��5   	   $
��1000��5   	    � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5   	      ShowTitleBar .    ControlBorderBrush#���   5      $��RightToLeft=�5   	    � DataContext 5   	   �� *	SaleAdd+  Locator �� Source# [  � 	Resources 5       �� MergedDictionaries	 �� Source�� 5   
    5      �� 5      $	 ..\..\Skins\MainSkin.xaml?�6%   %    5      .��5      � 
 � RowDefinitions
 5   
   �� 5      $��1* �6   �� 5       $��1* �6   �� 5!      $
��1.5* �6   �� 5"      $��4* �6   �� 5#      $��2* �6   �� 5$      $��1* �6   .+�5'   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   .+�5(      ��   TextBlockAddUpdateStyle#��[ 6   $	��5,0q�6I   العميل6^   �� 5)      -   5        $��First��5)      $	��300��6%   $	��5,0q�61    �� SelectedValuePath$ ID��6�    �� DisplayMemberPath$
 Name��6�    �� 
IsEditable .   ComboBoxStyle#��[ 5*   �   "   Sales.Helpers.FocusExtension   	IsFocused 5)   >   �� *	IsFocused+��6u   �� *	Clients+ �� SelectedItem 5*      �� *SelectedClient+ �� SelectedValue 6;   �� *NewSale.ClientID+ �� UpdateSourceTrigger$ PropertyChanged=�.  (System.Windows.Interactivity.Interaction   Triggers 5+      /  )System.Windows.Interactivity.EventTrigger  5,         	EventName$ SelectionChanged��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5-      /  )GalaSoft.MvvmLight.Command.EventToCommand     Command 60   �� *GetClientAccount+5.      50      �� 51      #��[ 6   $	��5,0q�6I   التاريخ6_   (  "System.Windows.Controls.DatePicker  52      $	��5,0q�6   $��Center=�6&   $	��300��6A     DatePickerStyle#��[ 6s      SelectedDate 6M   �� *NewSale.Date+6�   53      �� 55   
   $ 
Horizontal=�6   $��1��6.   .+�57      �� #��[ 6   $	��5,0q�6I   المندوب6_   �� 58      $	��300��6   $	��5,0q�6%   $ ID��6W   $
 Name��6n    . #��[ 59   �   ��58   2   �� *Salespersons+ 59      �� *SelectedSalesperson+ 6@   �� *NewSale.SalespersonID+$ PropertyChanged=�5:      5;      �� 5=   
   -   5        $
��pnl1��5=      $ 
Horizontal=�6!   $��2��6:   .+�5>      �� $��0q�6z     MetroCircleButtonStyle#���  6�   $	��5,0q�5?       +� FocusedElement 5>      ��  �� ElementName$ 
PriceFocus����6U   �� *BrowseCategories+.��5@      .  (MahApps.Metro.IconPacks.PackIconOcticons  �	  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconOcticonsKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]] 	  Kind$ Browser=�6-   $��40��6<   $��40��6H   5A      �� 5B      $	��5,0q�6   $	��120��6#   $��40��6/   $��16(�6;   $
��Bold"�6I   $��calibri)�6[   {�.  $��Center=�6�   *
  $MahApps.Metro.Controls.TextBoxHelper 
  UseFloatingWatermark .  
  AutoWatermark .  
  	Watermark$ الشركة��5D      ��6E   �� *NewSaleCategory.Company+" �� ValidatesOnNotifyDataErrors . $ PropertyChanged=��� 5E      $	��5,0q�6   $	��250��6#   $��40��6/   $��16(�6;   $
��Bold"�6J   $��calibri)�6\   {�.  $��Center=�6�    .  . $ 
الصنف��5G      ��6D   �� *NewSaleCategory.Category+ . $ PropertyChanged=�*  $MahApps.Metro.Controls.NumericUpDown  5I      -   5        $��
PriceFocus��5I   %      HideUpDownButtons . $
��Left=�6P   $	��5,0q�6r   $	��100��6   $��40��6�   $��16(�6�   $
��Bold"�6�   $��Veranda)�6�       Minimum$
  0.01Q�6�   $��Center=�6�    .  . $ 
السعر��5K      !   Value! 6D   �� *NewSaleCategory.Price+ . $ PropertyChanged=�" J� InputBindings" 5L      �� 5M      
# �� Key$# Enter��6D   $ �� Command$ 6!   �� % �� Path$% 	AddToBill�6D   5O        5Q       . $
��Left=�6>   $	��5,0q�6`   $	��100��6m   $��40��6y   $��16(�6�   $
��Bold"�6�   $��Veranda)�6�   $
  0.01Q�6�   $��Center=�6�    .  . $ الكمية��5S      ! 6E   �� *NewSaleCategory.Qty+ . $ PropertyChanged=�" 5T      �� 5U      $# Enter��6D   $ 6!   �� $% 	AddToBill�6D   5W      �� 5Y      -   5        $
��btn1��5Y      $��0q�6?   #���  6S   $	��5,0q�5Z      ��5Y   !   �� *	AddToBill+.��5[      ,  &MahApps.Metro.IconPacks.PackIconEntypo  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconEntypoKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]&   Kind$& 	AddToList=�6+   $��40��6<   $��40��6H   5\      5]      � 5^   
   $��3��6   ' � ColumnDefinitions' 5_      �� 5`      $��8* �6#   �� 5a      $��2* �6#   .+�5d      &   System.Windows.Controls.DataGrid  $��0��6   $	��5,0q�6'   (   HeadersVisibility$	( All=�5g      )   SelectionUnit$) FullRow=�5h      * J� IsManipulationEnabled* .  +   CanUserDeleteRows+ .  ,   CanUserAddRows, .  -   AutoGenerateColumns- .  ��5e      �� *SaleCategories+ 5f      �� *SelectedSaleCategory+.   Columns. 5m      0  *System.Windows.Controls.DataGridTextColumn  5n      ,  &System.Windows.Controls.DataGridColumn/   
IsReadOnly/ . 0   Header$0 الشركة��6<   1   Width5  /System.Windows.Controls.DataGridLengthConverter$
1 1.5* 6L     ColumnHeaderStyle2   HeaderStyle#2 [ 6Z   1  +System.Windows.Controls.DataGridBoundColumn3   Binding3 6�   �� *	Company+  5o      / . $0 
الصنف��6<   $1 3* 6K   #2 [ 6W   3 6�   �� *
Category+  5p      / . $0 
السعر��6<   $1 1* 6K   #2 [ 6W   3 6�   �� *Price+  5q      / . $0 الكمية��6<   $1 1* 6L   #2 [ 6X   3 6�   �� *Qty+  5s      / . $0 الإجمالى��6<   $
1 1.5* 6N   #2 [ 6\   3 6�   �� *
PriceTotal+4 �� StringFormat$4 {0:0.00;(0.00)}��4  .System.Windows.Controls.DataGridTemplateColumn  5u      $0 
تعديل��6.   $1 0.75* 6=   #2 [ 6K   5   CellTemplate5 5v      �� 5w      .R�5x   "   �� #���  5y   h   $��0q�6�   ��5x   )   �� *DataContext.Edit+6 �� RelativeSource6 �� 7 �� AncestorType"7  .��5z   &     $
& Edit=�6?   5{   #   5|      5~        5      $0 حذف��6.   $1 0.75* 6;   #2 [ 6I   5 5�      �� 5�      .R�5�   "   �� #���  5�   g   $��0q�6�   ��5�   *   �� *DataContext.Delete+6 �� "7  .��5�   &   .  (MahApps.Metro.IconPacks.PackIconMaterial  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]8   Kind$8 DeleteForever=�6A   5�   #   5�      5�      ��5�      �� 5�        MetroDataGrid9 �� BasedOn#9 [ 6   : �� 
TargetType":  5�      .�5�      �� ; �� Property ; �@ AlternatingRowBackground  GrayBrush10< �� Value#< �  5�      5�      5�        5�      $��1��6   $	��5,0q�6'   $= �� IsSynchronizedWithCurrentItem$
= TrueY�5�      $	( All=�5�      $) FullRow=�5�      * .  + .  , .  - .  ��5�      �� *	OldPrices+ 5�      �� *SelectedOldPrice+" 5�      d� 5�      > d� MouseAction$> LeftDoubleClicke�5�      $ 5�      �� *SelectPrice+? �� CommandParameter? 6-   �� *
OldPrices/+. 5�        5�      / . $0 
السعر��6<   $1 1* 6K   #2 [ 6W   3 6�   �� *Price+  5�      $0 اختيار��6.   $
1 0.5* 6>   #2 [ 6K   5 5�      �� 5�      .R�5�   "   �� #���  5�   g   $��0q�6�   ��5�   *   �� *DataContext.SelectPrice+6 �� "7  .��5�   &     $8 SelectInverse=�6A   5�   #   5�      5�      ��5�      �� 5�      #9 [ 6   ":  5�      .�5�      ��  ; �@ AlternatingRowBackground#< �  5�      5�      5�      5�      � 5�   
   $��4��6   
 5�      �� 5�      $��1* �6    �� 5�      $��1* �6    ' 5�      �� 5�      $��1* �6#   �� 5�      $��2* �6#   �� 5�      $��1* �6#   �� 5�      $��2* �6#   �� 5�      $��1* �6#   �� 5�      $��2* �6#   .+�5�      �� $��0��6   $��0��6%   #��[ 65   إجمالى الفاتورة6x     5�      -   5        $��Price��5�   C   $��0��6%   $��1��62   $	��5,0q�6P   {�.  $	��200��6o    	 NumericUpDownStyle#��[	 6�   ! 6|   �� *NewSale.Price+ . $ PropertyChanged=�6  �� 5�      $��0��6   $��2��6%   #��[ 66   الرصيد السابق6w     5�      -   5        $��OldDebt��5�   %   $��0��64   $��3��6A   {�.  $	��200��6d   #��[	 6�   ! 6q   �� *NewSale.OldDebt+ . $ PropertyChanged=�6  �� 5�      #��[ 6   $��0��6I   $��4��6V   إجمالى المطلوب6v     5�      $��0��6&   $��35��63   $	��200��6E   {�.  #��[	 6�   ! 6d   �� *NewSale.PriceTotal+$ PropertyChanged=�6�   �� 5�      #��[ 6   $��1��6I   $��0��6V   المدفوع نقداً6u     5�      -   5        $��CashPaid��5�   %   $��1��65   $��1��6B   $	��200��6S   #��[	 6�   ! 6`   �� *NewSale.CashPaid+ . $ PropertyChanged=�6�   �� 5�      #��[ 6   $��1��6I   $��2��6V   
الخصم6m     5�      -   5        $��DiscountPaid��5�   %   $  0Q�69   $��1��6E   $��3��6R   $	��200��6c   #��[	 6�   ! 6p   �� *NewSale.DiscountPaid+ . $ PropertyChanged=�6  �� 5�      #��[ 6   $��1��6I   $��4��6V   المتبقى6p     5�      $��1��6&   $��5��63   {�.  $	��200��6U   #��[	 6�   ! 6b   �� *NewSale.NewDebt+ . $ PropertyChanged=�6�   5�      �� 5�   
   $��Center=�6   $��Center=�63   $ 
Horizontal=�6N   $��5��6g   .+�5�      �� -	   5        $
��btn2��5�      $
��10,0q�6!   $��30��6/   $��Client��6T    
 SquareButtonStyle#��[
 6�   $	��180��6�   ��6;   �� *Save+ 6n   �� $ First��.��5�      �� $ 
Horizontal=�6   .+�5�      �� $$��حفظ وطباعة عادية��6!     TextBlockStyle#��[ 6:   $
��10,0q�6b   6r   ,  &MahApps.Metro.IconPacks.PackIconModern  5�      �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconModernKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]@   Kind$
@ Save=�6/   5�      5�      �� 5�      -
   5        $
��btn3��5�      $
��10,0q�6!   $��30��6/   $��Location��6T   #��[
 6�   $	��180��6�   ��6;   �� *Save+ 6p   �� $ First��.��5�      �� $ 
Horizontal=�6   .+�5�      �� $$��حفظ وطباعة مواقع��6!   #��[ 6:   $
��10,0q�6b   6r     5�      $
@ Save=�6/   5�      5�      �� 5�      $��	20,0,20,0q�6   #��[ 6+   ��6\   �� *Report+ 5�        5�   
   $ 
MouseEnter��6   . 5�      6  0System.Windows.Interactivity.InvokeCommandAction  A   CommandA 6$   �� *
ShowReport+5�        5�      $ 
MouseLeave��6   . 5�        A 6   �� *
HideReport+5�   
   5�      5�      5�      5�      