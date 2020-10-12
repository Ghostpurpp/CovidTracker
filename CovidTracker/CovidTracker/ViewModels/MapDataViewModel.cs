using CovidTracker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;

namespace CovidTracker.ViewModels
{
    public class MapDataViewModel
    {
        private string country;
        public string Country
        {
            get => country;
            set
            {
                country = value;
                OnPropertyChanged();
            }
        }

        private string cases;
        public string Cases
        {
            get => cases;
            set
            {
                cases = value;
                OnPropertyChanged();
            }
        }

        private string deaths;
        public string Deaths
        {
            get => deaths;
            set
            {
                deaths = value;
                OnPropertyChanged();
            }
        }

        private string recovered;
        public string Recovered
        {
            get { return recovered; }
            set
            {
                recovered = value;
                OnPropertyChanged(nameof(Recovered));
            }
        }

        private string active;
        public string Active
        {
            get { return active; }
            set
            {
                active = value;
                OnPropertyChanged(nameof(Active));
            }
        }

        private string tests;
        public string Tests
        {
            get { return tests; }
            set
            {
                tests = value;
                OnPropertyChanged(nameof(Tests));
            }
        }

        private string critical;
        public string Critical
        {
            get => critical;
            set
            {
                critical = value;
                OnPropertyChanged();
            }
        }

        private string casesPerMillion;
        public string CasesPerMillion
        {
            get => casesPerMillion;
            set
            {
                casesPerMillion = value;
                OnPropertyChanged();
            }
        }

        private string deathsPerMillion;
        public string DeathsPerMillion
        {
            get => deathsPerMillion;
            set
            {
                deathsPerMillion = value;
                OnPropertyChanged();
            }
        }

        private string activePerMillion;
        public string ActivePerMillion
        {
            get => activePerMillion;
            set
            {
                activePerMillion = value;
                OnPropertyChanged();
            }
        }

        private string testsPerMillion;
        public string TestsPerMillion
        {
            get => testsPerMillion;
            set
            {
                testsPerMillion = value;
                OnPropertyChanged();
            }
        }

        private string recoveredPerMillion;
        public string RecoveredPerMillion
        {
            get => recoveredPerMillion;
            set
            {
                recoveredPerMillion = value;
                OnPropertyChanged();
            }
        }

        private string criticalPerMillion;
        public string CriticalPerMillion
        {
            get => criticalPerMillion;
            set
            {
                criticalPerMillion = value;
                OnPropertyChanged();
            }
        }

        private string population;
        public string Population
        {
            get => population;
            set
            {
                population = value;
                OnPropertyChanged();
            }
        }


        public MapDataViewModel()
        {
            var storedContent = Preferences.Get("AllData", string.Empty);

            CountryData model = JsonConvert.DeserializeObject<CountryData>(storedContent);

            Country = model.Country;
            Cases = $"Cases: {model.Cases}";
            Deaths = $"Deaths: {model.Deaths}";
            Recovered = $"Recovered: {model.Recovered}";
            Active = $"Active: {model.Active}";
            Tests = $"Tests: {model.Tests}";
            Critical = $"Critical: {model.Critical}";
            CasesPerMillion = $"Cases Per One Million: {model.CasesPerOneMillion}";
            DeathsPerMillion = $"Deaths Per One Million: {model.DeathsPerOneMillion}";
            RecoveredPerMillion = $"Recovered Per One Million: {model.RecoveredPerOneMillion}";
            ActivePerMillion = $"Active Per One Million: {model.ActivePerOneMillion}";
            TestsPerMillion = $"Tests Per One Million: {model.TestsPerOneMillion}";
            CriticalPerMillion = $"Critical Per One Million: {model.CriticalPerOneMillion}";
            Population = $"Population: {model.Population}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
