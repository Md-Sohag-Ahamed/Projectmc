using Projectmc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projectmc.Controllers
{
    public class DrugController : Controller
    {
        pharmacyEntities db = new pharmacyEntities();
        // GET: Drug
        public ActionResult Index()
        {
            return View(db.Drugs.ToList());
        }
        public ActionResult Details(int id)
        {
            var d = db.Drugs.Find(id);
            return View(d);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Drug drug)
        {
            db.Drugs.Add(drug);
            db.SaveChanges();
         return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            var d = db.Drugs.Find(id);
            return View(d);
        } 
        [HttpPost]
        public ActionResult Edit(Drug drug)
        {
            db.Entry(drug).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var d = db.Drugs.Find(id);
            db.Drugs.Remove(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}