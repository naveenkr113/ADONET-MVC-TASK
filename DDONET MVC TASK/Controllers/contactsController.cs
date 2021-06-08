using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDONET_MVC_TASK.DAL;
using DDONET_MVC_TASK.Models;

namespace DDONET_MVC_TASK.Controllers
{
    public class contactsController : Controller
    {
        contactsrepository rep = new contactsrepository();    
        // GET: contacts
        public ActionResult Index()
        {
            var aa= rep.Disp_Rec();
            return View(aa);
        }

        // GET: contacts/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: contacts/Create
        public ActionResult Create()
        {
            var aa = rep.prof();
            ViewBag.ProfessionList = new SelectList(aa, "prf_id", "prf_nam");
            return View();
            
        }

        // POST: contacts/Create
        [HttpPost]
        public ActionResult Create(Contacts cont)
        {
            try
            {
                rep.Create_Rec(cont);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: contacts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: contacts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: contacts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
