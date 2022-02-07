using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ShoppingList.Model;

namespace ShoppingList.Lib.Json
{
    public static class JsonShopList
    {
        public static void ImportFromJson(string path, out List<ShopListItem> shopList)
        {
            //TODO обработать исключения
            using var file = new FileStream(path, FileMode.Open, FileAccess.Read);
            shopList = JsonSerializer.DeserializeAsync<List<ShopListItem>>(file).Result;
        }

        public static void ExportToJson(string path, in List<ShopListItem> shopList)
        {
            //TODO обработать исключения
            using var file = new FileStream(path, FileMode.Create, FileAccess.Write);
            JsonSerializer.SerializeAsync(file, shopList);
        }
    }
}