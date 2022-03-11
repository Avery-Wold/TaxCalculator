using System;
using System.Collections.Generic;
using TaxCalculator.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaxCalculator.Views
{
	public partial class TaxCalculatorView : ContentPage
    {
		public TaxCalculatorView(TaxCalculatorViewModel viewModel)
		{
			InitializeComponent();
			viewModel.Navigation = Navigation;
			BindingContext = viewModel;
			Title = "Get Tax Rate For Location";
			BackgroundColor = Color.FromHex("#312F31");
		}
	}
}
