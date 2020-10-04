using CovidTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CovidTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();
        }

        private void NewsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var nvm = new NewsViewModel();

            nvm.ViewArticle?.Execute(e);
        }
    }
}