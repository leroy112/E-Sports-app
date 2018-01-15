using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entities;

namespace DAL
{
    public class DALMatch
    {
        #region Fields

        SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Test123");

        #endregion

        #region Constructor

        public DALMatch()
        {

        }

        #endregion

        #region Methods

        public void SetTeam1(TeamEntity teamentity, MatchEntity matchentity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("UPDATE Wedstrijd SET Team1_ID = '" + teamentity.ID + "' WHERE ID = '" + matchentity.MatchID + "')", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetTeam2(TeamEntity teamentity, MatchEntity matchentity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("UPDATE Wedstrijd SET Team2_ID = '" + teamentity.ID + "' WHERE ID = '" + matchentity.MatchID + "')", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetWinner(TeamEntity teamentity, MatchEntity matchentity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("UPDATE Wedstrijd SET Winner_ID = '" + teamentity.ID + "' WHERE ID = '" + matchentity.MatchID + "')", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetTournamentID(TournamentEntity tournamententity, MatchEntity matchentity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("UPDATE Wedstrijd SET Toernooi_ID = '" + tournamententity.ID + "' WHERE ID = '" + matchentity.MatchID + "')", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        #endregion
    }
}
