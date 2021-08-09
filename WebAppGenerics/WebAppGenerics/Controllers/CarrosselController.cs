using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppGenerics.Controllers
{
    public class CarrosselController : Controller
    {
        // GET: Carrossel
        public ActionResult Index()
        {
            return View();
        }
    }
}