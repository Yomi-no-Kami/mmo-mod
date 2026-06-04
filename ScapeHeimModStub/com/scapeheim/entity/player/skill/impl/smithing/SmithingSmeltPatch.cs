using HarmonyLib;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.smithing
{
    [HarmonyPatch(typeof(Smelter))]
    internal static class SmithingSmeltPatch
    {
        /*
         * Awards smithing XP when bars finish smelting.
         *
         * Works for:
         * - Smelter
         * - Blast furnace
         */
        [HarmonyPatch("Spawn")]
        [HarmonyPostfix]
        private static void SpawnPostfix(
            string ore,
            int stack
        )
        {
            if (string.IsNullOrEmpty(ore))
            {
                return;
            }

            Player player = Player.m_localPlayer;

            if (player == null)
            {
                return;
            }

            string item =
                ore.Replace("(Clone)", "")
                    .Trim();

            if (!SmithingData.TryGet(item, out var data))
            {
                return;
            }

            SkillExperience.Award(
                player,
                SmithingSkill.Type,
                data.XP * stack
            );
        }
    }
}