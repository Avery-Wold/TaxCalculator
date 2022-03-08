using System;
using System.Windows.Input;
using TaxCalculator.Services;
using TaxCalculatorApp.Models;
using Taxjar;
using Xamarin.Forms;

namespace TaxCalculator.ViewModels
{
    public class TaxCalculatorViewModel : ViewModelBase
    {
        private readonly ITaxService _taxService;

        public TaxRateResult TaxRateResult { get; set; }
        public Location Location { get; set; }

        public bool IsRefreshing { get; set; }

        public TaxCalculatorViewModel(TaxService taxService)
        {
            _taxService = taxService;
            Location = new Location();
        }

        public string EnterZipLabel
        {
            get
            {
                return "Enter Zip Code For Location:";
            }
        }

        public string GetTaxRateLabel
        {
            get
            {
                return "Get Tax Rates";
            }
        }

        public ICommand GetTaxRate => new Command(async () =>
        {
            try
            {
                IsRefreshing = true;
                TaxRateResult = await _taxService.GetTaxRateForLocation(Location);
                IsRefreshing = false;
            }
            catch (TaxjarException e)
            {
                await DisplayAlert("Attention", e.TaxjarError.StatusCode + " " + e.TaxjarError.Detail, "OK");
            }

        });
    }
}
