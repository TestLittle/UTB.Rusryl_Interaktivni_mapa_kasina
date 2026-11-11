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

        public IActionResult PinManagement()
        {
            IList<Location> locations = _locationAppService.SelectAll();
            return View(locations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Location location)
        {
            _locationAppService.Create(location);
            return RedirectToAction(nameof(LocationController.PinManagement));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            bool deleted = _locationAppService.Delete(id);

            if (deleted)
            {
                return RedirectToAction(nameof(LocationController.PinManagement));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(int id)
        {
            _locationAppService.Edit(id);
            return RedirectToAction(nameof(LocationController.PinManagement));
        }
    }
}
