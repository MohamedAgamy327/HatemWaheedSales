   M S B A M L   `   `   `  ���� U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4ffCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.MetroMahApps.Metro.Controls.Dialogs  	 Sales6   0Sales.Views.StoreViews.CategoryInformationDialog   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     WdialogsCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro     R NMahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1-Custom http://www.galasoft.ch/mvvmlight  1   +MahApps.Metro.Controls.Dialogs.CustomDialog   Language$  ar-EG�4   .MahApps.Metro.Controls.Dialogs.BaseMetroDialog   Title$ بيانات الصنف��$��RightToLeft=�8   2MahApps.Metro.Controls.Dialogs.DialogParticipation   Register �� .���� -   $	��pnl��$��10q� � 	Resources  �� MergedDictionaries �� Source��  �� $ ..\..\Skins\MainSkin.xaml?�%    .+���  �� Orientation$ 
Horizontal=�$	��0,5q�.+���    TextBlockStyle#��[  $��0,5,10,5q�المخزن:�� #��[  $��0,5,50,5q����� *#!SelectedCategoryInformation.Stock+�� #��[  $��0,5,10,5q�الشركة:�� #��[  $��0,5,5,5q����� *%#SelectedCategoryInformation.Company+�� $ 
Horizontal=�$	��0,5q�.+��� #��[  $��0,5,10,5q�الصنف:�� #��[  $��0,5,50,5q����� *&$SelectedCategoryInformation.Category+�� #��[  $��0,5,10,5q�اللون:�� #��[  $��0,5,5,5q����� *#!SelectedCategoryInformation.Color+�� $ 
Horizontal=�$	��0,5q�.+��� #��[  $��0,5,5,5q�!رصيد بداية المدة:�� #��[  $��0,5,5,5q����� *&$SelectedCategoryInformation.QtyStart+�� $ 
Horizontal=�$	��0,5q�.+��� #��[  $��0,5,5,5q�الكمية:�� #��[  $��0,5,5,5q����� *!SelectedCategoryInformation.Qty+�� $ 
Horizontal=�$	��0,5q�.+��� #��[  $��0,5,5,5q�حد الطلب:�� #��[  $��0,5,5,5q����� **(SelectedCategoryInformation.RequestLimit+�� $ 
Horizontal=�$	��0,5q�.+��� #��[  $��0,5,5,5q�التكلفة:�� #��[  $��0,5,5,5q����� *" SelectedCategoryInformation.Cost+�� $ 
Horizontal=�$	��0,5q�.+��� #��[  $��0,5,5,5q�السعر:�� #��[  $��0,5,5,5q����� *#!SelectedCategoryInformation.Price+�� $ 
Horizontal=�$	��0,5q�.+��� #��[  $��0,5,5,5q�إجمالى التكلفة:�� #��[  $��0,5,5,5q����� *'%SelectedCategoryInformation.TotalCost+ �� StringFormat$ {0:0.00;(0.00)}���� $ 
Horizontal=�$	��0,5q�.+��� #��[  $��0,5,5,5q�إجمالى السعر:�� #��[  $��0,5,5,5q����� *(&SelectedCategoryInformation.TotalPrice+$ {0:0.00;(0.00)}���� $��0 5 0 5q��� $ 
Horizontal=�$	��0,5q�.+��� #��[  $��Center=�$
��10,0q�من(  "System.Windows.Controls.DatePicker  $	��200��$
��10,0q�  DatePickerStyle#��[    SelectedDate �� *
DateFrom+	 �� UpdateSourceTrigger$	 PropertyChanged=�.  (System.Windows.Interactivity.Interaction
   Triggers
 /  )System.Windows.Interactivity.EventTrigger     	EventName$ SelectedDateChanged��.  (System.Windows.Interactivity.TriggerBase   Actions. /  )GalaSoft.MvvmLight.Command.EventToCommand     Command �� *GetInformation+�� #��[  $��Center=�$
��10,0q�إلى  $	��200��$
��10,0q�#��[  �� *DateTo+$	 PropertyChanged=�
   $ SelectedDateChanged��.    �� *GetInformation+�� $ 
Horizontal=�$	��0,5q�.+��� #��[  $��0,5,5,5q�;9الكمية الموردة خلال فترة محددة:�� #��[  $��0,5,5,5q����� *'%SelectedCategoryInformation.SupplyQty+�� $ 
Horizontal=�$	��0,5q�.+��� #��[  $��0,5,5,5q�FDتكلفة الكمية الموردة خلال فترة محددة:�� #��[  $��0,5,5,5q����� *(&SelectedCategoryInformation.SupplyCost+�� $ 
Horizontal=�$	��0,5q�.+��� #��[  $��0,5,5,5q�;9الكمية المباعة خلال فترة محددة:�� #��[  $��0,5,5,5q����� *%#SelectedCategoryInformation.SaleQty+�� $ 
Horizontal=�$	��0,5q�.+��� #��[  $��0,5,5,5q�B@سعر الكمية المباعة خلال فترة محددة:�� #��[  $��0,5,5,5q����� *'%SelectedCategoryInformation.SalePrice+�� $��0 10 0 0q��� $ 
Horizontal=�$��0 10 0 0q�.+���  �� IsCancel . $��Information��  SquareButtonStyle#��[ $	��100������ *CloseDialog+.���� $ 
Horizontal=�.+��� $��
إلغاء��#��[  $
��10,0q�,	  &MahApps.Metro.IconPacks.PackIconModern	  �
  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconModernKind, MahApps.Metro.IconPacks, Version=1.9.1.0, Culture=neutral, PublicKeyToken=null]] 
  Kind$ Cancel=