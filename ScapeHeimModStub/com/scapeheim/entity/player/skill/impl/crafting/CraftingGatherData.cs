using ScapeHeimModStub.com.scapeheim.entity.player.skill.skillunlockpopups;
using System.Collections.Generic;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.crafting
{
    public static class CraftingGatherData
    {
        public static readonly Dictionary<string, SkillEntry> Data = new()
        {
            { "Pickable_Stone", new SkillEntry("Pickable_Stone", 2f, 0) },
            { "Pickable_Branch", new SkillEntry("Pickable_Branch", 2f, 0) },
            { "Pickable_ForestCryptRemains01", new SkillEntry("Pickable_ForestCryptRemains01", 3f, 0) },
        };

        public static bool TryGet(string id, out SkillEntry entry)
        {
            return Data.TryGetValue(id, out entry);
        }
    }
}
