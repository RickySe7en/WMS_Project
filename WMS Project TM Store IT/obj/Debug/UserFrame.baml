   M S B A M L   `   `   `  ����I  EWpf.TabControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC2clr-namespace:Wpf.Controls;assembly=Wpf.TabControlWpf.Controls  5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   R NWMS Project TM Store IT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WMS_Project_TM_Store_ITWMS_Project_TM_Store_IT 5   	   1&clr-namespace:System;assembly=mscorlibSystem 5   	   '   !WMS_Project_TM_Store_IT.UserFrame   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @r2clr-namespace:Wpf.Controls;assembly=Wpf.TabControl     5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   ;assembly&clr-namespace:System;assembly=mscorlib     5   	   7local%clr-namespace:WMS_Project_TM_Store_IT     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$!  Warehouse Management System��5	   	    � WindowState$ 	Maximized=�6-    � 
ResizeMode$ CanMinimize=�6G   .��5
      � -   5        $��GridTop��5
       � UseLayoutRounding .  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��7* �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6   �� 5      $	��150 �6   .+�5   
   �� -   5        $��CustomerLogo��5   -   $��0��6   $��0��6    .��5      �� $!��Resources/customer logo.png��6   $
��Fill=�69   5      �� 5   
   -   5        $��OurLogo��5   -   $��2��6   $��0��6    .��5      �� $��Resources/our-logo.png��6   $
��Fill=�64   5      �� 5   
   -   5        $��	KeepSpace��5      $��1��6!   $��0��61   
�������5      �� 5   
   -   5        $��scrollViewer��5      $��Disabled=�6+   $��Visible=�6T   $��1��6z   .��5      � -   5        $��LeftNav��5       5      �� 5      $	��140 �6$   �� 5       $	��140 �6$   �� 5!      $	��140 �6$   �� 5"      $	��140 �6$   �� 5#      $	��140 �6$   �� 5$      $	��140 �6$   �� 5%      $	��140 �6$   .+�5)      �� -   5        $��	dashboard��5)      $��0��6+   $��0��6;   
�������.��5*      �� $
��Fill=�6   $��Resources\1-dashboard.png��6+   5+      �� 5,      -   5        $��	inventory��5,      $��0��6+   $��1��6;   
�������.��5-      �� $
��Fill=�6   $��Resources\2-inventory.png��6+   5.      �� 5/      -	   5        $��inout��5/   *    K� ZIndex$ 2��6   $��0��68   $��2��6H   
�������.��53      �� $
��Fill=�6   $��Resources\3-inout.png��6+   54      � 55      -
   5        $��SubGrid��55   #   $	��133��6   $��2��62   $��0��6?   $ 1��6O    56      �� 57      $��1* �6(   �� 58      $��1* �6(   �� 59      $��1* �6(   �� 5:      $��1* �6(   .+�5<      �� -   5        $��Outbound��5<      $��0��6-   .��6Q   
Outbound6[   �� 5=      -   5        $��Inbound��5=      $��1��6,   .��6O   	Inbound6X   �� 5>      -   5        $��Returns��5>      $��2��6,   .��6O   	Returns6X   �� 5?      -   5        $
��dock��5?      $��3��6)   .��6I   Dock6O   5@      �� 5A      -   5        $��tasks��5A      $��0��6'   $��3��67   
�������.��5E      �� $
��Fill=�6   $��Resources\4-tasks.png��6+   5F      �� 5G      -   5        $��reports��5G      $��0��6)   $��4��69   
�������.��5K      �� $
��Fill=�6   $��Resources\5-reports.png��6+   5L      �� 5M      -   5        $��billing��5M      $��0��6(   $��5��68   
�������.��5R      �� $
��Fill=�6   $��Resources\6-billing.png��6+   5S      �� 5T      -   5        $��admin��5T      $��0��6'   $��6��67   
�������.��5X      �� $
��Fill=�6   $��Resources\7-admin.png��6+   5Y      5`      5a      � 5b   
   -   5        $��GridContent��5b      $��1��6"   $��1��6/   $��2��6?   .+�5c         Wpf.Controls.TabControl  -   5          Name$ 
tabControl��5c   I   $��1��6   $��0��6+   $��9��68      TabItemMinWidth$	 100Q�5d      	   TabItemMaxWidth$		 300Q�6   
   TabItemMinHeight$
 30Q�61      TabItemMaxHeight$ 50Q�6G   $��Center=�5e         TabItemNormalBackground 5j      �� 5k       �� EndPoint$	 0,1&�6*    �� 
StartPoint$	 0,0&�69   .��5l      �  � Color$ 	#FFFCFDFD��6'    � Offset$ 0Q�69   � 5m      $ 	#FFE5EAF5��6'   $	 0.3Q�69   � 5n      $ 	#FFCFD7EB��6'   $	 0.3Q�69   � 5o      $ 	#FFE0E5F5��6'   $	 0.7Q�69   � 5p      $ 	#FFECEEFC��6'   $ 1Q�69   5q          TabItemSelectedBackground 5u      �� 5v      $	 0,1&�6*   $	 0,0&�69   .��5w      � $ 	#FFFBFDFE��6'   $ 0Q�69   � 5x      $ 	#FFEAF6FB��6'   $	 0.3Q�69   � 5y      $ 	#FFCEE7FA��6'   $	 0.3Q�69   � 5z      $ 	#FFB9D1FA��6'   $ 1Q�69   5{      !   TabItemMouseOverBackground 5      �� 5�      $	 0,1&�6*   $	 0,0&�69   .��5�      � $ 	#FFFCFDFD��6'   $ 0Q�69   � 5�      $ 	#FFC6DDF7��6'   $	 0.3Q�69   � 5�      $ 	#FF99C6EE��6'   $	 0.3Q�69   � 5�      $ 	#FFB6D6F1��6'   $	 0.7Q�69   � 5�      $ 	#FFD9E9F9��6'   $ 1Q�69   5�      5�      � 5�      -   5        $��chart��5�      $��0,30,0,0q�6    $y�Hidden=�62    5�      �� 5�      $��30 �6$   �� 5�      �� 5�      $��20 �6$   .+�5�      � $��0��6    5�      �� 5�      $��1* �6+   �� 5�      $��1* �6+   �� 5�      $��1* �6+   �� 5�      $��1* �6+   �� 5�      $
��1.5* �6+   .+�5�      �� $��3��6   $��Right=�6,   $	��Top=�6H   $��	0,4,120,0q�6`   $��75��6s   $��25��6~   .��6�   Branch6�   �� 5�      -   5        $��branchFilter��5�      $��3��63   $��Right=�6C   $	��Top=�6_   $��	0,7,100,0q�6w   $��50��6�   $��20��6�    �� Text$	 All��6�   6�   �� 5�      $��3��6   $��Right=�6,   $	��Top=�6H   $��0,4,20,0q�6`   $��75��6r   $��25��6}   .��6�   Owner6�   �� 5�      -   5        $��ownerFilter��5�      $��3��62   $��Right=�6B   $	��Top=�6^   $��0,7,0,0q�6v   $��50��6�   $��20��6�   $	 All��6�   6�   �� 5�      -   5        $��	LocFilter��5�      $��4��6/   $��Right=�6?   $	��Top=�6[   $��	0,7,110,4q�6s   $��80��6�   $��25��6�      filterStyle#��[  6�    �� TextWrapping$
 Wrap=�6�   $��Location��6�   5�   @   �� 5�      -   5        $��	ProFilter��5�      $��4��6/   $��Right=�6?   $	��Top=�6[   $��	0,7,200,4q�6s   $��80��6�   $��25��6�   #��[  6�   $
 Wrap=�6�   $��Product��6�   5�   @   �� 5�      -   5        $��4��5�      $��Right=�6-   $	��Top=�6I   $��0,4,20,0q�6a   $��80��6s   $��25��6~   .��6�   Filter6�   �� 5�      $��2��6   $��Right=�6,   $	��Top=�6H   $��0,4,50,0q�6`   $	��100��6r   $��25��6~   .��6�   Show Zero Stock6�   �� 5�      -   5        $
��zero��5�      $��2��6+   $��Right=�6;   $	��Top=�6W   $��0,12,0,0q�6o   $��50��6�   $��25��6�    d� 	IsChecked$ FalseY�6�   6�   �� 5�      -   5        $��0��5�      $
��Left=�6-   $	��Top=�6H   $��10,4,0,0q�6`   $	��120��6r   $��25��6~   .��6�   Create New Stock6�   5�      &   System.Windows.Controls.DataGrid  5�      -   5        $��dataGrid��5�   (   $��1��6      AutoGenerateColumns .     AlternatingRowBackground
 �����   
IsReadOnly .  � 	Resources 5�       �� Color��%&  (��       5�   *   * SystemColors.HighlightBrushKey+)(��      5�   *   *1/SystemColors.InactiveSelectionHighlightBrushKey+)(�� <     5�   *   *53SystemColors.InactiveSelectionHighlightTextBrushKey+)�� 5�      $
 Blue��6\   �� 5�      $
 Blue��6m   �� 5�      $ White��6q   5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6H      Header$ Branch��6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *Branch+6S     5�      $ 1* 6G   $ Owner��6R    6-   �� *Owner+6R     5�      $ 1* 6M   $ Product��6X    6-   �� *ProductCode+6X     5�      $ 1* 6H   $ Colour��6S    6-   �� *Colour+6S     5�      $ 1* 6F   $
 Size��6Q    6-   �� *Size+6Q     5�      $ 1* 6J   $ Location��6U    6-   �� *
Location+6U     5�      $ 1* 6E   $	 UOM��6P    6-   �� *UOM+6P     5�      $ 1* 6E   $ Quantity��6P    6-   �� *QTY+6P     5�      $ 1* 6M   $ Stock Status��6X    6-   �� *StockStatus+6X     5�      $ 1* 6I   $ Arrival Date��6T    6-   �� *	Arrival+6T    � ContextMenu 5�      �� 5�      .@�5�      m� -   5        $��AdjustQuantity��5�   '   $��Adjust Quantity��6=   6V   m� 5�      -   5        $��AdjustStockStatus��5�   '   $��Adjust Stock Status��6@   6]   m� 5�      -    5        $��AdjustAttributes��5�   '   $��Adjust Attributes��6?   6Z   m� 5�      -!   5        $��CreateNewStock��5�   '   $��Create New Stock��6=   6W   m� 5�      -"   5        $��Convert2DMG��5�   '   $+��%Convert All Selected Stock to Damaged��6:   6i   m� 5�      -#   5        $��Convert2AVL��5�   '   $-��'Convert All Selected Stock to Available��6:   6k   m� 5�      -$   5        $��	ChangeLoc��5�   '   $��Change Location��68   6Q   5�      5�      5�      � 5�      -%   5        $��InputBox��5�      $y�	Collapsed=�6#   .+�5�      � 
���   �  J� Opacity$	  0.5Q�6*   �� 5�      $	��300��6   $��80��6(   
�������
���   �$��1q�6^   ! �� CornerRadius$! 15��6r   $��Center=�6�   $��Center=�6�   ._�5�      �� .+�5�      �� $��15q�6$   $9��3 What Location Would You Like to Change the Stock? ��60   $
��Bold"�6k   
����  �$��Lucida Calligraphy)�6�   �� 5�      -&   5        $��InputTextBox��5�   i   $	��200��6"   $��Center=�61   $��Center=�6N     	textStyle#��[ 6}   $
 Wrap=�6�   $��5q�6�   6�   �� 5�      " �� Orientation$" 
Horizontal=�6%   $��Center=�6>   .+�5�      �� -'   5        $��	YesButton��5�   %   $��50��66   $��10q�6A   $��  Yes  ��6M   6_   �� 5�      -(   5        $��NoButton��5�   %   $��50��65   $��10q�6@   $��  No  ��6L   6]   5�      5�      5�      5�      � 5�      -)   5        $��InvEditFrame��5�      $��0,30,0,0q�6'   
�������$y�Hidden=�6L    5�      �� 5�      $
��1.5* �6$   �� 5�      $��1* �6$   �� 5�      $��1* �6$   �� 5�      $��1* �6$   �� 5�      $��1* �6$   �� 5�      $��1* �6$   �� 5�      $��1* �6$   �� 5�      $��1* �6$   �� 5�      $��1* �6$   �� 5�      $��1* �6$   �� 5�      $
��0.8* �6$   �� 5�      $
��0.8* �6$   �� 5�      $
��0.8* �6$   �� 5�      $
��0.8* �6$   �� 5�      $
��0.8* �6$   �� 5�      $
��0.8* �6$   �� 5�      $
��0.8* �6$   �� 5�      $��2* �6$   �� 5�      $��2* �6$    5�      �� 5�      $��2* �6'   �� 5�      $��3* �6'   �� 5�      $��2* �6'   �� 5�      $��3* �6'   .+�5�      �� $��	Data Edit��6   
����  �$��0��6>   $��4��6K   $
��Left=�6_   $	��Top=�6z   $��Lucida Calligraphy)�6�   $��20(�6�   �� 5�      $��Branch��6   
���  ��$��1��6:   $��0��6G   $��0q�6W   �� 5�      $��Owner��6   
���  ��$��1��6:   $��2��6G   $��0q�6W   �� 5�      $��Product Code��6   
���  ��$��2��6@   $��0��6M   $��0q�6]   �� 5�      $��Colour��6   
���  ��$��2��6:   $��2��6G   $��0q�6W   �� 5�      $
��Size��6   
���  ��$��3��68   $��0��6E   $��0q�6U   �� 5�      $��Location��6   
���  ��$��3��6<   $��2��6I   $��0q�6Y   �� 5�      $	��UOM��6   
���  ��$��4��67   $��0��6D   $��0q�6T   �� 5�      $��Quantity��6   
���  ��$��4��6<   $��2��6I   $��0q�6Y   �� 5�      $��Arrival Date��6   
���  ��$��5��6@   $��0��6M   $��0q�6]   �� 5�      $��Batch Number��6   
����  �$��5��6A   $��2��6N   $��0q�6^   �� 5�      $��Expiry Date��6   
����  �$��6��6@   $��0��6M   $��0q�6]   �� 5�      $��Serial Number��6   
����  �$��6��6B   $��2��6O   $��0q�6_   �� 5�      $��Attribute 1��6   
����  �$��7��6@   $��0��6M   $��0q�6]   �� 5�      $��Attribute 2��6   
����  �$��7��6@   $��2��6M   $��0q�6]   �� 5�      $��Attribute 3��6   
����  �$��8��6@   $��0��6M   $��0q�6]   �� 5�      $��Attribute 4��6   
����  �$��8��6@   $��2��6M   $��0q�6]   �� 5      $��Attribute 5��6   
����  �$��9��6@   $��0��6M   $��0q�6]   �� 5     $��Stock Status��6   
���  ��$��9��6@   $��2��6M   $��0q�6]   �� 5     $��Reason��6   
���  ��$��10��6:   $��0��6H   $��0q�6X   $��7��6c   $��Center=�6t   $��18(�6�   �� 5     -*   5        $��BranchField��5     $��1��6-   $��1��6:   #��[ 6J   $
 Wrap=�6m   $��	20,5,20,5q�6�   �� 5     -+   5        $��
OwnerField��5     $��1��6,   $��3��69   #��[ 6I   $
 Wrap=�6l   $��	20,5,20,5q�6�   �� 5     -,   5        $��
PcodeField��5     $��2��6,   $��1��69   #��[ 6I   $
 Wrap=�6l   $��	20,5,20,5q�6�   �� 5     --   5        $��ColourField��5     $��2��6-   $��3��6:   #��[ 6J   $
 Wrap=�6m   $��	20,5,20,5q�6�   �� 5     -.   5        $��	SizeField��5     $��3��6+   $��1��68   #��[ 6H   $
 Wrap=�6k   $��	20,5,20,5q�6   �� 5	     -/   5        $��LocationField��5	     $��3��6/   $��3��6<   #��[ 6L   $
 Wrap=�6o   $��	20,5,20,5q�6�   �� 5
     -0   5        $��UOMField��5
     $��4��6*   $��1��67   #��[ 6G   $
 Wrap=�6j   $��	20,5,20,5q�6~   �� 5     -1   5        $��QTYField��5     #��[ 6*   $��4��6M   $��3��6Z   $
 Wrap=�6j   $��	20,5,20,5q�6~   �� 5     -2   5        $��ArrivalField��5     $��5��6.   $��1��6;   #��[ 6K   $
 Wrap=�6n   $��	20,5,20,5q�6�   �� 5     -3   5        $��
BatchField��5     $��5��6,   $��3��69   #��[ 6I   $
 Wrap=�6l   $��	20,5,20,5q�6�   �� 5     -4   5        $��ExpiryField��5     $��6��6-   $��1��6:   #��[ 6J   $
 Wrap=�6m   $��	20,5,20,5q�6�   �� 5     -5   5        $��SNField��5     $��6��6)   $��3��66   #��[ 6F   $
 Wrap=�6i   $��	20,5,20,5q�6}   �� 5     -6   5        $��
