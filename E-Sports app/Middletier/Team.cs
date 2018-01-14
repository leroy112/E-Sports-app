using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace Middletier
{
    public class Team 
    {

        #region Fields
        private DALTeam databaseObject = new DALTeam();
        internal TeamEntity Entity
        {
            get
            {
                TeamEntity entity = new TeamEntity();

                entity.ID = this.ID;
                entity.TeamName = this.TeamName;
                entity.ShortHandle = this.ShortHandle;
                entity.Password = this.Password;

                foreach (User member in Members)
                {
                    entity.Members.Add(member.Entity);
                }

                foreach (Tournament tournament in Tournaments)
                {
                    entity.Tournaments.Add(tournament.Entity);
                }

                return entity;
            }
            set
            {
                this.ID = value.ID;
                this.TeamName = value.TeamName;
                this.ShortHandle = value.ShortHandle;
                this.Password = value.Password;

                foreach (UserEntity member in value.Members)
                {
                    this.Members.Add(new User(member));
                }

                foreach (TournamentEntity tournament in value.Tournaments)
                {
                    this.Tournaments.Add(new Tournament(tournament));
                }
            }
        }

        int ID;
        string TeamName;
        string ShortHandle;
        string Password;
        List<User> Members = new List<User>();
        List<Tournament> Tournaments = new List<Tournament>();

        #endregion

        #region Constructor

        public Team(int ID, string teamname, string shorthandle, string password)
        {
            this.ID = ID;
            this.TeamName = teamname;
            this.ShortHandle = shorthandle;
            this.Password = password;
        }

        public Team(TeamEntity entity)
        {
            Entity = entity;
        }
        #endregion

        #region Methods

        public void SetTeamName(string teamname)
        {
            this.TeamName = teamname;
            databaseObject.SetTeamName(Entity);
        }

        public void SetShortHandle(string shorthandle)
        {
            this.ShortHandle = shorthandle;
            databaseObject.SetShortHandle(Entity);
        }

        public void SetPassword(string password)
        {
            this.Password = password;
            databaseObject.SetPassword(Entity);
        }

        public void AddMember(User user)
        {
            Members.Add(user);
            databaseObject.AddMember(Entity, user.Entity);
        }

        public void RemoveMember(User user)
        {
            Members.Remove(user);
            databaseObject.RemoveMember(Entity, user.Entity);
        }

        public void AddTournament(Tournament tournament)
        {
            Tournaments.Add(tournament);
            databaseObject.AddTournament(Entity, tournament.Entity);
        }

        public void RemoveTournament(Tournament tournament)
        {
            Tournaments.Remove(tournament);
            databaseObject.RemoveTournament(Entity, tournament.Entity);
        }

        public List<Team> GetAllTeams()
        {
            List<Team> teams = new List<Team>();
            List<TeamEntity> entities = databaseObject.GetAllTeams();

            foreach(TeamEntity entity in entities)
            {
                teams.Add(new Team(entity));
            }
            return teams;
        }
        #endregion
    }
}
