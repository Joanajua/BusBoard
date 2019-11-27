
namespace BusBoard.Api
{
    public class Codes
    {
        public string admin_district { get; set; }
        public string admin_county { get; set; }
        public string admin_ward { get; set; }
        public string parish { get; set; }
        public string parliamentary_constituency { get; set; }
        public string ccg { get; set; }
        public string ced { get; set; }
        public string nuts { get; set; }
    }

    public class Result
    {
        public double longitude { get; set; }
        public double latitude { get; set; }
       
        public Codes codes { get; set; }
    }

    public class PostCodeResult
    {
        public int status { get; set; }
        public Result result { get; set; }
    }
}