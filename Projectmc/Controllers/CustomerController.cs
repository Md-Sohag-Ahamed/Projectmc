using Projectmc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projectmc.Controllers
{
    public class CustomerController : Controller
    {
        pharmacyEntities db = new pharmacyEntities();
        // GET: Customer
        public ActionResult Index()
        {
            return View(db.customers.ToList());
        }
        public ActionResult Details(int id)
        {
            var p = db.customers.Find(id);
            return View(p);
        }
        public ActionResult Create()
        {
            ViewBag.DrugId = new SelectList(db.Drugs.OrderBy(c => c.DrugName), "DrugId", "DrugName", "Select Drug");
            return View();
        }
        [HttpPost]
        public ActionResult Create(customer customer)
        {
            db.customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.DrugId = new SelectList(db.Drugs.OrderBy(d => d.DrugName), "DrugId", "DrugName", "Select Drug");
            var p = db.customers.Find(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(customer customer)
        {
            db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var p = db.customers.Find(id);
            db.customers.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}