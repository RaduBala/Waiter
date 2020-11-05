using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Models;
using Waiter.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Waiter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MenuOrderViewModel menuOrderViewModel;

        public MenuPage()
        {
            InitializeComponent();

            menuOrderViewModel = new MenuOrderViewModel();

            MenuList.ItemsSource = menuOrderViewModel.MenuOrdersList;
        }

        protected override void OnAppearing()
        {

        }
    }
}