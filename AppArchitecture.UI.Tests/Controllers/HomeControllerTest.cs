using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppArchitecture.BL.CalculateDates.Contracts;
using AppArchitecture.BL.CalculateDates.Entities;
using AppArchitecture.UI.App_Start;
using AppArchitecture.UI.Controllers.CalculateDates;
using AppArchitecture.UI.Models.CalculateDates;
using Rhino.Mocks;
using System.Web.Mvc;
using System;

namespace AppArchitecture.UI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private ICalculateDatesService _calculateDatesService;
        private DisplayDatesController _controller;

        [TestInitialize]
        public void Setup()
        {
            AutoMapperConfig.ConfigureAutoMapper();
            _calculateDatesService = MockRepository.GenerateStub<ICalculateDatesService>();
            _controller = new DisplayDatesController(_calculateDatesService);
        }

        [TestMethod]
        public void Index_Should_Return_Null()
        {
            //Arrange
            _calculateDatesService.Stub(o => o.GetDatesToDisplay()).Return(null);

            // Act
            var difference = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNull(difference.Model);
        }

        [TestMethod]
        public void Index_Should_Return_NotNull()
        {
            //Arrange
            var selectedDates = new DatesToDisplayEntity()
            {
                DateFrom = new DateTime(2016, 05, 08),
                DateTo = new DateTime(2016, 05, 11)
            };

            _calculateDatesService.Stub(o => o.GetDatesToDisplay()).Return(selectedDates);

            // Act
            var difference = _controller.Index() as ViewResult;

            // Assert
            _calculateDatesService.AssertWasCalled(m => m.GetDatesToDisplay());
            Assert.IsNotNull(difference.Model);
            Assert.AreEqual(selectedDates.DateFrom, ((DatesToDisplayViewModel)difference.Model).DateFrom);
            Assert.AreEqual(selectedDates.DateTo, ((DatesToDisplayViewModel)difference.Model).DateTo);
        }
        [TestMethod]
        public void CalculateDates_Should_Return_Null()
        {
            //Arrange
            var selectedDates = new DatesToDisplayViewModel()
            {
                DateFrom = new DateTime(2016, 05, 08),
                DateTo = new DateTime(2016, 05, 11)
            };

            _calculateDatesService.Stub(o => o.CalculateDaysDifference(Arg<DateTime>.Is.Anything, Arg<DateTime>.Is.Anything)).Return(null);

            // Act
            var difference = _controller.CalculateDates(selectedDates) as ViewResult;

            // Assert
            Assert.IsNull(difference.Model);
        }

        [TestMethod]
        public void CalculateDates_Should_Return_NotNull()
        {
            //Arrange
           var selectedDates = new DatesToDisplayViewModel()
           {
               DateFrom = new DateTime(2016, 05, 08),
               DateTo = new DateTime(2016, 05, 11)
           };

            _calculateDatesService.Stub(o => o.CalculateDaysDifference(selectedDates.DateFrom, selectedDates.DateTo)).Return("3");

            // Act
            var difference = _controller.CalculateDates(selectedDates) as ViewResult;
    
            // Assert
            _calculateDatesService.AssertWasCalled(m => m.CalculateDaysDifference(selectedDates.DateFrom, selectedDates.DateTo));
            Assert.IsNotNull(difference.Model);
            Assert.AreEqual("3", difference.Model);
        }
    }
}
