using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace Middletier
{
    public class Match
    {

        #region Fields
        private DALMatch databaseObject = new DALMatch();

        internal MatchEntity Entity
        {
            get
            {
                MatchEntity entity = new MatchEntity();

                entity.MatchID = this.MatchID;
                entity.TournamentID = this.TournamentID;
                entity.Team1 = this.Team1.Entity;
                entity.Team2 = this.Team2.Entity;
                entity.Winner = this.Winner.Entity;

                return entity;
            }
            set
            {
                this.MatchID = value.MatchID;
                this.TournamentID = value.TournamentID;
                this.Team1.Entity = value.Team1;
                this.Team2.Entity = value.Team2;
                this.Winner.Entity = value.Winner;
            }
        }

        int MatchID;
        int TournamentID;
        Team Team1;
        Team Team2;
        Team Winner;

        #endregion

        #region Constructor

        public Match(int TournamentID, Team team1, Team team2)
        {
            this.Team1 = team1;
            this.Team2 = team2;
        }

        public Match(MatchEntity entity)
        {
            Entity = entity;
        }

        #endregion

        #region Methods

        public void SetTeam1(Team team)
        {
            this.Team1 = team;
            databaseObject.SetTeam1(team.Entity, Entity);
        }

        public void SetTeam2(Team team)
        {
            this.Team2 = team;
            databaseObject.SetTeam2(team.Entity, Entity);
        }

        public void SetWinner(Team team)
        {
            this.Winner = team;
            databaseObject.SetWinner(team.Entity, Entity);
        }

        public void SetTournamentID(Tournament tournament)
        {
            this.TournamentID = tournament.Entity.ID;
            databaseObject.SetTournamentID(tournament.Entity, Entity);
        }

        #endregion

    }
}
