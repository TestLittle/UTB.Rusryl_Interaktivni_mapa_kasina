using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UTB.Rusryl_Interaktivni_mapa_kasina.Web.Models;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
