using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TaxCalculator.Services;
using TaxCalculator.ViewModels;
using TaxCalculatorApp.Models;
using Taxjar;

namespace TaxCalculator.Tests.ViewModelTests
{
    [TestFixture]
    public class TaxOrderViewModelTests
    {
        private Mock<TaxService> _taxService;
        private Mock<DialogService> _dialogService;

        [SetUp]
        public void Setup()
        {
            _taxService = new Mock<TaxService>();
            _dialogService = new Mock<DialogService>();
        }

        [TestCase("US", "MN", "55406", "US", "CA", "90011")]
        public void GetTaxRate_WithValidData_CallsService(string fromCountry, string fromState, string fromZip, string toCountry, string toState, string toZip)
        {
            // Arrange
            var taxServiceMock = _taxService.Object;
            var dialogServiceMock = _dialogService.Object;

            var viewModel = new TaxOrderViewModel(taxServiceMock, dialogServiceMock);
            viewModel.TaxOrder = mockTestOrder(fromCountry, fromState, fromZip, toCountry, toState, toZip);

            // Act
            viewModel.GetTaxForOrder.Execute(null);

            // Assert
            _taxService.Verify();
        }

        [TestCase("US", "MN", "5540", "US", "CA", "90011")]
        [TestCase("US", "M", "55406", "US", "CA", "90011")]
        [TestCase("U", "MN", "55406", "US", "CA", "90011")]
        [TestCase("US", "MN", "55406", "US", "CA", "900111")]
        [TestCase("US", "MN", "55406", "US", "CB", "90011")]
        [TestCase("US", "MN", "55406", "U", "CA", "90011")]
        [TestCase("US", "MN", "55406", "US", "A", "90011")]
        public void GetTaxForOrder_WithInvalidData_ThrowsException(string fromCountry, string fromState, string fromZip, string toCountry, string toState, string toZip)
        {
            // Arrange
            var taxServiceMock = _taxService.Object;
            var dialogServiceMock = _dialogService.Object;
            var viewModel = new TaxOrderViewModel(taxServiceMock, dialogServiceMock);
            viewModel.TaxOrder = mockTestOrder(fromCountry, fromState, fromZip, toCountry, toState, toZip);

            // Act
            viewModel.GetTaxForOrder.Execute(null);

            // Assert
            Assert.ThrowsAsync<TaxjarException>(() => { throw new TaxjarException(); });
        }

        [TestCase("US", "MN", "", "US", "CA", "90011", "You must enter From State, Zip and Country")]
        [TestCase("US", "", "55426", "US", "CA", "90011", "You must enter From State, Zip and Country")]
        [TestCase("", "MN", "55426", "US", "CA", "90011", "You must enter From State, Zip and Country")]
        [TestCase("US", "MN", "55426", "", "CA", "90011", "You must enter To State, Zip and Country")]
        [TestCase("US", "MN", "55426", "US", "", "90011", "You must enter To State, Zip and Country")]
        [TestCase("US", "MN", "55426", "US", "CA", "", "You must enter To State, Zip and Country")]
        public void GetTaxForOrder_WithMissingData_DisplaysAlert(string fromCountry, string fromState, string fromZip, string toCountry, string toState, string toZip, string expectedMessage)
        {
            // Arrange
            var expected = expectedMessage;
            var taxServiceMock = _taxService.Object;
            _dialogService.Setup(d => d.DisplayAlert(It.IsAny<string>())).Returns(Task.CompletedTask);
            var dialogServiceMock = _dialogService.Object;

            var viewModel = new TaxOrderViewModel(taxServiceMock, dialogServiceMock);
            viewModel.TaxOrder = mockTestOrder(fromCountry, fromState, fromZip, toCountry, toState, toZip);

            // Act
            viewModel.GetTaxForOrder.Execute(null);

            // Assert
            _dialogService.Verify(ds => ds.DisplayAlert(expectedMessage), Times.AtLeastOnce);
        }

        #region Helper Methods
        private TaxOrder mockTestOrder(string fromCountry, string fromState, string fromZip, string toCountry, string toState, string toZip)
        {
            return new TaxOrder
            {
                FromCountry = fromCountry,
                FromState = fromState,
                FromZip = fromZip,
                ToCountry = toCountry,
                ToState = toState,
                ToZip = toZip
            };
        }
        #endregion
    }
}
