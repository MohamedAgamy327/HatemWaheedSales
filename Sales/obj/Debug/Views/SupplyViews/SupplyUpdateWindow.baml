   M S B A M L   `   `   `  ����@  <Sales, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null-clr-namespace:Sales.HelpersSales.Helpers  5      U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      Q MWPFTextBoxAutoComplete, Version=1.0.0.2, Culture=neutral, PublicKeyToken=null_Dclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoCompleteWPFTextBoxAutoComplete 5      0    *Sales.Views.SupplyViews.SupplyUpdateWindow   5      'Helpersclr-namespace:Sales.Helpers  5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5      R NMahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5      T	behaviorsDclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoComplete  5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5	   	   (  "MahApps.Metro.Controls.MetroWindow   Language$  ar-EG�5   	    � Title$, &تعديل فاتورة مشتريات��5
   	   $	��600��5   	   $
��1100��5   	    � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5   	      ShowTitleBar .    ControlBorderBrush#���   5      $��RightToLeft=�5   	    � DataContext 5   	   �� *SupplyUpdate+  Locator �� Source# [  � 	Resources 5       �� MergedDictionaries	 �� Source�� 5   
    5      �� 5      $	 ..\..\Skins\MainSkin.xaml?�6%   %    5      .��5      � 
 � RowDefinitions
 5   
   �� 5      $��1* �6   �� 5      $
��1.5* �6   �� 5       $��4* �6   �� 5!      $��2* �6   �� 5"      $��1* �6   .+�5%   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   .+�5&      ��   TextBlockAddUpdateStyle#��[ 6   $	��5,0q�6I   العميل6^   �� 5'      $	��300��6   $	��5,0q�6#   {�.    TextBoxStyle#��[ 6�   ��6C   �� *SelectedSupply.Client.Name+1  +WPFTextBoxAutoComplete.AutoCompleteBehavior   AutoCompleteItemsSource 6o   �� *PlacesSuggestions+6�   �� 5(      #��[ 6   $	��5,0q�6I   التاريخ6_   (  "System.Windows.Controls.DatePicker  5)      $	��5,0q�6   $��Center=�6'   $	��300��6B     DatePickerStyle#��[ 6{      SelectedDate 6N   �� *SelectedSupply.Date+6�   5*      �� 5,   
   -   5        $
��pnl1��5,      $ 
Horizontal=�6!   $��1��6:   .+�5-      �� $��0q�6y     MetroCircleButtonStyle#���  6�   $	��5,0q�5.       +� FocusedElement 5-      ��  �� ElementName$ 	CostFocus����6T   �� *BrowseCategories+.��5/      .  (MahApps.Metro.IconPacks.PackIconOcticons  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconOcticonsKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]   Kind$ Browser=�6-   $��40��6<   $��40��6H   50      �� 51      $	��5,0q�6   $	��200��6#   $��40��6/   $��16(�6;   $
��Bold"�6J   $��calibri)�6\   {�.  $��Center=�6�   *  $MahApps.Metro.Controls.TextBoxHelper   UseFloatingWatermark .    AutoWatermark .    	Watermark$ الشركة��53      ��6E   �� *NewSupplyCategory.Company+" �� ValidatesOnNotifyDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=��� 54      $	��5,0q�6   $	��300��6#   $��40��6/   $��16(�6;   $
��Bold"�6J   $��calibri)�6\   {�.  $��Center=�6�    .  . $ 
الصنف��56      ��6D   �� *NewSupplyCategory.Category+ . $ PropertyChanged=�*  $MahApps.Metro.Controls.NumericUpDown  58      -   5        $��	CostFocus��58   %      HideUpDownButtons . $
��Left=�6O   $	��5,0q�6q   $	��120��6~   $��40��6�   $��16(�6�   $
��Bold"�6�   $��Veranda)�6�      Minimum$
 0.01Q�6�   $��Center=�6�    .  . $ التكلفة��5:         Value 6F   �� *NewSupplyCategory.Cost+ . $ PropertyChanged=� J� InputBindings 5;      �� 5<      
 �� Key$ Enter��6D    �� Command 6!   ��  �� Path$ 	AddToBill�6D   5>        5@       . $
��Left=�6>   $	��5,0q�6`   $	��120��6m   $��40��6y   $��16(�6�   $
��Bold"�6�   $��Veranda)�6�   $
 0.01Q�6�   $��Center=�6�    .  . $ الكمية��5B       6E   �� *NewSupplyCategory.Qty+ . $ PropertyChanged=� 5C      �� 5D      $ Enter��6D    6!   �� $ 	AddToBill�6D   5F        5I       . $
��Left=�6?   $	��5,0q�6a   $	��120��6n   $��40��6z   $��16(�6�   $
��Bold"�6�   $��Veranda)�6�   $ 0Q�6�   $��Center=�6�    .  . $ 
السعر��5J       6D   �� *NewSupplyCategory.Price+ . $ PropertyChanged=� 5K      �� 5L      $ Enter��6D    6!   �� $ 	AddToBill�6D   5N      �� 5O      -   5        $
��btn1��5O      $��0q�6?   #���  6S   $	��5,0q�5P      ��5O   !   �� *	AddToBill+.��5Q      ,  &MahApps.Metro.IconPacks.PackIconEntypo  �	  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconEntypoKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]] 	  Kind$ 	AddToList=�6+   $��40��6<   $��40��6H   5R      5S      � 5T   
   $��2��6    � ColumnDefinitions 5U      �� 5V      $��8* �6#   �� 5W      $��2* �6#   .+�5Y      &
   System.Windows.Controls.DataGrid
  $��0��6   $	��5,0q�6'    
  HeadersVisibility$	 All=�5\        
  SelectionUnit$  FullRow=�5]      ! J� IsManipulationEnabled! .  " 
  CanUserDeleteRows" .  # 
  CanUserAddRows# .  $ 
  AutoGenerateColumns$ .  ��5Z      �� *SupplyCategories+% �� SelectedItem% 5[      �� *SelectedSupplyCategory+& 
  Columns& 5b      0  *System.Windows.Controls.DataGridTextColumn  5c      ,  &System.Windows.Controls.DataGridColumn'   
IsReadOnly' . (   Header$( الشركة��68   )   Width5  /System.Windows.Controls.DataGridLengthConverter$
) 1.5* 6H     ColumnHeaderStyle*   HeaderStyle#* [ 6V   1  +System.Windows.Controls.DataGridBoundColumn+   Binding+ 6�   �� *	Company+  5d      ' . $( 
الصنف��68   $) 3* 6G   #* [ 6S   + 6�   �� *
Category+  5e      ' . $( التكلفة��68   $) 1* 6I   #* [ 6U   + 6�   �� *Cost+  5f      ' . $( الكمية��68   $) 1* 6H   #* [ 6T   + 6�   �� *Qty+  5g      ' . $( الإجمالى��6<   $) 1* 6N   #* [ 6Z   + 6�   �� *	CostTotal+, �� StringFormat$, {0:0.00;(0.00)}��4  .System.Windows.Controls.DataGridTemplateColumn  5h      $( 
تعديل��6.   $) 0.75* 6=   #* [ 6K   -   CellTemplate- 5i      �� 5j      .R�5k      �� #���  5l   h   $��0q�6�   ��5k   %   �� *DataContext.Edit+. �� RelativeSource. �� / �� AncestorType"/  .��5m   "     $
 Edit=�6;   5n      5o      5q        5r      $( حذف��6*   $) 0.75* 67   #* [ 6E   - 5s      �� 5t      .R�5u      �� #���  5v   g   $��0q�6�   ��5u   &   �� *DataContext.Delete+. �� "/  .��5w   "   .  (MahApps.Metro.IconPacks.PackIconMaterial  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]0   Kind$0 DeleteForever=�6=   5x      5y      5{      ��5~      �� 5        MetroDataGrid1 �� BasedOn#1 [ 6   2 �� 
