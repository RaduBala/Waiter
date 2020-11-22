using System;
using System.Collections.Generic;
using System.Text;

namespace Waiter.Models
{
    public class MenuOrder
    {
        public string Title { get; set; }

        public int Price { get; set; } 

        public string Ingredients { get; set; }

        public MenuOrder()
        {

        }

        public List<MenuOrder> GetMenuOrders()
        {
            List<MenuOrder> menuOrders = new List<MenuOrder>()
            {
                new MenuOrder() { Title = "Ciorba de burta", Price = 20 , Ingredients = ""} ,
                new MenuOrder() { Title = "Fasole cu ciolan", Price = 25 , Ingredients = ""} ,
                new MenuOrder() { Title = "Cotlet de porc", Price = 30 , Ingredients = ""} ,
                new MenuOrder() { Title = "Papanasi", Price = 15 , Ingredients = ""} ,
            };

            return menuOrders;
        }
    }
}
