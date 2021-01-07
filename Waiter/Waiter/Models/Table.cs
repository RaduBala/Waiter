using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Waiter.Models
{
    public class Table
    {
        [JsonProperty("Number")]
        public int Number { get; set; }

        [JsonProperty("OccupiedStatus")]
        public bool OccupiedStatus { get; set; }

        [JsonProperty("Orders")]
        public List<TableOrder> Orders { get; set; }
    }
}
