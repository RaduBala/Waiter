using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Models;
using Waiter.Services;
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

            var x = Device.RuntimePlatform;
        }

        private async void Button_ConnectStateChange(object sender, EventArgs e)
        {
            if(false == RestaurantDatabase.ConnectionStatus)
            {
                await Navigation.PushAsync(new Connect());         
            }
            else
            {
                await RestaurantDatabase.Disconnect();

                OrdersPage.Clear();

                ConnectButton.Text = "Connect";
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (true == RestaurantDatabase.ConnectionStatus)
            {
                ConnectButton.Text = "Disconnect";
            }
        }

        private async void SaveRestaurant()
        {
            Restaurant restaurant = new Restaurant();

            restaurant.Name = "Dinar";

            restaurant.Menu = new List<MenuOrder>()
            {
                new MenuOrder() { Title = "Ciorba de burta", Price = 20 , Ingredients = "" , PhotoLink = "https://firebasestorage.googleapis.com/v0/b/waiterdatabase.appspot.com/o/Images%2Fciorba_burta.jpg?alt=media&token=1dd5337e-237b-48be-9112-f0ff0b0ae98d" } ,
                new MenuOrder() { Title = "Ciolan de porc" , Price = 30 , Ingredients = "" , PhotoLink = "https://firebasestorage.googleapis.com/v0/b/waiterdatabase.appspot.com/o/Images%2Fciolan_porc.jpg?alt=media&token=a9f87b18-a042-4015-a93f-99641e1ffb49" } ,
                new MenuOrder() { Title = "Papanasi"       , Price = 15 , Ingredients = "" , PhotoLink = "https://firebasestorage.googleapis.com/v0/b/waiterdatabase.appspot.com/o/Images%2Fpapanasi.jpg?alt=media&token=e91580d8-ec7b-4cd0-be2a-b767286f2f4f" } ,
            };

            restaurant.Tables = new List<Table>()
            {
                new Table() { Number = 1 , OccupiedStatus = false } ,
                new Table() { Number = 2 , OccupiedStatus = false } ,
                new Table() { Number = 3 , OccupiedStatus = false } ,
            };

            await RestaurantDatabase.SaveRestaurant(restaurant);
        }

        private async void Button_Menu(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage(RestaurantDatabase.GetMenu()));
        }
    }
}
