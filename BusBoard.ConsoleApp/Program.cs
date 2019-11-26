using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;


namespace BusBoard.ConsoleApp
{
  class Program
  {
       //private static string postCoderesponse;

        static void Main(string[] args)
    {


            List<Bus> busList = new List<Bus>();

            string code=null;
            string postCode = null;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            code = "490008660N";
            postCode = Console.ReadLine();

            var postCodeClient = new RestClient("http://api.postcodes.io/");
            var postCodeRequest = new RestRequest("postcodes/" + postCode , DataFormat.Json);
            var postCodeResponse = postCodeClient.Get(postCodeRequest);

            string postCodeJson = postCodeResponse.Content.ToString();

            //TFL Api
            var tflClient = new RestClient("https://api.tfl.gov.uk/StopPoint");
            //TFL Bus Times for a specific stop
            var tflBusTimeRequest = new RestRequest(code + "/Arrivals", DataFormat.Json);
            var tflBusTimeResponse = tflClient.Get(tflBusTimeRequest);
            //TFL Bus Stop Codes for a specific post code 
            var tflBusStopRequest = new RestRequest("?stopTypes=NaptanPublicBusCoachTram&radius=1000&lat=51.545029&lon=0.107808", DataFormat.Json);
            var tflBusStopResponse = tflClient.Get(tflBusStopRequest);

            string tflBusTimeJson = tflBusTimeResponse.Content.ToString();
            string tflBusStopsJson = tflBusStopResponse.Content.ToString();


            int counter = 0;


            var tflBusStopResult = JsonConvert.DeserializeObject<RootObject2>(tflBusStopsJson);
            var tflBusArrivalResult = JsonConvert.DeserializeObject<List<Bus>>(tflBusTimeJson);
            var postCodeResult = JsonConvert.DeserializeObject<RootObject>(postCodeJson);

            List<Bus> orderedResult = tflBusArrivalResult.OrderBy(o => o.timeToStation).ToList();

          
            
                Console.Write("The Next next 5 busses are:");
                foreach (var item in orderedResult)
                {
                    counter++;
                    Console.WriteLine("bus No:" + item.lineId + " arriving in " + item.timeToStation + " seconds");
                    if (counter == 6)
                    {
                    break;
                    }
                }
            
            //Console.WriteLine(response.Content);

            Console.ReadLine();

        }


        //// https://api.tfl.gov.uk/StopPoint/490008660N/Arrivals
    }
    public class Busses
    {
        public List<Bus> Data { get; set; }
    }
}


