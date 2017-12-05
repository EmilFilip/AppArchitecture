using AutoMapper;
using AppArchitecture.BL.CalculateDates.Entities;
using AppArchitecture.UI.Models.CalculateDates;

namespace AppArchitecture.UI.App_Start
{
    public class AutoMapperConfig
    {
        public static bool _initialized;
        public static void ConfigureAutoMapper()
        {
            if (_initialized)
            {
                return;
            }

            Mapper.Initialize(cfg => {
                cfg.CreateMap<DatesToDisplayEntity, DatesToDisplayViewModel>();
                cfg.CreateMap<DatesToDisplayViewModel, DatesToDisplayEntity>();
            });

            _initialized = true;
        }
    }
}