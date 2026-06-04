using Jotunn.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace ScapeHeimModStub.com.scapeheim.entity.player.shops.ui
{
    public class ShopItem
    {
        public string displayName;
        public string prefabName;
        public int price;

        public ShopItem(string displayName, string prefabName, int price)
        {
            this.displayName = displayName;
            this.prefabName = prefabName;
            this.price = price;
        }
    }

    public class ShopUI : MonoBehaviour
    {
        private static ShopUI Instance;

        private GameObject overlay;
        private GameObject panel;

        private GameObject buyContent;
        private GameObject sellContent;

        public static void Init()
        {
            if (Instance != null)
                return;

            GameObject obj = new GameObject("ShopUI");
            DontDestroyOnLoad(obj);

            Instance = obj.AddComponent<ShopUI>();
            Instance.Build();
        }

        private void Build()
        {
            if (GUIManager.Instance == null || GUIManager.CustomGUIFront == null)
            {
                Debug.LogError("[ShopUI] GUIManager not ready.");
                return;
            }

            // OVERLAY
            overlay = new GameObject("ShopOverlay");
            overlay.transform.SetParent(GUIManager.CustomGUIFront.transform, false);

            RectTransform overlayRt = overlay.AddComponent<RectTransform>();
            overlayRt.anchorMin = Vector2.zero;
            overlayRt.anchorMax = Vector2.one;
            overlayRt.offsetMin = Vector2.zero;
            overlayRt.offsetMax = Vector2.zero;

            Image overlayBg = overlay.AddComponent<Image>();
            overlayBg.color = new Color(0f, 0f, 0f, 0.75f);

            // MAIN PANEL
            panel = new GameObject("ShopPanel");
            panel.transform.SetParent(overlay.transform, false);

            RectTransform panelRt = panel.AddComponent<RectTransform>();
            panelRt.anchorMin = new Vector2(0.1f, 0.1f);
            panelRt.anchorMax = new Vector2(0.9f, 0.9f);
            panelRt.offsetMin = Vector2.zero;
            panelRt.offsetMax = Vector2.zero;

            Image panelBg = panel.AddComponent<Image>();
            panelBg.color = new Color(0.12f, 0.12f, 0.12f, 0.95f);

            overlay.SetActive(false);

            // CLOSE BUTTON
            GameObject closeBtn = new GameObject("CloseButton");
            closeBtn.transform.SetParent(panel.transform, false);

            Image closeImg = closeBtn.AddComponent<Image>();
            closeImg.color = new Color(0.8f, 0.2f, 0.2f, 1f);

            Button closeButton = closeBtn.AddComponent<Button>();

            RectTransform closeRt = closeBtn.GetComponent<RectTransform>();
            closeRt.anchorMin = new Vector2(1f, 1f);
            closeRt.anchorMax = new Vector2(1f, 1f);
            closeRt.pivot = new Vector2(1f, 1f);
            closeRt.anchoredPosition = new Vector2(-10f, -10f);
            closeRt.sizeDelta = new Vector2(28f, 28f);

            GameObject closeTextObj = new GameObject("Text");
            closeTextObj.transform.SetParent(closeBtn.transform, false);

            Text closeText = closeTextObj.AddComponent<Text>();
            closeText.text = "X";
            closeText.font = GUIManager.Instance.AveriaSerifBold;
            closeText.fontSize = 16;
            closeText.alignment = TextAnchor.MiddleCenter;
            closeText.color = Color.white;

            RectTransform ct = closeText.GetComponent<RectTransform>();
            ct.anchorMin = Vector2.zero;
            ct.anchorMax = Vector2.one;
            ct.offsetMin = Vector2.zero;
            ct.offsetMax = Vector2.zero;

            closeButton.onClick.AddListener(() => Hide());

            // TITLE
            GUIManager.Instance.CreateText(
                text: "Shop Name",
                parent: panel.transform,
                anchorMin: new Vector2(0f, 1f),
                anchorMax: new Vector2(0f, 1f),
                position: new Vector2(220f, -30f),
                font: GUIManager.Instance.AveriaSerifBold,
                fontSize: 30,
                color: GUIManager.Instance.ValheimOrange,
                outline: true,
                outlineColor: Color.black,
                width: 400f,
                height: 40f,
                addContentSizeFitter: false
            );

            // BUY PANEL
            GameObject buyPanel = new GameObject("BuyPanel");
            buyPanel.transform.SetParent(panel.transform, false);

            RectTransform buyRt = buyPanel.AddComponent<RectTransform>();
            buyRt.anchorMin = new Vector2(0.03f, 0.05f);
            buyRt.anchorMax = new Vector2(0.48f, 0.88f);
            buyRt.offsetMin = Vector2.zero;
            buyRt.offsetMax = Vector2.zero;

            Image buyBg = buyPanel.AddComponent<Image>();
            buyBg.color = new Color(0.20f, 0.20f, 0.20f, 1f);

            CreateSectionTitle("Buy", buyPanel.transform, new Vector2(0.03f, 0.88f), new Vector2(0.48f, 0.88f));

            buyContent = CreateScrollGrid("BuyScroll", buyPanel.transform, 3);

            // SELL PANEL
            GameObject sellPanel = new GameObject("SellPanel");
            sellPanel.transform.SetParent(panel.transform, false);

            RectTransform sellRt = sellPanel.AddComponent<RectTransform>();
            sellRt.anchorMin = new Vector2(0.52f, 0.05f);
            sellRt.anchorMax = new Vector2(0.97f, 0.88f);
            sellRt.offsetMin = Vector2.zero;
            sellRt.offsetMax = Vector2.zero;

            Image sellBg = sellPanel.AddComponent<Image>();
            sellBg.color = new Color(0.20f, 0.20f, 0.20f, 1f);

            CreateSectionTitle("Sell", sellPanel.transform, new Vector2(0.52f, 0.88f), new Vector2(0.97f, 0.88f));

            sellContent = CreateScrollGrid("SellScroll", sellPanel.transform, 3);
        }

        private GameObject CreateScrollGrid(string name, Transform parent, int columns)
        {
            GameObject scrollObj = new GameObject(name);
            scrollObj.transform.SetParent(parent, false);

            RectTransform scrollRt = scrollObj.AddComponent<RectTransform>();
            scrollRt.anchorMin = new Vector2(0.03f, 0.05f);
            scrollRt.anchorMax = new Vector2(0.97f, 0.85f);
            scrollRt.offsetMin = Vector2.zero;
            scrollRt.offsetMax = Vector2.zero;

            ScrollRect scrollRect = scrollObj.AddComponent<ScrollRect>();
            scrollRect.horizontal = false;
            scrollRect.vertical = true;

            Image bg = scrollObj.AddComponent<Image>();
            bg.color = new Color(0, 0, 0, 0);

            GameObject viewport = new GameObject("Viewport");
            viewport.transform.SetParent(scrollObj.transform, false);

            RectTransform vpRt = viewport.AddComponent<RectTransform>();
            vpRt.anchorMin = Vector2.zero;
            vpRt.anchorMax = Vector2.one;
            vpRt.offsetMin = Vector2.zero;
            vpRt.offsetMax = Vector2.zero;

            Image vpImg = viewport.AddComponent<Image>();
            vpImg.color = new Color(1, 1, 1, 0.01f);

            Mask mask = viewport.AddComponent<Mask>();
            mask.showMaskGraphic = false;

            GameObject content = new GameObject("Content");
            content.transform.SetParent(viewport.transform, false);

            RectTransform contentRt = content.AddComponent<RectTransform>();
            contentRt.anchorMin = new Vector2(0, 1);
            contentRt.anchorMax = new Vector2(1, 1);
            contentRt.pivot = new Vector2(0.5f, 1f);
            contentRt.sizeDelta = Vector2.zero;

            GridLayoutGroup grid = content.AddComponent<GridLayoutGroup>();
            grid.cellSize = new Vector2(170, 80);
            grid.spacing = new Vector2(12, 12);
            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            grid.constraintCount = columns;

            ContentSizeFitter fitter = content.AddComponent<ContentSizeFitter>();
            fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

            scrollRect.viewport = vpRt;
            scrollRect.content = contentRt;

            return content;
        }

        private void CreateSectionTitle(string text, Transform parent, Vector2 anchorMin, Vector2 anchorMax)
        {
            GUIManager.Instance.CreateText(
                text: text,
                parent: parent,
                anchorMin: anchorMin,
                anchorMax: anchorMax,
                position: new Vector2(100f, 10f),
                font: GUIManager.Instance.AveriaSerifBold,
                fontSize: 24,
                color: Color.white,
                outline: true,
                outlineColor: Color.black,
                width: 200f,
                height: 40f,
                addContentSizeFitter: false
            );
        }

        private Sprite GetItemIcon(string prefabName)
        {
            var prefab = ObjectDB.instance.GetItemPrefab(prefabName);
            if (prefab == null) return null;

            var itemDrop = prefab.GetComponent<ItemDrop>();
            if (itemDrop == null || itemDrop.m_itemData?.m_shared?.m_icons == null)
                return null;

            return itemDrop.m_itemData.m_shared.m_icons[0];
        }

        public GameObject CreateItemCard(Transform parent, ShopItem item)
        {
            Sprite icon = GetItemIcon(item.prefabName);

            GameObject card = new GameObject("ItemCard");
            card.transform.SetParent(parent, false);

            Image bg = card.AddComponent<Image>();
            bg.color = new Color(0.25f, 0.25f, 0.25f, 1f);

            RectTransform rt = card.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(170, 80);

            GameObject iconObj = new GameObject("Icon");
            iconObj.transform.SetParent(card.transform, false);

            Image iconImg = iconObj.AddComponent<Image>();
            iconImg.sprite = icon;
            iconImg.preserveAspect = true;

            RectTransform iconRt = iconObj.GetComponent<RectTransform>();
            iconRt.anchorMin = new Vector2(0, 0.5f);
            iconRt.anchorMax = new Vector2(0, 0.5f);
            iconRt.pivot = new Vector2(0, 0.5f);
            iconRt.anchoredPosition = new Vector2(6, 10);
            iconRt.sizeDelta = new Vector2(32, 32);

            // NAME + PRICE SPLIT FIX
            GameObject textObj = new GameObject("Text");
            textObj.transform.SetParent(card.transform, false);

            RectTransform tr = textObj.AddComponent<RectTransform>();
            tr.anchorMin = new Vector2(0, 0);
            tr.anchorMax = new Vector2(1, 1);
            tr.offsetMin = new Vector2(45, 10);
            tr.offsetMax = new Vector2(-5, 25);

            // NAME (WHITE)
            GameObject nameObj = new GameObject("Name");
            nameObj.transform.SetParent(textObj.transform, false);

            Text nameText = nameObj.AddComponent<Text>();
            nameText.text = item.displayName;
            nameText.font = GUIManager.Instance.AveriaSerifBold;
            nameText.fontSize = 13;
            nameText.color = Color.white;
            nameText.alignment = TextAnchor.UpperLeft;

            RectTransform nt = nameObj.GetComponent<RectTransform>();
            nt.anchorMin = new Vector2(0, 0.5f);
            nt.anchorMax = new Vector2(1, 1);
            nt.offsetMin = Vector2.zero;
            nt.offsetMax = Vector2.zero;

            // PRICE (YELLOW ONLY)
            GameObject priceObj = new GameObject("Price");
            priceObj.transform.SetParent(textObj.transform, false);

            Text priceText = priceObj.AddComponent<Text>();
            priceText.text = $"{item.price}g";
            priceText.font = GUIManager.Instance.AveriaSerifBold;
            priceText.fontSize = 12;
            priceText.color = new Color(1f, 0.85f, 0.2f);
            priceText.alignment = TextAnchor.LowerLeft;

            RectTransform pt = priceObj.GetComponent<RectTransform>();
            pt.anchorMin = new Vector2(0, 0);
            pt.anchorMax = new Vector2(1, 0.5f);
            pt.offsetMin = Vector2.zero;
            pt.offsetMax = Vector2.zero;

            // BUTTON
            GameObject btnObj = new GameObject("BuyButton");
            btnObj.transform.SetParent(card.transform, false);

            Image btnImg = btnObj.AddComponent<Image>();
            btnImg.color = new Color(0.2f, 0.6f, 0.2f, 1f);

            Button btn = btnObj.AddComponent<Button>();

            RectTransform btnRt = btnObj.GetComponent<RectTransform>();
            btnRt.anchorMin = new Vector2(0.5f, 0);
            btnRt.anchorMax = new Vector2(0.5f, 0);
            btnRt.pivot = new Vector2(0.5f, 0);
            btnRt.anchoredPosition = new Vector2(0, 4);
            btnRt.sizeDelta = new Vector2(80, 20);

            GameObject btnTextObj = new GameObject("Text");
            btnTextObj.transform.SetParent(btnObj.transform, false);

            Text btnText = btnTextObj.AddComponent<Text>();
            btnText.text = "BUY";
            btnText.font = GUIManager.Instance.AveriaSerifBold;
            btnText.fontSize = 11;
            btnText.alignment = TextAnchor.MiddleCenter;
            btnText.color = Color.white;

            RectTransform bt = btnText.GetComponent<RectTransform>();
            bt.anchorMin = Vector2.zero;
            bt.anchorMax = Vector2.one;
            bt.offsetMin = Vector2.zero;
            bt.offsetMax = Vector2.zero;

            btn.onClick.AddListener(() =>
            {
                Debug.Log($"Buying {item.prefabName}");
            });

            return card;
        }

        public static void Show()
        {
            if (Instance == null)
                Init();

            Instance.overlay.SetActive(true);
            GUIManager.BlockInput(true);

            var items = new ShopItem[]
            {
                new ShopItem("Wood", "Wood", 2),
                new ShopItem("Stone", "Stone", 3),
                new ShopItem("Copper", "CopperOre", 30),
                new ShopItem("Iron Ore", "IronOre", 75)
            };

            foreach (var item in items)
                Instance.CreateItemCard(Instance.buyContent.transform, item);
        }

        public static void Hide()
        {
            if (Instance == null)
                return;

            Instance.overlay.SetActive(false);
            GUIManager.BlockInput(false);
        }
    }
}