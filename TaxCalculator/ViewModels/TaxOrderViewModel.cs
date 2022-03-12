using System;
using System.Collections.Generic;
using System.Windows.Input;
using TaxCalculator.Services;
using TaxCalculator.Views;
using TaxCalculatorApp.Models;
using Taxjar;
using Xamarin.Forms;

namespace TaxCalculator.ViewModels
{
    public class TaxOrderViewModel : ViewModelBase
    {
        private readonly ITaxService _taxService;

		public TaxOrderViewModel(TaxService taxService)
        {
            _taxService = taxService;
            TaxOrder = new TaxOrder();
        }

		public ICommand GetTaxForOrder => new Command(async () =>
		{
            if (TaxOrder.FromState == null || TaxOrder.FromZip == null || TaxOrder.FromCountry == null)
            {
                await DisplayAlert("You must enter From State, Zip and Country", "", "OK");
            }
            else if (TaxOrder.ToState == null || TaxOrder.ToZip == null || TaxOrder.ToState == null)
            {
                await DisplayAlert("You must enter To State, Zip and Country", "", "OK");
            }
            else
            {
                try
                {
                    // Hardcoding line item values
                    var lineItems = new List<TaxCalculatorApp.Models.LineItem>();
                    lineItems.Add(new TaxCalculatorApp.Models.LineItem
                    {
                        Id = "1",
                        Quantity = 1,
                        ProductTaxCode = "31000",
                        UnitPrice = 15,
                        Discount = 0
                    });
                    TaxOrder.LineItems = lineItems;

                    TaxOrderResult = await _taxService.GetTaxForOrder(TaxOrder);

                    await Navigation.PushAsync(new TaxOrderDetailsView(TaxOrderResult));
                }
                catch (TaxjarException e)
                {
                    await DisplayAlert("Attention", e.TaxjarError.StatusCode + " " + e.TaxjarError.Detail, "OK");
                }
            }
		});

        private TaxOrder taxOrder;
        public TaxOrder TaxOrder
        {
            get => taxOrder;
            set
            {
                taxOrder = value;
                OnPropertyChanged(nameof(TaxOrder));
            }
        }

        private TaxOrderResult taxOrderResult;
        public TaxOrderResult TaxOrderResult
        {
            get => taxOrderResult;
            set
            {
                taxOrderResult = value;
                OnPropertyChanged(nameof(TaxOrderResult));
            }
        }
    }
}
