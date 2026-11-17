using Microsoft.AspNetCore.Mvc;
using UTB.Rusryl_Interaktivni_mapa_kasina.Application.Abstraction;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class LocationKindController : Controller
    {
        ILocationKindAppService _locationKindAppService;

        public LocationKindController(ILocationKindAppService locationKindAppService)
        {
            _locationKindAppService = locationKindAppService;
        }

        public IActionResult LocationKindManagement()
        {
            IList<LocationKind> locationKinds = _locationKindAppService.SelectAll();
            return View(locationKinds);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(LocationKind locationKind)
        {
            _locationKindAppService.Create(locationKind);
            return RedirectToAction(nameof(LocationKindController.LocationKindManagement));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            bool deleted = _locationKindAppService.Delete(id);

            if (deleted)
            {
                return RedirectToAction(nameof(LocationKindController.LocationKindManagement));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
