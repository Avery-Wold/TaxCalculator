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
            // Arrange
            var taxServiceMock = _taxService.Object;
            var dialogServiceMock = _dialogService.Object;

            // Act
            var viewModel = new MainPageViewModel(taxServiceMock, dialogServiceMock);

            // Assert
            Assert.NotNull(viewModel);
        }
    }
}
