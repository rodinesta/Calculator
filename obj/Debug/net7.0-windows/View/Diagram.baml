   M S B A M L   `   `   `  ����@  <TRPO1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TRPO1.ViewModelTRPO1.ViewModel  5   	   clr-namespace:TRPO1TRPO1  5   	       TRPO1.View.Diagram   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   /localclr-namespace:TRPO1.ViewModel     5   	   %trpo1clr-namespace:TRPO1     5   	     � Title$  Diagram��5	   	   $	��500��6   $	��260��6&    � DataContext 5
         TRPO1.ViewModel.DiagramVM  5   
   .��5      � .+�5   
   �� z�5      �� 5       �� ScaleX$ 1Q�6!    �� ScaleY$ -1Q�6,   .+�5      �� -   5         ��Name$	 BIN��5       �� Left$ 10��6%   
 �� Top$
 -400��66   $��50��6H   
��� �����6S   �� *
countBIN+ �� Mode$ OneWay=�6|   �� 5      -   5        $	 OCT��5      $ 70��6%   $
 -400��66   $��50��6H   
����  ���6S   �� *
countOCT+$ OneWay=�6|   �� 5      -   5        $	 DEC��5      $	 130��6%   $
 -400��67   $��50��6I   
���  ����6T   �� *
countDEC+$ OneWay=�6}   �� 5      -   5        $	 HEX��5      $	 190��6%   $
 -400��67   $��50��6I   
��� � ���6T   �� *
countHEX+$ OneWay=�6}   5      �� 5   
   $	��BIN��6   $��
25 410 0 0q�6   �� 5   
   $	��OCT��6   $��
83 410 0 0q�6   �� 5   
   $	��DEC��6   $��143 410 0 0q�6   �� 5   
   $	��HEX��6   $��203 410 0 0q�6   5      5      