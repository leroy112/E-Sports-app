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

       
        public Team team = new Team();
        public List<Team> Myteams = new List<Team>();
        public List<Team> AllTeams = new List<Team>();
        public List<Team> OtherTeams = new List<Team>();

        #endregion

        #region Methods

        public void LoadAllTeams()
        {
            foreach (Team team in team.GetAllTeams())
            {
                AllTeams.Add(team);
            }
        }

        public void LoadMyTeams(User loggedinuser)
        {
            foreach(Team team in team.GetMyTeams(loggedinuser))
            {
                Myteams.Add(team);
            }
        }

        public void FillOtherTeams()
        {
            foreach (Team team in AllTeams)
            {
                if (!Myteams.Contains(team))
                {
                    OtherTeams.Add(team);
                }
            }
        }

        #endregion
    }
}