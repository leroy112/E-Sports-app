using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TournamentEntity
    {
        #region fields
        public enum GameName { LeagueOfLegends, CSGO }

        public int ID { get; set; }
        public string Name { get; set; }
        public GameName Game { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime TimeLeft { get; set; }
        public string description { get; set; }
        public UserEntity admin { get; set; }
        public List<string> Rules { get; set; }
        public List<string> Prizes { get; set; }
        public List<TeamEntity> Participants { get; set; }
        public List<MatchEntity> Matches { get; set; }

        #endregion

        public void SetGameName(List<string> gamenames)
        {
            foreach(string name in gamenames)
            {
                Game = (GameName)Enum.Parse(typeof(GameName), name);
            }
        }

        public List<string> EnumToString()
        {
            List<string> strings = new List<string>();
            strings.Add(Game.ToString());
            return strings;
        }
        public void SetGame(string game)
        {
            if(game == "LeagueOfLegends")
            {
                Game = GameName.LeagueOfLegends;
            }
            else if(game == "CSGO")
            {
                Game = GameName.CSGO;
            }
        }
    }
}
