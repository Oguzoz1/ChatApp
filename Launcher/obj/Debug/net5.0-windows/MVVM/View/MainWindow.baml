   M S B A M L   `   `   `  ����I  ELauncherClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:LauncherLauncher  5   	   M+clr-namespace:LauncherClient.MVVM.ViewModelLauncherClient.MVVM.ViewModel  6.       LauncherClient.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   A	behaviors+http://schemas.microsoft.com/xaml/behaviors     5   	   (localclr-namespace:Launcher     5   	   A	viewmodel+clr-namespace:LauncherClient.MVVM.ViewModel     6.     � Title$  
MainWindow��5	   	   $	��700��6   $
��1000��6)   
������  � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency$
 True��6.    � WindowStyle$
 None=�6H    � DataContext 5      1  +LauncherClient.MVVM.ViewModel.MainViewModel  5   
   .��5      ��  �� CornerRadius$ 10��6   ���#191970$��4q�65    �� Padding$ 8q�6I   
���   � J� Opacity$
 0.99Q�6h   ._�5   
   � ��5      �� 5       �� ImageSource$ /images/background.jpg��6   	 j� Stretch$	 UniformToFill=�6B   
 � ColumnDefinitions
 5      �� 5      $	��200 �6#   �� 5      .+�5      ]� .+�5"      �� $��30��6   $	��Top=�5#      
���������5%      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=��� 5'      $	��Top=�6   $��Connect��6.   $��25��6@   ��5(      �� *ConnectToServerCommand+�� 5*      $
 0.40Q�6   ���#191970��5+      �� *Users+��5-      �� 5.      .R�5/      �� 
���������6(   �� *
Username+6B   50      52      53      �� 55      $��1��6   .+�56      �� $	��500��6   ���#191970$
 0.20Q�6=   �� 58       �� Orientation$ 
Horizontal=�6   .+�59      �� $��30��6    $	��700��5:       $��Bottom=�5;       �� 5<      $��60��6   $
��SEND��6(   5=      5>      �� 5@      -   5        $��64,575,733,52q�5@      .��5A      �� $#��/images/joindiscordbutton.png��6   $
��Fill=�6?   5B      �� 5C      $ 10��5D      ���#191970$��4q�69   $ 6q�6M   
���   �$
 0.75Q�5E   $   $	��300��63   $��338,0,338,588q�6?   ._�5F      �� ���#8D8BE4
���   � �� TextAlignment$ Center=�5G      $��60��5H      $	��250��5I      $��60(�5J      $��Lucida Sans)�5K      AERIA5M      5N      5O      5P      5Q      