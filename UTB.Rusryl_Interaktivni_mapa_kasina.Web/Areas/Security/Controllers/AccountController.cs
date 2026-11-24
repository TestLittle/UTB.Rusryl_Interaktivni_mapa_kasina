using Microsoft.AspNetCore.Mvc;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Web.Areas.Security.Controllers
{
    [Area("Security")]
    public class AccountController : Controller
    {
        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
