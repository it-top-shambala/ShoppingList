using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ShoppingList.Lib.Json;
using ShoppingList.Model;

namespace ShoppingList.App
{
    public partial class MainWindow : Window
    {
        private readonly List<ShopListItem> _list;
        public MainWindow()
        {
            InitializeComponent();
            
            var res = JsonShopList.ImportFromJson("shop_list.json", out _list);
            if (res)
            {
                ShopList.ItemsSource = _list;
            }
        }

        private void ShopList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ShopList.SelectedItem as ShopListItem;
            Input_ProductId.Text = item?.Id.ToString() ?? string.Empty;
            Input_ProductName.Text = item?.Name ?? string.Empty;
            Input_ProductComment.Text = item?.Comment ?? string.Empty;
        }

        private void Button_Delete_OnClick(object sender, RoutedEventArgs e)
        {
            _list.Remove(ShopList.SelectedItem as ShopListItem);
            ShopList.ItemsSource = null;
            ShopList.ItemsSource = _list;
        }

        private void Button_Add_OnClick(object sender, RoutedEventArgs e)
        {
            _list.Add(new ShopListItem
            {
                Id = Convert.ToInt32(Input_ProductId.Text),
                Name = Input_ProductName.Text,
                Comment = Input_ProductComment.Text
            });
            ShopList.ItemsSource = null;
            ShopList.ItemsSource = _list;
        }

        private void Button_Export_OnClick(object sender, RoutedEventArgs e)
        {
            JsonShopList.ExportToJson("shop_list.json", _list);
        }
    }
}