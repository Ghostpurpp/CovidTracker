using CovidTracker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CovidTracker.Services
{
    public class CovidService
    {
        private readonly HttpClient client;

        public CovidService()
        {
            client = new HttpClient();
        }

        public async Task<World> GetGlobal()
        {
            var res = await client.GetAsync("https://corona.lmao.ninja/v2/all?yesterday");

            var content = await res.Content.ReadAsStringAsync();

            var allCases = JsonConvert.DeserializeObject<World>(content);

            return allCases;
        }

        public async Task<List<ContinentData>> GetContinents()
        {
            var res = await client.GetAsync("https://corona.lmao.ninja/v2/continents?yesterday=true&sort");

            var content = await res.Content.ReadAsStringAsync();

            List<ContinentData> allContinents = JsonConvert.DeserializeObject<List<ContinentData>>(content);

            return allContinents;
        }

        public async Task<ContinentData> FindContinent(string continent)
        {
            var res = await client.GetAsync($"https://corona.lmao.ninja/v2/continents/{continent}?yesterday&strict");

            var content = await res.Content.ReadAsStringAsync();

            ContinentData foundContinent = JsonConvert.DeserializeObject<ContinentData>(content);

            return foundContinent;
        }

        public async Task<List<CountryData>> GetCountries()
        {
            var res = await client.GetAsync("https://corona.lmao.ninja/v2/countries?yesterday&sort");

            var content = await res.Content.ReadAsStringAsync();

            List<CountryData> allCountries = JsonConvert.DeserializeObject<List<CountryData>>(content);

            return allCountries;
        }

        public async Task<CountryData> FindCountry(string country)
        {
            var res = await client.GetAsync($"https://corona.lmao.ninja/v2/countries/{country}?yesterday=true&strict=true&query");

            var content = await res.Content.ReadAsStringAsync();

            CountryData foundCountry = JsonConvert.DeserializeObject<CountryData>(content);

            return foundCountry;
        }

        public async Task<Timeline> CountryStats(string country)
        {
            var res = await client.GetAsync($"https://corona.lmao.ninja/v2/historical/{country}?lastdays=30");

            var content = await res.Content.ReadAsStringAsync();

            CountryStat stat = JsonConvert.DeserializeObject<CountryStat>(content);

            return stat.Timeline;
        }
    }
}
