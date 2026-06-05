namespace ScapeHeimModStub.com.scapeheim.entity.player.shops
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
}
