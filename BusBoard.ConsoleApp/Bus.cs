using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BusBoard.ConsoleApp
{
    public class Bus
    {
        [JsonProperty(PropertyName = "lineId")]
        public string lineId { get; set; }
        [JsonProperty(PropertyName = "timeToStation")]
        public int timeToStation { get; set; }
    }
}
