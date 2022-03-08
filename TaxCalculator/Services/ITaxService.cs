using System;
using System.Threading.Tasks;
using TaxCalculatorApp.Models;

namespace TaxCalculator.Services
{
    public interface ITaxService
    {
        Task<TaxOrderResult> GetTaxForOrder(TaxOrder taxOrder);
        Task<TaxRateResult> GetTaxRateForLocation(Location location);
    }
}
