using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middletier
{
    class Tournament
    {

        public enum GameName {LeagueOfLegends, CSGO }

        #region Fields

        string Name;
        GameName Game;
        DateTime StartDate;
        DateTime TimeLeft;
        string description;
        User admin;
        List<string> Rules = new List<string>();
        List<string> Prizes = new List<string>();
        List<Team> Participants = new List<Team>();
        List<Match> Matches = new List<Match>();

        #endregion

        #region Constructor

        public void SetName(string name)
        {
            this.Name = name;
        }

        public void SetGame(GameName game)
        {
            this.Game = game;
        }

        public void SetStartDate(DateTime startdate)
        {
            this.StartDate = startdate;
        }

        public TimeSpan CalculateTimeLeft(DateTime timenow)
        {
            TimeSpan diff = StartDate.Subtract(timenow);

            return diff;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        #endregion

    }
}
