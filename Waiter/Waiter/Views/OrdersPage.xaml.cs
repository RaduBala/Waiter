using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class OrdersPage : ContentPage
    {
        private static ObservableCollection<OrdersPageViewModel> ordersList = new ObservableCollection<OrdersPageViewModel>();

        public OrdersPage()
        {
            InitializeComponent();

            OdersViewList.ItemsSource = ordersList;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public static void AddOrder(MenuOrder menuOrder, int count)
        {
            OrdersPageViewModel addedOrder = new OrdersPageViewModel { Order = menuOrder, Count = count } ;
            OrdersPageViewModel auxOrder   = ordersList.FirstOrDefault(x => x.Order == menuOrder);

            if(null == auxOrder)
            {
                ordersList.Add(addedOrder);
            }
            else
            {
                auxOrder.Count += count;
            }      
        }

        private void Button_Remove(object sender, EventArgs e)
        { 
            Button              button        = (Button)sender;
            OrdersPageViewModel serchedOrder  = (OrdersPageViewModel)button.BindingContext;
            OrdersPageViewModel selectedOrder = ordersList.FirstOrDefault(x => x.Order == serchedOrder.Order);

            if (null != selectedOrder)
            {
                if (selectedOrder.Count > 0)
                {
                    selectedOrder.Count--;

                    if(0 == selectedOrder.Count)
                    {
                        ordersList.Remove(selectedOrder);
                    }
                }
            }  
        }

        private void Button_Add(object sender, EventArgs e)
        {
            Button              button        = (Button)sender;
            OrdersPageViewModel serchedOrder  = (OrdersPageViewModel)button.BindingContext;
            OrdersPageViewModel selectedOrder = ordersList.FirstOrDefault(x => x.Order == serchedOrder.Order);

            if (null != selectedOrder)
            {
                selectedOrder.Count++;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}