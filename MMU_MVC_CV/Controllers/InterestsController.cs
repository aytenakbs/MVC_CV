using MMU_MVC_CV.Models.Entity;
using MMU_MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMU_MVC_CV.Controllers
{
    public class InterestsController : Controller
    {
        // GET: Interests
        GenericRepository<TblInterests> repo = new GenericRepository<TblInterests>();

        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(TblInterests p)
        {
            repo.TAdd(p);
            return RedirectToAction("index");
        }
        public ActionResult DeleteProject(int id)
        {
            var value = repo.Find(x => x.ID == id);
            repo.TDelete(value);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var value = repo.Find(x => x.ID == id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProject(TblInterests p)
        {
            var values = repo.Find(x => x.ID == p.ID);
            values.Description1 = p.Description1;
            values.Description2 = p.Description2;
            repo.TUpdate(values);
            return RedirectToAction("index");
        }

    }
}