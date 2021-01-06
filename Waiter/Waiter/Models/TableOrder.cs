using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Waiter.Models
{
    public class TableOrder
    {
        [JsonProperty("Title")]
        public string Title { get; set; }
    }
}
