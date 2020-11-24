using System;
using System.Collections.Generic;
using System.Text;
using Waiter.Models;

namespace Waiter.Services
{
    public class MenuDataEventArgs
    {
        public List<MenuOrder> MenuOrders { get; set; }
    }
}
