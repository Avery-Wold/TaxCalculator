using System.Windows.Input;
using TaxCalculator.Services;
using TaxCalculator.Views;
using Xamarin.Forms;

namespace TaxCalculator.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly ITaxService _taxService;

        public MainPageViewModel(TaxService taxService)
        {
            _taxService = taxService;
        }

        public ICommand GoToTaxRatesPage => new Command(async () =>
        {
            var taxCalculatorPage = Resolver.Resolve<TaxCalculatorView>();
            await Navigation.PushAsync(taxCalculatorPage);
        });

        public ICommand GoToTaxOrderPage => new Command(async () =>
        {
            var taxOrderPage = Resolver.Resolve<TaxOrderView>();
            await Navigation.PushAsync(taxOrderPage);
        });
    }
}
