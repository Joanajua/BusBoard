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
            int loopCounter = 0;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            
            string code2= null;
            postCode = Console.ReadLine();

            var postCodeClient = new RestClient("http://api.postcodes.io/");
            var postCodeRequest = new RestRequest("postcodes/" + postCode , DataFormat.Json);
            var postCodeResponse = postCodeClient.Get(postCodeRequest);

            string postCodeJson = postCodeResponse.Content.ToString();
            var postCodeResult = JsonConvert.DeserializeObject<PostCodeResult>(postCodeJson);

            string longitud = postCodeResult.result.longitude.ToString();
            string latitud= postCodeResult.result.latitude.ToString();

            //TFL Api
            var tflClient = new RestClient("https://api.tfl.gov.uk/StopPoint");
           
            //TFL Bus Stop Codes for a specific post code 
            var tflBusStopRequest = new RestRequest("?stopTypes=NaptanPublicBusCoachTram&radius=1000&lat=" + latitud + "&lon=" + longitud, DataFormat.Json);
            var tflBusStopResponse = tflClient.Get(tflBusStopRequest);

            string tflBusStopsJson = tflBusStopResponse.Content.ToString();
            var tflBusStopResult = JsonConvert.DeserializeObject<BusStopResponse>(tflBusStopsJson);

          
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

            List<Bus> orderedResult = tflBusArrivalResult.OrderBy(o => o.timeToStation).ToList();
            List<Bus> orderedResult2 = tflBusArrivalResult2.OrderBy(o => o.timeToStation).ToList();

            string busStopName = tflBusStopResult.stopPoints[0].commonName;


            Console.Write("Your nearest bus stop is " + busStopName + " Letter Code: " + tflBusStopResult.stopPoints[0].stopLetter + " ");

            Console.Write("The Next Busses arriving here are: ");
            Console.WriteLine();
            if (orderedResult.Count > 5)
            {
                loopCounter = 5;
            }
            else
            {
                loopCounter = orderedResult.Count();
            }
            for (int i = 0; i < loopCounter; i++)
                {
                    
                    Console.WriteLine("bus No: " + orderedResult[i].lineId + " arriving in " + orderedResult[i].timeToStation + " seconds");
                
                }

            Console.Write("Your Next nearest bus stop is " + busStopName + " Letter Code: " + tflBusStopResult.stopPoints[1].stopLetter + " ");

            Console.Write("The Next Busses arriving here are: ");
            Console.WriteLine();
            if (orderedResult2.Count >= 5)
            {
                loopCounter = 5;
            }
            else
            {
                loopCounter = orderedResult2.Count();
            }
            for (int i = 0; i < loopCounter; i++)
            {

                Console.WriteLine("bus No: " + orderedResult2[i].lineId + " arriving in " + orderedResult2[i].timeToStation + " seconds");


            }                //Console.WriteLine(response.Content);

                Console.ReadLine();

        }


        //// https://api.tfl.gov.uk/StopPoint/490008660N/Arrivals
    }
    public class Busses
    {
        public List<Bus> Data { get; set; }
    }
}


