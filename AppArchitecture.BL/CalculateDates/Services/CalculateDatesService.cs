using AppArchitecture.BL.CalculateDates.Contracts;
using AppArchitecture.BL.CalculateDates.Entities;
using AppArchitecture.BL.DALContracts;
using System;

namespace AppArchitecture.BL.CalculateDates.Services
{
    public class CalculateDatesService : ICalculateDatesService
    {

        private readonly ICalculateDatesContract _calculateDatesContract;
        
        public CalculateDatesService(ICalculateDatesContract calculateDatesContract)
        {
            _calculateDatesContract = calculateDatesContract;
        }

        public DatesToDisplayEntity GetDatesToDisplay()
        {
            return _calculateDatesContract.GetDatesToDisplay();
        }

        public string CalculateDaysDifference(DateTime dateFrom, DateTime dateTo)
        {
            return CalculateDates(dateFrom, dateTo);
        }

        private string CalculateDates(DateTime dateFrom, DateTime dateTo)
        {
            return (dateTo - dateFrom).TotalDays.ToString();
        }
    }
}
