using System.Collections.Generic;

namespace BusBoard.Api
{
    public class AdditionalProperty
    {
    public string category { get; set; }
    public string key { get; set; }
    public string sourceSystemKey { get; set; }
    public string value { get; set; }

    }

    public class StopPoint
    {
        public string naptanId { get; set; }

        public string stopLetter { get; set; }

        public string commonName { get; set; }

        public double lat { get; set; }
        public double lon { get; set; }
    }
    
    public class BusStopResponse
    {

    public List<StopPoint> stopPoints { get; set; }

     }
}
