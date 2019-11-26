using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    public class AdditionalProperty
    {
    public string category { get; set; }
    public string key { get; set; }
    public string sourceSystemKey { get; set; }
    public string value { get; set; }
}

public class StopPoint
{
public string naptanId { get; set; }
public string indicator { get; set; }
public string stopLetter { get; set; }
public List<string> modes { get; set; }
public string icsCode { get; set; }
public string stopType { get; set; }
public string stationNaptan { get; set; }
public List<object> lines { get; set; }
public List<object> lineGroup { get; set; }
public List<object> lineModeGroups { get; set; }
public bool status { get; set; }
public string id { get; set; }
public string commonName { get; set; }
public double distance { get; set; }
public string placeType { get; set; }
public List<AdditionalProperty> additionalProperties { get; set; }
public List<object> children { get; set; }
public double lat { get; set; }
public double lon { get; set; }
}
    
    public class RootObject2
{
public List<double> centrePoint { get; set; }
public List<StopPoint> stopPoints { get; set; }
public int pageSize { get; set; }
public int total { get; set; }
public int page { get; set; }
}
}
