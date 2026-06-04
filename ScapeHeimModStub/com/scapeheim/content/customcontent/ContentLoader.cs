using Jotunn.Utils;
using ScapeHeimModStub.com.scapeheim.content.customcontent;
using System.Collections.Generic;
using UnityEngine;

public static class ContentLoader
{
    private static readonly Dictionary<string, GameObject> Loaded = new();
    private static readonly Dictionary<string, AssetBundle> Bundles = new();

    public static GameObject Load(ContentDefinition def)
    {
        AssetBundle bundle;

        // reuse already loaded bundle
        if (!Bundles.TryGetValue(def.BundleResource, out bundle))
        {
            bundle = AssetUtils.LoadAssetBundleFromResources(def.BundleResource);

            if (bundle == null)
            {
                Jotunn.Logger.LogError($"Bundle failed: {def.BundleResource}");
                return null;
            }

            Bundles[def.BundleResource] = bundle;
        }

        GameObject prefab = bundle.LoadAsset<GameObject>(def.PrefabName);

        if (prefab == null)
        {
            Jotunn.Logger.LogError($"Prefab failed: {def.PrefabName}");
            return null;
        }

        Loaded[def.Name] = prefab;
        def.Prefab = prefab;

        return prefab;
    }

    public static GameObject Get(string name)
    {
        Loaded.TryGetValue(name, out var prefab);
        return prefab;
    }
}