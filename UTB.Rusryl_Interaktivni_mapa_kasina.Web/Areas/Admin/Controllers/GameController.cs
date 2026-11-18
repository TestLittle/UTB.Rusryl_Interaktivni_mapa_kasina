using Microsoft.AspNetCore.Mvc;
using UTB.Rusryl_Interaktivni_mapa_kasina.Application.Abstraction;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class GameController : Controller
    {
        IGameAppService _gameAppService;

        public GameController(IGameAppService gameAppService)
        {
            _gameAppService = gameAppService;
        }

        public IActionResult GameManagement()
        {
            IList<Game> games = _gameAppService.SelectAll().ToList();
            return View(games);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Game game)
        {
            _gameAppService.Create(game);
            return RedirectToAction(nameof(GameController.GameManagement));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            bool deleted = _gameAppService.Delete(id);
            if (deleted)
            {
                return RedirectToAction(nameof(GameController.GameManagement));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
