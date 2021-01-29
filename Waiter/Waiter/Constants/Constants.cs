using Xamarin.Forms;

namespace Waiter.Constans
{
    public static class Constants
    {
        public static string RestaurantKey = "-MQ8WbI5F945eeeEs6Za";

        public static string FirebaseUrl = "https://waiterdatabase.firebaseio.com/";

        public static string RestaurantConnectedEventName = "RestaurantConnected";

        public static string RestaurantDisconnectedEventName = "RestaurantDisconnected";

        public static string AddOrderEventName = "AddOrder";

        public static string RemoveOrderEventName = "RemoveOrder";

        public static string NfcScanActivateEventName = "NfcScanActivate";

        public static string NfcReadTagEventName = "NfcReadTag";

        public static string NfcWriteTagEventName = "NfcWriteTag";

        public static string NfcWriteTagFinishEventName = "NfcWriteTagFinish";
    }
}
