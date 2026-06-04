using Jotunn.Managers;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.skillunlockpopups { 
    public class SkillUnlockPopup : MonoBehaviour { 
        private static SkillUnlockPopup Instance; 
        private GameObject panel; private Image icon; 
        public static void Init() { 
            if (Instance != null) 
                return; 
            GameObject obj = new GameObject("SkillUnlockPopup"); 
            DontDestroyOnLoad(obj); Instance = obj.AddComponent<SkillUnlockPopup>(); 
            Instance.Build(); 
        } 
        private void Build() { 
            if (GUIManager.Instance == null || GUIManager.CustomGUIFront == null) {
                Debug.LogError("[SkillUnlockPopup] GUIManager not ready."); return; 
            } // ROOT (NO WOODPANEL)
              panel = new GameObject("SkillUnlockPopup"); 
            panel.transform.SetParent(GUIManager.CustomGUIFront.transform, false); 
            RectTransform rt = panel.AddComponent<RectTransform>(); 
            rt.anchorMin = new Vector2(0.5f, 0.8f); 
            rt.anchorMax = new Vector2(0.5f, 0.8f); 
            rt.pivot = new Vector2(0.5f, 0.5f); 
            rt.sizeDelta = new Vector2(560f, 90f); 
            // BACKGROUND (TRANSPARENT BLACK)
            Image bg = panel.AddComponent<Image>(); 
            bg.color = new Color(0f, 0f, 0f, 0.75f); 
            bg.raycastTarget = false; panel.SetActive(false); 
            // ICON
            GameObject iconObj = new GameObject("Icon"); 
            iconObj.transform.SetParent(panel.transform, false); 
            icon = iconObj.AddComponent<Image>(); 
            RectTransform iconRt = icon.GetComponent<RectTransform>(); 
            iconRt.anchorMin = new Vector2(0f, 0.5f); 
            iconRt.anchorMax = new Vector2(0f, 0.5f); 
            iconRt.pivot = new Vector2(0f, 0.5f); 
            iconRt.anchoredPosition = new Vector2(10f, 0f); 
            iconRt.sizeDelta = new Vector2(64, 64); 
            
            // TEXT
            GameObject textObj = new GameObject("Text"); 
            textObj.transform.SetParent(panel.transform, false); 
            var txt = textObj.AddComponent<TextMeshProUGUI>(); 
            txt.font = GUIManager.Instance.TMP_AveriaSansLibre; 
            txt.fontSize = 22; txt.color = UnityEngine.Color.white; 
            txt.alignment = TextAlignmentOptions.MidlineLeft; 
            txt.raycastTarget = false; 
            txt.textWrappingMode = TextWrappingModes.Normal; 
            txt.overflowMode = TextOverflowModes.Ellipsis; 
            txt.richText = true; 
            // add padding-safe rect
            RectTransform textRt = txt.GetComponent<RectTransform>(); 
            textRt.anchorMin = new Vector2(0f, 0f); 
            textRt.anchorMax = new Vector2(1f, 1f); 
            textRt.offsetMin = new Vector2(90f, 10f); 
            textRt.offsetMax = new Vector2(-15f, -10f); 
        } 
        public static void Show(Sprite sprite, string message) { 
            if (Instance == null) 
                Init(); 
            Instance.StartCoroutine(Instance.ShowRoutine(sprite, message)); 
        } 
        private IEnumerator ShowRoutine(Sprite sprite, string message) { 
            panel.SetActive(true); 
            icon.sprite = sprite; 
            // update TMP text via child lookup (Jötunn-created)
            TextMeshProUGUI txt = panel.transform.Find("Text")?.GetComponent<TextMeshProUGUI>(); 
            if (txt != null) 
                txt.text = message; 
            yield return new WaitForSeconds(4f); 
            GUIManager.BlockInput(false); 
            panel.SetActive(false); 
        } 
    } 
}