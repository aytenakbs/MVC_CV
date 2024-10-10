using MMU_MVC_CV.Models.Entity;
using MMU_MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMU_MVC_CV.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        DbCVEntities db = new DbCVEntities();
        GenericRepository<TblEducation> repo = new GenericRepository<TblEducation>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(TblEducation p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repo.TAdd(p);
            return RedirectToAction("index");
        }
        public ActionResult DeleteEducation(int id)
        {
            var value = repo.Find(x => x.ID == id);
            repo.TDelete(value);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var value = repo.Find(x => x.ID == id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEducation(TblEducation t)
        {
            var value = repo.Find(x => x.ID == t.ID);
            value.Title = t.Title;
            value.SubTitle1 = t.SubTitle1;
            value.SubTitle2 = t.SubTitle2;
            value.Date = t.Date;
            repo.TUpdate(value);
            return RedirectToAction("index");
        }

    }
}