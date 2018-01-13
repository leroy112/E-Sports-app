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
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("UPDATE toernooi SET Naam = '" + newname + "' WHERE ID = '" + TournamentID + "')", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetGame(string game, int TournamentID)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("UPDATE toernooi SET Game = '" + game + "' WHERE ID = '" + TournamentID + "')", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetStartDate(DateTime startdate, int TournamentID)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("UPDATE toernooi SET Datum = '" + startdate + "' WHERE ID = '" + TournamentID + "')", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetDescription(string description, int tournamentID)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("UPDATE toernooi SET Beschrijving = '" + description + "' WHERE ID = '" + tournamentID + "')", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetAdmin(string admin, int tournamentID)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("UPDATE toernooi SET Admin_Username = '" + admin + "' WHERE ID = '" + tournamentID + "')", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetRules(List<string> newrules, int tournamentID)
        {
            foreach (string rule in newrules)
            {
                try
                {
                    using (conn)
                    {
                        conn.Open();
                        SqlCommand myCommand = new SqlCommand("INSERT INTO regel (Tournament_ID, Regel) Values ('" + tournamentID + "', '" + rule + "') ", conn);
                        myCommand.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (SqlException)
                {

                }
            }
        }

        public void SetPrizes(List<string> newprizes, int tournamentID)
        {
            foreach (string prize in newprizes)
            {
                try
                {
                    using (conn)
                    {
                        conn.Open();
                        SqlCommand myCommand = new SqlCommand("INSERT INTO prijs (Tournament_ID, prijs) Values ('" + tournamentID + "', '" + prize + "') ", conn);
                        myCommand.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (SqlException)
                {

                }
            }
        }

        public void AddTeam(int teamID, int tournamentID)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("INSERT INTO Team_Toernooi (Team_ID, Toernooi_ID) Values ('" + teamID + "', '" + tournamentID + "') ", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void RemoveTeam(int teamID, int tournamentID)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("REMOVE Team_Toernooi WHERE Team_ID = '"+teamID+"' and Toernooi_ID = '"+tournamentID+"'" , conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void AddMatch(string match)
        {
            throw new NotImplementedException();
        }

        public void GetAllTournaments()
        {
            try
            {
                using (conn)
                {
                    conn.Open();

                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "GetAllTournaments";

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reader["ID"].ToString();
                                reader["Admin_Username"].ToString();
                                reader["Naam"].ToString();
                                reader["game"].ToString();
                                reader["Datum"].ToString();
                                reader["Beschrijving"].ToString();
                            }
                        }
                    }
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
