   M S B A M L   `   `   `  ����A  =WPF_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPF_UIWPF_UI  5   	       WPF_UI.OrderWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPF_UI     5   	     � Title$  OrderWindow��5   	   $	��450��6   $	��800��6*    � WindowStartupLocation$ CenterScreen=�67    � 
ResizeMode$ CanMinimize=�6]   ��5	      �� 5
   
    �� ImageSource$ Images/allbackground.jpg��6   6>   .��5      � .+�5   
   �� -   5        $
��logo��5      $��95,317,-212,10q�6   $��94��64   $	��911��6@   ��5      �� 5       �� DecodePixelWidth$	 300��6    �� 	UriSource$ /Images/bandeau2.jpg?�66   5      �� 5   
   -   5         ��Name$ createorder��5      $��Create Order��6&   $��45(�6=   $��0��6L   
������ 
���   �
������ $��	0,0,421,0q�6�   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � ��	 �� Value	 5      �� 5      
 �� 
TargetType"
 ��6.   .R�5   "   �� #��z��6)   ._�5   &   �� $��Center=�67   $��Center=�6T   5   #   5      5       �� Triggers 5      P� 5        P� Property �@J�IsMouseOver P� Value . . �5!      ��  � ��
	 ���� 6;   �� 5#       � ��$
	 Bold"�6;   5$      5&      5(      �� 5*   
   -   5        $ updateorder��5*      $��Update Order��6&   $��45(�6=   $��0��6L   
������ 
���   �
������ $��	378,0,0,0q�6�   ��5+      �� 5,      " ��6   .�5-      ��  � ��	 5.      �� 5/      "
 ��6.   .R�50   "   �� #��z��6)   ._�51   &   �� $��Center=�67   $��Center=�6T   52   #   53      55       56      P� 57       �@J�IsMouseOver . . �58      ��  � ��
	 ���� 6;   �� 5:       � ��$
	 Bold"�6;   5;      5=      5?      �� 5A   
   -   5        $ cancel��5A      $��Cancel��6!   $��16(�62   $��27��6@   $��58��6L   $��Right=�6W   $	��Top=�6s   $��
0,384,44,0q�6�   5D      5E      