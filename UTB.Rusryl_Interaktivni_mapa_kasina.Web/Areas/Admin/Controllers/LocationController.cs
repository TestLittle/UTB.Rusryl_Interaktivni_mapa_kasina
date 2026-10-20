using Microsoft.AspNetCore.Mvc;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
