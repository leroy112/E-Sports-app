using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Middletier;

namespace UI.Models
{
    public class TournamentModel
    {
        #region Fields

        Tournament Tournament = new Tournament();
        List<Team> participants = new List<Team>();
        List<Tournament> MyTournaments = new List<Tournament>();
        List<string> Rules = new List<string>();
        List<string> Prices = new List<string>();
        List<Match> Matches = new List<Match>();

        #endregion

        #region Methods

        public void LoadData()
        {
            foreach(Team team in Tournament.Participants)
            {
                participants.Add(team);
            }

            foreach(string rule in Tournament.Rules)
            {
                Rules.Add(rule);
            }

            foreach(string price in Tournament.Prizes)
            {
                Prices.Add(price);
            }
        }

        #endregion
    }
}