Attr1Field��5     $��7��6,   $��1��69   $
 Wrap=�6I   $��	20,5,20,5q�6]   #��[ 6p   �� 5     -7   5        $��
Attr2Field��5     $��7��6,   $��3��69   $
 Wrap=�6I   $��	20,5,20,5q�6]   #��[ 6p   �� 5     -8   5        $��
Attr3Field��5     $��8��6,   $��1��69   $
 Wrap=�6I   $��	20,5,20,5q�6]   #��[ 6p   �� 5     -9   5        $��
Attr4Field��5     $��8��6,   $��3��69   $
 Wrap=�6I   $��	20,5,20,5q�6]   #��[ 6p   �� 5     -:   5        $��
Attr5Field��5     $��9��6,   $��1��69   $
 Wrap=�6I   $��	20,5,20,5q�6]   #��[ 6p   �� 5     -;   5        $��
StockField��5     $��9��6,   $��3��69   $
 Wrap=�6I   $��	20,5,20,5q�6]   #��[ 6p   �� 5     -<   5        $��BranchFieldReadOnly��5     # �� 
IsReadOnly# . $��1��6G   $��1��6T     ReadOnlyStyle#��[ 6d   $
 Wrap=�6�   $��	20,5,20,5q�6�   �� 5     -=   5        $��OwnerFieldReadOnly��5     # . $��1��6F   $��3��6S   #��[ 6c   $
 Wrap=�6�   $��	20,5,20,5q�6�   �� 5     ->   5        $��PcodeFieldReadOnly��5     # . $��2��6F   $��1��6S   #��[ 6c   $
 Wrap=�6�   $��	20,5,20,5q�6�   �� 5     -?   5        $��ColourFieldReadOnly��5     # . $��2��6G   $��3��6T   #��[ 6d   $
 Wrap=�6�   $��	20,5,20,5q�6�   �� 5     -@   5        $��SizeFieldReadOnly��5     # . $��3��6E   $��1��6R   #��[ 6b   $
 Wrap=�6�   $��	20,5,20,5q�6�   �� 5     -A   5        $��LocationFieldReadOnly��5     # . $��3��6I   $��3��6V   #��[ 6f   $
 Wrap=�6�   $��	20,5,20,5q�6�   �� 5     -B   5        $��UOMFieldReadOnly��5     # . $��4��6D   $��1��6Q   #��[ 6a   $
 Wrap=�6�   $��	20,5,20,5q�6�   �� 5      -C   5        $��QTYFieldReadOnly��5      # . $��4��6D   $��3��6Q   #��[ 6a   $
 Wrap=�6�   $��	20,5,20,5q�6�   �� 5"     -D   5        $��ArrivalFieldReadOnly��5"     # . $��5��6H   $��1��6U   #��[ 6e   $
 Wrap=�6�   $��	20,5,20,5q�6�   �� 5#     -E   5        $��BatchFieldReadOnly��5#     # . $��5��6F   $��3��6S   #��[ 6c   $
 Wrap=�6�   $��	20,5,20,5q�6�   �� 5$     -F   5        $��ExpiryFieldReadOnly��5$     # . $��6��6G   $��1��6T   #��[ 6d   $
 Wrap=�6�   $��	20,5,20,5q�6�   �� 5%     -G   5        $��SNFieldReadOnly��5%     # . $��6��6C   $��3��6P   #��[ 6`   $
 Wrap=�6�   $��	20,5,20,5q�6�   �� 5'     -H   5        $��Attr1FieldReadOnly��5'     # . $��7��6F   $��1��6S   #��[ 6c   $
 Wrap=�6�   $��	20,5,20,5q�6�   �� 5(     -I   5        $��Attr2FieldReadOnly��5(     # . $��7��6F   $��3��6S   #��[ 6c   $
 Wrap=�6�   $��	20,5,20,5q�6�   �� 5)     -J   5        $��Attr3FieldReadOnly��5)     # . $��8��6F   $��1��6S   #��[ 6c   $
 Wrap=�6�   $��	20,5,20,5q�6�   �� 5*     -K   5        $��Attr4FieldReadOnly��5*     # . $��8��6F   $��3��6S   #��[ 6c   $
 Wrap=�6�   $��	20,5,20,5q�6�   �� 5+     -L   5        $��Attr5FieldReadOnly��5+     # . $��9��6F   $��1��6S   #��[ 6c   $
 Wrap=�6�   $��	20,5,20,5q�6�   �� 5,     -M   5        $��StockFieldReadOnly��5,     # . $��9��6F   $��3��6S   #��[ 6c   $
 Wrap=�6�   $��	20,5,20,5q�6�   	� 5.     -N   5        $��Reason1��5.     $��1. Initial Stock Load��6-   $��1��6M   $��3��6]   $
