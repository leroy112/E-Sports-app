using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Middletier
{
    public class Match : MatchEntity
    {

        #region Fields

        int MatchID;
        Team Team1;
        Team Team2;
        Team Winner;

        #endregion

        #region Constructor

        public Match(Team team1, Team team2)
        {
            this.Team1 = team1;
            this.Team2 = team2;
        }

        public Match()
        {

        }

        #endregion

        #region Methods

        public void SetTeam1(Team team)
        {
            this.Team1 = team;
        }

        public void SetTeam2(Team team)
        {
            this.Team2 = team;
        }

        public void SetWinner(Team team)
        {
            this.Winner = team;
        }

        public void SetMatchID(int ID)
        {
            this.MatchID = ID;
        }

        #endregion

    }
}
