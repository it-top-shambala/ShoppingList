using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ShoppingList.Model;

namespace ShoppingList.Lib.Json
{
    public static class JsonShopList
    {
        public static bool ImportFromJson(string path, out IEnumerable<ShopListItem> shopList)
        {
            try
            {
                using var file = new FileStream(path, FileMode.Open, FileAccess.Read);
                shopList = JsonSerializer.DeserializeAsync<IEnumerable<ShopListItem>>(file).Result;
                return true;
            }
            catch (Exception)
            {
                shopList = null;
                return false;
            }
        }

        public static void ExportToJson(string path, in IEnumerable<ShopListItem> shopList)
        {
            //TODO обработать исключения
            using var file = new FileStream(path, FileMode.Create, FileAccess.Write);
            JsonSerializer.SerializeAsync(file, shopList);
        }
    }
}