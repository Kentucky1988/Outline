   M S B A M L   `   `   `  ����  WpfApplication1    WpfApplication1.Print   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Print��5   	   $	��550��6   $	��550��6$   .��5      � -   5        $��
printAbrus��5       � ColumnDefinitions 5   
   �� 5      $
��300* �6   �� 5	      $	��250 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��350* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6#   $��2��63    �� Orientation$ Vertical=�6G   $��Center=�6^   .+�5      �� $��Center=�6   $��П Л А Н��61   $
��Bold"�6C   $��17(�6U   �� 5      -   5        $��leshoz��5   1   $��Center=�6   61   �� 5      -   5        $��felling��5   1   $��Center=�6   61   �� 5      -   5        $
��area��5   1   $��Center=�6   61   �� 5      $��Center=�6   $��МАШТАБ 1 : 10 000��61   5      �� 5   
   
���   �$��1q�6%   $��0��69   $��1��6I   $��30, 10, 5, 10q�6V   �� 5   
   -   5        $��myGrid��5      $��1��6#   $��0��60   �� 5   
   $��2��6   $��0��6"   $ Vertical=�63   $��Center=�6J   .+�5      �� -   5        $��shotPerformed��5   1   $��Center=�6   61   �� 5      -   5        $��planDrew��5   1   $��Center=�6   $��10q�6A   5      �� 5!   
   $��1��6   $��1��6"   $��2��62   $ Vertical=�6C   $��Center=�6Z   .+�5"      �� $��Center=�6   $)��#Геодезичний журнал��61   $
��Bold"�6N   �� 5#      .+�5$      &   System.Windows.Controls.DataGrid  -   5        $��myDataGridPoligon��5$      $��Center=�64   $��Center=�6Q      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6u      HeadersVisibility$ Column=�6�   
���   �6�   5%      �� 5&      $��Прив'язка��6   $
��Bold"�6(   $��Center=�6:   �� 5'      .+�5(        -	   5        $��myDataGridBinding��5(      $
 Auto 64   $ Column=�6G   
���   �6b   5)      5*      5+      5,      