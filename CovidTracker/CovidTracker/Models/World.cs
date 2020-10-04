using System;
using System.Collections.Generic;
using System.Text;

namespace CovidTracker.Models
{
    public class World
    {
        public string Updated { get; set; }
        public int Cases { get; set; }
        public int TodayCases { get; set; }
        public int Deaths { get; set; }
        public int TodayDeaths { get; set; }
        public int Recovered { get; set; }
        public int Active { get; set; }
        public int Critical { get; set; }
        public double CasesPerOneMillion { get; set; }
        public double DeathsPerOneMillion { get; set; }
        public int Tests { get; set; }
        public double TestsPerOneMillion { get; set; }
        public int AffectedCountries { get; set; }
    }
}
