using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        public ActionResult Inbox()
        {
            var messagelist = mm.GetList();
            return View(messagelist);
        }
        public ActionResult SendBox()
        {
            var messagelist = mm.GetListSendBox();
            return View(messagelist);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            return RedirectToAction("Inbox");
        }
        public ActionResult GetMessageDetails(int id)
        {
            var values = mm.GetMessage(id);
            return View(values);
        }
    }
}