using ScapeHeimModStub.com.scapeheim.entity.player.skill.skillunlockpopups;
using System.Collections.Generic;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.fletching
{
    public static class FletchingData
    {
        public static readonly Dictionary<string, SkillEntry> Data = new()
        {
            { "ArrowWood", new SkillEntry("ArrowWood", 2.5f, 0) },
            { "ArrowFlint", new SkillEntry("ArrowFlint", 3f, 10) },
            { "ArrowBronze", new SkillEntry("ArrowBronze", 4f, 20) },
            { "ArrowFire", new SkillEntry("ArrowFire", 4f, 25) },
            { "BoltBone", new SkillEntry("BoltBone", 4f, 30) },
            { "ArrowIron", new SkillEntry("ArrowIron", 5f, 35) },
            { "ArrowPoison", new SkillEntry("ArrowPoison", 5f, 40) },
            { "BoltIron", new SkillEntry("BoltIron", 5f, 45) },
            { "ArrowObsidian", new SkillEntry("ArrowObsidian", 6f, 50) },
            { "ArrowFrost", new SkillEntry("ArrowFrost", 6f, 55) },
            { "ArrowSilver", new SkillEntry("ArrowSilver", 6f, 60) },
            { "ArrowNeedle", new SkillEntry("ArrowNeedle", 7f, 70) },
            { "BoltBlackmetal", new SkillEntry("BoltBlackmetal", 7.5f, 72) },
            { "ArrowCarapace", new SkillEntry("ArrowCarapace", 8f, 80) },
            { "BoltCarapace", new SkillEntry("BoltCarapace", 8.5f, 82) },
            { "ArrowCharred", new SkillEntry("ArrowCharred", 9f, 90) },
            { "BoltCharred", new SkillEntry("BoltCharred", 9.5f, 91) },
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