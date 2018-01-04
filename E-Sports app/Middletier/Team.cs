using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middletier
{
    class Team 
    {
        
        #region Fields

        string TeamName;
        string ShortHandle;
        string Password;
        List<User> Members = new List<User>();
        List<Tournament> Tournaments = new List<Tournament>();

        #endregion

        #region Constructor

        public Team(string teamname, string shorthandle, string password)
        {
            this.TeamName = teamname;
            this.ShortHandle = shorthandle;
            this.Password = password;
        }

        #endregion

        #region Methods

        public void SetTeamName(string teamname)
        {
            this.TeamName = teamname;
        }

        public void SetShortHandle(string shorthandle)
        {
            this.ShortHandle = shorthandle;
        }

        public void SetPassword(string password)
        {
            this.Password = password;
        }

        public void AddMember(User user)
        {
            Members.Add(user);
        }

        public void RemoveMember(User user)
        {
            Members.Remove(user);
        }

        public void AddTournament(Tournament tournament)
        {
            Tournaments.Add(tournament);
        }

        public void RemoverTournament(Tournament tournament)
        {
            Tournaments.Remove(tournament);
        }

        #endregion
    }
}
