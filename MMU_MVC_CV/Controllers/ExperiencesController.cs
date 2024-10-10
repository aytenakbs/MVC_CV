using MMU_MVC_CV.Models.Entity;
using MMU_MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMU_MVC_CV.Controllers
{
    public class ExperiencesController : Controller
    {
        // GET: Experiences
        GenericRepository<TblExperiences> repo = new GenericRepository<TblExperiences>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(TblExperiences tblExperiences)
        {
            repo.TAdd(tblExperiences);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id)
        {
            TblExperiences t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {

            TblExperiences t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult UpdateExperience(TblExperiences p)
        {
            TblExperiences t = repo.Find(x => x.ID == p.ID);
            t.Title = p.Title;
            t.SubTitle = p.SubTitle;
            t.Date = p.Date;
            t.Description = p.Description;
            repo.TUpdate(t);
            return RedirectToAction("index");
        }

    }
}