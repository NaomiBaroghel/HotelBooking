   M S B A M L   `   `   `  ����A  =WPF_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPF_UIWPF_UI  5   	       WPF_UI.MessageWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPF_UI     5   	     � Title$  MessageWindow��5   	   $	��500��6   $	��500��6,    � WindowStartupLocation$ CenterScreen=�68    � 
ResizeMode$ CanMinimize=�6^   ��5	      �� 5
   
    �� ImageSource$ Images/allbackground.jpg��6   6>   .��5      � .+�5   
   �� -   5        $
��logo��5      $��219,133,248,312q�6   ��5      �� 5       �� DecodePixelWidth$	 300��6    �� 	UriSource$ /Images/warning.png?�66   5      �� 5   
   -   5        $��warning��5      $��10,344,26,0q�6   ��5      �� 5      $	 300��6   $ /Images/bandeau2.jpg?�66   5      �� 5   
   $;��5Your need to enter a correct e-mail for us to respond��6   $��10(�6Q   $��Italic$�6_   
�������$��Bottom=�6�   $
��Left=�6�   $��251,0,0,312q�6�   �� 5   
   -   5         ��Name$
 send��5      $
��Send��6   $��16(�6.   $��27��6<   $	��146��6I   $
��Left=�6U   $	��Top=�6p   $��238,421,0,0q�6�   {�.   �� 	IsDefault . 6�   �� 5   
   $��Your Name :��6   $��Bottom=�6'   $
��Left=�6B   $��
10,0,0,419q�6]   �� 5   
   -   5         ��Name$
 name��5      $�� ��6!   $��26,57,268,385q�6O   �� 5   
   $��Your e-mail :��6   $��Bottom=�6)   $
��Left=�6D   $��
10,0,0,364q�6_   �� 5   
   -   5        $
 mail��5      $�� ��6!   $��26,112,268,330q�6O   �� 5!   
   $��
Subject : ��6   $��Bottom=�6&   $
��Left=�6A   $��
10,0,0,309q�6\   �� 5"   
   -   5        $ subject��5"      $�� ��6$   $��26,167,238,272q�6U   �� 5$   
   $��	Message :��6   $��Bottom=�6%   $
��Left=�6@   $��
23,0,0,251q�6[   �� 5%   
   -   5        $ message��5%      $�� ��6$   $��41,225,95,122q�6U   �� 5(   
   -   5        $ cancel��5(      $��Cancel��6!   $��16(�62   $��27��6@   $��58��6L   $��Right=�6W   $	��Top=�6s   $��
0,421,26,0q�6�   5*      5+      