using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcProject.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var count = hm.HeadingCount();
            ViewBag.HeadingCount = count;
            var values = hm.Getlist();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> cv = (from x in cm.GetList()
                                       select new SelectListItem
                                       {
                                           Text = x.CategoryName,
                                           Value = x.CategoryID.ToString()
                                       }).ToList();
            List<SelectListItem> wv = (from x in wm.GetList()
                                       select new SelectListItem
                                       {
                                           Text = x.WriterName +" "+ x.WriterSurname,
                                           Value = x.WriterID.ToString()
                                       }).ToList();
            ViewBag.ddlw = wv;
            ViewBag.ddlc = cv;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Now;
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }
        
    }
}