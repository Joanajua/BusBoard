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
            if (info.PostCode != null)
            {
                apiManager.GetLonAndLatByPostCode(info.PostCode);
                info.orderedResult = apiManager.orderedResult;
                info.orderedResult2 = apiManager.orderedResult2;
                info.BusStopName1 = apiManager.busStopName + " " + apiManager.stopLetter1;
                info.BusStopName2 = apiManager.bustStopName2 + " " + apiManager.stopLetter2;
                info.isInLondon = apiManager.inLondon;
            }
            else
            { 
                info.isInLondon = apiManager.inLondon;
            }
           
           

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