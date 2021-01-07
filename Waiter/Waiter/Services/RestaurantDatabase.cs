using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waiter.Models;
using Waiter.Constans;
using Newtonsoft.Json.Linq;
using System;

namespace Waiter.Services
{
    public class RestaurantDatabase
    {
        private FirebaseClient firebaseClient = null;

        private Restaurant restaurant = null;

        private string connectionString = null;

        public RestaurantDatabase()
        {
            firebaseClient = new FirebaseClient(Constants.FirebaseUrl);
        }

        public async Task Connect(string restaurantConnectionString)
        {
            string[] restaurantConnectionStringArray = restaurantConnectionString.Split(' ');
            string   restaurantKey                   = restaurantConnectionStringArray[0];
            int      tableId                         = Int32.Parse(restaurantConnectionStringArray[1]) - 1;

            connectionString = restaurantConnectionString;

            ChildQuery childQuery = firebaseClient.Child("Restaurants").Child(restaurantKey);

            restaurant = await childQuery.OnceSingleAsync<Restaurant>();

            childQuery = firebaseClient.Child("Restaurants").Child(restaurantKey).Child("Tables").Child(tableId.ToString());

            Table table = restaurant.Tables.FirstOrDefault(x => x.Number == (tableId + 1));

            table.OccupiedStatus = true;

            await childQuery.PutAsync(table);
        }

        public async Task Disconnect()
        {
            string[] ConnectionStringArray = connectionString.Split(' ');
            string   restaurantKey         = ConnectionStringArray[0];
            int      tableId               = Int32.Parse(ConnectionStringArray[1]) - 1;

            ChildQuery childQuery = firebaseClient.Child("Restaurants").Child(restaurantKey).Child("Tables").Child(tableId.ToString());

            Table table = restaurant.Tables.FirstOrDefault(x => x.Number == (tableId + 1));

            table.OccupiedStatus = false;

            await childQuery.PutAsync(table);
        }

        public async Task SaveRestaurant(Restaurant restaurantAdded)
        {
            ChildQuery childQuery = firebaseClient.Child("Restaurants");

            await childQuery.PostAsync(restaurantAdded);
        }

        public Restaurant GetRestaurant()
        {
            return restaurant;
        }

        public List<MenuOrder> GetMenu()
        {
            return restaurant.Menu;
        }
    }
}
