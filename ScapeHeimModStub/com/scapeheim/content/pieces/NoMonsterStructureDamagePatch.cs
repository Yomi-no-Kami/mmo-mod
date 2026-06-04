using HarmonyLib;
using UnityEngine;

namespace ScapeHeimModStub.com.scapeheim.content.pieces
{
    [HarmonyPatch(typeof(WearNTear), "RPC_Damage")]
    public static class NoMonsterStructureDamagePatch
    {
        private static void Prefix(WearNTear __instance, long sender, HitData hit)
        {
            if (hit == null)
                return;

            Character attacker = hit.GetAttacker();

            if (attacker == null)
                return;

            if (__instance.m_piece == null)
                return;

            string prefabName = __instance.gameObject.name;

            if (prefabName.Contains("Karve") ||
                prefabName.Contains("VikingShip") ||
                prefabName.Contains("Raft") ||
                    prefabName.Contains("VikingShip_Ashlands"))
            {
                return;
            }


            if (attacker.IsMonsterFaction(Time.time))
            {
                // Remove all incoming structure damage
                hit.m_damage = new HitData.DamageTypes();
            }
        }
    }
}