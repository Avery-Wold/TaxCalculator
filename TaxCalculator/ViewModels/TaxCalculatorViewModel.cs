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

        public TaxCalculatorViewModel(TaxService taxService)
        {
            _taxService = taxService;
            Location = new Location();
        }

        public ICommand GetTaxRate => new Command(async () =>
        {
            IsRefreshing = true;

            try
            {
                TaxRateResult = await _taxService.GetTaxRateForLocation(Location);
                IsRefreshing = false;
                LocationDetailsVisible = true;
            }
            catch (TaxjarException e)
            {
                IsRefreshing = false;
                await DisplayAlert("Attention", e.TaxjarError.StatusCode + " " + e.TaxjarError.Detail, "OK");
            }
        });

        private TaxRateResult _taxRateResult;
        public TaxRateResult TaxRateResult
        {
            get => _taxRateResult;
            set
            {
                _taxRateResult = value;
                OnPropertyChanged(nameof(TaxRateResult));
            }
        }

        private Location _location;
        public Location Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        private bool _locationDetailsVisible = false;
        public bool LocationDetailsVisible
        {
            get => _locationDetailsVisible;
            set
            {
                _locationDetailsVisible = value;
                OnPropertyChanged(nameof(LocationDetailsVisible));
            }
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }
    }
}
