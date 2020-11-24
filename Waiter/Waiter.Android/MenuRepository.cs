using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using Java.Util;
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

            item.Put("Title", order.Title);
            item.Put("Ingredients", order.Ingredients);
            item.Put("Price", order.Price);

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

            await Task.Run(RetrivedDataUpdated);

            return MenuList;
        }
    }
}