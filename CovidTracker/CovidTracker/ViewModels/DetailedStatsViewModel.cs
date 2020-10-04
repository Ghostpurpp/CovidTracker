using CovidTracker.Models;
using CovidTracker.Services;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms.Internals;

namespace CovidTracker.ViewModels
{
    public class DetailedStatsViewModel : INotifyPropertyChanged
    {
        private readonly CovidService covidService;

        private CountryStat countryStates;
        public CountryStat CountryStates
        {
            get => countryStates;
            set
            {
                countryStates = value;
                OnPropertyChanged(nameof(CountryStates));
            }
        }


        private List<ChartEntry> caseEntries;
        public List<ChartEntry> CaseEntries
        {
            get => caseEntries;
            set
            {
                caseEntries = value;
                OnPropertyChanged();
            }
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

        private async void LoadStats()
        {
            CountryStat countryStat = await covidService.CountryStats("Spain");

            CountryStates = countryStat;

            //Debug.WriteLine(CountryStates.Country);
        }

        public DetailedStatsViewModel()
        {
            covidService = new CovidService();

            LoadStats();

            List<ChartEntry> chartEntries = new List<ChartEntry>();

            if(CountryStates != null)
            {
                foreach(var i in CountryStates.Timeline.Cases)
            {
                    ChartEntry caseEntry = new ChartEntry(i.Value)
                    {
                        ValueLabel = i.Value.ToString(),
                        Label = i.Key,
                        Color = SKColor.Parse("#000000")
                    };

                    chartEntries.Add(caseEntry);
                }

                CaseEntries = chartEntries;
            }

            //Debug.WriteLine(CaseEntries[0].Value);

            CaseChart = new BarChart { Entries = CaseEntries };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
