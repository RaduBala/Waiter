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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_SingIn_Clicked(object sender, EventArgs e)
        {
            User user = new User(Entry_Name.Text, Entry_Password.Text) ;

            await Navigation.PopModalAsync();
        }
    }
}