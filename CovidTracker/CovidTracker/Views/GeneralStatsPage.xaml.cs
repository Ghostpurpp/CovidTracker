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
    public partial class GeneralStatsPage : ContentPage
    {
        public GeneralStatsPage()
        {
            InitializeComponent();
        }
    }
}