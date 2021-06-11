using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDONET_MVC_TASK.DAL;
using DDONET_MVC_TASK.Models;
using PagedList;
using PagedList.Mvc;
using System.Web.Security;

namespace DDONET_MVC_TASK.Controllers
{
    public class contactsController : Controller
    {
        contactsrepository rep = new contactsrepository();
        /* GET: contacts
        public ActionResult Index(int? page)
        {
            var aa= rep.Disp_Rec();
            return View(aa.ToList().ToPagedList(page ?? 1, 5));
        } */
        
        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult Index(string searchBy, string search, int? page)
        {
            if (searchBy == "fst_nam")
            {
                var aa = rep.Disp_Rec_filtbynam(search);
                return View(aa.ToList().ToPagedList(page ?? 1, 5));

            }
            else if (searchBy == "prf_nam")
            {
                var aa = rep.Disp_Rec_filtbyprfnam(search);
                return View(aa.ToList().ToPagedList(page ?? 1, 5));
            }
            else
            {
                var aa = rep.Disp_Rec();
                return View(aa.ToList().ToPagedList(page ?? 1, 5));
            }
        }
        // GET: contacts/Details/5

        public ActionResult Details(int id)
        {
            var aaa = rep.Detail_Rec(id);
            return View(aaa);
        }

        // GET: contacts/Create

        [Authorize(Roles = "a")]

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
                var aa = rep.prof();
                ViewBag.ProfessionList = new SelectList(aa, "prf_id", "prf_nam");
                return View();
            }
 
        }

        // GET: contacts/Edit/5

        public ActionResult Edit(int id)
        {
           var aaa= rep.Find_Rec(id);    
            var aa = rep.prof();
            ViewBag.ProfessionList = new SelectList(aa, "prf_id", "prf_nam");
            return View(aaa);
        }

        // POST: contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(Contacts cont)
        {
            try
            {

                rep.Update_Rec(cont);

                return RedirectToAction("Index");
            }
            catch
            {
                var aa = rep.prof();
                ViewBag.ProfessionList = new SelectList(aa, "prf_id", "prf_nam");
                return View();
            }

        }

        // GET: contacts/Delete/5
        public ActionResult Delete(int id)
        {
            var aaa = rep.Detail_Rec(id);
            return View(aaa);
        }

        // POST: contacts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                rep.Delete_rec(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login() { 
            return View();
        }
        [HttpPost][AllowAnonymous]
        public ActionResult Login(int id, string pwd)
        {
            var aa = rep.login(id, pwd);
            if (aa == 1)
            {
                FormsAuthentication.SetAuthCookie(pwd,false);
                return RedirectToAction("index", "contacts");
             
            }
            else{
                TempData["msg"] = "username or password invalid";
                return View();
            }
        }
        
        public ActionResult Logout()
        {
           FormsAuthentication.SignOut();
            return RedirectToAction("Login", "contacts");
        }
    }
}
