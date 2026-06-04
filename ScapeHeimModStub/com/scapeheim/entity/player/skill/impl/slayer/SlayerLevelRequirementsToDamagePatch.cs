using HarmonyLib;
using ScapeHeimModStub.com.scapeheim.entity.player.skill.skillunlockpopups;
using UnityEngine;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.slayer
{
    [HarmonyPatch(typeof(Character), nameof(Character.Damage))]
    internal static class SlayerLevelRequirementsToDamagePatch
    {
        private static void Prefix(Character __instance, HitData hit)
        {
            if (__instance == null)
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

            string prefabName = Utils.GetPrefabName(__instance.gameObject);

            if (!SlayerData.TryGet(prefabName, out SkillEntry entry))
            {
                return;
            }

            float slayerLevel = player.GetSkillFactor(SlayerSkill.Type) * 100f;

            if (slayerLevel >= entry.LevelReq)
            {
                return;
            }

            // Zero all damage types
            hit.m_damage.m_blunt = 0f;
            hit.m_damage.m_slash = 0f;
            hit.m_damage.m_pierce = 0f;
            hit.m_damage.m_chop = 0f;
            hit.m_damage.m_pickaxe = 0f;
            hit.m_damage.m_fire = 0f;
            hit.m_damage.m_frost = 0f;
            hit.m_damage.m_lightning = 0f;
            hit.m_damage.m_poison = 0f;
            hit.m_damage.m_spirit = 0f;

            if (player == Player.m_localPlayer)
            {
                player.Message(
                    MessageHud.MessageType.Center,
                    $"You need Slayer level {entry.LevelReq} to damage {__instance.m_name}"
                );
            }
        }
    }
}
