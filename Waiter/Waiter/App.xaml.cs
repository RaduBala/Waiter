using System;
using Waiter.Services;
using Waiter.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Waiter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TabbedMenuPage())
            {
                BarBackgroundColor = Color.DarkOrange,
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
