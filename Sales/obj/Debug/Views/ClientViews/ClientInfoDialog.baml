   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      fCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.MetroMahApps.Metro.Controls.Dialogs  5      @ <Sales, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null-clr-namespace:Sales.HelpersSales.Helpers 5	      .   (Sales.Views.ClientViews.ClientInfoDialog   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      WdialogsCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro     5      R NMahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      )Helpersclr-namespace:Sales.Helpers  5	      4   .MahApps.Metro.Controls.Dialogs.BaseMetroDialog    Title$  خدمة عملاء��5      $��RightToLeft=�5      8   2MahApps.Metro.Controls.Dialogs.DialogParticipation   Register 5
      �� .��5      ��  � 	Resources 5   
    �� MergedDictionaries �� Source�� 5       5      �� 5      $ ..\..\Skins\MainSkin.xaml?�6)   %    5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $	��0,5q�6.   .+�5      ��    TextBlockStyle#��[  6   $��0,5,5,5q�6@   العميل:6Z   �� 5      #��[  6   $��0,5,5,5q�6@   ��6Q   �� *SelectedClient.Name+6x   5      �� 5   
   -   5        $	��pnl��5      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5      �� #��[  6   $��Center=�6@   $	��5,0q�6[   
الصنف6o   �� 5      -   5        $��First��5       �� 
IsEditable . $	��5,0q�6m   $	��200��6z    �� SelectedValuePath$ ID��6�    �� DisplayMemberPath$ Category��6�     ComboBoxStyle#��[ 6^  "  Sales.Helpers.FocusExtension	   	IsFocused	 6$   �� *	IsFocused+��6�   �� *
Categories+
 �� SelectedValue
 6�   �� *NewClientInfo.CategoryID+ �� SelectedItem 6  �� *SelectedCategory+ �� UpdateSourceTrigger$ PropertyChanged=�5       �� 5"      $	��5,0q�6   $	��100��6%   $��40��61   $��16(�6=   $
��Bold"�6L   $��Veranda)�6^   $��Center=�6t   *   $MahApps.Metro.Controls.TextBoxHelper   UseFloatingWatermark .    AutoWatermark .    	Watermark$ 
اللون��5$      ��6D   �� *NewClientInfo.Color+" �� ValidatesOnNotifyDataErrors . $ PropertyChanged=�.��6�   5%      *   $MahApps.Metro.Controls.NumericUpDown  5'         HideUpDownButtons . $
��Left=�6?   $	��5,0q�6a   $	��100��6n   $��40��6z   $��16(�6�   $
��Bold"�6�   $��Veranda)�6�      Minimum$
 0.01Q�6�   $��Center=�6�    .  . $ 
السعر��5)         Value 6D   �� *NewClientInfo.Price+ . $ PropertyChanged=�5*      �� 5,      $	��5,0q�6   $	��100��6%   $��40��61   $��16(�6=   $
��Bold"�6L   $��Veranda)�6^   $��Center=�6t    .  . $ الملاحظات��5.      ��6H   �� *NewClientInfo.Notes+ . $ PropertyChanged=�.��6�   5/      �� 51      -   5        $	��btn��51      $��0q�6}     MetroCircleButtonStyle#���  6�   $	��5,0q�52       +� FocusedElement 51       ��  �� ElementName$ Focus����6[   �� *AddClientInfo+.��53      ,  &MahApps.Metro.IconPacks.PackIconEntypo  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconEntypoKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]   Kind$ 	AddToList=�6+   $��30��6<   $��30��6H   54      55      &   System.Windows.Controls.DataGrid  57   
   $	��0,5q�58      $	��600��5;      $	��200��5<         HeadersVisibility$	 All=�5=         SelectionUnit$ FullRow=�5>       J� IsManipulationEnabled .     CanUserDeleteRows .     CanUserAddRows .     AutoGenerateColumns .  ��59      �� *ClientCategories+ 5:      �� *SelectedClientCategory+   Columns 5D      0	  *System.Windows.Controls.DataGridTextColumn	  5F      ,
  &System.Windows.Controls.DataGridColumn 
  
IsReadOnly .  
  Header$ 
الصنف��68     
  Width5  /System.Windows.Controls.DataGridLengthConverter$  3* 6G     ColumnHeaderStyle! 
  HeaderStyle#! [ 6S   1  +System.Windows.Controls.DataGridBoundColumn"   Binding" 6�   �� *
Category+	  5G       . $ 
السعر��68   $  1* 6G   #! [ 6S   " 6�   �� *Price+	  5H       . $ 
اللون��68   $  1* 6G   #! [ 6S   " 6�   �� *Color+	  5J       . $ ملاحظات��68   $  1* 6I   #! [ 6U   " 6�   �� *Notes+#   ElementStyle# 5K      �� 5L      .�5M      �� $ �� Property$ � ��% �� Value$
% Wrap=�6G   �� 5N      $ �@��TextAlignment$% Center=�6H   5O      5Q      4  .System.Windows.Controls.DataGridTemplateColumn  5S      $ حذف��6*   $
  0.5* 67   #! [ 6D   &   CellTemplate& 5T      �� 5U      .R�5V      �� #���  5W   f   $��0q�6�   ��5V   %   �� *DataContext.DeleteClientInfo+' �� RelativeSource' �� ( �� AncestorType1   +MahApps.Metro.Controls.Dialogs.CustomDialog"(  .��5X   "   .  (MahApps.Metro.IconPacks.PackIconMaterial  �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]])   Kind$) DeleteForever=�6=   5Y      5Z      5\      ��5`      �� 5a        MetroDataGrid* �� BasedOn#* [ 6   + �� 
TargetType"+  5b      .�5c      ��  $ �@ AlternatingRowBackground  GrayBrush10#% �  5d      5e      5h      �� 5i   
   $	��0,5q�6   $ 
Horizontal=�6$   $��Center=�6=   $��Bottom=�6Z   .+�5k      �� , �� IsCancel, . $��
ClientInfo��6F     SquareButtonStyle#��[ 6d   $	��100��6�   $
��10,0q�6�   ��6%   �� *CloseDialog+.��5l      �� $ 
Horizontal=�6   .+�5m      �� $��
إلغاء��6!   #��[  6/   $
��10,0q�6W   6g   ,  &MahApps.Metro.IconPacks.PackIconModern  5n      �  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconModernKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]]-   Kind$- Cancel=�6/   5o      5p      5q      5s      5u      