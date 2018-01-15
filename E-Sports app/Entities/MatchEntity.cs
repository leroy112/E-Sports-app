using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MatchEntity
    {
        #region Fields

        public int MatchID { get; set; }
        public int TournamentID { get; set; }
        public TeamEntity Team1 { get; set; }
        public TeamEntity Team2 { get; set; }
        public TeamEntity Winner { get; set; }

        #endregion
    }
}
