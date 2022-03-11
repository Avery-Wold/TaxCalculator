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
using System.Windows.Input;
using System.Reflection;

namespace TaxCalculator.Tests.ViewModelTests
{
    [TestFixture]
    public class MainPageViewModelTests
    {
        private Mock<TaxService> _taxService;

        [SetUp]
        public void Setup()
        {
            MockForms.Init();
            _taxService = new Mock<TaxService>();
        }

        [Test]
        public void AppIsRunning()
        {
            // Act
            var taxServiceMock = _taxService.Object;

            // Arrange
            var viewModel = new MainPageViewModel(taxServiceMock);

            // Assert
            Assert.NotNull(viewModel);
        }

        [Test]
        public void MainPageModel_OnStart_TaxRatesCommandCanExecute()
        {
            // Act
            var taxServiceMock = _taxService.Object;

            // Arrange
            var viewModel = new MainPageViewModel(taxServiceMock);

            // Assert
            viewModel.GoToTaxRatesView.CanExecute(true);
        }

        [Test]
        public void MainPageViewModel_OnStart_TaxOrdersCommandCanExecute()
        {
            // Act
            var taxServiceMock = _taxService.Object;

            // Arrange
            var viewModel = new MainPageViewModel(taxServiceMock);

            // Assert
            viewModel.GoToTaxOrderView.CanExecute(true);
        }
    }
}
