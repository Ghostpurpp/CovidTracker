﻿using CovidTracker.ViewModels;
using Microcharts;
using SkiaSharp;
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
    public partial class DetailedStatsPage : ContentPage
    {
        public DetailedStatsPage()
        {
            InitializeComponent();
        }
    }
}