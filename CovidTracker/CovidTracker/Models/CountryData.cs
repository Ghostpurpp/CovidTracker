using System;
using System.Collections.Generic;
using System.Text;

namespace CovidTracker.Models
{
    public class CountryData : World
    {
        public string Country { get; set; }
        public CountryInfo CountryInfo { get; set; }
        public string Population { get; set; }
        public string Continent { get; set; }
        public int OneCasePerPeople { get; set; }
        public int OneDeathPerPeople { get; set; }
        public int OneTestPerPeople { get; set; }
        public double ActivePerOneMillion { get; set; }
        public double RecoveredPerOneMillion { get; set; }
        public double CriticalPerOneMillion { get; set; }
    }
}
