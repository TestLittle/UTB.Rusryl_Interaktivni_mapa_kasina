using Microsoft.AspNetCore.Mvc;
using UTB.Rusryl_Interaktivni_mapa_kasina.Application.Abstraction;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class LocationController : Controller
    {
        ILocationAppService _locationAppService;

        public LocationController(ILocationAppService locationAppService)
        {
            _locationAppService = locationAppService;
        }

        public IActionResult Index()
        {
            IList<Location> locations = _locationAppService.SelectAll();
            return View(locations);
        }
    }
}
