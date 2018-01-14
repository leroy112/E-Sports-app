using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TeamEntity
    {
        #region Fields
        public int ID { get; set; }
        public string TeamName { get; set; }
        public string ShortHandle { get; set; }
        public string Password { get; set; }
        public List<UserEntity> Members { get; set; }
        public List<TournamentEntity> Tournaments { get; set; }
        #endregion
    }
}
