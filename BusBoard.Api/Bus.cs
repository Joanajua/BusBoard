using Newtonsoft.Json;

namespace BusBoard.Api
{
    public class Bus
    {
        [JsonProperty(PropertyName = "lineId")]
        public string lineId { get; set; }
        [JsonProperty(PropertyName = "timeToStation")]
        public int timeToStation { get; set; }
    }
}
