using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using Waiter.Models;
using Waiter.Services;



namespace Waiter.Droid
{
    class MenuListener : Java.Lang.Object, IValueEventListener
    {
        private List<MenuOrder> MenuList = new List<MenuOrder>();

        public event EventHandler<MenuDataEventArgs> OnRetrived;

        public MenuListener() : base()
        {

        }

        public void RequestData()
        {
            DatabaseReference databaseReference = AppDataHelper.GetDatabase().GetReference("Menu").Child("Order");

            databaseReference.AddValueEventListener(this);
        }

        public void OnCancelled(DatabaseError error)
        {
            throw new NotImplementedException();
        }

        public void OnDataChange(DataSnapshot snapshot)
        {
            if (null != snapshot)
            {
                IEnumerable<DataSnapshot> child = snapshot.Children.ToEnumerable<DataSnapshot>();

                MenuList.Clear();

                foreach(DataSnapshot Order in child)
                {
                    MenuOrder order = new MenuOrder();

                    order.Title       = Order.Child("Title").Value.ToString();
                    order.Price       = int.Parse(Order.Child("Price").Value.ToString());
                    order.Ingredients = Order.Child("Ingredients").Value.ToString();

                    MenuList.Add(order);
                }
            }

            OnRetrived.Invoke(this, new MenuDataEventArgs { MenuOrders = MenuList });
        }
    }
}