   M S B A M L   `   `   `  ����A  =WPF_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPF_UIWPF_UI  5   	       WPF_UI.PasswordMailWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPF_UI     5   	     � Title$  PasswordMailWindow��5   	   $��225.773��6$   $��405.67��65    � WindowStartupLocation$ CenterScreen=�6E    � 
ResizeMode$ CanMinimize=�6k   ��5	      �� 5
   
    �� ImageSource$ Images/allbackground.jpg��6   6>   .��5      �  � RowDefinitions 5   
   �� 5      $
��154* �6   �� 5      $	��41* �6   .+�5   
   �� -   5        $
��logo��5      $��-90,143,88,10q�6   $��2��63   ��5      �� 5       �� DecodePixelWidth$	 300��6    �� 	UriSource$ /Images/bandeau2.jpg?�66   5      �� 5   
   $��Enter your mail password:��6   $��52,62,185,44q�65   G� 5   
   -   5         G�Name$ password��5      $��74,80,163,44q�6(   �� 5   
   -   5         ��Name$ keeppassword��5      $'��!Do you wanna keep this password ?��6*   	 d� 	IsChecked$	 FalseY�6V   $��111,117,69,18q�6i   $��2��6�   �� 5   
   -   5        
 ��Name$
 ok��5      $��OK��6   $��16(�6*   $��27��68   $��58��6D   $��Right=�6O   $	��Top=�6k   $��0,0,45,0q�6�    J� RenderTransformOrigin$ -0.022,0.107&�6�   $��1��6�    �� 	IsDefault . 6�   �� 5   
   -   5        $
 cancel��5      $��Cancel��6!   $��16(�62   $��27��6@   $��58��6L   $��Right=�6W   $	��Top=�6s   $��0,0,45,0q�6�   $ -0.022,0.107&�6�   $��1��6�   5      5      