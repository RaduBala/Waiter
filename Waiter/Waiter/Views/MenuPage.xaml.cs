using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Waiter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage(List<MenuOrder> menuOrders)
        {
            InitializeComponent();

            MenuList.ItemsSource = menuOrders;
        }

        protected override void OnAppearing()
        {

        }

        private async void MenuList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (null != e.SelectedItem)
            {
                MenuOrder menuOrder = (MenuOrder)e.SelectedItem;

                MenuList.SelectedItem = null;

                await Navigation.PushModalAsync(new AddOrderPage(menuOrder));
            }
        }
    }
}