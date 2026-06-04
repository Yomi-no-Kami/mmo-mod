using ScapeHeimModStub.com.scapeheim.entity.player.skill.skillunlockpopups;
using System.Collections.Generic;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.herblore
{
    public static class HerbloreData
    {
        // Character prefab names -> Herblore requirement/xp
        public static readonly Dictionary<string, SkillEntry> Data = new()
        {
            // MEADS
            { "MeadBaseHealthMinor", new SkillEntry("MeadBaseHealthMinor", 4f, 0) },
            { "MeadBaseStaminaMinor", new SkillEntry("MeadBaseStaminaMinor", 5f, 7) },
            { "MeadBaseHealthMedium", new SkillEntry("MeadBaseHealthMedium", 6f, 20) },
            { "MeadBaseStaminaMedium", new SkillEntry("MeadBaseStaminaMedium", 7f, 27) },
            { "MeadBaseTasty", new SkillEntry("MeadBaseTasty", 8f, 30) },
            { "MeadBaseHasty", new SkillEntry("MeadBaseHasty", 9f, 33) },
            { "MeadBaseStrength", new SkillEntry("MeadBaseStrength", 10f, 35) },
            { "MeadBasePoisonResist", new SkillEntry("MeadBasePoisonResist", 11f, 37) },
            { "MeadBaseSwimmer", new SkillEntry("MeadBaseSwimmer", 12f, 39) },
            { "MeadBaseFrostResist", new SkillEntry("MeadBaseFrostResist", 13f, 40) },
            { "MeadBaseTamer", new SkillEntry("MeadBaseTamer", 14f, 50) },
            { "BarleyWineBase", new SkillEntry("BarleyWineBase", 15f, 57) },
            { "MeadBaseBzerker", new SkillEntry("MeadBaseBzerker", 16f, 60) },
            { "MeadBaseBugRepellent", new SkillEntry("MeadBaseBugRepellent", 17f, 65) },
            { "MeadBaseHealthMajor", new SkillEntry("MeadBaseHealthMajor", 18f, 67) },
            { "MeadBaseLingeringStamina", new SkillEntry("MeadBaseLingeringStamina", 19f, 69) },
            { "MeadBaseEitrMinor", new SkillEntry("MeadBaseEitrMinor", 20f, 71) },
            { "MeadBaseLightFoot", new SkillEntry("MeadBaseLightFoot", 21f, 75) },
            { "MeadBaseEitrLingering", new SkillEntry("MeadBaseEitrLingering", 22f, 80) },
            { "MeadBaseHealthLingering", new SkillEntry("MeadBaseHealthLingering", 23f, 85) },
        };

        public static bool TryGet(string itemName, out SkillEntry entry)
        {
            return Data.TryGetValue(itemName, out entry);
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