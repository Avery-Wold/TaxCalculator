using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TaxCalculator.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected async Task DisplayAlert(
            string title,
            string message,
            string accept = "Ok",
            string cancel = null,
            Exception exception = null)
        {
            if (string.IsNullOrWhiteSpace(cancel))
            {
                await Application.Current.MainPage.DisplayAlert(title, message, accept);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
            }
        }
    }
}
