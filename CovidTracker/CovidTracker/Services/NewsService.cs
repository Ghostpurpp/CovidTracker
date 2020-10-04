using CovidTracker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CovidTracker.Services
{
    public class NewsService
    {
        private readonly HttpClient client;

        public NewsService()
        {
            client = new HttpClient();
        }

        public async Task<ArticleData> GetArticles()
        {
            var res = await client.GetAsync("http://newsapi.org/v2/everything?q=covid&sortBy=publishedAt&apiKey=7a54f979ebea4192a8ec79cb025d66dc");

            var content = await res.Content.ReadAsStringAsync();

            ArticleData articleData = JsonConvert.DeserializeObject<ArticleData>(content);

            return articleData;
        }
    }
}
