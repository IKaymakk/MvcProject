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
using PagedList;
using PagedList.Mvc;
namespace MvcProject.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index(int p=1)
        {
            var count = hm.HeadingCount();
            ViewBag.HeadingCount = count;
            var values = hm.Getlist().ToPagedList(p,5);
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
                                           Text = x.WriterName + " " + x.WriterSurname,
                                           Value = x.WriterID.ToString()
                                       }).ToList();
            ViewBag.ddlw = wv;
            ViewBag.ddlc = cv;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingStatus = true;
            p.HeadingDate = DateTime.Now;
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
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
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }
        public ActionResult ChangeStatusHeading(int id)
        {
            hm.HeadingChangeStatus(id);
            return RedirectToAction("Index");
        }
    }
}