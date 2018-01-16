﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            StartPaginaModel model = new StartPaginaModel();
            model.LoadAllTournaments();

            return View(model);
        }
    }
}