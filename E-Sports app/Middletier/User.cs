using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middletier
{
    public enum Account_Type { player, admin };

    class User
    {
        #region Fields

        string Username;
        Account_Type Account;
        string SirName;
        string Lastname;
        string SteamID;
        string LOLUsername;
        string Email;
        List<Team> Teams = new List<Team>();

        #endregion

        #region Constructor

        public User(string username, Account_Type account, string sirname, string Lastname, string steamID, string lolusername, string email)
        {
            this.Username = username;
            this.Account = account;
            this.SirName = sirname;
            this.Lastname = Lastname;
            this.SteamID = steamID;
            this.LOLUsername = lolusername;
            this.Email = email;
        }

        #endregion

        #region Methods

        public void SetUserName(string username)
        {
            this.Username = username;
        }

        public void SetSirname(string sirname)
        {
            this.SirName = sirname;
        }

        public void SetLastName(string lastname)
        {
            this.Lastname = lastname;
        }

        public void SetSteamID(string steamid)
        {
            this.SteamID = steamid;
        }

        public void SetLOLUserName(string lolusername)
        {
            this.LOLUsername = lolusername;
        }

        public void SetEmail(string email)
        {
            this.Email = email;
        }

        public void AddTeam(Team team)
        {
            Teams.Add(team);
        }

        public void RemoveTeam(Team team)
        {
            Teams.Remove(team);
        }

        public void DeleteTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public void DeleteTournament(Tournament tournament)
        {
            throw new NotImplementedException();
        }

        public void DeleteMatch(Match match)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
