﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaxCalculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Bootstrapper.Initialize();
            MainPage = new NavigationPage(Resolver.Resolve<MainPage>());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
