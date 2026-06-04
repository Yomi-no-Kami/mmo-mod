using HarmonyLib;
using ScapeHeimModStub.com.scapeheim.entity.player.skill.skillunlockpopups;
using System.Collections.Generic;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.slayer
{
    internal static class SlayerTracking
    {
        public static readonly Dictionary<Character, Player> LastPlayerAttacker = new();
    }

    [HarmonyPatch(typeof(Character), nameof(Character.Damage))]
    internal static class SlayerTrackDamagePatch
    {
        private static void Prefix(Character __instance, HitData hit)
        {
            if (__instance == null || hit == null)
            {
                return;
            }

            if (__instance.IsPlayer())
            {
                return;
            }

            Character attacker = hit.GetAttacker();

            if (attacker == null || !attacker.IsPlayer())
            {
                return;
            }

            Player player = attacker as Player;

            if (player == null)
            {
                return;
            }

            SlayerTracking.LastPlayerAttacker[__instance] = player; // Certain weapons deal poison DoT etc, this should fix not receiving slayer xp due to that.
        }
    }

    [HarmonyPatch(typeof(Character), nameof(Character.OnDeath))]
    internal static class SlayerGainExperiencePatch
    {
        private static void Prefix(Character __instance)
        {
            if (__instance == null)
            {
                return;
            }

            if (__instance.IsPlayer())
            {
                return;
            }

            if (!SlayerTracking.LastPlayerAttacker.TryGetValue(__instance, out Player player))
            {
                return;
            }

            string prefabName = Utils.GetPrefabName(__instance.gameObject)
                .Replace("(Clone)", "");

            if (!SlayerData.TryGet(prefabName, out SkillEntry entry))
            {
                return;
            }

            float slayerLevel = player.GetSkillFactor(SlayerSkill.Type) * 100f;

            if (slayerLevel < entry.LevelReq)
            {
                return;
            }

            player.RaiseSkill(SlayerSkill.Type, entry.XP);

            SlayerTracking.LastPlayerAttacker.Remove(__instance); // Certain weapons deal poison DoT etc, this should fix not receiving slayer xp due to that.
        }
    }
}