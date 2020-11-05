using System;
using System.Collections.Generic;
using System.Text;
using Waiter.Models;

namespace Waiter.ViewModels
{
    public class MenuOrderViewModel
    {
        public List<MenuOrder> MenuOrdersList { get; set; }

        public MenuOrderViewModel()
        {
            MenuOrdersList = new MenuOrder().GetMenuOrders();
        }
    }
}
