using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace CovidTracker.Models
{
    public class MapData
    {
        public CountryData CountryData { get; set; }
        public Position CountryPosition { get; set; }
        public string CountryLabel { get; set; }
        public string CountryFacts { get; set; }
    }
}
