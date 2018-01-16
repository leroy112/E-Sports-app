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
        
        private Tournament Tournament = new Tournament();
        public List<Team> participants = new List<Team>();
        public List<Tournament> MyTournaments = new List<Tournament>();
        public List<Tournament> AllTournaments = new List<Tournament>();
        public List<Rule> Rules = new List<Rule>();
        public List<Price> Prices = new List<Price>();
        public List<Match> Matches = new List<Match>();

        #endregion

        #region Methods

        public void LoadParticipants()
        {
            foreach(Team team in Tournament.Participants)
            {
                participants.Add(team);
            }
        }

        public void LoadAllTournaments()
        {
            foreach (Tournament tournament in Tournament.GetallTournaments())
            {
                AllTournaments.Add(tournament);
            }
        }

        public void LoadMyTournaments(User loggedinuser)
        {
            foreach (Tournament tournament in Tournament.GetMyTournaments(loggedinuser))
            {
                MyTournaments.Add(tournament);
            }
        }
       
        public void GetMatches()
        {
            foreach (Match match in Tournament.Matches)
            {
                Matches.Add(match);
            }
        }

        public void GetPrices()
        {
            foreach (Price price in Tournament.Prizes)
            {
                Prices.Add(price);
            }
        }

        public void GetRules()
        {
            foreach (Rule rule in Tournament.Rules)
            {
                Rules.Add(rule);
            }
        }

        #endregion
    }
}