using MMU_MVC_CV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMU_MVC_CV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCVEntities db = new DbCVEntities();
        public ActionResult Index()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }
        public PartialViewResult SocialMedia()
        {
            var values = db.TblSocialMedia.ToList();
            return PartialView(values);
        }
        public PartialViewResult Experience()
        {
            var values = db.TblExperiences.ToList();
            return PartialView(values);
        }
        public PartialViewResult Education()
        {
            var values = db.TblEducation.ToList();
            return PartialView(values);
        }
        public PartialViewResult Skill()
        {
            var values = db.TblSkills.ToList();
            return PartialView(values);
        }
        public PartialViewResult Projects()
        {
            var values = db.TblInterests.ToList();
            return PartialView(values);
        }
        public PartialViewResult Certificates()
        {
            var values = db.TblCertificates.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(TblContact t)
        {
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblContact.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}