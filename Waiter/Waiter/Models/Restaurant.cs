using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Waiter.Models
{
    public class Restaurant
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Menu")]
        public List<MenuOrder> Menu { get; set; }

        [JsonProperty("Tables")]
        public List<Table> Tables { get; set; }
    }
}
