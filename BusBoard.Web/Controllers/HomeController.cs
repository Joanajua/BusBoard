using System.Collections.Generic;
using System.Web.Mvc;
using BusBoard.Api;
using BusBoard.Web.Models;
using BusBoard.Web.ViewModels;



namespace BusBoard.Web.Controllers
{
  public class HomeController : Controller
  {
        Api.APIManager apiManager = new Api.APIManager();
        PostcodeSelection postcode = new PostcodeSelection();
        List<Bus> tflBusArrivalResult = new List<Bus>();
        List<Bus> tflBusArrivalResult2 = new List<Bus>();
        List<Bus> orderedResult = new List<Bus>();
        List<Bus> orderedResult2 = new List<Bus>();

        public ActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public ActionResult BusInfo(PostcodeSelection selection)
    {

            // Add some properties to the BusInfo view model with the data you want to render on the page.
            // Write code here to populate the view model with info from the APIs.
            // Then modify the view (in Views/Home/BusInfo.cshtml) to render upcoming buses.
            
            var info = new BusInfo(selection.Postcode);
            
            apiManager.GetLonAndLatByPostCode(info.PostCode);
            info.orderedResult = apiManager.orderedResult;
            info.orderedResult2 = apiManager.orderedResult2;
            info.BusStopName1 =  apiManager.busStopName + " " + apiManager.stopLetter1;
            info.BusStopName2 = apiManager.bustStopName2 + " " + apiManager.stopLetter2;

           
            //if (orderedResult.Count > 5)
            //{
            //    apiManager.loopCounter = 5;
            //}
            //else
            //{
            //    apiManager.loopCounter = orderedResult.Count();
            //}
            //for (int i = 0; i < api.loopCounter; i++)
            //{

            //    Console.WriteLine("bus No: " + orderedResult[i].lineId + " arriving in " + orderedResult[i].timeToStation + " seconds");

            //}

            //Console.Write("Your Next nearest bus stop is " + api.busStopName + " Letter Code: " + api.stopLetter2 + " ");

            //Console.Write("The Next Busses arriving here are: ");
            //Console.WriteLine();
            //if (orderedResult2.Count >= 5)
            //{
            //    api.loopCounter = 5;
            //}
            //else
            //{
            //    api.loopCounter = orderedResult2.Count();
            //}
            //for (int i = 0; i < api.loopCounter; i++)
            //{

            //    Console.WriteLine("bus No: " + orderedResult2[i].lineId + " arriving in " + orderedResult2[i].timeToStation + " seconds");
            //}
            //apiManager.GetLonAndLatByPostCode(info.PostCode);
            //tflBusArrivalResult = info.tflBusArrivalResult;
            //tflBusArrivalResult2 = info.tflBusArrivalResult2;
            //orderedResult = info.orderedResult;
            //orderedResult2 = info.orderedResult2;

            return View(info);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Information about this site";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Contact us!";

      return View();
    }
  }
}