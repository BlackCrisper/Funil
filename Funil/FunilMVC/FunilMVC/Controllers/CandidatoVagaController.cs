﻿using FunilMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FunilMVC.Controllers
{
    public class CandidatoVagaController : Controller
    {
        BDFunilEntities1 bd = new BDFunilEntities1();
        // GET: CandidatoVaga
        public ActionResult Index()
        {

            return View(bd.CANDIDATOVAGA.ToList());
        }
      

    }
}