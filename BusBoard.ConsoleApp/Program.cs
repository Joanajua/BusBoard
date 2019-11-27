using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BusBoard.Api;

namespace BusBoard.ConsoleApp
{
  class Program
  {
       //private static string postCoderesponse;

        static void Main(string[] args)
        {


            List<Bus> tflBusArrivalResult = new List<Bus>();
            List<Bus> tflBusArrivalResult2 = new List<Bus>();
            List<Bus> orderedResult = new List<Bus>();
            List<Bus> orderedResult2 = new List<Bus>();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            APIManager apiManager = new APIManager();
            Console.WriteLine("Please Enter a Post Code to see the arrivals for the nearest 2 bus stops");
            string postCode = Console.ReadLine();
            apiManager.GetLonAndLatByPostCode(postCode);
            tflBusArrivalResult = apiManager.tflBusArrivalResult;
            tflBusArrivalResult2 = apiManager.tflBusArrivalResult2;
            orderedResult = apiManager.orderedResult;
            orderedResult2 = apiManager.orderedResult2;
            ShowResults(tflBusArrivalResult, tflBusArrivalResult2, orderedResult, orderedResult2, apiManager);
            
            Console.ReadLine();
           
        }

        static public void ShowResults(List<Bus> tflBusArrivalResult, List<Bus> tflBusArrivalResult2, List<Bus> orderedResult, List<Bus> orderedResult2, APIManager api)
        {

            Console.Write("Your nearest bus stop is " + api.busStopName + " Letter Code: " + api.stopLetter1 + " ");

            Console.Write("The Next Busses arriving here are: ");
            Console.WriteLine();
            if (orderedResult.Count > 5)
            {
                api.loopCounter = 5;
            }
            else
            {
                api.loopCounter = orderedResult.Count();
            }
            for (int i = 0; i < api.loopCounter; i++)
            {

                Console.WriteLine("bus No: " + orderedResult[i].lineId + " arriving in " + orderedResult[i].timeToStation + " seconds");

            }

            Console.Write("Your Next nearest bus stop is " + api.busStopName + " Letter Code: " + api.stopLetter2 + " ");

            Console.Write("The Next Busses arriving here are: ");
            Console.WriteLine();
            if (orderedResult2.Count >= 5)
            {
                api.loopCounter = 5;
            }
            else
            {
                api.loopCounter = orderedResult2.Count();
            }
            for (int i = 0; i < api.loopCounter; i++)
            {

                Console.WriteLine("bus No: " + orderedResult2[i].lineId + " arriving in " + orderedResult2[i].timeToStation + " seconds");
            }
        }

    }


        //// https://api.tfl.gov.uk/StopPoint/490008660N/Arrivals
}
   



