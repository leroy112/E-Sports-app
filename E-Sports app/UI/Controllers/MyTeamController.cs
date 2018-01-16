using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;
using Middletier;

namespace UI.Controllers
{
    public class MyTeamController : Controller
    {

        User LoggedInUser = new User("User1", Account_Type.Player, "Leroy", "Van de Ven", "84745834", "Vi0llet", "Leroylyon@hotmail.com");

        // GET: MyTeam
        public ActionResult Index()
        {
            MyTeamModel model = new MyTeamModel();
            model.LoadAllTeams();
            model.LoadMyTeams(LoggedInUser);
            model.FillOtherTeams();
            return View(model);
        }

        public RedirectToRouteResult AddTeam(Team team)
        {
            LoggedInUser.AddTeam(team);
            team.AddMember(LoggedInUser);
            return RedirectToAction("Index", "MyTeam");
        }
    }
}