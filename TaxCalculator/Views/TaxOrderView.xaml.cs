using System;
using System.Collections.Generic;
using TaxCalculator.ViewModels;
using Xamarin.Forms;

namespace TaxCalculator.Views
{
    public partial class TaxOrderView : ContentPage
    {
        public TaxOrderView(TaxOrderViewModel viewModel)
		{
			InitializeComponent();
			viewModel.Navigation = Navigation;
			BindingContext = viewModel;
			BackgroundColor = Color.FromHex("#312F31");
		}
	}
}
