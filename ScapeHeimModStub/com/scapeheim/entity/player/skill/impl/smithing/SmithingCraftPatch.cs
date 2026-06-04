using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.smithing
{
    [HarmonyPatch(typeof(InventoryGui))]
    public static class SmithingCraftPatch
    {

        [HarmonyPatch(nameof(InventoryGui.DoCrafting))]
        [HarmonyPrefix]
        private static bool DoCraftingPrefix(
    InventoryGui __instance,
    Player player
)
        {
            if (__instance?.m_craftRecipe == null || player == null)
            {
                return true;
            }

            if (player.m_currentStation == null)
            {
                return true;
            }

            string station =
                player.m_currentStation.name.ToLower();

            if (!station.Contains("forge"))
            {
                return true;
            }

            string item =
                __instance.m_craftRecipe.m_item.gameObject.name
                    .Replace("(Clone)", "")
                    .Trim();

            if (!SmithingData.TryGet(item, out var data))
            {
                return true;
            }

            float level =
                SkillExperience.GetLevel(
                    player,
                    SmithingSkill.Type
                );

            if (level < data.LevelReq)
            {
                MessageHud.instance.ShowMessage(
                    MessageHud.MessageType.Center,
                    $"Smithing level {data.LevelReq} required"
                );

                return false;
            }

            return true;
        }
        /*
         * Prevent crafting + award XP
         */
        [HarmonyPatch(nameof(InventoryGui.DoCrafting))]
        [HarmonyPostfix]
        private static void DoCraftingPostfix(
    InventoryGui __instance,
    Player player
)
        {
            if (__instance?.m_craftRecipe == null || player == null)
            {
                return;
            }

            if (player.m_currentStation == null)
            {
                return;
            }

            string station =
                player.m_currentStation.name.ToLower();

            if (!station.Contains("forge"))
            {
                return;
            }

            string item =
                __instance.m_craftRecipe.m_item.gameObject.name
                    .Replace("(Clone)", "")
                    .Trim();

            if (!SmithingData.TryGet(item, out var data))
            {
                return;
            }

            SkillExperience.Award(
                player,
                SmithingSkill.Type,
                data.XP
            );
        }

        /*
         * Grey out recipe in crafting list
         */
        [HarmonyPatch(nameof(InventoryGui.AddRecipeToList))]
        [HarmonyPrefix]
        private static void AddRecipeToListPrefix(
            Recipe recipe,
            ref bool canCraft
        )
        {
            if (Player.m_localPlayer == null || recipe == null)
            {
                return;
            }

            string item =
                recipe.m_item.gameObject.name
                    .Replace("(Clone)", "")
                    .Trim();

            if (!SmithingData.TryGet(item, out var data))
            {
                return;
            }

            float level =
                SkillExperience.GetLevel(
                    Player.m_localPlayer,
                    SmithingSkill.Type
                );

            if (level < data.LevelReq)
            {
                canCraft = false;
            }
        }

        /*
         * Red requirement text + disable button
         */
        [HarmonyPatch(nameof(InventoryGui.UpdateRecipe))]
        [HarmonyPostfix]
        private static void UpdateRecipePostfix(
    InventoryGui __instance
)
        {
            if (Player.m_localPlayer == null)
            {
                return;
            }

            if (__instance.m_selectedRecipe.Recipe == null)
            {
                return;
            }

            Recipe recipe =
                __instance.m_selectedRecipe.Recipe;

            string item =
                recipe.m_item.gameObject.name
                    .Replace("(Clone)", "")
                    .Trim();

            if (!SmithingData.TryGet(item, out var data))
            {
                __instance.m_recipeName.color = Color.white;
                __instance.m_recipeDecription.color = Color.white;

                return;
            }

            float level =
                SkillExperience.GetLevel(
                    Player.m_localPlayer,
                    SmithingSkill.Type
                );

            bool locked =
                level < data.LevelReq;

            if (locked)
            {
                string requirement =
                    $"<color=red>Smithing level {data.LevelReq} required!</color>\n\n";

                // Prevent duplicate appending every frame
                if (!__instance.m_recipeDecription.text.Contains("Smithing level"))
                {
                    __instance.m_recipeDecription.text =
                        requirement +
                        $"<color=white>{__instance.m_recipeDecription.text}</color>";
                }

                // Keep title white
                __instance.m_recipeName.color = Color.white;

                // Keep description white
                __instance.m_recipeDecription.color = Color.white;

                __instance.m_craftButton.interactable = false;

                return;
            }

            __instance.m_recipeName.color = Color.white;
            __instance.m_recipeDecription.color = Color.white;

            // only re-enable if vanilla says it's allowed
            bool hasRequirements =
                Player.m_localPlayer.HaveRequirements(
                    recipe,
                    false,
                    1
                );

            __instance.m_craftButton.interactable &=
    hasRequirements;
        }
    }
}