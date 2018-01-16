using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;
using Middletier;

namespace UI.Controllers
{
    public class TournamentController : Controller
    {

        User LoggedInUser = new User("User1", Account_Type.Player, "Leroy", "Van de Ven", "84745834", "Vi0llet", "Leroylyon@hotmail.com");

        // GET: Tournament
        public ActionResult Index()
        {
            TournamentModel model = new TournamentModel();
            model.LoadAllTournaments();
            model.LoadMyTournaments(LoggedInUser);
            model.LoadParticipants();
            model.GetPrices();
            model.GetRules();
            return View(model);
        }
    }
}