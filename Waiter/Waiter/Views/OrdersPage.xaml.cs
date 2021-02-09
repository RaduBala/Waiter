using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Waiter.Models;
using Waiter.Services;
using Waiter.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Waiter.Constans;
using Rg.Plugins.Popup.Services;

namespace Waiter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : ContentPage
    {
        private static OrdersPageViewModel ordersPageViewModel = new OrdersPageViewModel();

        public OrdersPage()
        {
            InitializeComponent();

            BindingContext = ordersPageViewModel;

            MessagingCenter.Subscribe<TabbedMenuPage>(this, Constants.RestaurantDisconnectedEventName, OnDisconnect);
            MessagingCenter.Subscribe<AddOrderPage, TableOrder>(this, Constants.AddOrderEventName, AddOrder);
        }

        private void OnDisconnect(TabbedMenuPage tabbedMenuPage)
        {
            ordersPageViewModel.OrderListItems.Clear();

            ordersPageViewModel.IsButtonVisible = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public static void Clear()
        {
            ordersPageViewModel.OrderListItems.Clear();
        }

        public static void AddOrder(AddOrderPage addOrderPage, TableOrder order)
        {
            TableOrder    addedOrder = order;
            OrderListItem auxOrder   = ordersPageViewModel.OrderListItems.FirstOrDefault(x => x.Order.Order == order.Order); 

            if(null == auxOrder)
            {
                OrderListItem orderListItem = new OrderListItem { Order = addedOrder, CommitStatus = false };

                ordersPageViewModel.OrderListItems.Add(orderListItem);
            }
            else
            {
                auxOrder.Order.Count += addedOrder.Count;
            }      
        }

        private void Button_Remove(object sender, EventArgs e)
        {
            Button        button        = (Button)sender;
            OrderListItem serchedOrder  = (OrderListItem)button.BindingContext;
            OrderListItem selectedOrder = ordersPageViewModel.OrderListItems.FirstOrDefault(x => x.Order == serchedOrder.Order);

            if (null != selectedOrder)
            {
                if (selectedOrder.Order.Count > 0)
                {
                    selectedOrder.Order.Count--;

                    if(0 == selectedOrder.Order.Count)
                    {
                        ordersPageViewModel.OrderListItems.Remove(selectedOrder);
                    }
                }
            }  
        }

        private void Button_Add(object sender, EventArgs e)
        {
            Button        button        = (Button)sender;
            OrderListItem serchedOrder  = (OrderListItem)button.BindingContext;
            OrderListItem selectedOrder = ordersPageViewModel.OrderListItems.FirstOrDefault(x => x.Order == serchedOrder.Order);

            if (null != selectedOrder)
            {
                selectedOrder.Order.Count++;
            }
        }

        private void Button_CommitClicked(object sender, EventArgs e)
        {
            List<TableOrder> tableOrders = new List<TableOrder>();

            foreach(OrderListItem item in ordersPageViewModel.OrderListItems)
            {
                item.CommitStatus = true;

                tableOrders.Add(item.Order);
            }

            RestaurantDatabase.SaveOrders(tableOrders);

            //ordersPageViewModel.MultifunctionButtonName = "PAY WITH CARD";

            //PopupNavigation.Instance.PushAsync(new PaymentView());
        }
    }
}