using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Middletier
{
    public class Tournament
    {

        public enum GameName {LeagueOfLegends, CSGO }

        #region Fields
        internal TournamentEntity Entity
        {
            get; set;
        }

        int ID;
        string Name;
        GameName Game;
        DateTime StartDate;
        DateTime TimeLeft;
        string description;
        User admin;
        List<string> Rules = new List<string>();
        List<string> Prizes = new List<string>();
        List<Team> Participants = new List<Team>();
        List<Match> Matches = new List<Match>();

        Team team1;
        Team team2;

        #endregion

        #region Constructor
        
        public Tournament(int id, string name, GameName game, DateTime startdate, string description, User admin)
        {
            this.ID = id;
            this.Name = name;
            this.Game = game;
            this.StartDate = startdate;
            this.description = description;
            this.admin = admin;
        }

        public Tournament(TournamentEntity entity)
        {
            Entity = entity;
        }
        #endregion

        #region Methods

        public void SetName(string name)
        {
            this.Name = name;
        }

        public void SetGame(GameName game)
        {
            this.Game = game;
        }

        public void SetStartDate(DateTime startdate)
        {
            this.StartDate = startdate;
        }

        public TimeSpan CalculateTimeLeft(DateTime timenow)
        {
            TimeSpan diff = StartDate.Subtract(timenow);

            return diff;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        public void SetAdmin(User admin)
        {
            this.admin = admin;
        }

        public void SetRules(List<string> newrules)
        {
            foreach(string rule in newrules)
            {
                Rules.Add(rule);
            }
        }

        public void SetPrizes(List<string> newprizes)
        {
            foreach(string prize in newprizes)
            {
                Prizes.Add(prize);
            }
        }

        public void AddTeam(Team team)
        {
            Participants.Add(team);
        }

        public void RemoveTeam(Team team)
        {
            Participants.Remove(team);
        }

        public void AddMatch(Match match)
        {
            Matches.Add(match);
        }

        public void CalculateSeeding()
        {
            throw new NotImplementedException();
        }

        public void CreateMatches()
        {
            if(team1 != null && team2 != null)
            {
                Match match = new Match(team1,team2);
                AddMatch(match);
                team1 = null;
                team2 = null;
            }
            else
            {
                foreach(Team team in Participants)
                {
                    if(team1 == null)
                    {
                        team1 = team;
                    }
                    else if(team2 == null)
                    {
                        team2 = team;
                        break;
                    }
                }
            }
        }
        
        #endregion
    }
}
