using CovidTracker.Models;
using CovidTracker.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace CovidTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        readonly MapViewModel nvm = new MapViewModel();
        public MapPage()
        {
            InitializeComponent();
        }

        private async void LocPin_InfoWindowClicked(object sender, PinClickedEventArgs e)
        {
            Pin pin = sender as Pin;

            List<MapData> model = nvm.Locations;

            foreach (var i in model)
            {
                if (i.CountryData.Country == pin.Label)
                {
                    string content = JsonConvert.SerializeObject(i.CountryData);

                    Preferences.Set("AllData", content);
                    //await App.Current.MainPage.Navigation.PushAsync(new MapDataPage());

                    await Shell.Current.GoToAsync(nameof(MapDataPage));
                }
            }
        }
    }
}