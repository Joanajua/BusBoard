using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using RestSharp;


namespace BusBoard.Api
{
    public class APIManager
    {
        public string code = null;
        public string postCode = null;
        public int loopCounter = 0;
        public string code2 = null;
        public string busStopName;
        public string bustStopName2;
        public string stopLetter1;
        public string stopLetter2;
        public bool inLondon = false;
        public List<Bus> tflBusArrivalResult = new List<Bus>();
        public List<Bus> tflBusArrivalResult2 = new List<Bus>();
        public List<Bus> orderedResult = new List<Bus>();
        public List<Bus> orderedResult2 = new List<Bus>();


        public void GetLonAndLatByPostCode(string postCode)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var postCodeClient = new RestClient("http://api.postcodes.io/");
            var postCodeRequest = new RestRequest("postcodes/" + postCode, DataFormat.Json);
            var postCodeResponse = postCodeClient.Get(postCodeRequest);

            string postCodeJson = postCodeResponse.Content.ToString();
            var postCodeResult = JsonConvert.DeserializeObject<PostCodeResult>(postCodeJson);

            string longitud = postCodeResult.result.longitude.ToString();
            string latitud = postCodeResult.result.latitude.ToString();


            //TFL Api
            var tflClient = new RestClient("https://api.tfl.gov.uk/StopPoint/?app_id=a392514e&app_key=f1fdf44292c0935a45c5a1893758af3e");

            //TFL Bus Stop Codes for a specific post code 
            var tflBusStopRequest = new RestRequest("?stopTypes=NaptanPublicBusCoachTram&radius=1000&lat=" + latitud + "&lon=" + longitud, DataFormat.Json);
            var tflBusStopResponse = tflClient.Get(tflBusStopRequest);

        
                string tflBusStopsJson = tflBusStopResponse.Content.ToString();
                var tflBusStopResult = JsonConvert.DeserializeObject<BusStopResponse>(tflBusStopsJson);

            if (tflBusStopResult.stopPoints.Count > 0)
            {


                inLondon = true;
                code = tflBusStopResult.stopPoints[0].naptanId;
                code2 = tflBusStopResult.stopPoints[1].naptanId;

                //TFL Bus Times for a specific stop
                var tflBusTimeRequest = new RestRequest(code + "/Arrivals", DataFormat.Json);
                var tflBusTimeResponse = tflClient.Get(tflBusTimeRequest);

                string tflBusTimeJson = tflBusTimeResponse.Content.ToString();



                //TFL Bus Times for a specific stop2
                var tflBusTimeRequest2 = new RestRequest(code2 + "/Arrivals", DataFormat.Json);
                var tflBusTimeResponse2 = tflClient.Get(tflBusTimeRequest2);

                string tflBusTimeJson2 = tflBusTimeResponse2.Content.ToString();



                var tflBusArrivalResult = JsonConvert.DeserializeObject<List<Bus>>(tflBusTimeJson);
                var tflBusArrivalResult2 = JsonConvert.DeserializeObject<List<Bus>>(tflBusTimeJson2);

                orderedResult = tflBusArrivalResult.OrderBy(o => o.timeToStation).ToList();
                orderedResult2 = tflBusArrivalResult2.OrderBy(o => o.timeToStation).ToList();
                busStopName = tflBusStopResult.stopPoints[0].commonName;
                bustStopName2 = tflBusStopResult.stopPoints[1].commonName;
                stopLetter1 = tflBusStopResult.stopPoints[0].stopLetter;
                stopLetter2 = tflBusStopResult.stopPoints[1].stopLetter;
            }
            else
            {
                inLondon = false;

            }
            
        }


}
}
