using ScapeHeimModStub.com.scapeheim.entity.player.skill.skillunlockpopups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.farming
{
    public static class FarmingData
    {

        public static readonly Dictionary<string, SkillEntry> Data = new()
        {

            // GATHERING
            { "RaspberryBush", new SkillEntry("RaspberryBush", 2f, 0) },
            { "Pickable_Mushroom", new SkillEntry("Pickable_Mushroom", 3f, 3) },
            { "VineGreen_sapling", new SkillEntry("VineGreen_sapling", 2.5f, 9) },
            { "Pickable_Thistle", new SkillEntry("Pickable_Thistle", 4f, 15) },
            { "BlueberryBush", new SkillEntry("BlueberryBush", 4f, 22) },
            { "Pickable_Mushroom_yellow", new SkillEntry("Pickable_Mushroom_yellow", 4f, 25) },
            { "Pickable_SeedCarrot", new SkillEntry("Pickable_SeedCarrot", 4f, 28) },
            { "Pickable_Carrot", new SkillEntry("Pickable_Carrot", 4f, 28) },
            { "Pickable_Turnip", new SkillEntry("Pickable_Turnip", 6f, 34) },
            { "Pickable_SeedTurnip", new SkillEntry("Pickable_SeedTurnip", 6f, 34) },
            { "Pickable_Barley", new SkillEntry("Pickable_Barley", 7f, 48) },
            { "CloudberryBush", new SkillEntry("CloudberryBush", 8f, 52) },
            { "Pickable_Flax_Wild", new SkillEntry("Pickable_Flax_Wild", 8f, 55) },
            { "Pickable_Flax", new SkillEntry("Pickable_Flax", 8f, 55) },
            { "Pickable_Mushroom_JotunPuffs", new SkillEntry("Pickable_Mushroom_JotunPuffs", 9f, 66) },
            { "Pickable_Mushroom_Magecap", new SkillEntry("Pickable_Mushroom_Magecap", 10f, 72) },
            { "Pickable_SmokePuff", new SkillEntry("Pickable_SmokePuff", 11f, 82) },
            { "Pickable_Fiddlehead", new SkillEntry("Pickable_Fiddlehead", 12f, 85) },
            

            // PLANTING

            { "Beech_Sapling", new SkillEntry("Beech_Sapling", 5f, 20) },
            { "FirTree_Sapling", new SkillEntry("FirTree_Sapling", 6f, 20) },
            { "sapling_carrot", new SkillEntry("sapling_carrot", 4f, 28) },
            { "sapling_seedcarrot", new SkillEntry("sapling_seedcarrot", 4f, 28) },
            { "PineTree_Sapling", new SkillEntry("PineTree_Sapling", 7f, 30) },
            { "sapling_turnip", new SkillEntry("sapling_turnip", 5f, 34) },
            { "sapling_seedturnip", new SkillEntry("sapling_seedturnip", 5f, 34) },
            { "sapling_onion", new SkillEntry("sapling_onion", 7f, 42) },
            { "sapling_seedonion", new SkillEntry("sapling_seedonion", 7f, 42) },
            { "Birch_Sapling", new SkillEntry("Birch_Sapling", 8f, 40) },
            { "Oak_Sapling", new SkillEntry("Oak_Sapling", 9f, 50) },
            { "sapling_barley", new SkillEntry("sapling_barley", 8f, 48) },
            { "sapling_flax", new SkillEntry("sapling_flax", 6f, 55) },
            { "sapling_jotunpuffs", new SkillEntry("sapling_jotunpuffs", 9f, 66) },
            { "sapling_magecap", new SkillEntry("sapling_magecap", 10f, 72) },
            { "VineAsh_sapling", new SkillEntry("VineAsh_sapling", 16f, 88 ) },


            // CUSTOM TO ADD

            // ANCIENT TREES
            // YGGDRASIL SHOOTS
            // SCORCHED TREES


        };

        // OPTIONAL DISPLAY NAME OVERRIDES (key = prefab name)
        public static readonly Dictionary<string, string> DisplayNames = new()
        {
            // GATHERING
            { "RaspberryBush", "Raspberry Bush" },
            { "Pickable_Mushroom", "Mushroom" },
            { "Pickable_Thistle", "Thistle" },
            { "BlueberryBush", "Blueberry Bush" },
            { "Pickable_Mushroom_yellow", "Yellow Mushroom" },
            { "Pickable_SeedCarrot", "Carrot Plant" },
            { "Pickable_Carrot", "Carrot" },
            { "Pickable_Turnip", "Turnip" },
            { "Pickable_SeedTurnip", "Turnip Plant" },
            { "Pickable_Barley", "Barley" },
            { "CloudberryBush", "Cloudberry Bush" },
            { "Pickable_Flax_Wild", "Wild Flax" },
            { "Pickable_Flax", "Flax" },
            { "Pickable_Mushroom_JotunPuffs", "Jotun Puffs" },
            { "Pickable_Mushroom_Magecap", "Magecap" },
            { "Pickable_SmokePuff", "Smoke Puff" },
            { "Pickable_Fiddlehead", "Fiddlehead" },
            { "VineAsh", "Ashvine" },

            // PLANTING TREES
            { "Beech_Sapling", "Beech Sapling" },
            { "FirTree_Sapling", "Fir Sapling" },
            { "PineTree_Sapling", "Pine Sapling" },
            { "Birch_Sapling", "Birch Sapling" },
            { "Oak_Sapling", "Oak Sapling" },
            { "VineAsh_sapling", "Ashvine Sapling" },
            { "VineGreen_sapling", "Vine Sapling" },

            // PLANTING CROPS
            { "sapling_carrot", "Carrot" },
            { "sapling_seedcarrot", "Carrot Seed Plant" },
            { "sapling_turnip", "Turnip" },
            { "sapling_seedturnip", "Turnip Seed Plant" },
            { "sapling_onion", "Onion" },
            { "sapling_seedonion", "Onion Seed Plant" },
            { "sapling_barley", "Barley" },
            { "sapling_flax", "Flax" },
            { "sapling_jotunpuffs", "Jotun Puffs Sapling" },
            { "sapling_magecap", "Magecap Sapling" },
        };

        public static bool TryGet(string characterName, out SkillEntry entry)
        {
            return Data.TryGetValue(characterName, out entry);
        }

        public static List<SkillEntry> GetUnlocksForLevel(int level)
        {
            List<SkillEntry> list = new();

            foreach (var entry in Data.Values)
                if (entry.LevelReq == level)
                    list.Add(entry);

            return list;
        }

        public static string GetDisplayName(string prefabName, string fallback)
        {
            if (string.IsNullOrEmpty(prefabName))
                return fallback;

            if (DisplayNames.TryGetValue(prefabName, out string displayName))
                return displayName;

            return fallback;
        }
    }
}
