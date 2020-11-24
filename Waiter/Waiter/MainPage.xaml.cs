using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Models;
using Waiter.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;


namespace Waiter
{
    public partial class MainPage : ContentPage
    {
        IMenuRepository menuRepository;

        public MainPage()
        {
            InitializeComponent();

            Navigation.PushModalAsync(new LoginPage());

            menuRepository = DependencyService.Get<IMenuRepository>();
        }

        private async void Button_Connect(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Connect());
        }

        private void Button_Menu(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MenuPage(menuRepository.GetMenu()));
        }
    }
}
