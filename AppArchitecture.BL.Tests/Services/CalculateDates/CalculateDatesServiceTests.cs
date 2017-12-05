using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppArchitecture.BL.CalculateDates.Contracts;
using AppArchitecture.BL.CalculateDates.Entities;
using AppArchitecture.BL.CalculateDates.Services;
using AppArchitecture.BL.DALContracts;
using Rhino.Mocks;
using System;

namespace AppArchitecture.BL.Tests.Services.CalculateDates
{
    [TestClass]
    public class HomeControllerTest
    {
        private ICalculateDatesContract _calculateDatesContract;
        private ICalculateDatesService _calculateDatesService;
        private ICalculateDatesService _calculateDatesServiceMocked;

        [TestInitialize]
        public void Setup()
        {
            _calculateDatesContract = MockRepository.GenerateStub<ICalculateDatesContract>();
            _calculateDatesService = new CalculateDatesService(_calculateDatesContract);
            _calculateDatesServiceMocked = MockRepository.GenerateStub<ICalculateDatesService>();
        }

        [TestMethod]
        public void GetDatesToDisplay_Should_Return_Null()
        {
            //Arrange
            _calculateDatesContract.Stub(o => o.GetDatesToDisplay()).Return(null);

            // Act
            var result = _calculateDatesService.GetDatesToDisplay();

            // Assert
            _calculateDatesContract.AssertWasCalled(m => m.GetDatesToDisplay());
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetDatesToDisplay_Should_Return_NotNull()
        {
            var selectedDates = new DatesToDisplayEntity()
            {
                DateFrom = new DateTime(2016, 05, 08),
                DateTo = new DateTime(2016, 05, 11)
            };

            //Arrange
            _calculateDatesContract.Stub(o => o.GetDatesToDisplay()).Return(selectedDates);

            // Act
            var result = _calculateDatesService.GetDatesToDisplay();

            // Assert
            _calculateDatesContract.AssertWasCalled(m => m.GetDatesToDisplay());
            Assert.IsNotNull(result);
            Assert.AreEqual("2016-05-08", result.DateFrom);
            Assert.AreEqual("2016-05-11", result.DateTo);
        }

        [TestMethod]
        public void CalculateDaysDifference_Should_Return_NotNull()
        {
            var selectedDates = new DatesToDisplayEntity()
            {
                DateFrom = new DateTime(2016, 05, 08),
                DateTo = new DateTime(2016, 05, 11)
            };

            //Arrange
            _calculateDatesServiceMocked.Stub(o => o.CalculateDaysDifference(selectedDates.DateFrom, selectedDates.DateTo));

            // Act
            var result = _calculateDatesService.CalculateDaysDifference(selectedDates.DateFrom, selectedDates.DateTo);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("3", result);
        }

        [TestMethod]
        public void CalculateDaysDifference_Should_Return_EmptyString()
        {
            //Arrange
            _calculateDatesServiceMocked.Stub(o => o.CalculateDaysDifference(Arg<DateTime>.Is.Anything, Arg<DateTime>.Is.Anything)).Return(null);

            // Act
            var result = _calculateDatesService.CalculateDaysDifference(Arg<DateTime>.Is.NotNull, Arg<DateTime>.Is.NotNull);

            // Assert
            Assert.AreEqual("", result);
        }
    }
}
