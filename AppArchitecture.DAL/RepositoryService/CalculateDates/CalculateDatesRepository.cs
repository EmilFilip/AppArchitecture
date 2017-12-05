using AppArchitecture.BL.CalculateDates.Entities;
using AppArchitecture.BL.DALContracts;
using System;

namespace AppArchitecture.DAL.RepositoryService.CalculateDates
{
    public class CalculateDatesRepository : RepositoryBase, ICalculateDatesContract
    {
        public DatesToDisplayEntity GetDatesToDisplay()
        {
            return new DatesToDisplayEntity()
            {
                DateFrom = new DateTime(2016, 5, 8),
                DateTo = new DateTime(2016, 05, 09)
            };
        }
    }
}
