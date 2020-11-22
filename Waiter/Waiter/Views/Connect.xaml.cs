﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Waiter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Connect : ContentPage
    {
        List<MenuOrder> MenuList = new List<MenuOrder>();

        public Connect()
        {
            InitializeComponent();
        }

        public async void OnScanResult()
        {
            await Navigation.PopAsync();
        }

        private async void Button_ScanQrCodeAsync(object sender, EventArgs e)
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

        private async void Button_ScanNfc(object sender, EventArgs e)
        {
            IMenuRepository  menuRepository = DependencyService.Get<IMenuRepository>();

            MenuList = await menuRepository.GetMenuAsync();

            await Navigation.PushAsync(new MenuPage(MenuList));
        }
    }
}