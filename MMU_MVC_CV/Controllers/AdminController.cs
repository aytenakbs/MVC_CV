using MMU_MVC_CV.Models.Entity;
using MMU_MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMU_MVC_CV.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TblAdmin> repo=new GenericRepository<TblAdmin>();
        public ActionResult Index()
        {
            var list=repo.List();
            return View(list);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(TblAdmin tblAdmin)
        {
            repo.TAdd(tblAdmin);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {

            TblAdmin t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(TblAdmin p)
        {
            TblAdmin t = repo.Find(x => x.ID == p.ID);
            t.UserName = p.UserName;
            t.Password = p.Password;
            repo.TUpdate(t);
            return RedirectToAction("index");
        }
    }
}