using SimpleJson;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ScapeHeimModStub.com.scapeheim.entity.player.shops
{
    public class ShopDatabase
    {
        public class ShopDefinition
        {
            public int shopId;
            public string name;
            public bool canSell;
            public List<ShopStock> stock;
        }

        public class ShopStock
        {
            public string itemName;
            public int amount;
        }

        public class ItemValue
        {
            public string itemName;
            public int buyValue;
            public int sellValue;
        }

        private static Dictionary<int, ShopDefinition> shops = new Dictionary<int, ShopDefinition>();
        private static Dictionary<string, ItemValue> values = new Dictionary<string, ItemValue>();

        private static string BasePath =>
            Path.Combine(BepInEx.Paths.PluginPath, "ScapeHeimModStub", "Assets", "Data");

        public static void Load()
        {
            LoadShops();
            LoadItemValues();
        }


        private static JsonObject ToDict(object obj)
        {
            return obj as JsonObject;
        }

        private static JsonArray ToList(object obj)
        {
            return obj as JsonArray;
        }

        private static int ToInt(object obj)
        {
            return System.Convert.ToInt32(obj);
        }

        private static void LoadShops()
        {
            string path = Path.Combine(BasePath, "shops.json");

            if (!File.Exists(path))
            {
                Debug.LogWarning("[ScapeHeim] Missing shops.json");
                return;
            }

            string json = File.ReadAllText(path);
            object rootObj = SimpleJson.SimpleJson.DeserializeObject(json);

            var root = ToDict(rootObj);

            if (root == null)
            {
                Debug.LogError("[ScapeHeim] Root is NOT a dictionary (JSON must start with { })");
                return;
            }

            if (!root.ContainsKey("shops"))
            {
                Debug.LogError("[ScapeHeim] Missing 'shops' key");
                return;
            }

            var shopsArr = ToList(root["shops"]);

            if (shopsArr == null)
            {
                Debug.LogError("[ScapeHeim] 'shops' is not an array");
                return;
            }

            shops.Clear();

            foreach (var s in shopsArr)
            {
                var dict = ToDict(s);
                if (dict == null) continue;

                var shop = new ShopDefinition
                {
                    shopId = ToInt(dict["shopId"]),
                    name = dict["name"].ToString(),
                    canSell = dict.ContainsKey("canSell") && (bool)dict["canSell"],
                    stock = new List<ShopStock>()
                };

                var stockArr = ToList(dict["stock"]);

                if (stockArr != null)
                {
                    foreach (var st in stockArr)
                    {
                        var sd = ToDict(st);
                        if (sd == null) continue;

                        shop.stock.Add(new ShopStock
                        {
                            itemName = sd["itemName"].ToString(),
                            amount = ToInt(sd["amount"])
                        });
                    }
                }

                shops[shop.shopId] = shop;
            }

            Debug.Log($"[ScapeHeim] Loaded {shops.Count} shops");
        }

        private static void LoadItemValues()
        {
            string path = Path.Combine(BasePath, "item_values.json");

            if (!File.Exists(path))
            {
                Debug.LogWarning("[ScapeHeim] Missing item_values.json");
                return;
            }

            string json = File.ReadAllText(path);
            object rootObj = SimpleJson.SimpleJson.DeserializeObject(json);

            var root = ToDict(rootObj);

            if (root == null)
            {
                Debug.LogError("[ScapeHeim] Root is NOT a dictionary (item_values.json)");
                return;
            }

            if (!root.ContainsKey("items"))
            {
                Debug.LogError("[ScapeHeim] Missing 'items' key");
                return;
            }

            var itemsArr = ToList(root["items"]);

            if (itemsArr == null)
            {
                Debug.LogError("[ScapeHeim] 'items' is not an array");
                return;
            }

            values.Clear();

            foreach (var i in itemsArr)
            {
                var dict = ToDict(i);
                if (dict == null) continue;

                string name = dict["itemName"].ToString();

                values[name] = new ItemValue
                {
                    itemName = name,
                    buyValue = ToInt(dict["buyValue"]),
                    sellValue = ToInt(dict["sellValue"])
                };
            }

            Debug.Log($"[ScapeHeim] Loaded {values.Count} item values");
        }

        public static ShopDefinition GetShop(int id)
        {
            shops.TryGetValue(id, out var shop);
            return shop;
        }

        public static int GetBuyValue(string item)
            => values.TryGetValue(item, out var v) ? v.buyValue : 1;

        public static int GetSellValue(string item)
            => values.TryGetValue(item, out var v) ? v.sellValue : 1;
    }
}