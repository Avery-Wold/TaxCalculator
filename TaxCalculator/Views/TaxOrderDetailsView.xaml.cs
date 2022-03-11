using System;
using System.Collections.Generic;
using TaxCalculator.ViewModels;
using TaxCalculatorApp.Models;
using Xamarin.Forms;

namespace TaxCalculator.Views
{
	public partial class TaxOrderDetailsView : ContentPage
	{
		public TaxOrderDetailsView(TaxOrderResult result)
		{
			InitializeComponent();
			BindingContext = new TaxOrderDetailsViewModel(result);
			Title = "Tax Rates For Order";
			BackgroundColor = Color.FromHex("#312F31");
		}
	}
}
