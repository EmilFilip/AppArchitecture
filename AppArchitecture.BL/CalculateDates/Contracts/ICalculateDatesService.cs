using AppArchitecture.BL.CalculateDates.Entities;
using System;

namespace AppArchitecture.BL.CalculateDates.Contracts
{
    public interface ICalculateDatesService
    {
        DatesToDisplayEntity GetDatesToDisplay();

        string CalculateDaysDifference(DateTime dateFrom, DateTime dateTo);
    }
}
