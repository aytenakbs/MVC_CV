using MMU_MVC_CV.Models.Entity;
using MMU_MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMU_MVC_CV.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        DbCVEntities db = new DbCVEntities();
        GenericRepository<TblSkills> repo = new GenericRepository<TblSkills>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSkill(TblSkills p)
        {
            repo.TAdd(p);
            return RedirectToAction("index");
        }
        public ActionResult DeleteSkill(int id)
        {
            var skill = repo.TGet(id);
            repo.TDelete(skill);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            TblSkills t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult UpdateSkill(TblSkills t)
        {
            var value = repo.Find(x => x.ID == t.ID);
            value.Skill = t.Skill;
            value.Ratio = t.Ratio;
            value.Description = t.Description;
            repo.TUpdate(value);
            return RedirectToAction("index");
        }
    }
}