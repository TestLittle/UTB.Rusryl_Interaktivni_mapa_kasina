using Microsoft.AspNetCore.Mvc;
using UTB.Rusryl_Interaktivni_mapa_kasina.Application.Abstraction;
using UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class CommentController : Controller
    {
        ICommentAppService _commentAppService;

        public CommentController(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;
        }

        public IActionResult CommentManagement()
        {
            IList<Comment> comments = _commentAppService.SelectAll();
            return View(comments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            _commentAppService.Create(comment);
            return RedirectToAction(nameof(CommentController.CommentManagement));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            bool deleted = _commentAppService.Delete(id);

            if (deleted)
            {
                return RedirectToAction(nameof(CommentController.CommentManagement));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
