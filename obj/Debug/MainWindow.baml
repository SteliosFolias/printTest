   M S B A M L   `   `   `  ����D  @printTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:printTest	printTest  5   	       printTest.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:printTest     5   	   -   5          � Title$  User_Report��5   	   $	��768��64   $
��1024��6A    � WindowStyle$
 None=�6N    � WindowState$ 	Maximized=�6a    � 	Resources 5	       �� 
TargetType   corners �� Property �� Value �� 
TargetType �� CornerRadius	 �� EndPoint
 �� 
StartPoint � Color � Offset ��Name��%  &	        �� 5
   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       �@��TextAlignment$ Center=�68   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 3,3,3,3��6!   ��5      �� 5   "   $	 0.5,1&�66   $
 0.5,0&�6G   .��5   &   � $ Black��63   $ 1Q�6A   � 5   &   $ 	#FFF90000��63   5   #   ._�5      �� $ contentPresenter��6/   #��z��6I   #��z��6}   #��z��6�   #��z��6�   #��z��6  5      5      5      5      5      .��5      � 
���   � � RowDefinitions 5   
   �� 5        � ColumnDefinitions 5"   
   �� 5#      .+�5%   
   �� -   5        $
��date��5%      $ ��Thursday 12 Apr 2018 17:20��6   $
��Left=�6A   $��
446,16,0,0q�6\   $	��Top=�6p   
�������$��12(�6�   $	��180��6�   �� 5&   
   -   5         ��Name$ 
copyrights��5&      $,��&Donald Rupert @ Arres Bovis Vive Shops��6$   $
��Left=�6U   $��
406,42,0,0q�6p   $	��Top=�6�   
�������$��12(�6�   $	��233��6�   �� 5'   
   -   5        #��[  5'      $��Print��62   $
��Left=�6B   $��259,579,0,0q�6]   $	��Top=�6r   $	��245��6�   
�������$��84��6�   $��24(�6�   $
��Bold"�6�   ��6�   Z� 6�   �� 5)   
   -   5        $ deposit_date��5)      $
��DATE��6   $
��Left=�65   $��400,153,0,0q�6P   $	��Top=�6e   ���	#FFF39F07$��30(�6�   ��6}   Z� 6�   �� 5*   
   -   5        $ total��5*       $��TOTAL��6   $
��Left=�6/   $��563,153,0,0q�6J   $	��Top=�6_   ���	#FFF39F07$��30(�6�   ��6w   Z� 6�   �� 5+   
   -   5         ��Name$
 DAY1��5+      $
��DAY1��6    $
��Left=�6,   $��41��6G   $��271,219,0,0q�6S    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��207��6�   
������� �� TextAlignment$ Right=�6�   |�.   �� 
IsReadOnly . $��24(�64  ��6�   Z�  �� SelectionBrush 6�   Z� ��6  Z� 64  �� 5,   
   -   5        $
 DAY2��5,      $
��DAY2��6    $
��Left=�6,   $��41��6G   $��271,265,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��207��6�   
�������$ Right=�6�   |�.   . $��24(�64  ��6�   Z�  6�   Z� ��6  Z� 64  �� 5-   
   -	   5        $
 DAY3��5-      $
��DAY3��6    $
��Left=�6,   $��41��6G   $��271,307,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��207��6�   
�������$ Right=�6�   |�.   . $��24(�64  ��6�   Z�  6�   Z� ��6  Z� 64  �� 5.   
   -
   5        $
 DAY4��5.      $
��DAY4��6    $
��Left=�6,   $��41��6G   $��271,355,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��207��6�   
�������$ Right=�6�   |�.   . $��24(�64  ��6�   Z�  6�   Z� ��6  Z� 64  �� 5/   
   -   5        $
 DAY5��5/      $
��DAY5��6    $
��Left=�6,   $��41��6G   $��271,401,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��207��6�   
�������$ Right=�6�   |�.   . $��24(�64  ��6�   Z�  6�   Z� ��6  Z� 64  �� 50   
   -   5        $
 DAY6��50      $
��DAY6��6    $
��Left=�6,   $��41��6G   $��271,446,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��207��6�   
�������$ Right=�6�   |�.   . $��24(�64  ��6�   Z�  6�   Z� ��6  Z� 64  �� 51   
   -   5        $
 DAY7��51      $
��DAY7��6    $
��Left=�6,   $��41��6G   $��271,494,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��207��6�   
�������$ Right=�6�   |�.   . $��24(�64  ��6�   Z�  6�   Z� ��6  Z� 64  �� 52   
   -   5        $ 
ttlamount1��52      $��0��6&   $
��Left=�6/   $��41��6J   $��560,223,0,0q�6V   $
 Wrap=�6k   $	��Top=�6   $��96��6�   
�������$ Right=�6�   |�.   . $��20(�66  ��6�   Z�  6�   Z� ��6  Z� 66  �� 53   
   -   5        $ 
ttlamount2��53      $��0��6&   $
��Left=�6/   $��41��6J   $��560,265,0,0q�6V   $
 Wrap=�6k   $	��Top=�6   $��96��6�   
�������$ Right=�6�   |�.   . $��20(�66  ��6�   Z�  6�   Z� ��6  Z� 66  �� 54   
   -   5        $ 
ttlamount3��54      $��0��6&   $
��Left=�6/   $��41��6J   $��560,310,0,0q�6V   $
 Wrap=�6k   $	��Top=�6   $��96��6�   
�������$ Right=�6�   |�.   . $��20(�66  ��6�   Z�  6�   Z� ��6  Z� 66  �� 55   
   -   5        $ 
ttlamount4��55      $��0��6&   $
��Left=�6/   $��41��6J   $��560,358,0,0q�6V   $
 Wrap=�6k   $	��Top=�6   $��96��6�   
�������$ Right=�6�   |�.   . $��20(�66  ��6�   Z�  6�   Z� ��6  Z� 66  �� 56   
   -   5        $ 
ttlamount5��56      $��0��6&   $
��Left=�6/   $��41��6J   $��560,404,0,0q�6V   $
 Wrap=�6k   $	��Top=�6   $��96��6�   
�������$ Right=�6�   |�.   . $��20(�66  ��6�   Z�  6�   Z� ��6  Z� 66  �� 57   
   -   5        $ 
ttlamount6��57      $��0��6&   $
��Left=�6/   $��41��6J   $��560,450,0,0q�6V   $
 Wrap=�6k   $	��Top=�6   $��96��6�   
�������$ Right=�6�   |�.   . $��20(�66  ��6�   Z�  6�   Z� ��6  Z� 66  �� 58   
   -   5        $ 
ttlamount7��58      $��0��6&   $
��Left=�6/   $��41��6J   $��560,498,0,0q�6V   $
 Wrap=�6k   $	��Top=�6   $��96��6�   
�������$ Right=�6�   |�.   . $��20(�66  ��6�   Z�  6�   Z� ��6  Z� 66  �� 59   
   -   5        #��[  59      $��supervisor report��62   $
��Left=�6N   $��560,579,0,0q�6i   $	��Top=�6~   $	��245��6�   
�������$��84��6�   $��24(�6�   $
��Bold"�6�   ��6�   Z� 6�   5;      5<      