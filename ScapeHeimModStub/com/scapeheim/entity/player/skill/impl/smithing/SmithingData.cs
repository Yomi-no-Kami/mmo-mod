using ScapeHeimModStub.com.scapeheim.entity.player.skill.skillunlockpopups;
using System.Collections.Generic;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.smithing
{
    public static class SmithingData
    {
        public static readonly Dictionary<string, SkillEntry> Data = new()
        {
            // EARLY GAME
            { "Copper", new SkillEntry("Copper", 1f, 0) },
            { "Tin", new SkillEntry("Tin", 1f, 0) },

            // BRONZE
            { "Bronze", new SkillEntry("Bronze", 1.5f, 10) },
            { "KnifeButcher", new SkillEntry("KnifeButcher", 1.5f, 6) },
            { "KnifeCopper", new SkillEntry("KnifeCopper", 1.5f, 9) },
            { "BronzeNails", new SkillEntry("BronzeNails", 1.5f, 12) },
            { "Cultivator", new SkillEntry("Cultivator", 1.5f, 13) },
            { "ArmorBronzeLegs", new SkillEntry("ArmorBronzeLegs", 1.5f, 15) },
            { "AtgeirBronze", new SkillEntry("AtgeirBronze", 1.5f, 16) },
            { "MaceBronze", new SkillEntry("MaceBronze", 1.5f, 17) },
            { "ArmorBronzeChest", new SkillEntry("ArmorBronzeChest", 1.5f, 18) },
            { "AxeBronze", new SkillEntry("AxeBronze", 1.5f, 19) },
            { "ShieldBronzeBuckler", new SkillEntry("ShieldBronzeBuckler", 1.5f, 20) },
            { "HelmetBronze", new SkillEntry("HelmetBronze", 1.5f, 21) },
            { "PickaxeBronze", new SkillEntry("PickaxeBronze", 1.5f, 22) },
            { "SpearBronze", new SkillEntry("SpearBronze", 1.5f, 23) },
            { "SwordBronze", new SkillEntry("SwordBronze", 1.5f, 24) },

            // IRON
            { "Iron", new SkillEntry("Iron", 2f, 25) },
            { "IronNails", new SkillEntry("IronNails", 2.5f, 28) },
            { "BowHuntsman", new SkillEntry("BowHuntsman", 2.5f, 29) },
            { "ArmorIronLegs", new SkillEntry("ArmorIronLegs", 2.5f, 30) },
            { "AtgeirIron", new SkillEntry("AtgeirIron", 2.5f, 31) },
            { "MaceIron", new SkillEntry("MaceIron", 2.5f, 32) },
            { "ArmorIronChest", new SkillEntry("ArmorIronChest", 2.5f, 33) },
            { "AxeIron", new SkillEntry("AxeIron", 2.5f, 34) },
            { "ShieldIronBuckler", new SkillEntry("ShieldIronBuckler", 2.5f, 35) },
            { "HelmetIron", new SkillEntry("HelmetIron", 2.5f, 36) },
            { "PickaxeIron", new SkillEntry("PickaxeIron", 2.5f, 37) },
            { "SpearElderbark", new SkillEntry("SpearElderbark", 2.5f, 38) },
            { "SwordIron", new SkillEntry("SwordIron", 2.5f, 39) },
            { "ShieldIronTower", new SkillEntry("ShieldIronTower", 2.5f, 40) },
            { "ShieldBanded", new SkillEntry("ShieldBanded", 2.5f, 42) },
            { "SledgeIron", new SkillEntry("SledgeIron", 2.5f, 43) },
            { "Battleaxe", new SkillEntry("Battleaxe", 2.5f, 44) },

            // SILVER
            { "Silver", new SkillEntry("Silver", 3.5f, 42) },
            { "ArmorWolfLegs", new SkillEntry("ArmorWolfLegs", 4f, 45) },
            { "KnifeSilver", new SkillEntry("KnifeSilver", 4f, 47) },
            { "ArmorWolfChest", new SkillEntry("ArmorWolfChest", 4f, 48) },
            { "ShieldSilver", new SkillEntry("ShieldSilver", 4f, 49) },
            { "HelmetDrake", new SkillEntry("HelmetDrake", 4f, 51) },
            { "SwordSilver", new SkillEntry("SwordSilver", 4f, 53) },
            { "SpearWolfFang", new SkillEntry("SpearWolfFang", 4f, 54) },
            { "FistFenrirClaw", new SkillEntry("FistFenrirClaw", 4f, 56) },
            { "BowDraugrFang", new SkillEntry("BowDraugrFang", 4f, 59) },
            { "BattleaxeCrystal", new SkillEntry("BattleaxeCrystal", 4f, 60) },
            { "ShieldSerpentscale", new SkillEntry("ShieldSerpentscale", 4f, 61) },

            // BLACKMETAL
            { "BlackMetal", new SkillEntry("BlackMetal", 4.5f, 62) },
            { "ArmorPaddedGreaves", new SkillEntry("ArmorPaddedGreaves", 5f, 65) },
            { "AtgeirBlackmetal", new SkillEntry("AtgeirBlackmetal", 5f, 66) },
            { "ShieldBlackmetal", new SkillEntry("ShieldBlackmetal", 5f, 67) },
            { "ArmorPaddedCuirass", new SkillEntry("ArmorPaddedCuirass", 5f, 68) },
            { "AxeBlackmetal", new SkillEntry("AxeBlackmetal", 5f, 69) },
            { "KnifeBlackmetal", new SkillEntry("KnifeBlackmetal", 5f, 70) },
            { "HelmetPadded", new SkillEntry("HelmetPadded", 5f, 71) },
            { "PickaxeBlackmetal", new SkillEntry("PickaxeBlackmetal", 5f, 72) },
            { "MaceSilver", new SkillEntry("MaceSilver", 5f, 73) },
            { "ShieldBlackmetalTower", new SkillEntry("ShieldBlackmetalTower", 5f, 74) },
            { "SwordBlackmetal", new SkillEntry("SwordBlackmetal", 5f, 75) },
            { "MaceNeedle", new SkillEntry("MaceNeedle", 5f, 77) },

            // CARAPACE / MISTLANDS
            { "Lantern", new SkillEntry("Lantern", 1f, 79) },
            { "ArmorCarapaceLegs", new SkillEntry("ArmorCarapaceLegs", 6f, 80) },
            { "ShieldCarapaceBuckler", new SkillEntry("ShieldCarapaceBuckler", 6f, 81) },
            { "CrossbowArbalest", new SkillEntry("CrossbowArbalest", 6f, 82) },
            { "ArmorCarapaceChest", new SkillEntry("ArmorCarapaceChest", 6f, 83) },
            { "ShieldCarapace", new SkillEntry("ShieldCarapace", 6f, 84) },
            { "SpearCarapace", new SkillEntry("SpearCarapace", 6f, 85) },
            { "HelmetCarapace", new SkillEntry("HelmetCarapace", 6f, 86) },
            { "KnifeSkollAndHati", new SkillEntry("KnifeSkollAndHati", 6f, 88) },
            { "AxeJotunBane", new SkillEntry("AxeJotunBane", 6f, 89) },
            { "SwordMistwalker", new SkillEntry("SwordMistwalker", 6f, 90) },
            { "AtgeirHimminAfl", new SkillEntry("AtgeirHimminAfl", 6f, 91) },
            { "Demolisher", new SkillEntry("Demolisher", 6f, 91) },
            { "SwordKrom", new SkillEntry("SwordKrom", 6f, 91) },
            { "BowSpineSnap", new SkillEntry("BowSpineSnap", 6f, 91) },

            // FLAMETAL / ASHLANDS
            { "FlametalNew", new SkillEntry("FlametalNew", 6.5f, 92) },
            { "HelmetFlametal", new SkillEntry("HelmetFlametal", 7f, 92) },
            { "ArmorFlametalChest", new SkillEntry("ArmorFlametalChest", 7f, 93) },
            { "ArmorFlametalLegs", new SkillEntry("ArmorFlametalLegs", 7f, 94) },
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