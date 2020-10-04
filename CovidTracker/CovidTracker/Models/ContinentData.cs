using System;
using System.Collections.Generic;
using System.Text;

namespace CovidTracker.Models
{
    public class ContinentData : World
    {
        public double Population { get; set; }
        public string Continent { get; set; }
        public double ActivePerOneMillion { get; set; }
        public double RecoveredPerOneMillion { get; set; }
        public double CriticalPerOneMillion { get; set; }
    }
}
