   M S B A M L   `   `   `  ����G  CGPTAssistant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:GPTAssistantGPTAssistant  5   	       GPTAssistant.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:GPTAssistant     5   	     � WindowStyle$
  None=�5   	    � AllowsTransparency$
 True��5	   	   ���#343541 � WindowStartupLocation$ Manual=�5   	    � Left$ 0��5   	   
 � Top$ 0��6    � 
ResizeMode$ CanResizeWithGrip=�5   	    � Topmost$
 True��5   	    � Title$ 
MainWindow��5   	   $	��450��5   	      CustomStylesRoundWindow#��[  5   	   ��5   	   ��  �� Source# Zo�	 �� Path$	 Height�.��5      � 
 � RowDefinitions
 5   
   �� 5      $
��Auto �6   6,   �� 5      6   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   .+�5   
   �� -   5         ��Name$ MainScrollVieser��5   $   $��1��6   $��Hidden=�6>   .��5      �� -   5         ��Name$ ChatStackPanel��5      .+�5      �� 
������� �� Padding$ 5,5,5,5q�6.   Red button - close�� 5       Blue - clear�� 5"      %#Green - config(not implemented yet)�� 5$      Alt + A - Hide or show chat5&      5'      5(      �� 5*   
   $��0��5+       �� Orientation$ 
Horizontal=�5,      $��Right=�5-      .+�5.      �� -   5          CustomStyleFlatCircleButton#��[ 5.      
�������$��5,5,0,5q�50      51      �� 52      #��[ 6   
��� � �$��5,5,0,5q�54      �� 55      -   5        #��[ 55      
���  ��$��5,5,5,5q�57      58      59      �� 5;   
   $��2��6   $��5,5,5,5q�6   ���#343541$��Center=�6D    �� Padding$ 10,10,10,10q�6_    �� CornerRadius$ 20��6u   $��2��6�    J� Effect 5<      3  -System.Windows.Media.Effects.DropShadowEffect  5=         
BlurRadius$ 10Q�6#      Color$ 	LightGray��63      ShadowDepth$ 0Q�6E   ._�5?      �� $��Hidden=�6   .��5@      �� -   5         ��Name$ ClientTextBox��5B      $��2��5A      $��0q�5D       �� TextWrapping$
 Wrap=�5E      
�������$��0,5,5,5q�5G      ���#343541$��13(�5I      $	��300��5J      .��6   5K      5L      5M      #   GPTAssistant.CustomResizeGrip  5N   
   $��3��6!   60   5O      5P      