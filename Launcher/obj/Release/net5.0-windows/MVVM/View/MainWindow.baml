   M S B A M L   `   `   `  ���� I  ELauncherClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:LauncherLauncher  M+clr-namespace:LauncherClient.MVVM.ViewModelLauncherClient.MVVM.ViewModel      LauncherClient.MainWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     A	behaviors+http://schemas.microsoft.com/xaml/behaviors     (localclr-namespace:Launcher     A	viewmodel+clr-namespace:LauncherClient.MVVM.ViewModel       � Title$  
MainWindow��$	��700��$
��1000��
������  � WindowStartupLocation$ CenterScreen=� � AllowsTransparency$
 True�� � WindowStyle$
 None=� � DataContext 1  +LauncherClient.MVVM.ViewModel.MainViewModel  .����  �� CornerRadius$ 10�����#191970$��4q� �� Padding$ 8q�
���   � J� Opacity$
 0.99Q�._�� ����  �� ImageSource$ /images/background.jpg��	 j� Stretch$	 UniformToFill=�
 � ColumnDefinitions
 �� $	��200 ��� .+�]� .+��� $��30��$	��Top=�
����������� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=��� $	��Top=�$��Connect��$��25������ *ConnectToServerCommand+�� $
 0.40Q����#191970���� *Users+���� .R��� 
����������� *
Username+�� $��1��.+��� $	��500�����#191970$
 0.20Q���  �� Orientation$ 
Horizontal=�.+��� $��30��$	��700��$��Bottom=��� $��60��$
��SEND���� -   $��64,575,733,52q�.���� $#��/images/joindiscordbutton.png��$
��Fill=��� $ 10�����#191970$��4q�$ 6q�
���   �$
 0.75Q�$	��300��$��338,0,338,588q�._��� ���#8D8BE4
���   � �� TextAlignment$ Center=�$��60��$	��250��$��60(�$��Lucida Sans)�AERIA