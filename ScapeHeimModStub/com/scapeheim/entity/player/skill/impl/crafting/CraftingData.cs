using ScapeHeimModStub.com.scapeheim.entity.player.skill.skillunlockpopups;
using System.Collections.Generic;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.crafting
{
    public static class CraftingData
    {
        public static readonly Dictionary<string, SkillEntry> Data = new()
        {
            // GENERAL/NECESSITIES
            { "Hammer", new SkillEntry("Hammer", 3f, 0) },
            { "AxeStone", new SkillEntry("AxeStone", 3f, 0) },
            { "Club", new SkillEntry("Club", 3f, 0) },
            { "Torch", new SkillEntry("Torch", 3f, 0) },
            { "Hoe", new SkillEntry("Hoe", 3f, 3) },

            // MEADOWS
            { "ArmorRagsLegs", new SkillEntry("ArmorRagsLegs", 7.25f, 2) },
            { "ArmorRagsChest", new SkillEntry("ArmorRagsChest", 7.25f, 3) },
            { "AxeFlint", new SkillEntry("AxeFlint", 7.25f, 5) },
            { "SpearFlint", new SkillEntry("SpearFlint", 7.25f, 6) },
            { "KnifeFlint", new SkillEntry("KnifeFlint", 7.25f, 7) },
            { "Bow", new SkillEntry("Bow", 8.5f, 10) },
            { "HelmetLeather", new SkillEntry("HelmetLeather", 8.5f, 13) },
            { "ArmorLeatherLegs", new SkillEntry("ArmorLeatherLegs", 8.5f, 15) },
            { "ArmorLeatherChest", new SkillEntry("ArmorLeatherChest", 8.5f, 17) },
            { "CapeDeerHide", new SkillEntry("CapeDeerHide", 8.5f, 20) },
            { "ShieldWood", new SkillEntry("ShieldWood", 8.5f, 22) },
            { "ShieldWoodTower", new SkillEntry("ShieldWoodTower", 8.5f, 25) },

            { "PickaxeAntler", new SkillEntry("PickaxeAntler", 9f, 28) },

            // BLACK FOREST
            { "SledgeStagbreaker", new SkillEntry("SledgeStagbreaker", 9f, 30) },
            { "ShieldBoneTower", new SkillEntry("ShieldBoneTower", 9f, 32) },
            { "BowFineWood", new SkillEntry("BowFineWood", 9.5f, 35) },

            { "HelmetTrollLeather", new SkillEntry("HelmetTrollLeather", 10f, 37) },
            { "ArmorTrollLeatherLegs", new SkillEntry("ArmorTrollLeatherLegs", 10f, 39) },
            { "ArmorTrollLeatherChest", new SkillEntry("ArmorTrollLeatherChest", 10f, 41) },

            // SWAMP
            { "HelmetRoot", new SkillEntry("HelmetRoot", 11f, 45) },
            { "ArmorRootChest", new SkillEntry("ArmorRootChest", 11f, 47) },
            { "ArmorRootLegs", new SkillEntry("ArmorRootLegs", 11f, 49) },
            { "BombOoze", new SkillEntry("BombOoze", 9f, 51) },

            // OCEAN
            { "KnifeChitin", new SkillEntry("KnifeChitin", 13f, 53) },
            { "SpearChitin", new SkillEntry("SpearChitin", 13f, 55) },

            // MOUNTAINS
            { "HelmetFenring", new SkillEntry("HelmetFenring", 14f, 60) },
            { "ArmorFenringChest", new SkillEntry("ArmorFenringChest", 14f, 62) },
            { "ArmorFenringLegs", new SkillEntry("ArmorFenringLegs", 14f, 64) },
            { "CapeLinen", new SkillEntry("CapeLinen", 12f, 66) },
            { "CapeWolf", new SkillEntry("CapeWolf", 15f, 70) },

            // PLAINS
            { "LoxSaddle", new SkillEntry("LoxSaddle", 9f, 75) },
            { "CapeLox", new SkillEntry("CapeLox", 17f, 76) },

            // MISTLANDS
            { "BombBile", new SkillEntry("BombBile", 9f, 77) },
            { "CapeFeather", new SkillEntry("CapeFeather", 12f, 78) },
            { "StaffFireball", new SkillEntry("StaffFireball", 17f, 79) },
            { "StaffIceShards", new SkillEntry("StaffIceShards", 17f, 79) },
            { "StaffShield", new SkillEntry("StaffShield", 17f, 79) },
            { "StaffSkeleton", new SkillEntry("StaffSkeleton", 17f, 79) },
            { "HelmetMage", new SkillEntry("HelmetMage", 19f, 80) },
            { "ArmorMageChest", new SkillEntry("ArmorMageChest", 19f, 81) },
            { "ArmorMageLegs", new SkillEntry("ArmorMageLegs", 19f, 82) },

            // ASHLANDS
            { "CapeAsksvin", new SkillEntry("CapeAsksvin", 15f, 83) },
            { "HelmetMage_Ashlands", new SkillEntry("HelmetMage_Ashlands", 23f, 84) },
            { "ArmorMageChest_Ashlands", new SkillEntry("ArmorMageChest_Ashlands", 23f, 85) },
            { "ArmorMageLegs_Ashlands", new SkillEntry("ArmorMageLegs_Ashlands", 23f, 86) },
            { "StaffGreenRoots", new SkillEntry("StaffGreenRoots", 27f, 87) },
            { "StaffClusterbomb", new SkillEntry("StaffClusterbomb", 27f, 87) },
            { "StaffLightning", new SkillEntry("StaffLightning", 27f, 87) },
            { "StaffRedTroll", new SkillEntry("StaffRedTroll", 27f, 87) },

            // DEEP NORTH
            { "TankardOdin", new SkillEntry("TankardOdin", 0f, 100) },
            { "HelmetOdin", new SkillEntry("HelmetOdin", 0f, 100) },
            { "CapeOdin", new SkillEntry("CapeOdin", 0f, 100) },
        };

        public static bool TryGet(string item, out SkillEntry entry)
        {
            return Data.TryGetValue(item, out entry);
        }

        public static List<SkillEntry> GetUnlocksForLevel(int level)
        {
            List<SkillEntry> list = new();

            foreach (var entry in Data.Values)
                if (entry.LevelReq == level)
                    list.Add(entry);

            return list;
        }
    }
}