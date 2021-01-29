using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Waiter.Constans;
using Waiter.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Waiter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOrderPage : ContentPage
    {
        private MenuOrder addedOrder = null;

        private void GetImage(string PhotoLink)
        {
            Uri imageUri = new Uri(PhotoLink);

            OrderPhoto_Image.Source = ImageSource.FromUri(imageUri);
        }

        public AddOrderPage(MenuOrder menuOrder)
        {
            InitializeComponent();

            GetImage(menuOrder.PhotoLink);

            addedOrder = menuOrder;
        }

        private void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            int orderCount = Int32.Parse(Label_OrderCount.Text);

            orderCount++;

            Label_OrderCount.Text = orderCount.ToString();
        }

        private void ButtonRemove_Clicked(object sender, EventArgs e)
        {
            int orderCount = Int32.Parse(Label_OrderCount.Text);

            if(orderCount > 0)
            {
                orderCount--;
            }

            Label_OrderCount.Text = orderCount.ToString();
        }

        private async void ButtonAddOrder_Clicked(object sender, EventArgs e)
        {
            int orderCount = Int32.Parse(Label_OrderCount.Text);

            TableOrder tableOrder = new TableOrder() { Order = addedOrder, Count = orderCount };

            MessagingCenter.Send(this, Constants.AddOrderEventName, tableOrder);

            await Navigation.PopModalAsync();
        }
    }
}