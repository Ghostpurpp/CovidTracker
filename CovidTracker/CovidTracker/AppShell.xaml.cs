using CovidTracker.Views;
using Xamarin.Forms;

namespace CovidTracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
            Routing.RegisterRoute(nameof(InfoPage), typeof(InfoPage));
            Routing.RegisterRoute(nameof(NewsPage), typeof(NewsPage));
            Routing.RegisterRoute(nameof(DetailedStatsPage), typeof(DetailedStatsPage));
            Routing.RegisterRoute(nameof(MapDataPage), typeof(MapDataPage));
        }
    }
}
