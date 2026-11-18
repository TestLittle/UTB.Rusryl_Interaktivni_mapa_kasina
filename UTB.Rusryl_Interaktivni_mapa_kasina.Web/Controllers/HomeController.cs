using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;
using UTB.Rusryl_Interaktivni_mapa_kasina.Web.Models;
using UTB.Rusryl_Interaktivni_mapa_kasina.Infrastructure.Database;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Web.Controllers
{
    public class HomeController : Controller
    {
        private CasinoMapDbContext context { get; set; }
        public HomeController(CasinoMapDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            List<MarkerModel> markers = new List<MarkerModel>();
            foreach(Location location in this.context.Locations)
            {
                markers.Add(new MarkerModel
                {
                    Title = location.Name,
                    Description = "",
                    Latititude = location.Latitude,
                    Longitude = location.Longitude
                });
            }
            ViewBag.Markers = JsonConvert.SerializeObject(markers);
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
