using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Views;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;


namespace Waiter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Navigation.PushAsync(new LoginPage());
        }

        private async void Button_StartScan(object sender, EventArgs e)
        {
            ZXingScannerPage scannerPage = new ZXingScannerPage();

            await Navigation.PushAsync(scannerPage);

            scannerPage.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();

                    await Navigation.PushAsync(new MenuPage());
                });
            };
        }

        private void Button_Menu_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MenuPage());
        }
    }
}
