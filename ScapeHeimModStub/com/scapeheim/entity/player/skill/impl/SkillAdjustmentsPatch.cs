using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl
{
    [HarmonyPatch(typeof(Skills))]
    class SkillAdjustmentsPatch
    {

        /**
        * Removes skill drain on death
        * 0.25 -> 0
        **/
        [HarmonyPatch("OnDeath")]
        [HarmonyPrefix]
        static void RemoveSkillDrain(ref float ___m_DeathLowerFactor)
        {
            ___m_DeathLowerFactor = 0f;
            Jotunn.Logger.LogInfo($"[ScapeHeim]: New modified death lower factor. (Current: {___m_DeathLowerFactor})");
        }

        /**
        * Sets max total skill cap a player can reach
        * 600 -> 1100
        **/
        [HarmonyPatch("GetTotalSkillCap")]
        [HarmonyPostfix]
        static void HigherTotalSkillCap(ref float ___m_totalSkillCap)
        {
            ___m_totalSkillCap = 2000f;
            Jotunn.Logger.LogInfo($"[ScapeHeim]: New modified total skill cap loaded successfully. (Current: {___m_totalSkillCap})");
        }
    }
}
