using TaxCalculator.ViewModels;
using Xamarin.Forms;

namespace TaxCalculator
{
    public partial class MainPage : ContentPage
    {
		public MainPage(MainPageViewModel viewModel)
		{
			InitializeComponent();
			viewModel.Navigation = Navigation;
			BindingContext = viewModel;
			NavigationPage.SetBackButtonTitle(this, "");
			BackgroundColor = Color.FromHex("#312F31");
		}
	}
}
