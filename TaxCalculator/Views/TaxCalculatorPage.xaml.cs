using System;
using System.Collections.Generic;
using TaxCalculator.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaxCalculator.Views
{
	public partial class TaxCalculatorPage : ContentPage
    {
		public TaxCalculatorPage(TaxCalculatorViewModel viewModel)
		{
			InitializeComponent();
			viewModel.Navigation = Navigation;
			BindingContext = viewModel;
			Title = "Get Tax Rate";
		}
	}
}
