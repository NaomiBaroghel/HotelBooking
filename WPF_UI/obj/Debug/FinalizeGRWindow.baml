   M S B A M L   `   `   `  ����A  =WPF_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPF_UIWPF_UI  5   	       WPF_UI.FinalizeGRWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPF_UI     5   	     � Title$  FinalizeGRWindow��5   	   $	��400��6"   $	��500��6/    � WindowStartupLocation$ CenterScreen=�6<    � 
ResizeMode$ CanMinimize=�6b   ��5	      �� 5
   
    �� ImageSource$ Images/allbackground.jpg��6   6>   .��5      �  � RowDefinitions 5   
   �� 5      $
��386* �6   �� 5      $	��33* �6   .+�5   
   �� -   5        $
��logo��5      $��69,2,-171,283q�6   ��5      �� 5       �� DecodePixelWidth$	 300��6    �� 	UriSource$ /Images/bandeau2.jpg?�66   5      �� 5   
   -   5         ��Name$ 
addrequest��5      $��Add Request��6%   $��16(�6;   $��27��6I   $	��146��6V   $
��Left=�6b   $	��Top=�6}   $��	263,0,0,0q�6�   $��1��6�   {�.   �� 	IsDefault . 6�   �� 5   
   $��Enter your Family Name:��6   $��Bottom=�63   $
��Left=�6N   $��
10,0,0,286q�6i   �� 5   
   -   5        	 ��Name$	 family��5      $��My Family Name is..��6#   $��10,59,275,254q�6f   $��Italic$�6~   
�������6�   �� 5    
   $��Enter your Private Name:��6   $��Bottom=�64   $
��Left=�6O   $��
10,0,0,219q�6j   �� 5!   
   -   5        $	 Private��5!      $��My Private Name is..��6$   $��10,126,275,187q�6i   $��Italic$�6�   
�������6�   �� 5#   
   $��Enter your Address Mail :��6   $��Bottom=�65   $
��Left=�6P   $��
10,0,0,148q�6k   �� 5$   
   -   5        $
	 mail��5$      $��someone@exemple.com��6!   $��10,197,275,116q�6b   $��Italic$�6z   
�������6�   �� 5&   
   -   5        
 ��Name$
 
newsletter��5&      $7��1You want to subcribe to our newsletter for FREE ?��6'    d� 	IsChecked$ FalseY�6c   $��69,229,83,85q�6v   6�   �� 5*   
   -   5        $ cancel��5*      $��Cancel��6!   $��3��62   $��1��6B   $��16(�6O   $��27��6]   $��58��6i   $��Right=�6t   $	��Top=�6�   $��0,0,20,0q�6�   5,      5-      