using HarmonyLib;

namespace ScapeHeimModStub.com.scapeheim.content.pieces
{
    [HarmonyPatch(typeof(WearNTear), "UpdateWear")]
    public static class NoWeatherStructureDamagePatch
    {
        private static bool Prefix(WearNTear __instance, ref bool __state)
        {
            if (__instance.m_piece == null)
                return true;

            if (__instance.GetComponent<Ship>() != null)
                return true;

            // Save original value
            __state = __instance.m_noRoofWear;

            // Temporarily disable weather wear
            __instance.m_noRoofWear = false;

            return true;
        }

        private static void Postfix(WearNTear __instance, bool __state)
        {
            // Restore original value
            __instance.m_noRoofWear = __state;
        }
    }
}