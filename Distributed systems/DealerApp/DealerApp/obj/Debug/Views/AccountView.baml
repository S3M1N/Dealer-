   M S B A M L   `   `   `  ����D  @DealerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DealerApp.ViewsDealerApp.Views  5      !    DealerApp.Views.AccountView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:DealerApp.Views     5      .��5	      � .+�5
   
   �� $��Account Info��6   $��Center=�6'   $	��Top=�6D   $��15(�6\   
�������6j   �� 5   
   $
��Mark��6   $
��Left=�6   $	��Top=�6:   $��
368,37,0,0q�6R   $��15(�6f   
�������6t   �� 5   
   $��Model��6   $
��Left=�6    $	��Top=�6;   $��
359,67,0,0q�6S   $��15(�6g   
�������6u   �� 5   
   -   5          ��Name$
  Mark��5      $
��Left=�6    $��
417,43,0,0q�6;    �� TextWrapping$
 Wrap=�6O   $	��Top=�6c   $	��120��6{   �� 5   
   -   5        $  Model��5      $
��Left=�6!   $��
417,73,0,0q�6<   $
 Wrap=�6P   $	��Top=�6d   $	��120��6|   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$
 Yaer��5      $
��Left=�6#   $��
417,96,0,0q�6>   $	��Top=�6R   $	��120��6j   �� 5   
   $
��Year��6   $
��Left=�6   $	��Top=�6:   $��
374,93,0,0q�6R   $��15(�6f   
�������6t   �� 5   
   -   5        $	��Add��5      $
��Left=�6   $��
550,41,0,0q�6:   $	��Top=�6N   $��51��6u   �� 5   
   -   5        $��Remove��5      $
��Left=�6"   $��
550,73,0,0q�6=   $	��Top=�6Q   $��51��6{   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$	 Car��5      $��84,128,84,44q�6!      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Mark��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Mark+6L     5      $ Model��6%   $	 100 6N    64   �� *Model+6N     5      $
 Year��6%   $	 100 6L    63   �� *Year+6L     5      $ Price��6%   $	 100 6N    64   �� *Price+6N   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ Status��6)   $	 100 6R    69   �� *Stat+6R   5      o� 5   
   $
��Left=�6   $	��Top=�6*   .@�5      m� -   5        $��
Car Search��5      5      m� 5      -   5        $��Log Out��5      5       5!      5#      5$      