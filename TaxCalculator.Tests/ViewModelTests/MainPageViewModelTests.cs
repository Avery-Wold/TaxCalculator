using System;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TaxCalculator.Services;
using TaxCalculator.ViewModels;
using TaxCalculator.Views;
using TaxCalculatorApp.Models;
using Xamarin.Forms;
using Autofac;
using Autofac.Extras.Moq;

namespace TaxCalculator.Tests.ViewModelTests
{
    [TestFixture]
    public class MainPageViewModelTests
    {
        [Test]
        public void MainPageViewModel_WhenSuccessfull_TaxRatesCommandCanExecute()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var viewModel = mock.Create<MainPageViewModel>();

                viewModel.GoToTaxRatesPage.CanExecute(true);
            }
        }

        [Test]
        public void MainPageViewModel_WhenSuccessfull_TaxOrdersCommandCanExecute()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var viewModel = mock.Create<MainPageViewModel>();

                viewModel.GoToTaxOrderPage.CanExecute(true);
            }
        }
    }
}
