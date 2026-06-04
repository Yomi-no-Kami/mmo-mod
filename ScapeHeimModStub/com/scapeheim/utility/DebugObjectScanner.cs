using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ScapeHeimModStub.com.scapeheim.utility
{

    public class DebugObjectScanner : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F8))
            {
                Jotunn.Logger.LogInfo("F8 pressed - scanner running");
                ScanNearbyObjects();
            }
        }

        private void ScanNearbyObjects()
        {
            Player player = Player.m_localPlayer;
            if (player == null)
            {
                Jotunn.Logger.LogWarning("No local player found");
                return;
            }

            Vector3 pos = player.transform.position;

            ZNetView[] all = FindObjectsByType<ZNetView>(FindObjectsSortMode.None);

            Jotunn.Logger.LogInfo("=== F8 OBJECT SCAN ===");

            foreach (var view in all)
            {
                if (view == null) continue;

                float dist = Vector3.Distance(pos, view.transform.position);

                if (dist > 10f) continue; // only nearby objects

                Jotunn.Logger.LogInfo(
                    $"{view.GetPrefabName()} | {view.gameObject.name} | dist: {dist:F1}"
                );
            }
        }
    }
}