��Left=�6q   $��20,0,0,0q�6�   $��10��6�   $��Center=�6�   6�   	� 5/     -O   5        $��Reason2��5/     $��2. TS stock adjustment��6-   $��1��6N   $��3��6^   $
��Left=�6r   $��20,0,0,0q�6�   $��11��6�   $��Center=�6�   6�   	� 50     -P   5        $��Reason3��50     $��3. Stock status change��6-   $��1��6N   $��3��6^   $
��Left=�6r   $��20,0,0,0q�6�   $��12��6�   $��Center=�6�   6�   	� 51     -Q   5        $��Reason4��51     $ ��4. Stock attributes change��6-   $��1��6R   $��3��6b   $
��Left=�6v   $��20,0,0,0q�6�   $��13��6�   $��Center=�6�   6�   	� 52     -R   5        $��Reason5��52     $��5. Location Change��6-   $��1��6J   $��3��6Z   $
��Left=�6n   $��20,0,0,0q�6�   $��14��6�   $��Center=�6�   6�   	� 53     -S   5        $��Reason6��53     $��6. Stock Creation��6-   $��1��6I   $��3��6Y   $
��Left=�6m   $��20,0,0,0q�6�   $��15��6�   $��Center=�6�   6�   	� 54     -T   5        $��Reason7��54     $+��%7. Other Reason: (please write below)��6-   $��16��6]   $��1��6k   $��3��6{   $
��Left=�6�   $��20,0,0,0q�6�   $��Center=�6�   6�   �� 55     -U   5        $��ReasonField��55     $ �� 	MaxLength$	$ 100��6-   $�� ��6=   # . $��17��6W   $��1��6e   $��3��6u   #��[ 6�   $
 Wrap=�6�   $��	20,5,20,5q�6�   $y�Hidden=�6�   �� 56     -V   5        $��SaveEdit��56     $
��Save��6)   $��18��68   $��0��6F   $��2��6W   $��33��6k   $	��100��6w   $��
0,10,100,0q�6�   $��18(�6�   $	��Top=�6�   $��Right=�6�   6�   �� 57     -W   5        $��
CancelEdit��57     $��Cancel��6+   $��18��6<   $��2��6J   $��2��6Z   $��33��6n   $	��100��6z   $��
100,10,0,0q�6�   $��18(�6�   $	��Top=�6�   $
��Left=�6�   6�   59     5:     5;     5<     