using Jotunn.Managers;
using ScapeHeimModStub.com.scapeheim.content.customcontent.locations.generalstore;

namespace ScapeHeimModStub.com.scapeheim.content.customcontent
{
    public static class ScapeHeimContent
    {
        public static void Init()
        {
            // Load ALL custom assets first (important)
            GeneralStoreLocation.Register();

        }
    }
}