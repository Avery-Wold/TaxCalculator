using System.Windows.Input;
using TaxCalculator.Services;
using Xamarin.Forms;

namespace TaxCalculator.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly ITaxService _taxService;

        public MainPageViewModel()
        {

        }

        public string SelectOptionLabel
        {
            get
            {
                return "Select an option to calculate tax";
            }
        }

        public ICommand GoToTaxRatesPage => new Command(async () =>
        {
            //var taxCalculatorPage = Resolver.Resolve<TaxCalculatorPage>();
            //await Navigation.PushAsync(taxCalculatorPage);
        });
    }
}
