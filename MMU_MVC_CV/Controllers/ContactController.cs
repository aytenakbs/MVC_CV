using MMU_MVC_CV.Models.Entity;
using MMU_MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MMU_MVC_CV.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        GenericRepository<TblContact> repo = new GenericRepository<TblContact>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
    }
}