using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TaxCalculator.Services;

namespace TaxCalculator.Tests.ServiceTests
{
    [TestFixture]
    public class DialogServiceTests
    {
        private Mock<DialogService> _dialogService;

        [SetUp]
        public void Setup()
        {
            _dialogService = new Mock<DialogService>();
        }

        [Test]
        public void GetTaxRate_WithNoZip_DisplaysAlert()
        {
            // Arange
            _dialogService.Setup(d => d.DisplayAlert(It.IsAny<string>())).Returns(Task.CompletedTask);

            // Assert
            _dialogService.Verify();
        }
    }
}
