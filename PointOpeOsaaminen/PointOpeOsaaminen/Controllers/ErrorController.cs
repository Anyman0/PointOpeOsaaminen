using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PointOpeOsaaminen.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult ErrorView()
        {
            return View();
        }
    }
}