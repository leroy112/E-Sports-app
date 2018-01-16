using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class MyTeamController : Controller
    {
        // GET: MyTeam
        public ActionResult Index()
        {
            MyTeamModel model = new MyTeamModel();
            model.LoadAllTeams();
            model.LoadMyTeams();
            return View(model);
        }

        public RedirectToRouteResult AddTeam()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}