using HarmonyLib;

namespace ScapeHeimModStub.com.scapeheim.content.dungeons
{
    [HarmonyPatch(typeof(DungeonGenerator), "Awake")]
    public static class BurialChambersDungeonSizePatch
    {
        private static void Postfix(DungeonGenerator __instance)
        {
            // Increase max room cap
            __instance.m_maxRooms = 50;

            // Prevent early tiny dungeons
            __instance.m_minRooms = 20;
            __instance.m_minRequiredRooms = 20;


            // __instance.m_maxRooms = UnityEngine.Random.Range(30, 50);
        }
    }
}