using System;
using System.Windows.Input;
using TaxCalculator.Services;
using TaxCalculatorApp.Models;
using Taxjar;
using Xamarin.Forms;

namespace TaxCalculator.ViewModels
{
    public class TaxOrderViewModel : ViewModelBase
    {
        private readonly ITaxService _taxService;

        public TaxOrder TaxOrder { get; set; }
        public FromLocation FromLocation { get; set; }
        public ToLocation ToLocation { get; set; }
		public TaxOrderResult TaxOrderResult { get; set; }

		public TaxOrderViewModel(TaxService taxService)
        {
            _taxService = taxService;

            TaxOrder = new TaxOrder();
            ToLocation = new ToLocation();
            FromLocation = new FromLocation();
        }

		public ICommand GetTaxForOrder => new Command(async () =>
		{
			try
			{
				TaxOrder.FromLocation = new FromLocation
				{
					FromCountry = FromLocation.FromCountry,
					FromZip = FromLocation.FromZip,
					FromState = FromLocation.FromState,
					FromCity = FromLocation.FromCity,
					FromStreet = FromLocation.FromStreet
				};

				TaxOrder.ToLocation = new ToLocation
				{
					ToCountry = ToLocation.ToCountry,
					ToZip = ToLocation.ToZip,
					ToState = ToLocation.ToState,
					ToCity = ToLocation.ToCity,
					ToStreet = ToLocation.ToStreet
				};

				TaxOrderResult = await _taxService.GetTaxForOrder(TaxOrder);
			}
			catch (TaxjarException e)
			{
				await DisplayAlert("Attention", e.TaxjarError.StatusCode + " " + e.TaxjarError.Detail, "OK");
			}
		});
	}
}
