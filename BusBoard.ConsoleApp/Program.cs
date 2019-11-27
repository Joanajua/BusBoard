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


          
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            Api.APIManager apiManager = new Api.APIManager();
            string postCode = Console.ReadLine();
            apiManager.GetLonAndLatByPostCode(postCode);
            Console.ReadLine();
           
        }                

                

  }


        //// https://api.tfl.gov.uk/StopPoint/490008660N/Arrivals
}
   



