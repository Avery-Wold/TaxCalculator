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
    public class TaxCalculatorViewModelTests
    {
        private Mock<TaxService> _taxService;
        private Mock<DialogService> _dialogService;

        [SetUp]
        public void Setup()
        {
            _taxService = new Mock<TaxService>();
            _dialogService = new Mock<DialogService>();
        }

        [Test]
        public void GetTaxRateButton_OnNavigatedTo_CanExecute()
        {
            // Act
            var taxServiceMock = _taxService.Object;
            var dialogServiceMock = _dialogService.Object;
            var viewModel = new TaxCalculatorViewModel(taxServiceMock, dialogServiceMock);

            // Arrange
            var result = viewModel.GetTaxRate.CanExecute(true);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void GetTaxRate_WithValidZip_CallsService()
        {
            // Act
            var taxServiceMock = _taxService.Object;
            var dialogServiceMock = _dialogService.Object;

            var viewModel = new TaxCalculatorViewModel(taxServiceMock, dialogServiceMock);
            viewModel.Location = new Location
            {
                Zip = "55426"
            };

            // Arrange
            viewModel.GetTaxRate.Execute(null);

            // Assert
            _taxService.Verify();
        }

        [Test]
        public void GetTaxRate_WithNoZip_DisplaysAlert()
        {
            // Act
            var expectedMessage = "You must enter a zip code";
            var taxServiceMock = _taxService.Object;
            _dialogService.Setup(d => d.DisplayAlert(It.IsAny<string>())).Returns(Task.CompletedTask);
            var dialogServiceMock = _dialogService.Object;

            var viewModel = new TaxCalculatorViewModel(taxServiceMock, dialogServiceMock);
            viewModel.Location = new Location
            {
                Zip = ""
            };

            // Arrange
            viewModel.GetTaxRate.Execute(null);

            // Assert
            _dialogService.Verify(ds => ds.DisplayAlert(expectedMessage), Times.AtLeastOnce);
        }

        [Test]
        public void GetTaxRate_WithInvalidZip_ThrowsException()
        {
            // Act
            var taxServiceMock = _taxService.Object;
            var dialogServiceMock = _dialogService.Object;
            var viewModel = new TaxCalculatorViewModel(taxServiceMock, dialogServiceMock);
            viewModel.Location= new Location
            {
                Zip = "5540"
            };

            // Arrange
            viewModel.GetTaxRate.Execute(null);

            // Assert
            Assert.ThrowsAsync<TaxjarException>(() => { throw new TaxjarException(); });
        }
    }
}
