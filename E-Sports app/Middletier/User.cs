using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Middletier
{
    public enum Account_Type { Player, Admin };

    public class User
    {
        #region Fields
        internal UserEntity Entity
        {
            get
            {
                UserEntity entity = new UserEntity();
                entity.Username = this.Username;
                entity.SetAccount(EnumToString());
                entity.SirName = this.SirName;
                entity.Lastname = this.Lastname;
                entity.SteamID = this.SteamID;
                entity.LOLUsername = this.LOLUsername;
                entity.Email = this.Email;

                foreach(Team team in Teams)
                {
                    entity.Teams.Add(team.Entity);
                }
                return entity;
            }
            set
            {
                this.Username = value.Username;
                this.SetAccountName(value.EnumToString());
                this.SirName = value.SirName;
                this.Lastname = value.Lastname;
                this.SteamID = value.SteamID;
                this.LOLUsername = value.LOLUsername;
                this.Email = value.Email;

                foreach(TeamEntity teamentity in value.Teams)
                {
                    new Team(teamentity);
                }

            }
        }


        public string Username;
        private Account_Type Account;
        public string SirName;
        public string Lastname;
        private string SteamID;
        private string LOLUsername;
        private string Email;
        private List<Team> Teams = new List<Team>();

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

        public User(UserEntity entity)
        {
            Entity = entity;
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

        private string EnumToString()
        {
            List<string> strings = new List<string>();
            strings.Add(Account.ToString());
            return Account.ToString();
        }

        public void SetAccountName(List<string> accounttypes)
        {
            foreach (string type in accounttypes)
            {
                Account = (Account_Type)Enum.Parse(typeof(Account_Type), type);
            }
        }

        #endregion
    }
}
