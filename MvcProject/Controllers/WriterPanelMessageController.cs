﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator mv = new MessageValidator();
        ContactManager cm = new ContactManager(new EfContactDal());
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetList(p);
            return View(messagelist);
        }
        public PartialViewResult MessageListMenu()
        {
            var sayi3 = mm.GetMessageCount();
            ViewBag.Count4 = sayi3;
            var sayi = cm.GetTrashBoxCount();
            ViewBag.Count3 = sayi;
            ViewBag.Count = sayi;
            return PartialView();
        }
        public ActionResult SendBox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListSendBox(p);
            return View(messagelist);
        }
        public ActionResult GetMessageDetails(int id)
        {
            var values = mm.GetMessage(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult result = mv.Validate(p);
            if (result.IsValid)
            {
                string mail = (string)Session["WriterMail"];
                p.SenderMail = mail;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }
    }
}