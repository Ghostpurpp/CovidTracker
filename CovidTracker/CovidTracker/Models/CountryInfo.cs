namespace CovidTracker.Models
{
    public class CountryInfo
    {
        public int Id { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Flat { get; set; }
    }
}