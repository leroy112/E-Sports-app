using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALTeam
    {
        #region Fields

        SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Test123");

        #endregion

        #region Constructor

        public DALTeam()
        {

        }

        #endregion

        #region Methods

        public void AddTeam(string TeamName, string Shorthandle, string Wachtwoord)
        {
            using (conn)
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("INSERT INTO Team (TeamNaam, Shorthandle, Wachtwoord) " + "Values (" + TeamName + ", " + Shorthandle + ", " + Wachtwoord + ")", conn);
                myCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void RemoveTeam(int TeamID)
        {
            using (conn)
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("DELETE FROM Team Where ID = '" + TeamID + "'", conn);
                myCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void SetTeamName(string teamname, int TeamID)
        {
            using (conn)
            {
                conn.Open();
                SqlCommand mycommand = new SqlCommand("UPDATE Team SET Teamnaam = '" + teamname + "' WHERE ID = '" + TeamID + "'; ", conn);
                mycommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void SetShortHandle(string shorthandle, int TeamID)
        {
            using (conn)
            {
                conn.Open();
                SqlCommand mycommand = new SqlCommand("UPDATE Team SET Shorthandle = '" + shorthandle + "' WHERE ID = '" + TeamID + "'; ", conn);
                mycommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void SetPassword(string password, int TeamID)
        {
            using (conn)
            {
                conn.Open();
                SqlCommand mycommand = new SqlCommand("UPDATE Team SET Wachtwoord = '" + password + "' WHERE ID = '" + TeamID  + "'; ", conn);
                mycommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void AddMember(int teamID, string Username)
        {
            using (conn)
            {
                conn.Open();
                SqlCommand mycommand = new SqlCommand("AddMember("+Username+","+teamID+"; ", conn);
                mycommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void RemoveMember(int teamID, string username)
        {
            using (conn)
            {
                conn.Open();
                SqlCommand mycommand = new SqlCommand("AddMember(" + teamID + "," + username + "; ", conn);
                mycommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void AddTournament(int TeamID, int TournamentID)
        {
            using (conn)
            {
                conn.Open();
                SqlCommand mycommand = new SqlCommand("AddTournament(" + TeamID + "," + TournamentID + "; ", conn);
                mycommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void RemoverTournament(int teamID, int tournamentID)
        {
            using (conn)
            {
                conn.Open();
                SqlCommand mycommand = new SqlCommand("RemoveTournament(" + teamID + "," + tournamentID + "; ", conn);
                mycommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void GetAllTeams()
        {
            using (conn)
            {
                conn.Open();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetAllTeams";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reader["ID"].ToString();
                            reader["TeamNaam"].ToString();
                            reader["ShortHandle"].ToString();
                        }
                    }
                }
                conn.Close();
            }
        }


        #endregion

    }
}
