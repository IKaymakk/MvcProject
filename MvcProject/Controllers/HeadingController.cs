﻿using BusinessLayer.Concrete;
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
using Newtonsoft.Json.Linq;

namespace MvcProject.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index(string a, int p = 1)
        {
            var count = hm.HeadingCount();
            ViewBag.HeadingCount = count;
            if (a == null)
            {
                var values2 = hm.Getlist().ToPagedList(p, 10);
                return View(values2);
            }
            else
            {
                var values = hm.SearchingList(a).ToPagedList(p, 10);
                return View(values);
            }
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
        public ActionResult HeadingReportTable()
        {
            var values = hm.Getlist();
            return View(values);
        }
        public ActionResult DeleteHeading(int id)
        {
            var head = hm.GetById(id);
            hm.HeadingDelete(head);
            return RedirectToAction("Index");
        }
    }
}