using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.Web.ViewModels
{
    public class BusInfo
    {
        public BusInfo(string postCode)
        {
            PostCode = postCode;
        }

        public string PostCode { get; set; }
        public string Title { get; set; }
        public string BusStopName1 { get; set; }
        public string BusStopName2 { get; set; }
        public bool isInLondon = false;

        public List<Bus> orderedResult = new List<Bus>();
        public List<Bus> orderedResult2 = new List<Bus>();
    }
}