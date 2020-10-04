using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CovidTracker.Views.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardView : ContentView
    {
        public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(CardView), string.Empty);
        public static readonly BindableProperty CardContentProperty = BindableProperty.Create(nameof(CardContent), typeof(string), typeof(CardView), string.Empty);

        public string CardTitle
        {
            get => (string)GetValue(CardTitleProperty);
            set => SetValue(CardTitleProperty, value);
        }

        public string CardContent
        {
            get => (string)GetValue(CardContentProperty);
            set => SetValue(CardContentProperty, value);
        }

        public CardView()
        {
            InitializeComponent();

            innerTitle.SetBinding(Label.TextProperty, new Binding(nameof(CardTitle), source: this));
            innerContent.SetBinding(Label.TextProperty, new Binding(nameof(CardContent), source: this));
        }
    }
}