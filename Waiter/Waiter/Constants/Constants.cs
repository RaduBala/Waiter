using Xamarin.Forms;

namespace Waiter.Constans
{
    public static class Constants
    {
        public static string RestUrl = Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:5001/api/todoitems/{0}" : "https://localhost:5001/api/todoitems/{0}";
    }
}
