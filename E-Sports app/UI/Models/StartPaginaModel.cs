using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Middletier;

namespace UI.Models
{
    public class StartPaginaModel
    {
        #region Fields

        public User LoggedInUser = new User("User1", Account_Type.Player, "Leroy", "Van de Ven", "84745834", "Vi0llet", "leroylyon@hotmail.com");
        private Tournament tournament = new Tournament();
        public List<Tournament> tournaments = new List<Tournament>();

        #endregion

        #region Methods

        public void LoadAllTournaments()
        {
            foreach (Tournament tournament in tournament.GetallTournaments())
            {
                tournaments.Add(tournament);
            }
        }

        #endregion
    }
}