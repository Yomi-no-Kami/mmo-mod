using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using UnityEngine;

namespace ScapeHeimModStub.com.scapeheim.content.customcontent.locations.generalstore
{
    internal static class GeneralStoreLocation
    {
        internal static void Register()
        {
            GameObject prefab = ContentLoader.Load(
                new ContentDefinition
                {
                    Name = "The General Store",
                    BundleResource = "ScapeHeimModStub.Assets.CustomModels.scapeheim_generalstore",
                    PrefabName = "ScapeHeim_AbandonedShop"
                }
            );

            if (prefab == null)
                return;

            Transform shopkeeper = FindChildRecursive(prefab.transform, "ScapeHeim_ShopKeeper");

            if (shopkeeper != null)
            {
                if (!shopkeeper.TryGetComponent<GeneralStoreShopkeeper>(out _))
                {
                    shopkeeper.gameObject.AddComponent<GeneralStoreShopkeeper>();
                }
            }
            else
            {
                Jotunn.Logger.LogError(
                    "Could not find ScapeHeim_ShopKeeper inside location prefab"
                );
            }

            LocationConfig config = new LocationConfig
            {
                Biome = Heightmap.Biome.Meadows,
                Quantity = 75,
                ExteriorRadius = 50f,
                ClearArea = true,
                Priotized = true,
                MinAltitude = 1f
            };

            ZoneManager.Instance.AddCustomLocation(
                new CustomLocation(prefab, true, config)
            );

            Jotunn.Logger.LogInfo("[ScapeHeim]: General Store registered as CustomLocation");
        }

        private static Transform FindChildRecursive(Transform parent, string name)
        {
            foreach (Transform child in parent.GetComponentsInChildren<Transform>(true))
            {
                if (child.name == name)
                {
                    return child;
                }
            }

            return null;
        }
    }
}