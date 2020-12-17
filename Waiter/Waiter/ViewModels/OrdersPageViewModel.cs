using System;
using System.Collections.Generic;
using System.Text;
using Waiter.Models;

namespace Waiter.ViewModels
{
    class OrdersPageViewModel
    {
        public MenuOrder Order { get; set; }

        public int Count { get; set; }
    }
}