TargetType"2 
 5�      .�5�      �� 3 �� Property 3 �@
 AlternatingRowBackground  GrayBrush104 �� Value#4 �  5�      5�      5�      
  5�      $��1��6   $	��5,0q�6'   $	 All=�5�      $  FullRow=�5�      $5 �� IsSynchronizedWithCurrentItem$
5 TrueY�5�      ! .  " .  # .  $ .  ��5�      �� *
OldCosts+% 5�      �� *SelectedOldCost+ 5�      d� 5�      6 d� MouseAction$6 LeftDoubleClicke�5�       5�      �� *
SelectCost+7 �� CommandParameter7 6,   �� *	OldCosts/+& 5�        5�      ' . $( التكلفة��6<   $) 0.75* 6M   #* [ 6\   + 6�   �� *Cost+  5�      $( اختيار��6.   $
) 0.5* 6>   #* [ 6K   - 5�      �� 5�      .R�5�   "   �� #���  5�   g   $��0q�6�   ��5�   *   �� *DataContext.SelectCost+. �� "/  .��5�   &     $0 SelectInverse=�6A   5�   #   5�      5�      ��5�      �� 5�      #1 [ 6   "2 
 5�      .�5�      ��  3 �@
 AlternatingRowBackground#4 �  5�      5�      5�      5�      � 5�   
   $��3��6   
 5�      �� 5�      $��1* �6    �� 5�      $��1* �6     5�      �� 5�      $��1* �6#   �� 5�      $��2* �6#   �� 5�      $��1* �6#   �� 5�      $��2* �6#   �� 5�      $��1* �6#   �� 5�      $��2* �6#   .+�5�      �� $��0��6   $��0��6%   #��[ 65   إجمالى التكلفة6w     5�      -   5        $
