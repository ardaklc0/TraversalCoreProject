using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EFCommentDal());

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(EntityLayer.Concrete.Comment comment)
        {
            comment.CommentDate = DateTime.Now;
            comment.CommentState = true;
            commentManager.TAdd(comment);
            return RedirectToAction("Index", "Destination");
        }
    }
}
