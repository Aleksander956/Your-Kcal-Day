   M S B A M L   `   `   `  ���� H  DYour Kcal Day, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Your_Kcal_DayYour_Kcal_Day  $    Your_Kcal_Day.AddProductWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:Your_Kcal_Day       � Title$  AddProductWindow��$	��406��$	��582�� � Left$	 700��
 � Top$	 100��.��� $��0,0,2,9q�.+��� $��Dodaj produkt��$
��Left=�$��	159,0,0,0q�$	��Top=�$��14(�$
��Bold"��� $��Wyszukaj produktu��$
��Left=�$��	14,37,0,0q�$	��Top=��� -    ��Name$ product_name��$
��Left=�$��23��$��	13,63,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��148�� J� RenderTransformOrigin$ 0.5,0.5&��� $��Ilość w g��$
��Left=�$��
314,37,0,0q�$	��Top=��� -   $ product_weight��$
��Left=�$��23��$��
318,63,0,0q�$
 Wrap=�$	��Top=�$	��120��$	��100��&   System.Windows.Controls.DataGrid  -     Name$ ProductList��$
��Left=�$	��233��   SelectionMode$ Single=�$��
10,123,0,0q�$	��Top=�$	��552���� -   $��Dodaj��$
��Left=�$��
469,63,0,0q�$	��Top=�$��80��$��23���� $.��(Zaznacz produkt, który chcesz dodać:
��$
��Left=�$��	10,97,0,0q�$	��Top=