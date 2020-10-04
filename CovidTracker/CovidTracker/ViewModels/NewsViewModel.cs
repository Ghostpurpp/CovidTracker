using CovidTracker.Models;
using CovidTracker.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CovidTracker.ViewModels
{
    public class NewsViewModel : INotifyPropertyChanged
    {
        private readonly NewsService newsService;

        private Article currentArticle;
        public Article CurrentArticle
        {
            get => currentArticle;
            set
            {
                currentArticle = value;
                OnPropertyChanged();
            }
        }

        private List<Article> articles;
        public List<Article> Articles
        {
            get => articles;
            set
            {
                articles = value;
                OnPropertyChanged();
            }
        }

        Command<SelectedItemChangedEventArgs> viewArticle;
        public Command<SelectedItemChangedEventArgs> ViewArticle => viewArticle ?? (viewArticle = new Command<SelectedItemChangedEventArgs>(ViewFullArticle));

        public NewsViewModel()
        {
            newsService = new NewsService();
            LoadNews();
        }

        private async void LoadNews()
        {
            ArticleData articleData = await newsService.GetArticles();

            List<Article> newsArticles = articleData.Articles;

            Articles = newsArticles;
        }

        private async void ViewFullArticle(SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Article;

            await Browser.OpenAsync(item.Url, BrowserLaunchMode.SystemPreferred);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
