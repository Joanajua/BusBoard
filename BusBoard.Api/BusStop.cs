using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.Api
{
    class BusStop
    {
        public string Name {get; set;}
        public string Id { get; set; } 

        public List<Bus> ListBusses = new List<Bus>();
    }
}
