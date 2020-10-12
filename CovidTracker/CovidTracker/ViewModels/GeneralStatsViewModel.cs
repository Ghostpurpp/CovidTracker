using CovidTracker.Models;
using CovidTracker.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CovidTracker.ViewModels
{
    public class GeneralStatsViewModel : INotifyPropertyChanged
    {
        private readonly CovidService covidService;

        private int todayCases;
        private int cases;
        private int todayDeaths;
        private int deaths;
        private int recovered;
        private int tests;
        private int active;
        private List<string> location;
        private int region;
        private string regionName;

        public event PropertyChangedEventHandler PropertyChanged;

        public int TodayCases {
            get { return todayCases; }
            set 
            {
                todayCases = value;
                OnPropertyChanged(nameof(TodayCases));
            } 
        }

        public int Cases
        {
            get { return cases; }
            set
            {
                cases = value;
                OnPropertyChanged(nameof(Cases));
            }
        }

        public int TodayDeaths
        {
            get { return todayDeaths; }
            set
            {
                todayDeaths = value;
                OnPropertyChanged(nameof(TodayDeaths));
            }
        }

        public int Deaths
        {
            get { return deaths; }
            set
            {
                deaths = value;
                OnPropertyChanged(nameof(Deaths));
            }
        }

        public int Recovered
        {
            get { return recovered; }
            set
            {
                recovered = value;
                OnPropertyChanged(nameof(Recovered));
            }
        }
        public int Active
        {
            get { return active; }
            set
            {
                active = value;
                OnPropertyChanged(nameof(Active));
            }
        }

        public int Tests
        {
            get { return tests; }
            set
            {
                tests = value;
                OnPropertyChanged(nameof(Tests));
            }
        }
        public List<string> Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChanged(nameof(Location));
            }
        }
        public int Region
        {
            get { return region; }
            set
            {
                region = value;
                OnPropertyChanged();
                SelectedData();
            }
        }
        public string RegionName
        {
            get { return regionName; }
            set
            {
                regionName = value;
                OnPropertyChanged();
            }
        }

        public GeneralStatsViewModel()
        {
            covidService = new CovidService();
            GetLocations();
            GetGlobalData();
        }

        private async void GetGlobalData()
        {
            World global = await covidService.GetGlobal();

            TodayCases = global.TodayCases;
            Cases = global.Cases;
            TodayDeaths = global.TodayDeaths;
            Deaths = global.Deaths;
            Recovered = global.Recovered;
            Tests = global.Tests;
            Active = global.Active;
        }

        private async void GetLocations()
        {
            List<ContinentData> continents = await covidService.GetContinents();
            List<CountryData> countries = await covidService.GetCountries();
            List<string> allLocations = new List<string>
            {
                "Global"
            };
            foreach (var i in continents)
            {
                allLocations.Add(i.Continent);
            }

            foreach(var j in countries)
            {
                allLocations.Add(j.Country);
            }

            Location = allLocations;
        }

        private async void SelectedData()
        {
            string regionName = Location[Region];
            if (Region > 1 && Region < 6)
            {
                ContinentData continent = await covidService.FindContinent(regionName);

                TodayCases = continent.TodayCases;
                Cases = continent.Cases;
                TodayDeaths = continent.TodayDeaths;
                Deaths = continent.Deaths;
                Recovered = continent.Recovered;
                Active = continent.Active;
                Tests = continent.Tests;
            }
            else if(Region > 6)
            {
                CountryData country = await covidService.FindCountry(regionName);

                TodayCases = country.TodayCases;
                Cases = country.Cases;
                TodayDeaths = country.TodayDeaths;
                Deaths = country.Deaths;
                Recovered = country.Recovered;
                Active = country.Active;
                Tests = country.Tests;
            }
            else
            {
                GetGlobalData();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
