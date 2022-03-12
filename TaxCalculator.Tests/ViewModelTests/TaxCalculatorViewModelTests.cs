using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TaxCalculator.Services;
using TaxCalculator.ViewModels;
using TaxCalculatorApp.Models;

namespace TaxCalculator.Tests.ViewModelTests
{
    [TestFixture]
    public class TaxCalculatorViewModelTests
    {
        //MainPageViewModel _vm;
        //protected Mock<INavigation> NavigationService;

        //[SetUp]
        //public void SetUp()
        //{
        //    //var mainPageMock = new Mock<TaxService>().Object;
        //    //_vm = new MainPageViewModel(mainPageMock);
        //}
        private Mock<TaxService> _taxService;

        [SetUp]
        public void Setup()
        {
            _taxService = new Mock<TaxService>();
        }

        [Test]
        public void GetTaxRateButton_On_CanExecute()
        {
            // Act
            var taxServiceMock = _taxService.Object;

            // Arrange
            var viewModel = new TaxCalculatorViewModel(taxServiceMock);

            // Assert
            viewModel.GetTaxRate.CanExecute(true);
        }
    }
}
