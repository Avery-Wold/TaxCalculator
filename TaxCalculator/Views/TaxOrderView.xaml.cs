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
			Title = "Get Tax Rate For Order";
			BackgroundColor = Color.FromHex("#312F31");
		}
    }
}
