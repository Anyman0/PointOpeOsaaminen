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
    public class OpettajatController : Controller
    {
        private OpeOsaamisKantaEntities db = new OpeOsaamisKantaEntities();

        // GET: Opettajat
        public ActionResult Index()
        {
            var opettaja = db.Opettaja.Include(o => o.Sukunimi);

            return View(db.Opettaja.ToList());
        }
        public ActionResult IndexKäyttäjät()
        {
            var opettaja = db.Opettaja.Include(o => o.Sukunimi);

            return View(db.Opettaja.ToList());
        }
        [HttpPost]
        public ActionResult Index(string Sukunimi, Opettaja Ope)
        {
            var opettaja = db.Opettaja.ToList().Where(o => o.Sukunimi.StartsWith(Sukunimi));
            return View(opettaja);
        }
        // GET: Opettajat/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Opettaja opettaja = db.Opettaja.Find(id);
            OpettajaOsaaminenViewModel yhdistys = new OpettajaOsaaminenViewModel();
            List<Osaaminen> joskus = new List<Osaaminen>();

            var hh = db.OpettajaOsaaminen.Where(o => o.OpettajaID == opettaja.OpettajaID);
            var oo = hh.ToList();
            foreach (OpettajaOsaaminen opeOsaa in oo)
            {
                yhdistys.OpettajaID = opeOsaa.OpettajaID;
                yhdistys.OsaamisID = opeOsaa.OsaamisID;
                //opettajaOsaaminen.OpettajaOsaamisID = opeOsaa.OpettajaOsaamisID;
                //opettajaOsaaminen.OsaamisenKuvaus = opeOsaa.OsaamisenKuvaus;

                var ee = db.Osaaminen.Find(yhdistys.OsaamisID);
                joskus.Add(ee);
            }

            OpettajaOsaaminenViewModel viewModel = new OpettajaOsaaminenViewModel(opettaja,
            joskus);

            if (opettaja == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // GET: Opettajat/Create
        public ActionResult Create()
        {
            //return View();
            var opettaja = new Opettaja();
            var kaikkiOsaamiset = from t in db.Osaaminen
                                  select t;
            OpettajaOsaaminenViewModel viewModel = new OpettajaOsaaminenViewModel(opettaja,
                db.Osaaminen.ToList());

            return View(viewModel);
        }

        // POST: Opettajat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OpettajaOsaaminenViewModel opettajaOsaaminenViewModel)
        {
            Opettaja opettaja1 = new Opettaja();
            OpettajaOsaaminen opettajaOsaaminen1 = new OpettajaOsaaminen();
           
            opettaja1.Etunimi = opettajaOsaaminenViewModel.Etunimi;
            opettaja1.Sukunimi = opettajaOsaaminenViewModel.Sukunimi;
            opettaja1.Sähköposti = opettajaOsaaminenViewModel.Sähköposti;
            opettaja1.Henkilönumero = opettajaOsaaminenViewModel.Henkilönumero;
            opettaja1.Yksikkö = opettajaOsaaminenViewModel.Yksikkö;
            opettaja1.Toimenkuva = opettajaOsaaminenViewModel.Toimenkuva;

            db.Opettaja.Add(opettaja1);
            db.SaveChanges();

          
            if (opettajaOsaaminenViewModel.ValitutOsaamiset != null)
            {
                foreach (var osaamisID in opettajaOsaaminenViewModel.ValitutOsaamiset)
                {
                    OpettajaOsaaminen opettajaOsaaminen = new OpettajaOsaaminen();
                    opettajaOsaaminen.OsaamisID = osaamisID;
                    
                    int taasOpeID = (
                       from p in db.Opettaja
                       orderby p.OpettajaID descending
                       select p.OpettajaID
                   ).Take(1).SingleOrDefault();

                    opettajaOsaaminen.OpettajaID = taasOpeID;

                    db.OpettajaOsaaminen.Add(opettajaOsaaminen);
                    db.SaveChanges();
                }
            }
           
            return RedirectToAction("Index");
        }

        // GET: Opettajat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opettaja opettaja = db.Opettaja.Find(id);
            if (opettaja == null)
            {
                return HttpNotFound();
            }
            return View(opettaja);
        }

        // POST: Opettajat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OpettajaID,Etunimi,Sukunimi,Sähköposti,Henkilönumero,Yksikkö,Toimenkuva")] Opettaja opettaja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opettaja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opettaja);
        }

        // GET: Opettajat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opettaja opettaja = db.Opettaja.Find(id);
            if (opettaja == null)
            {
                return HttpNotFound();
            }
            return View(opettaja);
        }

        // POST: Opettajat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opettaja opettaja = db.Opettaja.Find(id);
            db.Opettaja.Remove(opettaja);
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
