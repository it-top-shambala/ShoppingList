using System.Collections.Generic;
using System.Windows;
using ShoppingList.Lib.Json;
using ShoppingList.Model;

namespace ShoppingList.App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            var res = JsonShopList.ImportFromJson("shop_list.json", out var list);
            if (res)
            {
                ShopList.ItemsSource = list;
            }
        }
    }
}