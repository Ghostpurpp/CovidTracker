using System;
using System.Collections.Generic;
using System.Text;

namespace CovidTracker.Models
{
    public class CountryStat
    {
        public string Country { get; set; }
        public string[] Province { get; set; }
        public Timeline Timeline { get; set; }
    }
}
