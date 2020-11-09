using System;
using System.Collections.Generic;
using System.Text;
using Waiter.Models;

namespace Waiter.ViewModels
{
    public class MenuOrderViewModel
    {
        public List<Order> MenuOrdersList { get; set; }

        public MenuOrderViewModel()
        {
            MenuOrdersList = new Order().GetMenuOrders();
        }
    }
}
