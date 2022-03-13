using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TaxCalculator.Services
{
    public class DialogService : IDialogService
    {
        public virtual async Task DisplayAlert(string message)
        {
            await App.Current.MainPage.DisplayAlert("Attention", message, "OK");
        }
    }
}
