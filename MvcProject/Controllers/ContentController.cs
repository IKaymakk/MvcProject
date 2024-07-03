using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ContentController : Controller
    {
        IContentManager cm = new IContentManager(new EfContentDal());
        CommentManager com = new CommentManager(new EfCommentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id)
        {
            var values = cm.GetlistByHeadingID(id);
            return View(values);
        }
        public PartialViewResult ContentComments(int id)
        {
            var comments = com.CommentListByHeadingID(id);
            return PartialView(comments);
        }
    }
}