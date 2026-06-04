using Jotunn;
using ScapeHeimModStub.com.scapeheim.content.customcontent;
using ScapeHeimModStub.com.scapeheim.entity.player.shops;
using ScapeHeimModStub.com.scapeheim.entity.player.shops.ui;
using UnityEngine;

public class GeneralStoreShopkeeper : MonoBehaviour, Hoverable, Interactable
{

    public string GetHoverText() => "Open General Store";
    public string GetHoverName() => "Shopkeeper";

    public bool Interact(Humanoid user, bool hold, bool alt)
    {
        if (hold) return false;

        return true;
    }

    public bool UseItem(Humanoid user, ItemDrop.ItemData item) => false;

}