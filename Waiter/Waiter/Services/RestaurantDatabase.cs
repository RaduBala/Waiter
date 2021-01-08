using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waiter.Models;
using Waiter.Constans;
using Newtonsoft.Json.Linq;
using System;
using Waiter.ViewModels;

namespace Waiter.Services
{
    public static class RestaurantDatabase
    {
        private static FirebaseClient firebaseClient = null;

        private static Restaurant restaurant = null;

        private static string connectionString = null;

        public static bool ConnectionStatus { get; set; }

        public static async Task Connect(string restaurantConnectionString)
        {
            string[] restaurantConnectionStringArray = restaurantConnectionString.Split(' ');
            string   restaurantKey                   = restaurantConnectionStringArray[0];
            int      tableId                         = Int32.Parse(restaurantConnectionStringArray[1]) - 1;

            firebaseClient = new FirebaseClient(Constants.FirebaseUrl);

            connectionString = restaurantConnectionString;

            ChildQuery childQuery = firebaseClient.Child("Restaurants").Child(restaurantKey);

            restaurant = await childQuery.OnceSingleAsync<Restaurant>();

            childQuery = firebaseClient.Child("Restaurants").Child(restaurantKey).Child("Tables").Child(tableId.ToString());

            Table table = restaurant.Tables.FirstOrDefault(x => x.Number == (tableId + 1));

            table.OccupiedStatus = true;

            await childQuery.PutAsync(table);

            ConnectionStatus = true;
        }

        public static async Task Disconnect()
        {
            string[] ConnectionStringArray = connectionString.Split(' ');
            string   restaurantKey         = ConnectionStringArray[0];
            int      tableId               = Int32.Parse(ConnectionStringArray[1]) - 1;

            ChildQuery childQuery = firebaseClient.Child("Restaurants").Child(restaurantKey).Child("Tables").Child(tableId.ToString());

            Table table = restaurant.Tables.FirstOrDefault(x => x.Number == (tableId + 1));

            table.OccupiedStatus = false;
            table.Orders         = null;

            await childQuery.PutAsync(table);

            restaurant.Menu.Clear();

            restaurant = null;

            ConnectionStatus = false;
        }

        public static async Task SaveRestaurant(Restaurant restaurantAdded)
        {
            ChildQuery childQuery = firebaseClient.Child("Restaurants");

            await childQuery.PostAsync(restaurantAdded);
        }

        public static async void SaveOrders(List<TableOrder> orders)
        {
            string[] ConnectionStringArray = connectionString.Split(' ');
            string   restaurantKey         = ConnectionStringArray[0];
            int      tableId               = Int32.Parse(ConnectionStringArray[1]) - 1;

            ChildQuery childQuery = firebaseClient.Child("Restaurants").Child(restaurantKey).Child("Tables").Child(tableId.ToString());

            Table table = restaurant.Tables.FirstOrDefault(x => x.Number == (tableId + 1));

            table.Orders = orders;

            await childQuery.PutAsync(table);
        }

        public static Restaurant GetRestaurant()
        {
            return restaurant;
        }

        public static List<MenuOrder> GetMenu()
        {
            List<MenuOrder> menu = null;

            if(null != restaurant)
            {
                menu = restaurant.Menu;
            }

            return menu;
        }
    }
}
