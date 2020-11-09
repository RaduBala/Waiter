using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;


namespace Waiter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Navigation.PushModalAsync(new LoginPage());
        }

        public async void OnScanResult()
        {
            await Navigation.PopModalAsync();

            await Navigation.PushAsync(new MenuPage());
        }

        private async void Button_StartScan(object sender, EventArgs e)
        {
            ZXingScannerPage scannerPage            = new ZXingScannerPage();
            PermissionStatus cameraPermissionStatus = await Permissions.CheckStatusAsync<Permissions.Camera>();

            if (PermissionStatus.Granted != cameraPermissionStatus)
            {
                cameraPermissionStatus = await Permissions.RequestAsync<Permissions.Camera>();
            }

            if (PermissionStatus.Granted == cameraPermissionStatus)
            {
                await Navigation.PushModalAsync(scannerPage);

                scannerPage.OnScanResult += (result) =>
                {
                    Device.BeginInvokeOnMainThread(OnScanResult);
                };
            }
        }

        private void Button_Menu_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MenuPage());
        }
    }
}
