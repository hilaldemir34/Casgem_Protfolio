using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Casgem_Portfolio.Models.Entities;


namespace Casgem_Portfolio.Controllers
{
    public class LoginController : Controller
    {
        CasgemPortfolioDBEntities db = new CasgemPortfolioDBEntities();
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin admin)
        {
            var values = db.TblAdmin.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["UserName"] = values.UserName.ToString();
                return RedirectToAction("Index", "Portfolio");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}