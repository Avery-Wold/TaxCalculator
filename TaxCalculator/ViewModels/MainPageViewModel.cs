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

        public ICommand GoToTaxRatesView => new Command(async () =>
        {
            var taxCalculatorView = Resolver.Resolve<TaxCalculatorView>();
            await Navigation.PushAsync(taxCalculatorView);
        });

        public ICommand GoToTaxOrderView => new Command(async () =>
        {
            var taxOrderView = Resolver.Resolve<TaxOrderView>();
            await Navigation.PushAsync(taxOrderView);
        });
    }
}
