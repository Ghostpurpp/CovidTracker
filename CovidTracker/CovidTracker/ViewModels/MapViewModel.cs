using CovidTracker.Models;
using CovidTracker.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace CovidTracker.ViewModels
{
    public class MapViewModel : INotifyPropertyChanged
    {
        private readonly CovidService covidService;

        private List<MapData> locations;
        public List<MapData> Locations
        {
            get => locations;
            set
            {
                locations = value;
                OnPropertyChanged(nameof(Locations));
            }
        }

        public MapViewModel()
        {
            covidService = new CovidService();
            LoadData();
        }

        private async void LoadData()
        {
            List<CountryData> countryData = await covidService.GetCountries();

            List<MapData> info = new List<MapData>();

            foreach(var i in countryData)
            {
                MapData data = new MapData
                {
                    CountryData = i,
                    CountryPosition = new Position(i.CountryInfo.Lat, i.CountryInfo.Long),
                    CountryLabel = i.Country,
                    CountryFacts = $"Cases: {i.Cases} \n Deaths: {i.Deaths} \n Recoveries: {i.Recovered}"
                };

                info.Add(data);
            }

            Locations = info;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
