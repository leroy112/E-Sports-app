using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace Middletier
{
    public class Tournament
    {
        private DALTournament DatabaseObject = new DALTournament();

        public enum GameName {LeagueOfLegends, CSGO }

        #region Fields

        internal TournamentEntity Entity
        {
            get
            {
                TournamentEntity entity = new TournamentEntity();

                entity.ID = this.ID;
                entity.Name = this.Name;
                entity.SetGameName(EnumToString());
                entity.StartDate = this.StartDate;
                entity.TimeLeft = this.TimeLeft;
                entity.Description = this.description;
                entity.Admin = this.admin.Entity;
                
                if(Rules.Count >= 0)
                {
                    foreach (Rule rule in Rules)
                    {
                        entity.Rules.Add(rule.Entity);
                    }
                }

                if(Prizes.Count >= 0)
                {
                    foreach (Price prize in Prizes)
                    {
                        entity.Prizes.Add(prize.Entity);
                    }
                }

                if(Participants.Count >= 0)
                {
                    foreach (Team team in Participants)
                    {
                        entity.Participants.Add(team.Entity);
                    }
                }

                if(Matches.Count >= 0)
                {
                    foreach (Match match in Matches)
                    {
                        entity.Matches.Add(match.Entity);
                    }
                }
                return entity;
            }
            set
            {
                this.ID = value.ID;
                this.Name = value.Name;
                this.SetGameName(value.EnumToString());
                this.StartDate = value.StartDate;
                this.TimeLeft = value.TimeLeft;

                foreach(RuleEntity rule in value.Rules)
                {
                    this.Rules.Add(new Rule(rule));
                }

                foreach(PriceEntity price in value.Prizes)
                {
                    this.Prizes.Add(new Price(price));
                }

                foreach(TeamEntity teamentity in value.Participants)
                {
                    this.Participants.Add(new Team(teamentity));
                }

                foreach (MatchEntity matchentity in value.Matches)
                {
                    this.Matches.Add(new Match(matchentity));
                }
            }
        }

        private int ID;
        public string Name;
        public GameName Game;
        public DateTime StartDate;
        public DateTime TimeLeft;
        public string description;
        public User admin;
        public List<Rule> Rules = new List<Rule>();
        public List<Price> Prizes = new List<Price>();
        public List<Team> Participants = new List<Team>();
        public List<Match> Matches = new List<Match>();

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

        public Tournament()
        {

        }
        #endregion

        #region Methods

        public void SetName(string name)
        {
            this.Name = name;
            DatabaseObject.SetName(Entity);
        }

        public void SetGame(GameName game)
        {
            this.Game = game;
            DatabaseObject.SetGame(Entity);
        }

        public void SetStartDate(DateTime startdate)
        {
            this.StartDate = startdate;
            DatabaseObject.SetStartDate(Entity);
        }

        public TimeSpan CalculateTimeLeft(DateTime timenow)
        {
            TimeSpan diff = StartDate.Subtract(timenow);

            return diff;
        }

        public void SetDescription(string description)
        {
            this.description = description;
            DatabaseObject.SetDescription(Entity);
        }

        public void SetAdmin(User admin)
        {
            this.admin = admin;
            DatabaseObject.SetAdmin(Entity);
        }

        public void SetRules(Rule rule)
        {
            Rules.Add(rule);
            DatabaseObject.SetRules(Entity);
        }

        public void SetPrizes(Price price)
        {
            Prizes.Add(price);
            DatabaseObject.SetPrizes(Entity);
        }

        public void AddTeam(Team team)
        {
            Participants.Add(team);
            DatabaseObject.AddTeam(team.Entity, Entity);
        }

        public void RemoveTeam(Team team)
        {
            Participants.Remove(team);
            DatabaseObject.RemoveTeam(team.Entity, Entity);
        }

        public void AddMatch(Match match)
        {
            Matches.Add(match);
            DatabaseObject.AddMatch(match.Entity.Team1, match.Entity.Team2, this.Entity);
        }

        private void CreateMatches(Tournament tournament)
        {
            if(team1 != null && team2 != null)
            {
                Match match = new Match(tournament.ID, team1, team2);
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

        public List<Tournament> GetallTournaments()
        {
            List<Tournament> tournaments = new List<Tournament>();
            List<TournamentEntity> entities = DatabaseObject.GetAllTournaments();
            foreach (TournamentEntity tournamententity in entities)
            {
                tournaments.Add(new Tournament(tournamententity));
            }
            return tournaments;
        }

        public List<Tournament> GetMyTournaments(User user)
        {
            List<Tournament> mytournaments = new List<Tournament>();
            List<TournamentEntity> entities = DatabaseObject.GetMyTournaments(user.Entity);
            foreach(TournamentEntity tournamententity in entities)
            {
                mytournaments.Add(new Tournament(tournamententity));
            }
            return mytournaments;
        }

        public List<Rule> GetallRules()
        {
            List<Rule> rules = new List<Rule>();
            foreach(RuleEntity ruleentity in DatabaseObject.GetAllRules())
            {
                Rule rule = new Rule(ruleentity);
                rules.Add(rule);
            }
            return rules;
        }

        private List<string> EnumToString()
        {
            List<string> strings = new List<string>();
            strings.Add(Game.ToString());
            return strings;
        }

        public void SetGameName(List<string> gamenames)
        {
            foreach (string name in gamenames)
            {
                Game = (GameName)Enum.Parse(typeof(GameName), name);
            }
        }

        #endregion
    }
}
