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
        int writeridinfo;
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        IContentManager ıcm = new IContentManager(new EfContentDal());
        Context c = new Context();
        int id;


        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeadings(string p)
        {
            var count = hm.HeadingCount();
            ViewBag.Count = count;
            p = (string)Session["WriterMail"];
            writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
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
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.d = writeridinfo;
            p.HeadingStatus = true;
            p.HeadingDate = DateTime.Now;
            p.WriterID = writeridinfo;
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
        public ActionResult AllHeadings()
        {
            var count = hm.HeadingCount();
            ViewBag.Count = count;
            var values = hm.Getlist();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = writeridinfo;
            p.ContentDate = DateTime.Now;
            p.ContentStatus = true;
            ıcm.ContentAdd(p);
            return RedirectToAction("MyHeadings");
        }
        public ActionResult ToDoList()
        {
            return View();
        }
    }
}