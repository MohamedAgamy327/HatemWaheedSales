   M S B A M L   `   `   `  ����@  <Sales, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null-clr-namespace:Sales.HelpersSales.Helpers  5      U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      fCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.MetroMahApps.Metro.Controls.Dialogs 5      Q MWPFTextBoxAutoComplete, Version=1.0.0.2, Culture=neutral, PublicKeyToken=null_Dclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoCompleteWPFTextBoxAutoComplete 5      1    +Sales.Views.StoreViews.CategoryUpdateDialog   5      'Helpersclr-namespace:Sales.Helpers  5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      WdialogsCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro     5      Z	behaviorsDclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoComplete     5      R NMahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      4  .MahApps.Metro.Controls.Dialogs.BaseMetroDialog    Title$  تعديل صنف��5      $��RightToLeft=�5      8  2MahApps.Metro.Controls.Dialogs.DialogParticipation   Register 5      �� .��5      �� -   5        $	��pnl��5      $��10q�6    � 	Resources 5   
    �� MergedDictionaries �� Source�� 5       5      �� 5      $ ..\..\Skins\MainSkin.xaml?�6)   %    5      .+�5   
   ��    TextBlockStyle#��[  6   $	��0,5q�6<   المخزن6Q   �� 5   
    �� SelectedValuePath$ ID��63    �� DisplayMemberPath$
 Name��6J    �� 
IsEditable .   ComboBoxStyle#��[ 5   �   ��5      �� *Stocks+ �� SelectedItem 5      �� *SelectedStock+	 �� SelectedValue	 6:   �� *SelectedCategory.StockID+"
 �� ValidatesOnNotifyDataErrors
 .  �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   #��[  6   $	��0,5q�6<   الشركة6Q   �� 5   
   {�.  $ ID��6H   $
 Name��6_    . #��[ 5   �   ��5   &   �� *	Companies+ 5      �� *SelectedCompany+	 6<   �� *SelectedCategory.CompanyID+
 . $ PropertyChanged=�6�   �� 5!   
   #��[  6   $	��0,5q�6<   
الصنف6P   �� 5"   
   {�.    TextBoxStyle#��[ 6�   ��6'   �� *SelectedCategory.Name+
 . $ PropertyChanged=�6�   �� 5#   
   #��[  6   $	��0,5q�6<   
اللون6P   �� 5%   
   #��[ 6�   ��6   �� *SelectedCategory.Color+
 . $ PropertyChanged=�1  +WPFTextBoxAutoComplete.AutoCompleteBehavior   AutoCompleteItemsSource 6�   �� *ColorsSuggestions+6�   �� 5'   
   #��[  6   $	��0,5q�6<    رصيد بداية المدة6[   *  $MahApps.Metro.Controls.NumericUpDown  5(   
      Minimum$ 0Q�6!     NumericUpDownStyle#��[ 6�   {�6-   �� *	CanEdit+   Value 6L   �� *SelectedCategory.QtyStart+
 . $ PropertyChanged=� J� InputBindings 5)      �� 5*      
 �� Key$ Enter��6=    �� Command 6   ��  �� Path$ Update�6=   5,      �� 5.   
   #��[  6   $	��0,5q�6<   التكلفة6R     5/   
   $ 0Q�6!   #��[ 6�    6-   �� *SelectedCategory.Cost+
 . $ PropertyChanged=� 50      �� 51      $ Enter��6=    6   �� $ Update�6=   53      �� 55   
   #��[  6   $	��0,5q�6<   
السعر6P     56   
   $ 0Q�6!   #��[ 6�   "   Sales.Helpers.FocusExtension   	IsFocused 6-   �� *	IsFocused+ 6d   �� *SelectedCategory.Price+
 . $ PropertyChanged=� 57      �� 58      $ Enter��6=    6   �� $ Update�6=   5:      �� 5<   
   #��[  6   $	��0,5q�6<   حد الطلب6S     5=   
   $ 0Q�6"   #��[ 6�    6.   �� *SelectedCategory.RequestLimit+
 . $ PropertyChanged=� 5>      �� 5?      $ Enter��6=    6   �� $ Update�6=   5A      )  #MahApps.Metro.Controls.ToggleSwitch  5C   
   $��Center=�6S      OnLabel$ ملغى��6p      OffLabel$ غير ملغى��6     ToggleSwitchStyle#��[ 6�      	IsChecked 6    �� *SelectedCategory.Isarchived+6�   �� 5G   
   $��0 15 0 0q�6   �� 5H   
    �� Orientation$ 
Horizontal=�6   $��0 10 0 0q�6.   .+�5I      �� -   5        $	��btn��5I        SquareButtonStyle#��[ 6;   $	��100��6f   ��6    �� *Update+.��5J      �� $ 
Horizontal=�6   .+�5K      �� $��
تحديث��6!   #��[  6/   $
��10,0q�6W   6g   .  (MahApps.Metro.IconPacks.PackIconMaterial  5L      �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]   Kind$ Update=�61   5M      5N      �� 5O       �� IsCancel . $��Update��6E   #��[ 6_   $	��100��6�   $
��10,0q�6�   ��6%   �� *CloseDialog+.��5P      �� $ 
Horizontal=�6   .+�5Q      �� $��
إلغاء��6!   #��[  6/   $
��10,0q�6W   6g   ,	  &MahApps.Metro.IconPacks.PackIconModern	  5R      �
  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconModernKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]] 
  Kind$ Cancel=�6/   5S      5T      5U      5V      5X      