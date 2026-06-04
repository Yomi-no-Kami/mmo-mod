using HarmonyLib;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.crafting
{
    [HarmonyPatch(typeof(Player), nameof(Player.PlacePiece))]
    internal static class CraftingBuildPieceExperienceGainPatch
    {
        private static void Postfix(Player __instance)
        {
            if (__instance == null)
            {
                return;
            }

            // Vanilla already gives 0.25f
            // Add another 0.25f for total 0.50f
            __instance.RaiseSkill(
                Skills.SkillType.Crafting,
                0.25f
            );
        }
    }
}