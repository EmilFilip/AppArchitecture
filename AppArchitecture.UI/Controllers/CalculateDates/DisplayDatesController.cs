using AutoMapper;
using AppArchitecture.BL.CalculateDates.Contracts;
using AppArchitecture.UI.Models.CalculateDates;
using System.Web.Mvc;

namespace AppArchitecture.UI.Controllers.CalculateDates
{
    public class DisplayDatesController : Controller
    {

        private readonly ICalculateDatesService _calculateDatesService;

        public DisplayDatesController(ICalculateDatesService calculateDatesService)
        {
            _calculateDatesService = calculateDatesService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var datesToDisplay = _calculateDatesService.GetDatesToDisplay();

            var model = Mapper.Map<DatesToDisplayViewModel>(datesToDisplay);
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CalculateDates(DatesToDisplayViewModel selectedDates)
        {
            var difference = _calculateDatesService.CalculateDaysDifference(selectedDates.DateFrom, selectedDates.DateTo);

            return View(model: difference);
        }
    }
}