using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TaxCalculator.Views;
using TaxCalculatorApp.Models;
using Xamarin.Forms;

namespace TaxCalculator.ViewModels
{
    public class TaxOrderDetailsViewModel : ViewModelBase
    {
        public TaxOrderResult TaxOrderResult { get; set; }

        public TaxOrderDetailsViewModel(TaxOrderResult result)
        {
            TaxOrderResult = result;
        }
    }
}
