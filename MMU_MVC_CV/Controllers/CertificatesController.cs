using MMU_MVC_CV.Models.Entity;
using MMU_MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMU_MVC_CV.Controllers
{
    public class CertificatesController : Controller
    {
        // GET: Certificates
        GenericRepository<TblCertificates> repo = new GenericRepository<TblCertificates>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        public ActionResult DeleteCertificate(int id)
        {
            var value = repo.Find(x => x.ID == id);
            repo.TDelete(value);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult UpdateCertificate(int id)
        {
            var value = repo.Find(x => x.ID == id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCertificate(TblCertificates t)
        {
            var value = repo.Find(x => x.ID == t.ID);
            value.Description = t.Description;
            value.Date = t.Date;
            repo.TUpdate(value);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCertificate(TblCertificates t)
        {
            repo.TAdd(t);
            return RedirectToAction("index");
        }
    }
}