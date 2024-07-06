using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        IContentManager cm = new IContentManager(new EfContentDal());
        public PartialViewResult Index(int id = 0)
        {
            var value = cm.GetlistByHeadingID(id);
            return PartialView(value);
        }
        public ActionResult Headings()
        {
            var value = hm.Getlist();
            return View(value);
        }
    }
}