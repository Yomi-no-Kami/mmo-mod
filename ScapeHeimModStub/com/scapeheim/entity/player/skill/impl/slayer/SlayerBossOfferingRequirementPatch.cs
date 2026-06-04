using HarmonyLib;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.slayer
{
    [HarmonyPatch(typeof(Humanoid), nameof(Humanoid.UseItem))]
    internal static class SlayerBossOfferingBlockPatch
    {
        private static bool Prefix(Player __instance, ItemDrop.ItemData item)
        {
            if (__instance == null || item == null)
            {
                return true;
            }

            string itemName = item.m_dropPrefab?.name ?? item.m_shared.m_name;

            int required = itemName switch
            {
                "TrophyDeer" => 20,
                "AncientSeed" => 40,
                "WitheredBone" => 50,
                "DragonEgg" => 60,
                "GoblinTotem" => 70,
                "DvergrKey" => 80, // first time time kill mistlands boss
                "TrophySeekerBrute" => 80, // Subsequent kills mistlands boss
                "Bell" => 90,
                _ => 0
            };

            if (required <= 0)
            {
                return true;
            }

            float level = __instance.GetSkillFactor(SlayerSkill.Type) * 100f;

            if (level < required)
            {
                __instance.Message(
                    MessageHud.MessageType.Center,
                    $"You need a Slayer level of {required} to make this offering"
                );

                return false;
            }

            return true;
        }
    }
}