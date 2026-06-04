using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScapeHeimModStub.com.scapeheim.content.pieces
{
    internal class FartherBuildDistancePatch
    {

        [HarmonyPatch("RemovePiece")]
        [HarmonyPatch("UpdateWearNTearHover")]
        [HarmonyPatch("PieceRayTest")]
        [HarmonyPrefix]
        /**
         * Increases the player's max place distance for placing and removing objects
         */
        static void FartherPlaceDistance(ref float ___m_maxPlaceDistance)
        {
            ___m_maxPlaceDistance = 15f; // Original value: 5f
        }
    }
}
