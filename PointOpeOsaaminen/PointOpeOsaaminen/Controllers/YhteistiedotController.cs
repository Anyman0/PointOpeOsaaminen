using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PointOpeOsaaminen.Models;

namespace PointOpeOsaaminen.Controllers
{
    public class YhteistiedotController : Controller
    {
        private OpeOsaamisKantaEntities db = new OpeOsaamisKantaEntities();

        // GET: Yhteistiedot
        public ActionResult Index()
        {
            return View(db.Yhteistiedot.ToList());
        }

        // GET: Yhteistiedot/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yhteistiedot yhteistiedot = db.Yhteistiedot.Find(id);
            if (yhteistiedot == null)
            {
                return HttpNotFound();
            }
            return View(yhteistiedot);
        }

        // GET: Yhteistiedot/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yhteistiedot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OpettajaID,Sukunimi,Etunimi,Sähköposti,PuhelinNumero")] Yhteistiedot yhteistiedot)
        {
            if (ModelState.IsValid)
            {
                db.Yhteistiedot.Add(yhteistiedot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yhteistiedot);
        }

        // GET: Yhteistiedot/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yhteistiedot yhteistiedot = db.Yhteistiedot.Find(id);
            if (yhteistiedot == null)
            {
                return HttpNotFound();
            }
            return View(yhteistiedot);
        }

        // POST: Yhteistiedot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OpettajaID,Sukunimi,Etunimi,Sähköposti,PuhelinNumero")] Yhteistiedot yhteistiedot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yhteistiedot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yhteistiedot);
        }

        // GET: Yhteistiedot/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yhteistiedot yhteistiedot = db.Yhteistiedot.Find(id);
            if (yhteistiedot == null)
            {
                return HttpNotFound();
            }
            return View(yhteistiedot);
        }

        // POST: Yhteistiedot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yhteistiedot yhteistiedot = db.Yhteistiedot.Find(id);
            db.Yhteistiedot.Remove(yhteistiedot);
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
