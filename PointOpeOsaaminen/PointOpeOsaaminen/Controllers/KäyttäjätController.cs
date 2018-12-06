using PointOpeOsaaminen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PointOpeOsaaminen.Controllers
{
    public class KäyttäjätController : Controller
    {
        // GET: Käyttäjät
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorise(Käyttäjät u)
        {
            if (ModelState.IsValid)
            {
                using (OpeOsaamisKantaEntities db = new OpeOsaamisKantaEntities())
                {

                    var v = db.Käyttäjät.Where(a => a.KäyttäjäTunnus.Equals(u.KäyttäjäTunnus) && a.Salasana.Equals(u.Salasana)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedKäyttäjäID"] = v.KäyttäjäID.ToString();
                        Session["LogedKäyttäjäSalasana"] = v.Salasana.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        u.Loginerror = "Väärä Käyttäjä tai salasana";
                        return View("Index", u);

                    }
                }
            }
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Käyttäjät");
        }
    }
}
    
