using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middletier
{
    class CSGOMatch : Match
    {
        #region Fields

        int Team1_Wins;
        int Team2_Wins;

        #endregion

        #region Constructor

        public CSGOMatch(Team team1, Team team2)
        {
            SetTeam1(team1);
            SetTeam2(team2);
        }

        #endregion

        #region Methods



        #endregion
    }
}
