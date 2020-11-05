using System;
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

            MainPage = new TabbedMenuPage();
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
