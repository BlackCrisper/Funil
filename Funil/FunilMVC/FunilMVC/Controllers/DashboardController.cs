using FunilMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FunilMVC.Controllers
{
    public class DashboardController : Controller
    {

        BDFunilEntities1 bd = new BDFunilEntities1();

        // GET: Dashboard
        public ActionResult Index()
        {
            return View(bd.DashBoard.ToList());
        }
    }
}