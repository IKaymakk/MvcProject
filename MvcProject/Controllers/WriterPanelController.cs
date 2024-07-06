using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeadings(string p)
        {
            Context c = new Context();
            p = (string)Session["WriterMail"];
            var writeridinfo=c.Writers.Where(x=>x.WriterMail==p).Select(y=>y.WriterID).FirstOrDefault();
            var values = hm.GetlistByWriter(writeridinfo);
            return View(values);
        }
       
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> ctg = (from x in cm.GetList()
                                        select new SelectListItem
                                        {
                                            Text = x.CategoryName,
                                            Value = x.CategoryID.ToString()
                                        }).ToList();
            ViewBag.ctg = ctg;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            p.HeadingStatus = true;
            p.HeadingDate = DateTime.Now;
            p.WriterID = 4;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeadings");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> cv = (from x in cm.GetList()
                                       select new SelectListItem
                                       {
                                           Text = x.CategoryName,
                                           Value = x.CategoryID.ToString()
                                       }).ToList();
            ViewBag.Category = cv;
            var value = hm.GetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeadings");
        }
        public ActionResult ChangeStatusHeading(int id)
        {
            hm.HeadingChangeStatus(id);
            return RedirectToAction("MyHeadings");
        }
    }
}