using AppArchitecture.BL.CalculateDates.Entities;

namespace AppArchitecture.BL.DALContracts
{
    public interface ICalculateDatesContract
    {
        DatesToDisplayEntity GetDatesToDisplay();
    }
}
