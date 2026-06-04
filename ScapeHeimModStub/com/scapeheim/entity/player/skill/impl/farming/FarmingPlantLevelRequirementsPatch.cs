using HarmonyLib;
using ScapeHeimModStub.com.scapeheim.entity.player.skill.skillunlockpopups;
using System.Collections.Generic;
using UnityEngine;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.farming
{
    [HarmonyPatch(typeof(Player), nameof(Player.HaveRequirements), typeof(Piece), typeof(Player.RequirementMode))]
    internal static class FarmingPlantLevelRequirementsPatch
    {
        [HarmonyPostfix]
        private static void Postfix(
            Player __instance,
            Piece piece,
            Player.RequirementMode mode,
            ref bool __result
        )
        {
            if (__instance == null || piece == null)
                return;

            if (mode != Player.RequirementMode.CanBuild)
                return;

            string prefabName = Utils.GetPrefabName(piece.gameObject);

            if (!FarmingData.TryGet(prefabName, out SkillEntry entry))
                return;

            int farmingLevel = Mathf.FloorToInt(
                __instance.GetSkillLevel(Skills.SkillType.Farming)
            );

            if (farmingLevel < entry.LevelReq)
            {
                __result = false;
            }
        }
    }

    [HarmonyPatch(typeof(Player), nameof(Player.TryPlacePiece))]
    internal static class FarmingPlantBlockPlacementPatch
    {
        [HarmonyPrefix]
        private static bool Prefix(Player __instance, Piece piece, ref bool __result)
        {
            if (__instance == null || piece == null)
                return true;

            string prefabName = Utils.GetPrefabName(piece.gameObject);

            if (!FarmingData.TryGet(prefabName, out SkillEntry entry))
                return true;

            int farmingLevel = Mathf.FloorToInt(
                __instance.GetSkillLevel(Skills.SkillType.Farming)
            );

            if (farmingLevel >= entry.LevelReq)
                return true;

            string itemName = FarmingData.GetDisplayName(prefabName, piece.m_name);

            if (Localization.instance != null)
                itemName = Localization.instance.Localize(itemName);

            __result = false;
            return false;
        }
    }

    [HarmonyPatch(typeof(Player), nameof(Player.TryPlacePiece))]
    internal static class FarmingPlantXpPatch
    {
        [HarmonyPostfix]
        private static void Postfix(Player __instance, Piece piece, bool __result)
        {
            // only give XP if placement actually succeeded
            if (!__result) return;
            if (__instance == null || piece == null) return;

            string prefabName = Utils.GetPrefabName(piece.gameObject);

            if (!FarmingData.TryGet(prefabName, out SkillEntry entry))
                return;

            SkillExperience.Award(__instance, Skills.SkillType.Farming, entry.XP);
        }
    }

    [HarmonyPatch(typeof(PieceTable), nameof(PieceTable.UpdateAvailable))]
    internal static class FarmingPlantDescriptionPatch
    {
        private static readonly Dictionary<string, string> OriginalDescriptions = new();

        [HarmonyPostfix]
        private static void Postfix(PieceTable __instance, Player player)
        {
            if (__instance == null || player == null)
                return;

            foreach (GameObject prefab in __instance.m_pieces)
            {
                if (prefab == null)
                    continue;

                Piece piece = prefab.GetComponent<Piece>();
                if (piece == null)
                    continue;

                string prefabName = Utils.GetPrefabName(piece.gameObject);

                if (!FarmingData.TryGet(prefabName, out SkillEntry entry))
                    continue;

                if (!OriginalDescriptions.ContainsKey(prefabName))
                {
                    OriginalDescriptions[prefabName] = piece.m_description ?? "";
                }

                int farmingLevel = Mathf.FloorToInt(
                    player.GetSkillLevel(Skills.SkillType.Farming)
                );

                string color = farmingLevel >= entry.LevelReq ? "orange" : "red";
                string originalDesc = OriginalDescriptions[prefabName];

                piece.m_description =
                    $"<color={color}>Requires Farming level {entry.LevelReq}</color>" +
                    (string.IsNullOrWhiteSpace(originalDesc) ? "" : $"\n{originalDesc}");
            }
        }
    }
}