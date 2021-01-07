using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Waiter.Models
{
    public class TableOrder
    {
        [JsonProperty("Order")]
        public MenuOrder Order { get; set; }

        [JsonProperty("Count")]
        public int Count { get; set; }
    }
}
