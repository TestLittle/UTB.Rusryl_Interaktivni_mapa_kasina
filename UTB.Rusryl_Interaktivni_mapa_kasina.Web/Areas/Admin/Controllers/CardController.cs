using Microsoft.AspNetCore.Mvc;
using UTB.Rusryl_Interaktivni_mapa_kasina.Application.Abstraction;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class CardController : Controller
    {
        ICardAppService _cardAppService;

        public CardController(ICardAppService cardAppService)
        {
            _cardAppService = cardAppService;
        }

        public IActionResult CardManagement()
        {
            IList<Card> cards = _cardAppService.SelectAll().ToList();
            return View(cards);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Card card)
        {
            if (ModelState.IsValid)
            {
                _cardAppService.Create(card);
                return RedirectToAction(nameof(CardController.CardManagement));
            }
            
            return View(card);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            bool deleted = _cardAppService.Delete(id);
            if (deleted)
            {
                return RedirectToAction(nameof(CardController.CardManagement));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
