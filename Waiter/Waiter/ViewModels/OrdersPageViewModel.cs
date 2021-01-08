using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Waiter.Models;

namespace Waiter.ViewModels
{
    public class OrdersPageViewModel
    {
        public ObservableCollection<OrderListItem> OrderListItems {get; set;}

        public OrdersPageViewModel()
        {
            OrderListItems = new ObservableCollection<OrderListItem>();
        }
    }
}
