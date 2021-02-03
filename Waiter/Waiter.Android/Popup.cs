using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Waiter.Droid;
using Waiter.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(Popup))]
namespace Waiter.Droid
{
    public class Popup : IPopup
    {
        private Context CurrentContext
        {
            get { return Android.App.Application.Context; }
        }

        public void ShowMessage(string content)
        {
            Toast.MakeText(CurrentContext, content, ToastLength.Short).Show();
        }
    }
}