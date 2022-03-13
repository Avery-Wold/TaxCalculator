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
        private readonly IDialogService _dialogService;

		public TaxOrderViewModel(TaxService taxService, DialogService dialogService)
        {
            _taxService = taxService;
            _dialogService = dialogService;
            TaxOrder = new TaxOrder();
        }

		public ICommand GetTaxForOrder => new Command(async () =>
		{
            if (string.IsNullOrWhiteSpace(TaxOrder.FromState) || string.IsNullOrWhiteSpace(TaxOrder.FromZip) || string.IsNullOrWhiteSpace(TaxOrder.FromCountry))
            {
                await _dialogService.DisplayAlert("You must enter From State, Zip and Country");

            }
            else if (string.IsNullOrWhiteSpace(TaxOrder.ToState) || string.IsNullOrWhiteSpace(TaxOrder.ToZip) || string.IsNullOrWhiteSpace(TaxOrder.ToCountry))
            {
                await _dialogService.DisplayAlert("You must enter To State, Zip and Country");
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
                    await _dialogService.DisplayAlert(e.TaxjarError.StatusCode + " " + e.TaxjarError.Detail);
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
