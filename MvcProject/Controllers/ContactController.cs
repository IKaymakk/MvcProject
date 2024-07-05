using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcProject.Controllers
{
    public class ContactController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        Context ctx = new Context();
        public ActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }
        public ActionResult GetContactDetails(int id)
        {
            var values = cm.GetContact(id);
            return View(values);
        }
        public PartialViewResult MessageListMenu()
        {
            var sayi3 = mm.GetMessageCount();
            ViewBag.Count4 = sayi3;
            var sayi = cm.GetTrashBoxCount();
            ViewBag.Count3 = sayi;
            var sayı2 = mm.GetMessageCount();
            var sayı = cm.GetContactCount();
            ViewBag.Count = sayı;
            ViewBag.Count2 = sayı2;
            return PartialView();
        }
        public ActionResult ContactChangeStatu(int id)
        {
            cm.ContactStatu(id);
            return RedirectToAction("Index");
        }
        public ActionResult ContactChangeStatuTrash(int id)
        {
            cm.ContactStatu(id);
            return RedirectToAction("ContactTrashBox");
        }
        public ActionResult ContactTrashBox()
        {
         
            var value = cm.GetLTrashist();
            return View(value);
        }
    }
}