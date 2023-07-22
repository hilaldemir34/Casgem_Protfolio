using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Cagem_Portfolio.Controllers
{
    public class ReferanceController : Controller
    {
        CasgemPortfolioDBEntities db = new CasgemPortfolioDBEntities();
        // GET: Referance
        public ActionResult Index()
        {
            var values = db.TblReferance.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddReferance()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddReferance(TblReferance p)
        {
            db.TblReferance.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DeleteReferance(int id)
        {
            var value = db.TblReferance.Find(id);
            db.TblReferance.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateReferance(int id)
        {
            var value = db.TblReferance.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateReferance(TblReferance p)
        {
            var value = db.TblReferance.Find(p.ReferanceID);
            value.NameSurname = p.NameSurname;
            value.Mail = p.Mail;
            value.Phone = p.Phone;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}