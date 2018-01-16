using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserEntity
    {
        #region Fields
        public enum Account_Type { Player, Admin };

        public string Username;
        public Account_Type Account { get; set; }
        public string SirName { get; set; }
        public string Lastname { get; set; }
        public string SteamID { get; set; }
        public string LOLUsername { get; set; }
        public string Email { get; set; }
        public List<TeamEntity> Teams { get; set; }

        #endregion

        public List<string> EnumToString()
        {
            List<string> strings = new List<string>();
            strings.Add(Account.ToString());
            return strings;
        }
        public void SetAccount(string game)
        {
            if (game == "Admin")
            {
                Account = Account_Type.Admin;
            }
            else if (game == "Player")
            {
                Account = Account_Type.Player;
            }
        }

    }
}
