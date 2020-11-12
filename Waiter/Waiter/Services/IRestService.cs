using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Waiter.Models;
using Xamarin.Forms;

namespace Waiter.Services
{
    internal interface IRestService
    {
        Task<List<Order>> GetMenuAsync();
    }
}