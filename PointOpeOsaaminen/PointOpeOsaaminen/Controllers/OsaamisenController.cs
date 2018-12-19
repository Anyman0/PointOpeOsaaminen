using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PointOpeOsaaminen.Models;
using PointOpeOsaaminen.ViewModel;

namespace PointOpeOsaaminen.Controllers
{
    public class OsaamisenController : Controller
    {
        private OpeOsaamisKantaEntities db = new OpeOsaamisKantaEntities();

        // GET: Osaamisen       
        public ActionResult Index()
        {
            var osaamiset = db.Osaaminen.Include(o => o.OpenOsaaminen);          
            return View(db.Osaaminen.ToList());
        }
        public ActionResult IndexKäyttäjät()
        {
            var osaamiset = db.Osaaminen.Include(o => o.OpenOsaaminen);
            return View(db.Osaaminen.ToList());
        }
        [HttpPost]       
        public ActionResult Index(string Skill, Osaaminen Osaam)
        {
            var osaamiset = db.Osaaminen.ToList().Where(o => o.OpenOsaaminen.StartsWith(Skill));
            return View(osaamiset);
        }
        // GET: Osaamisen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osaaminen osaamiset = db.Osaaminen.Find(id);
            if (osaamiset == null)
            {
                return HttpNotFound();
            }
            return View(osaamiset);
        }

        // GET: Osaamisen/Create
        public ActionResult Create()
        {
            //ViewBag.OpettajaID = new SelectList(db.Opettaja, "OpettajaID", "Etunimi");
            return View();
        }

        // POST: Osaamisen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        

        public ActionResult Create([Bind(Include = "OsaamisID,OpenOsaaminen,Kuvaus")] Osaaminen osaaminen)
        {
            if (ModelState.IsValid)
            {
                db.Osaaminen.Add(osaaminen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(osaaminen);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osaaminen osaaminen = db.Osaaminen.Find(id);
            if (osaaminen == null)
            {
                return HttpNotFound();
            }
            return View(osaaminen);
        }

        // POST: Osaamisen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        

        public ActionResult Edit([Bind(Include = "OsaamisID,OpenOsaaminen,Kuvaus")] Osaaminen osaaminen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osaaminen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(osaaminen);
        }

       

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osaaminen osaaminen = db.Osaaminen.Find(id);
            if (osaaminen == null)
            {
                return HttpNotFound();
            }
            return View(osaaminen);
        }

        // POST: Osaamisen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public ActionResult DeleteConfirmed(int id)
        {
            Osaaminen osaaminen = db.Osaaminen.Find(id);
            db.Osaaminen.Remove(osaaminen);
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
