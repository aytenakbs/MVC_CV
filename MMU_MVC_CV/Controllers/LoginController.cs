using MMU_MVC_CV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MMU_MVC_CV.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin t)
        {
            DbCVEntities db=new DbCVEntities();
            var info = db.TblAdmin.FirstOrDefault(x => x.UserName == t.UserName && x.Password == t.Password);
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.UserName, false);
                Session["UserName"]=info.UserName.ToString();
                return RedirectToAction("Index","About");
            }
            else
            {
                return RedirectToAction("index","Login");
            }
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("index","Login");
        }
    }
}