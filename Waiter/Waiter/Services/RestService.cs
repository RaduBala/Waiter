﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Waiter.Constans;
using Waiter.Models;
using Xamarin.Forms;

namespace Waiter.Services
{
    class RestService : IRestService
    {
        HttpClient client ;

        public List<Order> Menu { get; private set; }

        public RestService()
        {
            client = new HttpClient();
        }

        public async Task<List<Order>> GetMenuAsync()
        {
            Menu = new List<Order>();

            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Menu = JsonConvert.DeserializeObject<List<Order>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Menu ;
        }
    }
}