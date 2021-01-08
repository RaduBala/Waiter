using System;
using System.Collections.Generic;
using System.Text;

namespace Waiter.Models
{
    public class OrderListItem
    {
        public TableOrder Order { get; set; }

        public bool RemoveButtonIsVisible { get; set; }

        public bool AddButtonIsVisible { get; set; }
    }
}
