using Projectmc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projectmc.Controllers
{
    public class PharmacyController : Controller
    {
        pharmacyEntities db = new pharmacyEntities();
        // GET: Pharmacy
        public ActionResult Index()
        {
            return View(db.pharmacies.OrderBy(p => p.PharmacyName).ToList());
        }
        public ActionResult Details(int id)
        {
            var p = db.pharmacies.Find(id);
            return View(p);
        }
        public ActionResult Create()
        {
            ViewBag.DrugId = new SelectList(db.Drugs.OrderBy(c => c.DrugName), "DrugId", "DrugName", "Select Drug");
            return View();
        }
        [HttpPost]
        public ActionResult Create(pharmacy pharmacy)
        {
            db.pharmacies.Add(pharmacy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.DrugId = new SelectList(db.Drugs.OrderBy(d => d.DrugName), "DrugId", "DrugName", "Select Drug");
            var p = db.pharmacies.Find(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(pharmacy pharmacy)
        {
            db.Entry(pharmacy).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var p = db.pharmacies.Find(id);
            db.pharmacies.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}