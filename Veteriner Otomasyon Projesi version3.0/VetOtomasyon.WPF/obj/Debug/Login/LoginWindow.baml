   M S B A M L   `   `   `  ����K  GVetOtomasyon.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:VetOtomasyon.WPF.LoginVetOtomasyon.WPF.Login  5   	   (    "VetOtomasyon.WPF.Login.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0local$clr-namespace:VetOtomasyon.WPF.Login  5   	     � Title$  LoginWindow��5	   	   $	��450��6   $	��800��6*   .��5
      � $��	0,0,0,-31q�6    � ColumnDefinitions 5   
   �� 5      $
��365* �6   �� 5      $	��31* �6   ��5   
   �� 5       �� 
StartPoint$ 0.3,1&�6"    �� EndPoint$ 0.8,1&�65   .��5      �  � Color$ #56ffff��6    � Offset$ 1Q�6/   � 5      $ #ff5656��6   $ 0Q�6/   5      .+�5   
   �� $	��390��6   $	��Top=�6    �� CornerRadius$ 	0 0 180 0��66   ���#100E17$��2��6d   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��2��6.   .+�5      �� $	��350��6   .+�5      �� $��/Images/clinic.png��6   $	��300��64   $	��300��6@   $	��Top=�6M   $��30q�6e   $
��Fill=�6q   5      �� 5      $	��400��6   .+�5      �� $��20 40q�6   .+�5      �� $��Veteriner Randevu Sistemi��6    $��20q�6A   
������� �� TextAlignment$ Center=�6`   $��23(�6w   $��Great Vibes)�6�   6�   �� 5      $ 
Horizontal=�6!   $��10q�6:   .+�5       '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$
	 User=�62   $��25��6>   $��25��6I   
�������6U   �� 5!      -   5        
 ��Name$
 txtUsername��5!   "   $
��10 0q�67   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ E-mail��6E   
�������$	��250��6�   
������� �� 
CaretBrush �	#FFD94448 �� SelectionBrush �	#FFD944486�   5"      �� 5#      $ 
Horizontal=�6!   $��10q�6:   .+�5$        $
	 Lock=�62   $��25��6>   $��25��6I   
�������6U   �� 5%      -   5        $
 txtPassword��5%   "   $
��10 0q�67   $ ********��6E   
�������$	��250��6�   
������� �	#FFD94448 �	#FFD944486�   5&      �� 5'      $��10q�6!   $��Center=�6-   .+�5(      �� -   5         ��Name$ btnLogin��5*   B   $	��100��5(   !   $��40��6-   $��Giriş��6:   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 1��5)      $��2q�6G   ���#D94448���#D94448
�������5+      5-      5/      51      52      53      54      