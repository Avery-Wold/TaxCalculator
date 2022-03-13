using System;
using System.Threading.Tasks;

namespace TaxCalculator.Services
{
    public interface IDialogService
    {
        Task DisplayAlert(string message);
    }
}
