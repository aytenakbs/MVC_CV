using MMU_MVC_CV.Models.Entity;
using MMU_MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMU_MVC_CV.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        DbCVEntities db = new DbCVEntities();
        GenericRepository<TblAbout> repo = new GenericRepository<TblAbout>();
        [HttpGet]
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(TblAbout p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Name = p.Name;
            t.Description = p.Description;
            t.Surname = p.Surname;
            t.Address = p.Address;
            t.PhoneNumber = p.PhoneNumber;
            t.Email = p.Email;
            t.Image = p.Image;
            repo.TUpdate(t);
            return RedirectToAction("index");
        }
    }
}