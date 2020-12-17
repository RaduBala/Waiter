using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Storage;
using Java.Util;
using Plugin.Media;
using Waiter.Droid;
using Waiter.Models;
using Xamarin.Forms;

[assembly : Dependency(typeof(MenuRepository))]
namespace Waiter.Droid
{
    class MenuRepository : IMenuRepository
    {
        private MenuListener menuListener = null;

        private static List<MenuOrder> MenuList = new List<MenuOrder>();

        private bool RetrivedDataFlag = false;

        FirebaseStorage firebaseStorage;

        private void MenuListener_OnRetrived(object sender, Services.MenuDataEventArgs e)
        {
            RetrivedDataFlag = true;

            MenuList = e.MenuOrders;
        }

        private void RetrivedDataUpdated()
        {
            while (false == RetrivedDataFlag) ;
        }

        public void SaveOrder(MenuOrder order)
        {
            HashMap item = new HashMap();

            item.Put("Title"      , order.Title      );
            item.Put("Ingredients", order.Ingredients);
            item.Put("Price"      , order.Price      );
            item.Put("Photo link" , order.PhotoLink  );

            DatabaseReference databaseReference = AppDataHelper.GetDatabase().GetReference("Menu").Child("Order").Push();

            databaseReference.SetValue(item);
        }

        public List<MenuOrder> GetMenu()
        {
            return MenuList; 
        }

        public async Task<List<MenuOrder>> GetMenuAsync()
        {
            if (null == menuListener)
            {
                menuListener = new MenuListener();

                menuListener.OnRetrived += MenuListener_OnRetrived;
            }

            menuListener.RequestData();

            await System.Threading.Tasks.Task.Run(RetrivedDataUpdated);

            return MenuList;
        }

        public async Task<string> GetImage(string PhotoName)
        {
            firebaseStorage = new FirebaseStorage("waiterdatabase.appspot.com");

            string imageUrl = await firebaseStorage.Child("Images").Child(PhotoName).GetDownloadUrlAsync();

            return imageUrl;
        }
    }
}