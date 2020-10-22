using CovidTracker.Models;
using CovidTracker.Services;
using Microcharts;
using SkiaSharp;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CovidTracker.ViewModels
{
    public class DetailedStatsViewModel : INotifyPropertyChanged
    {
        private readonly CovidService covidService;

        private List<KeyValuePair<string, int>> caseData;
        public List<KeyValuePair<string, int>> CaseData
        {
            get => caseData;
            set
            {
                caseData = value;
                OnPropertyChanged();

                List<ChartEntry> chartEntries = new List<ChartEntry>();

                foreach (var i in CaseData)
                {
                    ChartEntry ncaseEntry = new ChartEntry(i.Value)
                    {
                        ValueLabel = i.Value.ToString(),
                        Label = i.Key,
                        Color = SKColors.White,
                        TextColor = SKColors.White
                    };

                    chartEntries.Add(ncaseEntry);
                }

                CaseChart = new BarChart { Entries = chartEntries, LabelColor = SKColors.Black, BackgroundColor = SKColors.Transparent };
            }
        }

        private List<KeyValuePair<string, int>> deathsData;
        public List<KeyValuePair<string, int>> DeathsData
        {
            get => deathsData;
            set
            {
                deathsData = value;
                OnPropertyChanged();

                List<ChartEntry> chartEntries = new List<ChartEntry>();

                foreach (var i in DeathsData)
                {
                    ChartEntry ncaseEntry = new ChartEntry(i.Value)
                    {
                        ValueLabel = i.Value.ToString(),
                        Label = i.Key,
                        Color = SKColors.White,
                        TextColor = SKColors.White
                    };

                    chartEntries.Add(ncaseEntry);
                }

                DeathChart = new BarChart { Entries = chartEntries, LabelColor = SKColors.Black, BackgroundColor = SKColors.Transparent };
            }
        }

        private List<KeyValuePair<string, int>> recoveredData;
        public List<KeyValuePair<string, int>> RecoveredData
        {
            get => recoveredData;
            set
            {
                recoveredData = value;
                OnPropertyChanged();

                List<ChartEntry> chartEntries = new List<ChartEntry>();

                foreach (var i in RecoveredData)
                {
                    ChartEntry ncaseEntry = new ChartEntry(i.Value)
                    {
                        ValueLabel = i.Value.ToString(),
                        Label = i.Key,
                        Color = SKColors.White,
                        TextColor = SKColors.White
                    };

                    chartEntries.Add(ncaseEntry);
                }

                RecoveredChart = new BarChart { Entries = chartEntries, LabelColor = SKColors.Black, BackgroundColor = SKColors.Transparent };
            }
        }

        private List<string> location;
        public List<string> Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChanged();
            }
        }
        
        private int region;
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

        private async void LoadStats()
        {
            Timeline timelines = await covidService.CountryStats("Afghanistan");

            CaseData = timelines.Cases.ToList();

            DeathsData = timelines.Deaths.ToList();

            RecoveredData = timelines.Recovered.ToList();
        }

        private async void GetLocations()
        {
            List<CountryData> countries = await covidService.GetCountries();
            List<string> allLocations = new List<string>();

            foreach (var j in countries)
            {
                allLocations.Add(j.Country);
            }

            Location = allLocations;
        }

        private async void SelectedData()
        {
            string regionName = Location[Region];

            Timeline timelines = await covidService.CountryStats(regionName);

            if(timelines != null)
            {
                CaseData = timelines.Cases.ToList();

                DeathsData = timelines.Deaths.ToList();

                RecoveredData = timelines.Recovered.ToList();
            }

            else
            {
                await App.Current.MainPage.DisplayAlert($"{regionName} has no data", "Try another country", "OK");
            }
        }

        public DetailedStatsViewModel()
        {
            covidService = new CovidService();
            
            LoadStats();
            GetLocations();
        }

        private Chart caseChart;
        public Chart CaseChart
        {
            get => caseChart;
            set
            {
                caseChart = value;
                OnPropertyChanged();
            }
        }

        private Chart deathChart;
        public Chart DeathChart
        {
            get => deathChart;
            set
            {
                deathChart = value;
                OnPropertyChanged();
            }
        }

        private Chart recoveredChart;
        public Chart RecoveredChart
        {
            get => recoveredChart;
            set
            {
                recoveredChart = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
