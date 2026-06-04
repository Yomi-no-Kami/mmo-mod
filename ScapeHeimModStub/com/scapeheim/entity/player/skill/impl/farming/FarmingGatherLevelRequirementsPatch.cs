using HarmonyLib;
using ScapeHeimModStub.com.scapeheim.entity.player.skill.skillunlockpopups;
using UnityEngine;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.farming
{
    [HarmonyPatch(typeof(Pickable), nameof(Pickable.GetHoverText))]
    public static class FarmingGatherLevelRequirementsPatch
    {
        [HarmonyPrefix]
        private static bool Prefix(Pickable __instance, ref string __result)
        {
            if (Player.m_localPlayer == null || __instance == null)
                return true;

            string prefabName = __instance.name.Replace("(Clone)", "").Trim();

            if (!FarmingData.TryGet(prefabName, out SkillEntry entry))
                return true;

            int farmingLevel = Mathf.FloorToInt(
                Player.m_localPlayer.GetSkillLevel(Skills.SkillType.Farming)
            );

            if (farmingLevel >= entry.LevelReq)
                return true;

            string itemName = prefabName;

            ItemDrop itemDrop = __instance.GetComponent<ItemDrop>();
            if (itemDrop != null)
            {
                itemName = Localization.instance != null
                    ? Localization.instance.Localize(itemDrop.m_itemData.m_shared.m_name)
                    : itemDrop.m_itemData.m_shared.m_name;
            }

            // override display name
            itemName = FarmingData.GetDisplayName(prefabName, itemName);

            string useKey = Localization.instance != null
                ? Localization.instance.Localize("$KEY_Use")
                : "Use";

            string pickupText = Localization.instance != null
                ? Localization.instance.Localize("$inventory_pickup")
                : "Pick up";

            __result =
                $"{itemName}\n" +
                $"<color=red>A Farming level of {entry.LevelReq} is required to gather {itemName}!</color>\n" +
                $"[<color=yellow><b>{useKey}</b></color>] {pickupText}";

            return false;
        }
    }

    [HarmonyPatch(typeof(Pickable), nameof(Pickable.RPC_Pick))]
    internal static class FarmingPickableXpPatch
    {
        private static void Prefix(Pickable __instance, ref bool __state)
        {
            if (__instance == null)
            {
                __state = false;
                return;
            }

            // capture state BEFORE pickup
            __state = !__instance.GetPicked();
        }

        private static void Postfix(Pickable __instance, bool __state)
        {
            if (__instance == null)
                return;

            // already picked before interaction started → ignore spam
            if (!__state)
                return;

            string prefabName = __instance.name.Replace("(Clone)", "").Trim();

            if (!FarmingData.TryGet(prefabName, out SkillEntry entry))
                return;

            if (Player.m_localPlayer == null)
                return;

            SkillExperience.Award(
                Player.m_localPlayer,
                Skills.SkillType.Farming,
                entry.XP
            );
        }
    }

    [HarmonyPatch(typeof(Pickable), nameof(Pickable.Interact))]
    public static class FarmingPickableBlockPatch
    {
        [HarmonyPrefix]
        private static bool Prefix(
            Pickable __instance,
            Humanoid character,
            bool repeat,
            bool alt
        )
        {
            if (Player.m_localPlayer == null || __instance == null)
                return true;

            string prefabName = __instance.name.Replace("(Clone)", "").Trim();

            if (!FarmingData.TryGet(prefabName, out SkillEntry entry))
                return true;

            float farmingLevel =
                Player.m_localPlayer.GetSkills().GetSkillLevel(Skills.SkillType.Farming);

            if (farmingLevel < entry.LevelReq)
            {
                string itemName = prefabName;

                ItemDrop itemDrop = __instance.GetComponent<ItemDrop>();
                if (itemDrop != null)
                {
                    itemName = Localization.instance != null
                        ? Localization.instance.Localize(itemDrop.m_itemData.m_shared.m_name)
                        : itemDrop.m_itemData.m_shared.m_name;
                }

                // override display name
                itemName = FarmingData.GetDisplayName(prefabName, itemName);

                string msg =
                    $"<color=red>A Farming level of {entry.LevelReq} is required to gather {itemName}!</color>";

                MessageHud.instance?.ShowMessage(
                    MessageHud.MessageType.Center,
                    msg
                );

                return false; // BLOCK INTERACTION
            }

            return true;
        }
    }
}