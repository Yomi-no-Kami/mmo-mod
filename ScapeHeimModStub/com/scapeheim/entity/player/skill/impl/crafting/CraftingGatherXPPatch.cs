using HarmonyLib;
using UnityEngine;
using ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.crafting;
using ScapeHeimModStub.com.scapeheim.entity.player.skill.skillunlockpopups;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.crafting
{
    [HarmonyPatch(typeof(Pickable), nameof(Pickable.Interact))]
    public static class CraftingGatherXPPatch
    {
        [HarmonyPrefix]
        private static void Prefix(Pickable __instance, Humanoid character, bool repeat, bool alt)
        {
            if (Player.m_localPlayer == null || __instance == null)
                return;

            string prefabName = __instance.name.Replace("(Clone)", "").Trim();

            if (!CraftingGatherData.TryGet(prefabName, out SkillEntry entry))
                return;

            float craftingLevel =
                Player.m_localPlayer.GetSkills().GetSkillLevel(Skills.SkillType.Crafting);

            if (craftingLevel < entry.LevelReq)
                return;

            SkillExperience.Award(Player.m_localPlayer, Skills.SkillType.Crafting, entry.XP);
        }
    }
}