��Cost��5�   C   $��0��6%   $��1��62   $	��5,0q�6O   {�.  $	��200��6n    	 NumericUpDownStyle#��[	 6�    6{   �� *SelectedSupply.Cost+ . $ PropertyChanged=�6  �� 5�      #��[ 6   $��0��6I   $��2��6V   المدفوع نقداً6u     5�      -   5        $��CashPaid��5�   %   $ 0Q�65   $��0��6A   $��3��6N   $	��200��6^   #��[	 6�    6k   �� *SelectedSupply.CashPaid+ . $ PropertyChanged=�6	  �� 5�      #��[ 6   $��0��6I   $��4��6V   
الخصم6m     5�      -   5        $��DiscountPaid��5�   %   $ 0Q�69   $��0��6E   $��5��6R   $	��200��6c   #��[	 6�    6p   �� *SelectedSupply.DiscountPaid+ . $ PropertyChanged=�6  �� 5�      #��[ 6   $��1��6I   $��0��6V   المتبقى6o     5�      $��1��6&   $��1��63   {�.  $	��200��6U   #��[	 6�    6b   �� *SelectedSupply.Change+ . $ PropertyChanged=�6�   �� 5�      #��[ 6   $��1��6I   $��2��6V   الرصيد السابق6v     5�      -   5        $��OldDebt��5�   &   $��1��65   $��3��6B   {�.  $	��200��6d   #��[	 6�    6q   �� *SelectedSupply.OldDebt+ . $ PropertyChanged=�6  �� 5�      #��[ 6   $��1��6I   $��4��6V   إجمالى المتبقى6w     5�      $��1��6%   $��5��62   {�.  $	��200��6T   #��[	 6�    6a   �� *SelectedSupply.NewDebt+ . $ PropertyChanged=�6�   5�      �� 5�   
   $��Center=�6   $��Center=�63   $ 
Horizontal=�6N   $��5��6g   .+�5�      �� -   5        $
��btn2��5�      $��30��6"    
 SquareButtonStyle#��[
 6�   $	��100��6�   ��6.   �� *Save+ 6G   �� $ Focus��.��5�      �� $ 
Horizontal=�6   .+�5�      �� $��حفظ��6!     TextBlockStyle#��[ 6-   $
��10,0q�6U   6e   ,  &MahApps.Metro.IconPacks.PackIconModern  5�      �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconModernKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]8   Kind$
8 Save=�6/   5�      5�      5�      5�      5�      