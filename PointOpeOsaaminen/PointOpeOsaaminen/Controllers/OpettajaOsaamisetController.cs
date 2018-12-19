using PointOpeOsaaminen.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PointOpeOsaaminen.Controllers
{
    public class OpettajaOsaamisetController : Controller
    {
        private OpeOsaamisKantaEntities db = new OpeOsaamisKantaEntities();
        // GET: OpettajaOsaamiset
        public ActionResult Index()
        {
            var opettajaOsaaminen = db.OpettajaOsaaminen.Include(o => o.Opettaja).Include(o => o.Osaaminen);

            return View(opettajaOsaaminen.ToList());
        }
        [HttpPost]
        public ActionResult Index(string Etunimi, Opettaja Ope)
        {
            var opettaja = db.OpettajaOsaaminen.ToList().Where(o => o.Opettaja.Etunimi.StartsWith(Etunimi));
            return View(opettaja);
        }
      
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpettajaOsaaminen opettajaOsaaminen = db.OpettajaOsaaminen.Find(id);
            if (opettajaOsaaminen == null)
            {
                return HttpNotFound();
            }
            return View(opettajaOsaaminen);
        }

        // GET: OpettajaOsaamiset/Create
        public ActionResult Create()
        {
            ViewBag.OpettajaID = new SelectList(db.Opettaja, "OpettajaID", "Etunimi");
            ViewBag.OsaamisID = new SelectList(db.Osaaminen, "OsaamisID", "OpenOsaaminen");
            return View();
        }

        // POST: OpettajaOsaamiset/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OpettajaOsaamisID,OpettajaID,OsaamisID,OsaamisenKuvaus")] OpettajaOsaaminen opettajaOsaaminen)
        {
            if (ModelState.IsValid)
            {

                db.OpettajaOsaaminen.Add(opettajaOsaaminen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.OpettajaID = new SelectList(db.Opettaja, "OpettajaID", "Etunimi", opettajaOsaaminen.OpettajaID);
            ViewBag.OsaamisID = new SelectList(db.Osaaminen, "OsaamisID", "OpenOsaaminen", opettajaOsaaminen.OsaamisID);
            return View(opettajaOsaaminen);
        }

        // GET: OpettajaOsaamiset/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpettajaOsaaminen opettajaOsaaminen = db.OpettajaOsaaminen.Find(id);
            if (opettajaOsaaminen == null)
            {
                return HttpNotFound();
            }
            ViewBag.OpettajaID = new SelectList(db.Opettaja, "OpettajaID", "Etunimi", opettajaOsaaminen.OpettajaID);
            ViewBag.OsaamisID = new SelectList(db.Osaaminen, "OsaamisID", "OpenOsaaminen", opettajaOsaaminen.OsaamisID);
            return View(opettajaOsaaminen);
        }

        // POST: OpettajaOsaamiset/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OpettajaOsaamisID,OpettajaID,OsaamisID,OsaamisenKuvaus")] OpettajaOsaaminen opettajaOsaaminen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opettajaOsaaminen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OpettajaID = new SelectList(db.Opettaja, "OpettajaID", "Etunimi", opettajaOsaaminen.OpettajaID);
            ViewBag.OsaamisID = new SelectList(db.Osaaminen, "OsaamisID", "OpenOsaaminen", opettajaOsaaminen.OsaamisID);
            return View(opettajaOsaaminen);
        }

        // GET: OpettajaOsaamiset/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpettajaOsaaminen opettajaOsaaminen = db.OpettajaOsaaminen.Find(id);
            if (opettajaOsaaminen == null)
            {
                return HttpNotFound();
            }
            return View(opettajaOsaaminen);
        }

        // POST: OpettajaOsaamiset/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OpettajaOsaaminen opettajaOsaaminen = db.OpettajaOsaaminen.Find(id);
            db.OpettajaOsaaminen.Remove(opettajaOsaaminen);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}