using System;
using Moq;
using NUnit.Framework;
using TaxCalculator.Services;
using TaxCalculator.ViewModels;

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
        TaxCalculatorViewModel _vm;

        [SetUp]
        public void Setup()
        {
            _taxService = new Mock<TaxService>();
            _vm = new TaxCalculatorViewModel(_taxService.Object);
        }
    }
}
