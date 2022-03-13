using Moq;
using NUnit.Framework;
using TaxCalculator.Services;
using TaxCalculator.ViewModels;

namespace TaxCalculator.Tests.ViewModelTests
{
    [TestFixture]
    public class MainPageViewModelTests
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
        public void AppIsRunning()
        {
            // Act
            var taxServiceMock = _taxService.Object;
            var dialogServiceMock = _dialogService.Object;

            // Arrange
            var viewModel = new MainPageViewModel(taxServiceMock, dialogServiceMock);

            // Assert
            Assert.NotNull(viewModel);
        }

        [Test]
        public void MainPageModel_OnStart_TaxRatesCommandCanExecute()
        {
            // Act
            var taxServiceMock = _taxService.Object;
            var dialogServicMock = _dialogService.Object;
            var viewModel = new MainPageViewModel(taxServiceMock, dialogServicMock);

            // Arrange
            var result = viewModel.GoToTaxRatesView.CanExecute(true);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void MainPageViewModel_OnStart_TaxOrdersCommandCanExecute()
        {
            // Act
            var taxServiceMock = _taxService.Object;
            var dialogServicMock = _dialogService.Object;
            var viewModel = new MainPageViewModel(taxServiceMock, dialogServicMock);

            // Arrange
            var result = viewModel.GoToTaxOrderView.CanExecute(true);

            // Assert
            Assert.That(result, Is.True);
        }
    }
}
