   M S B A M L   `   `   `  ����@  <Sales, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null-clr-namespace:Sales.HelpersSales.Helpers  5      U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      fCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.MetroMahApps.Metro.Controls.Dialogs 5      4    .Sales.Views.ClientViews.ClientAccountAddDialog   5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1-Custom http://www.galasoft.ch/mvvmlight  5   	   )Helpersclr-namespace:Sales.Helpers  5      JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5	      @d2http://schemas.microsoft.com/expression/blend/2008     5
      WdialogsCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro     5      R	 NMahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks 	 5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006 	 5      1  +MahApps.Metro.Controls.Dialogs.CustomDialog   Language$  ar-EG�5      4  .MahApps.Metro.Controls.Dialogs.BaseMetroDialog   Title$ إضافة سند��5      $��RightToLeft=�5      8  2MahApps.Metro.Controls.Dialogs.DialogParticipation   Register 5      �� .��5      �� -   5        $	��pnl��5      $��10q�6    � 	Resources 5   
    �� MergedDictionaries �� Source�� 5       5      �� 5      $ ..\..\Skins\MainSkin.xaml?�6)   %    5      .+�5   
   ��    TextBlockStyle#��[  6   $	��0,5q�6=   العميل6R   �� 5   
   -   5        $��First��5       �� SelectedValuePath$ ID��6w    �� DisplayMemberPath$
 Name��6�    �� 
IsEditable .   ComboBoxStyle#��[ 5   �   "   Sales.Helpers.FocusExtension	   	IsFocused	 5       �� *	IsFocused+��6W   �� *	Clients+
 �� SelectedItem
 5      �� *SelectedClient+ �� SelectedValue 6;   �� *NewClientAccount.ClientID+.  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5          	EventName$ SelectionChanged��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5!      /  )GalaSoft.MvvmLight.Command.EventToCommand     Command 6,   �� *GetClientAccount+5"      5$      �� 5%   
   #��[  6   $	��0,5q�6<   البيان6Q   �� 5&   
    . $ ID��6P   $ 	Statement��6g   #��[ 6�   ��6&   �� *AccountStatements+
 6�   �� *SelectedStatement+ �� UpdateSourceTrigger$ PropertyChanged=�5'      �� 5)   
   #��[  6   $	��0,5q�6<   التاريخ6R   (	  "System.Windows.Controls.DatePicker	  5*   
     DatePickerStyle#��[ 6D    	  SelectedDate 6   �� *NewClientAccount.Date+6o   �� 5,   
   #��[  6   $	��0,5q�6<   التفاصيل6S   �� 5-   
     TextBoxStyle#��[ 6>   ��6   �� *NewClientAccount.Details+6f   �� 5/   
   #��[  6   $	��0,5q�6<   $"الرصيد قبل الإضافة6]   *
  $MahApps.Metro.Controls.NumericUpDown
  50   
   {�.    NumericUpDownStyle#��[ 6r    
  Value 64   �� *	OldDebt+$ PropertyChanged=�6�   �� 51   
   #��[  6   $	��0,5q�6<   المبلغ6Q   
  52   
   #��[ 6�    
  Minimum$
 0.01Q�6�    6#   �� *Amount+" �� ValidatesOnNotifyDataErrors . $ PropertyChanged=� J� InputBindings 53      �� 54      
 �� Key$ Enter��6;    �� Command 6   ��  �� Path$
 Save�6;   56      �� 57   
   #��[  6   $	��0,5q�6<   $"الرصيد بعد الإضافة6]   
  58   
   {�.  #��[ 6r    64   �� *	NewDebt+$ PropertyChanged=�6�   �� 59   
   $��0 15 0 0q�6   �� 5:   
    �� Orientation$ 
Horizontal=�6   $��0 10 0 0q�6.   .+�5;      �� -   5        $	��btn��5;        SquareButtonStyle#��[ 6s   $	��100��6�   ��6    �� *Save+ +� FocusedElement 69   ��  �� ElementName$ First��.��5<      �� $ 
Horizontal=�6   .+�5=      �� $��حفظ��6!   #��[  6-   $
��10,0q�6U   6e   , 	 &MahApps.Metro.IconPacks.PackIconModern  5>      � 	 �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconModernKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]   Kind$
 Save=�6/   5?      5@      �� 5A       �� IsCancel . $	��Add��6E   #��[ 6\   $	��100��6�   $
��10,0q�6�   ��6%   �� *CloseDialog+.��5B      �� $ 
Horizontal=�6   .+�5C      �� $��
إلغاء��6!   #��[  6/   $
��10,0q�6W   6g     5D      $ Cancel=�6/   5E      5F      5G      5H      5J      