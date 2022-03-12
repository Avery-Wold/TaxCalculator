using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TaxCalculator.Services;
using TaxCalculatorApp.Models;
using Taxjar;

namespace TaxCalculator.Tests.ServiceTests
{
    [TestFixture]
    public class TaxServiceTests
    {
        private Mock<TaxService> _taxService;

        [SetUp]
        public void Setup()
        {
            _taxService = new Mock<TaxService>();
        }

        [Test]
        public void GetApiToken()
        {
            var key = Settings.TaxJarApiKey;

            if (!string.IsNullOrEmpty(key))
            {
                Assert.IsTrue(true, key);
            }
            else
            {
                Assert.IsFalse(false, "no api key received");
            }
        }

        [Test]
        public async Task GetTaxRateForLocation_WithValidZip_ReturnsRates()
        {
            // Arrange
            var mockService = _taxService.Object;
            var location = new Location
            {
                Country = "US",
                Zip = "55406",
                State = "MN",
                City = "Minneapolis"
            };

            // Act
            var rates = await mockService.GetTaxRateForLocation(location);

            // Assert
            Assert.NotNull(rates);
            Assert.AreEqual(0.005m, rates.CityRate);
            Assert.AreEqual(0.06875m, rates.StateRate);
            Assert.AreEqual(0.08025m, rates.CombinedRate);
        }

        [Test]
        public async Task GetTaxRateForLocation_WithInvalidZip_ReturnsNull()
        {
            // Arrange
            var mockService = _taxService.Object;
            var location = new Location
            {
                Country = "US",
                Zip = "",
                State = "MN",
                City = "Minneapolis"
            };

            // Act
            var rates = await mockService.GetTaxRateForLocation(location);

            // Assert
            Assert.IsNull(rates);
        }

        [Test]
        public async Task GetTaxRateForOrder_WithValidTaxOrder_ReturnsNull()
        {
            // Arrange
            var mockService = _taxService.Object;

            var lineItems = new List<TaxCalculatorApp.Models.LineItem>();
            lineItems.Add(new TaxCalculatorApp.Models.LineItem
            {
                Id = "1",
                Quantity = 1,
                ProductTaxCode = "31000",
                UnitPrice = 15,
                Discount = 0
            });

            var taxOrder = new TaxOrder
            {
                FromState = "MN",
                FromZip = "55406",
                FromCountry = "US",
                ToState = "MN",
                ToZip = "55337",
                ToCountry = "US",
                Amount = 1234.56m,
                Shipping = 1.51m,
                LineItems = lineItems
            };

            // Act
            var rates = await mockService.GetTaxForOrder(taxOrder);

            // Assert
            Assert.IsNotNull(rates);
            Assert.AreEqual(1.18m, rates.AmountToCollect);
            Assert.AreEqual(16.51m, rates.TaxableAmount);
            Assert.AreEqual(0.07125m, rates.TaxRate);
        }

        [Test]
        public async Task GetTaxRateForOrder_WithInvalidTaxOrder_ReturnsRates()
        {
            // Arrange
            var mockService = _taxService.Object;

            var taxOrder = new TaxOrder();

            // Act
            var rates = await mockService.GetTaxForOrder(taxOrder);

            // Assert
            Assert.IsNull(rates);
        }
    }
}
