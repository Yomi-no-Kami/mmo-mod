using ScapeHeimModStub.com.scapeheim.entity.player.skill.skillunlockpopups;
using System.Collections.Generic;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.slayer
{
    public static class SlayerData
    {
        // Character prefab names -> Slayer requirement/xp
        public static readonly Dictionary<string, SkillEntry> Data = new()
        {
            // PASSIVE
            { "Crow", new SkillEntry("Crow", 1f, 0) },
            { "Seagal", new SkillEntry("Seagal", 1f, 0) },
            { "Hare", new SkillEntry("Hare", 1f, 0) },
            { "Chicken", new SkillEntry("Chicken", 1f, 0) },
            { "Hen", new SkillEntry("Hen", 1f, 0) },
            { "AshCrow", new SkillEntry("AshCrow", 1f, 0) },

            // MEADOWS
            { "Neck", new SkillEntry("Neck", 1f, 0) },
            { "Greyling", new SkillEntry("Greyling", 1.25f, 0) },
            { "Boar", new SkillEntry("Boar", 2f, 1) },
            { "Deer", new SkillEntry("Deer", 3f, 7) },

            // BLACK FOREST
            { "Greydwarf", new SkillEntry("Greydwarf", 3f, 21) },
            { "Skeleton", new SkillEntry("Skeleton", 3f, 23) },
            { "Greydwarf_Shaman", new SkillEntry("Greydwarf_Shaman", 3.5f, 25) },
            { "Greydwarf_Elite", new SkillEntry("Greydwarf_Elite", 4f, 27) },
            { "Ghost", new SkillEntry("Ghost", 5f, 29) },
            { "Skeleton_Poison", new SkillEntry("Skeleton_Poison", 6f, 31) },
            { "Bjorn", new SkillEntry("Bjorn", 15f, 33) },
            { "Troll", new SkillEntry("Troll", 10f, 35) },

            // SWAMP
            { "Blob", new SkillEntry("Blob", 4f, 41) },
            { "Draugr", new SkillEntry("Draugr", 4f, 42) },
            { "Draugr_Elite", new SkillEntry("Draugr_Elite", 6f, 43) },
            { "BlobElite", new SkillEntry("BlobElite", 5f, 44) },
            { "Leech", new SkillEntry("Leech", 2.5f, 45) },
            { "Wraith", new SkillEntry("Wraith", 6f, 46) },
            { "Surtling", new SkillEntry("Surtling", 2f, 47) },
            { "Abomination", new SkillEntry("Abomination", 20f, 48) },
            { "BogWitchKvastur", new SkillEntry("BogWitchKvastur", 18f, 49) },

            // MOUNTAINS
            { "Wolf", new SkillEntry("Wolf", 6f, 51) },
            { "Hatchling", new SkillEntry("Hatchling", 6.5f, 52) },
            { "Fenring", new SkillEntry("Fenring", 7f, 53) },
            { "StoneGolem", new SkillEntry("StoneGolem", 25f, 54) },
            { "Bat", new SkillEntry("Bat", 1f, 55) },
            { "Ulv", new SkillEntry("Ulv", 3.5f, 56) },
            { "Fenring_Cultist", new SkillEntry("Fenring_Cultist", 8f, 57) },

            // PLAINS
            { "Deathsquito", new SkillEntry("Deathsquito", 8f, 61) },
            { "Goblin", new SkillEntry("Goblin", 9f, 62) },
            { "GoblinBrute", new SkillEntry("GoblinBrute", 20f, 63) },
            { "GoblinShaman", new SkillEntry("GoblinShaman", 10f, 64) },
            { "Lox", new SkillEntry("Lox", 12f, 65) },
            { "BlobTar", new SkillEntry("BlobTar", 8f, 66) },
            { "Unbjorn", new SkillEntry("Unbjorn", 25f, 67) },

            // MISTLANDS
            { "SeekerBrood", new SkillEntry("SeekerBrood", 5f, 71) },
            { "Seeker", new SkillEntry("Seeker", 9f, 72) },
            { "SeekerBrute", new SkillEntry("SeekerBrute", 30f, 73) },
            { "Gjall", new SkillEntry("Gjall", 30f, 74) },
            { "Tick", new SkillEntry("Tick", 7f, 75) },
            { "Dverger", new SkillEntry("Dverger", 14f, 76) },
            { "DvergerMage", new SkillEntry("DvergerMage", 14f, 77) },

            // ASHLANDS
            { "BonemawSerpent", new SkillEntry("BonemawSerpent", 30f, 81) },
            { "Volture", new SkillEntry("Volture", 18f, 81) },
            { "BlobLava", new SkillEntry("BlobLava", 13f, 81) },
            { "Charred_Melee", new SkillEntry("Charred_Melee", 22f, 82) },
            { "Charred_Archer", new SkillEntry("Charred_Archer", 18f, 83) },
            { "Charred_Twitcher", new SkillEntry("Charred_Twitcher", 18f, 84) },
            { "Charred_Mage", new SkillEntry("Charred_Mage", 30f, 85) },
            { "Asksvin", new SkillEntry("Asksvin", 35f, 86) },
            { "piece_Charred_Balista", new SkillEntry("piece_Charred_Balista", 13f, 87) },
            { "Morgen", new SkillEntry("Morgen", 40f, 88) },
            { "FallenValkyrie", new SkillEntry("FallenValkyrie", 38f, 89) },

            // BOSSES
            { "Eikthyr", new SkillEntry("Eikthyr", 12f, 20) },
            { "gd_king", new SkillEntry("gd_king", 32f, 40) },
            { "TentaRoot", new SkillEntry("TentaRoot", 1f, 0) },
            { "Bonemass", new SkillEntry("Bonemass", 47f, 50) },
            { "Dragon", new SkillEntry("Dragon", 62f, 60) },
            { "GoblinKing", new SkillEntry("GoblinKing", 77f, 70) },
            { "SeekerQueen", new SkillEntry("SeekerQueen", 92f, 80) },
            { "Fader", new SkillEntry("Fader", 107f, 90) },

            // MINIBOSSES
            { "Skeleton_Hildir", new SkillEntry("Skeleton_Hildir", 18f, 20) },
            { "Fenring_Cultist_Hildir", new SkillEntry("Fenring_Cultist_Hildir", 40f, 20) },
            { "GoblinBruteBros", new SkillEntry("GoblinBruteBros", 60f, 20) },
            { "Charred_Melee_Dyrnwyn", new SkillEntry("Charred_Melee_Dyrnwyn", 80f, 20) },
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
    }
}