using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private static ObservableCollection<OrdersPageViewModel> ordersPageViewModel = new ObservableCollection<OrdersPageViewModel>();

        public OrdersPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            OrdersList.ItemsSource = ordersPageViewModel;
        }

        public static void AddOrder(MenuOrder menuOrder, int count)
        {
            OrdersPageViewModel addedOrder = new OrdersPageViewModel { Order = menuOrder, Count = count } ;
            OrdersPageViewModel auxOrder   = ordersPageViewModel.FirstOrDefault(x => x.Order == menuOrder);

            if(null == auxOrder)
            {
                ordersPageViewModel.Add(addedOrder);
            }
            else
            {
                auxOrder.Count += count;
            }      
        }
    }
}