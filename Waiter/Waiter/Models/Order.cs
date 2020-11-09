using System;
using System.Collections.Generic;
using System.Text;

namespace Waiter.Models
{
    public class Order
    {
        public string Name { get; set; }

        public int Price { get; set; } 

        public string Ingredients { get; set; }

        public Order()
        {

        }

        public List<Order> GetMenuOrders()
        {
            List<Order> menuOrders = new List<Order>()
            {
                new Order() { Name = "Ciorba de burta", Price = 20 , Ingredients = ""} ,
                new Order() { Name = "Fasole cu ciolan", Price = 25 , Ingredients = ""} ,
                new Order() { Name = "Cotlet de porc", Price = 30 , Ingredients = ""} ,
                new Order() { Name = "Papanasi", Price = 15 , Ingredients = ""} ,
            };

            return menuOrders;
        }
    }
}
