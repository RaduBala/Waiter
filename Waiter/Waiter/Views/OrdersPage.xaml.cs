using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Waiter.Models;
using Waiter.Services;
using Waiter.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Waiter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : ContentPage
    {
        private static ObservableCollection<TableOrder> ordersList = new ObservableCollection<TableOrder>();

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
            TableOrder addedOrder = new TableOrder { Order = menuOrder, Count = count } ;
            TableOrder auxOrder   = ordersList.FirstOrDefault(x => x.Order == menuOrder);

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
            Button     button        = (Button)sender;
            TableOrder serchedOrder  = (TableOrder)button.BindingContext;
            TableOrder selectedOrder = ordersList.FirstOrDefault(x => x.Order == serchedOrder.Order);

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
            Button     button        = (Button)sender;
            TableOrder serchedOrder  = (TableOrder)button.BindingContext;
            TableOrder selectedOrder = ordersList.FirstOrDefault(x => x.Order == serchedOrder.Order);

            if (null != selectedOrder)
            {
                selectedOrder.Count++;
            }
        }

        private void Button_CommitClicked(object sender, EventArgs e)
        {
            List<TableOrder> tableOrders = ordersList.ToList();

            RestaurantDatabase.SaveOrders(tableOrders);
        }
    }
}