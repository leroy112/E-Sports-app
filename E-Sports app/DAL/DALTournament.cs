using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class DALTournament
    {
        #region fields

        SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Test123");

        #endregion

        #region Constructor

        public DALTournament()
        {

        }

        #endregion

        #region Methods

        public void SetName(int TournamentID, string newname)
        {
            using (conn)
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("UPDATE toernooi SET Naam = '"+newname+"' WHERE ID = '"+TournamentID+"')", conn);
                myCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void SetGame(string game, int TournamentID)
        {
            using (conn)
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("UPDATE toernooi SET Game = '" + game + "' WHERE ID = '" + TournamentID + "')", conn);
                myCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void SetStartDate(DateTime startdate, int TournamentID)
        {
            using (conn)
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("UPDATE toernooi SET Datum = '" + startdate + "' WHERE ID = '" + TournamentID + "')", conn);
                myCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        #endregion
    }
}
