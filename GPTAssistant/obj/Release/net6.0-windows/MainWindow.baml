   M S B A M L   `   `   `  ���� G  CGPTAssistant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:GPTAssistantGPTAssistant      GPTAssistant.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:GPTAssistant       � WindowStyle$
  None=� � AllowsTransparency$
 True�����#343541 � WindowStartupLocation$ Manual=� � Left$ 0��
 � Top$ 0�� � 
ResizeMode$ CanResizeWithGrip=� � Topmost$
 True�� � Title$ 
MainWindow��$	��800��$	��450��.���  � RowDefinitions �� $
��Auto ��� �� $
��Auto �.+��� -   	 ��Name$	 MainScrollVieser��$��1��$��Hidden=�.���� -   
 ��Name$
 ChatStackPanel��.+��� 
������� �� Padding$ 5,5,5,5q�Red button - close�� Blue - clear�� %#Green - config(not implemented yet)�� Alt + A - Hide or show chat�� $��0�� �� Orientation$ 
Horizontal=�$��Right=�.+��� -      CustomStyleFlatCircleButton#��[  
�������$��5,5,0,5q��� #��[  
��� � �$��5,5,0,5q��� -   #��[  
���  ��$��5,5,5,5q��� $��2��$��5,5,5,5q����#343541$��Center=� �� Padding$ 10,10,10,10q� �� CornerRadius$ 20��$��2�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   Color$ 	LightGray��   ShadowDepth$ 0Q�._��� -    ��Name$ ClientTextBox��$��2��$��0q� �� TextWrapping$
 Wrap=�
�������$��0,5,5,5q����#343541$��13(�.��