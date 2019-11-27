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
using BusBoard;



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

            Api.APIManager apiManager = new Api.APIManager();
            Console.WriteLine("Please Enter a Post Code to see the arrivals for the nearest 2 bus stops");
            string postCode = Console.ReadLine();
            apiManager.GetLonAndLatByPostCode(postCode);
            tflBusArrivalResult = apiManager.tflBusArrivalResult;
            tflBusArrivalResult2 = apiManager.tflBusArrivalResult2;
            orderedResult = apiManager.orderedResult;
            orderedResult2 = apiManager.orderedResult2;
            apiManager.ShowResults(tflBusArrivalResult, tflBusArrivalResult2, orderedResult, orderedResult2);
            Console.ReadLine();
           
        }                

                

  }


        //// https://api.tfl.gov.uk/StopPoint/490008660N/Arrivals
}
   



