   M S B A M L   `   `   `  ����  WMS Project TM Store IT!    WMS_Project_TM_Store_IT.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        �� 	Resources  5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius ��Name �� Triggers P� Property	 P� Value
 �� 
TargetName � RowDefinitions K� ZIndex K� IsItemsHost=  7System.Windows.Controls.Primitives.DataGridColumnHeader ��Name �� Padding �� 
StartPoint �� EndPoint � Color � Offset J� SnapsToDevicePixels'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� 
TargetName �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value)  #System.Windows.Controls.DataGridRow?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid � ColumnDefinitions?  9System.Windows.Controls.Primitives.DataGridCellsPresenter   
ItemsPanelA	  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter   DetailsVisibility$   SelectiveScrollingOrientation;
  5System.Windows.Controls.SelectiveScrollingOrientation  
  Vertical! �� ConverterParameter&   System.Windows.Controls.DataGrid#"   RowDetailsScrollingConverter# �� 	Converter$ �� RelativeSource% �� AncestorType:  4System.Windows.Controls.Primitives.DataGridRowHeader7  1System.Windows.Controls.DataGridHeadersVisibility
&   Row!'   HeadersVisibilityConverter   	textStyle( �� Triggers) �� Color  filterStyle  ReadOnlyStyle��%f  '��       '�� Q    '�� �    '  Z    '  �
    &	      &	 ;    &	 �    �� 5   
   " ��6   .�5      ��  � �� 5      �� 5	      " ��6&   .R�5
      � .+�5      �� $��Border��6%   
����ح�
�������$��1,1,1,1q�5   !   $ 6,6,0,0��6<   ._�5   "   �� $ ContentSite��63   $��Center=�6H   $��Center=�5   %   $��Header��6B   $��1,1,1,1q�6Y   5      5       5      P� 5       �@��
IsSelected	 . . �5   "   �� $
 Border��6)    � ��
 ��ح�6S   5      P� 5       �@��
IsSelected	 .  . �5   "   �� $
 Border��6)    � ��
 �����6S   5      5      5      5      �� 5   
   " ��6   .�5      ��  � �� 5      �� 5       " ��6&   .R�5!      �  5"      �� 5#   "   $
��Auto �60   �� 5$   "   $��* �60   .+�5&      �� $��0��5'      $ 1��5(       . 
������ 5*      �� 5+      $��1��5,   !   
�������$��1q�5.   !   $ 0, 12, 12, 12��5/   !   ._�50   "   �� $��SelectedContent��63   51      52      53      55      56      �� 57   
   " ��6   .�58      ��  � ��
 �����6+   �� 59       � ��
 �   �6+   �� 5:       �@��TextAlignment$ Center=�68   �� 5;       � �� 5<      �� 5=      " ��6&   .R�5>      �� $ 10��6!   ���#ccc$��1q�6F   #��z��6Z   ._�5?      �� $ contentPresenter��6/   #��z��6I   #��z��6}   #��z��6�   #��z��6�   #��z��6  5@       5A      P� 5B       �@J�IsMouseOver	 . . �5C   "   ��  � ��
 ��  �6?   �� 5D   "    � ��
 �����6?   �� 5E   "    � ��$
 Bold"�6?   5F      5H      5J      5K      �� 5V   
   "  6   .�5W      ��  � ��$ Center=�69   �� 5X       � ��$ 35��6'   �� 5Y       �@ SeparatorBrush
 �  ��6/   �� 5Z       � ��$ Black"�6+   �� 5[       � �� 5\      �� 5]      "  6&   .R�5^      � .+�5_      �� $ columnHeaderBorder��6%   $��1q�6A   $ 3,0,3,0q�6U   ��5`   "   �� 5a   &   $ 0.5,0&�6:   $ 0.5,1&�6M   .��5b   *   � $ 	#FFFCFDFD��67   $ 0Q�6I   � 5c   *   $ 	#FFECEEFC��67   $ 1Q�6I   5d   '   ��5f   "   �� 5g   &   $ 0.5,0&�6:   $ 0.5,1&�6M   .��5h   *   � $ 	#FFFBFDFE��67   $ 0Q�6I   � 5i   *   $ 	#FFB9D1FA��67   $ 1Q�6I   5j   '   ._�5l   "   �� #��z��63   #��z��5m       # z 5n      5o       5p        5q   "   CommonStates��. 5r   &     
Normal��62     5s   &   	MouseOver��. 5t   *   �� .��5u   .   �� $ columnHeaderBorder��6K   $N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�5v      .g�5w   2     $ 0��6F   $ Purple��6R   5x   /   5y   +   5z   '   5{   #   5}      5~      5�      5�      �� 5�   
   "  6   .�5�      ��  � ��
 ��ح�6+   �� 5�       �@=�ErrorTemplate 69   Z� �� 5�       � �� 5�      �� 5�      "  6&   .R�5�      �� $ 
DGR_Border��6!   #��z��65   #��z��5�   !    . ��5�      �� 5�   "   $ 0.5,0&�66   $ 0.5,1&�6I   .��5�   &   � $ 0Q�63   $ White��6>   � 5�   &   $ 1Q�63   $ White��6>   5�   #   ._�5�         5�   "   �� 5�   &   $
��Auto �67   �� 5�   &   $��* �67    5�   "   �� 5�   &   $��* �64   �� 5�   &   $
��Auto �64   .+�5�   "     $��1��69   #��z 6I   # z 5�      	  5�   "   $��1��6;   $��1��6H   #y�z 5�       5�   %   �� *AreRowDetailsFrozen+#! Z  ## Z" $ �� "%  5�        5�   "   $��2��64   $ Vertical=�6E   y�5�      �� *HeadersVisibility+#! Z& ## Z' $ �� "%  5�       5�        5�   "   CommonStates��. 5�   &     
Normal��62     5�   &   Normal_AlternatingRow��. 5�   *   �� .��5�   .   �� $ 
DGR_Border��6K   $N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�5�      .g�5�   2     $ 0��6F   $ Azure��6R   5�   /   �� 5�   .   $ 
DGR_Border��6K   $N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�5�      .g�5�   2     $ 0��6F   $ Azure��6R   5�   /   5�   +   5�   '     5�   &   	MouseOver��. 5�   *   �� .��5�   .   �� $ 
DGR_Border��6K   $N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�5�      .g�5�   2     $ 0��6F   $ 	LightBlue��6R   5�   /   �� 5�   .   $ 
DGR_Border��6K   $N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�5�      .g�5�   2     $ 0��6F   $ White��6R   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      5�      �� 5�   
   " ��6"   .�5�      ��  � ��
 �����6+   �� 5�       � ��
 �   �6+   �� 5�       � ��$ Verdana)�6+   ( 5�      P� 5�       �@J�IsMouseOver	 . . �5�      ��  � �� 5�      �� 5�      #) � ��6.   5�      5�      5�      �� 5�   
   " ��6$   .�5�      ��  � ��
 �����6+   �� 5�       � ��
 �����6+   �� 5�       � ��$ Verdana)�6+   �� 5�       � ��$ Italic$�6*   �� 5�       � ��$ Center=�62   ( 5�      P� 5�       �@J�IsMouseOver	 . . �5�      ��  � �� 5�      �� 5�      #) � ��6.   5�      5�      5�      �� 5�   
   " ��6&   .�5�      ��  � �� 5�      �� 5�      #) � ��6&   5�      5�      5�      5�      