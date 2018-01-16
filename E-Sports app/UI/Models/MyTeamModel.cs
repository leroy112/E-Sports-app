using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Middletier;

namespace UI.Models
{
    public class MyTeamModel
    {
        #region Fields

        public User LoggedInUser = new User("User1", Account_Type.Player, "Leroy", "Van de Ven", "84745834", "Vi0llet", "Leroylyon@hotmail.com");
        private Team team = new Team();
        public List<Team> Myteams = new List<Team>();
        public List<Team> AllTeams = new List<Team>();

        #endregion

        #region Methods

        public void LoadAllTeams()
        {
            foreach (Team team in team.GetAllTeams())
            {
                AllTeams.Add(team);
            }
        }

        public void LoadMyTeams()
        {
            foreach(Team team in team.GetMyTeams(LoggedInUser))
            {
                Myteams.Add(team);
            }
        }

        #endregion
    }
}