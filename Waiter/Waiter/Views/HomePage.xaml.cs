using System;
using System.Collections.Generic;
using System.Linq;
using Waiter.Constans;
using Waiter.Models;
using Waiter.Services;
using Waiter.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Waiter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomePageViewModel homePageViewModel = new HomePageViewModel();

        private string QrCodeResultText = null;

        public HomePage()
        {
            InitializeComponent();

            BindingContext = homePageViewModel;

            Navigation.PushModalAsync(new LoginPage());

            MessagingCenter.Subscribe<TabbedMenuPage>(this, Constants.RestaurantDisconnectedEventName, OnDisconnect);
        }

        private void OnDisconnect(TabbedMenuPage tabbedMenuPage)
        {
            homePageViewModel.IsConnected = false;
        }

        private void OnConnectViewUpdate()
        {
            homePageViewModel.IsConnected = true;
        }

        private async void OnQrCodeScanResult()
        {
            await Navigation.PopModalAsync();

            OnScanResult();
        }

        public async void OnScanResult()
        {
            await RestaurantDatabase.Connect(QrCodeResultText);

            homePageViewModel.Menu = RestaurantDatabase.GetMenu();

            MessagingCenter.Send(this, Constants.RestaurantConnectedEventName);

            OnConnectViewUpdate();
        }

        private async void Button_ScanQrCodeAsync_Clicked(object sender, EventArgs e)
        {
            ZXingScannerPage scannerPage           = new ZXingScannerPage();
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
                    QrCodeResultText = result.Text;

                    Device.BeginInvokeOnMainThread(OnQrCodeScanResult);
                };
            }
        }

        private async void Button_ScanNfc_Clicked(object sender, EventArgs e)
        {
            NfcScannerPage nfcScannerPage = new NfcScannerPage();

            await Navigation.PushModalAsync(nfcScannerPage);

            nfcScannerPage.OnScanResult += (data) =>
            {
                QrCodeResultText = data;

                Device.BeginInvokeOnMainThread(OnQrCodeScanResult);
            };
        }

        private async void MenuList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (null != e.SelectedItem)
            {
                MenuOrder menuOrder = (MenuOrder)e.SelectedItem;

                ListView_Menu.SelectedItem = null;

                await Navigation.PushModalAsync(new AddOrderPage(menuOrder));
            }
        }

        private async void SaveRestaurant()
        {
            Restaurant restaurant = new Restaurant();

            restaurant.Name = "Dinar";

            restaurant.Menu = new List<MenuOrder>()
            {
                new MenuOrder() { Title = "Ciorba de burta" , Price = 20 , Ingredients = "" , PhotoLink = "https://firebasestorage.googleapis.com/v0/b/waiterdatabase.appspot.com/o/Images%2Fciorba_burta.jpg?alt=media&token=1dd5337e-237b-48be-9112-f0ff0b0ae98d" } ,
                new MenuOrder() { Title = "Ciolan de porc"  , Price = 30 , Ingredients = "" , PhotoLink = "https://firebasestorage.googleapis.com/v0/b/waiterdatabase.appspot.com/o/Images%2Fciolan_porc.jpg?alt=media&token=a9f87b18-a042-4015-a93f-99641e1ffb49"  } ,
                new MenuOrder() { Title = "Papanasi"        , Price = 15 , Ingredients = "" , PhotoLink = "https://firebasestorage.googleapis.com/v0/b/waiterdatabase.appspot.com/o/Images%2Fpapanasi.jpg?alt=media&token=e91580d8-ec7b-4cd0-be2a-b767286f2f4f"     } ,
            };

            restaurant.Tables = new List<Table>()
            {
                new Table() { Number = 1 , OccupiedStatus = false } ,
                new Table() { Number = 2 , OccupiedStatus = false } ,
                new Table() { Number = 3 , OccupiedStatus = false } ,
            };

            await RestaurantDatabase.SaveRestaurant(restaurant);
        }
    }
}