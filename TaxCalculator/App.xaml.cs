using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaxCalculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            RegisterDependencies.Initialize();
            MainPage = new NavigationPage(Resolver.Resolve<MainPage>())
            {
                BarBackgroundColor = Color.FromHex("#7c21f3")
            };

            if (Device.RuntimePlatform == Device.iOS)
                ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
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
