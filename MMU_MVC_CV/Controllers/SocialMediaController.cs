using MMU_MVC_CV.Models.Entity;
using MMU_MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMU_MVC_CV.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        GenericRepository<TblSocialMedia> repo = new GenericRepository<TblSocialMedia>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedia p)
        {

            repo.TAdd(p);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = repo.Find(x => x.ID == id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedia p)
        {
            var value = repo.Find(x => x.ID == p.ID);
            value.Account = p.Account;
            value.Icon = p.Icon;
            value.Link = p.Link;
            value.Status = true;
            repo.TUpdate(value);
            return RedirectToAction("index");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var value = repo.Find(x => x.ID == id);
            value.Status = false;
            return RedirectToAction("index");
        }
    }
}