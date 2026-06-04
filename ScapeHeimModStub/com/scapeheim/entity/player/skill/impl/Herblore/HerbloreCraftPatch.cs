using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.herblore
{
    [HarmonyPatch(typeof(InventoryGui))]
    public static class HerbloreCraftPatch
    {
        /*
         * BLOCK + REQUIREMENT CHECK
         */
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

            string item =
                __instance.m_craftRecipe.m_item.gameObject.name
                    .Replace("(Clone)", "")
                    .Trim();

            if (!HerbloreData.TryGet(item, out var data))
            {
                return true;
            }

            float level =
                SkillExperience.GetLevel(
                    player,
                    HerbloreSkill.Type
                );

            if (level < data.LevelReq)
            {
                MessageHud.instance.ShowMessage(
                    MessageHud.MessageType.Center,
                    $"Herblore level {data.LevelReq} required"
                );

                return false;
            }

            return true;
        }

        /*
         * GIVE XP AFTER CRAFT
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

            string item =
                __instance.m_craftRecipe.m_item.gameObject.name
                    .Replace("(Clone)", "")
                    .Trim();

            if (!HerbloreData.TryGet(item, out var data))
            {
                return;
            }

            SkillExperience.Award(
                player,
                HerbloreSkill.Type,
                data.XP
            );
        }

        /*
         * GREY OUT RECIPES
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

            if (!HerbloreData.TryGet(item, out var data))
            {
                return;
            }

            float level =
                SkillExperience.GetLevel(
                    Player.m_localPlayer,
                    HerbloreSkill.Type
                );

            if (level < data.LevelReq)
            {
                canCraft = false;
            }
        }

        /*
         * UI RED TEXT + BUTTON LOCK
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

            Recipe recipe = __instance.m_selectedRecipe.Recipe;

            string item =
                recipe.m_item.gameObject.name
                    .Replace("(Clone)", "")
                    .Trim();

            if (!HerbloreData.TryGet(item, out var data))
            {
                __instance.m_recipeName.color = Color.white;
                __instance.m_recipeDecription.color = Color.white;
                return;
            }

            float level =
                SkillExperience.GetLevel(
                    Player.m_localPlayer,
                    HerbloreSkill.Type
                );

            bool locked = level < data.LevelReq;

            if (locked)
            {
                string requirement =
                    $"<color=red>Herblore level {data.LevelReq} required!</color>\n\n";

                if (!__instance.m_recipeDecription.text.Contains("Herblore level"))
                {
                    __instance.m_recipeDecription.text =
                        requirement +
                        $"<color=white>{__instance.m_recipeDecription.text}</color>";
                }

                __instance.m_recipeName.color = Color.white;
                __instance.m_recipeDecription.color = Color.white;

                __instance.m_craftButton.interactable = false;
                return;
            }

            __instance.m_recipeName.color = Color.white;
            __instance.m_recipeDecription.color = Color.white;

            bool hasRequirements =
                Player.m_localPlayer.HaveRequirements(recipe, false, 1);

            __instance.m_craftButton.interactable &= hasRequirements;
        }
    }
}