using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

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
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("INSERT INTO Team (TeamNaam, Shorthandle, Wachtwoord) " + "Values (" + TeamName + ", " + Shorthandle + ", " + Wachtwoord + ")", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void RemoveTeam(int TeamID)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("DELETE FROM Team Where ID = '" + TeamID + "'", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetTeamName(string teamname, int TeamID)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand mycommand = new SqlCommand("UPDATE Team SET Teamnaam = '" + teamname + "' WHERE ID = '" + TeamID + "'; ", conn);
                    mycommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetShortHandle(string shorthandle, int TeamID)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand mycommand = new SqlCommand("UPDATE Team SET Shorthandle = '" + shorthandle + "' WHERE ID = '" + TeamID + "'; ", conn);
                    mycommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetPassword(TeamEntity entity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand mycommand = new SqlCommand("UPDATE Team SET Wachtwoord = '" + entity.Password + "' WHERE ID = '" + entity.ID + "'; ", conn);
                    mycommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void AddMember(int teamID, string Username)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand mycommand = new SqlCommand("AddMember(" + Username + "," + teamID + "; ", conn);
                    mycommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void RemoveMember(int teamID, string username)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand mycommand = new SqlCommand("AddMember(" + teamID + "," + username + "; ", conn);
                    mycommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void AddTournament(int TeamID, int TournamentID)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand mycommand = new SqlCommand("AddTournament(" + TeamID + "," + TournamentID + "; ", conn);
                    mycommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void RemoverTournament(int teamID, int tournamentID)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand mycommand = new SqlCommand("RemoveTournament(" + teamID + "," + tournamentID + "; ", conn);
                    mycommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public List<TeamEntity> GetAllTeams()
        {
            List<TeamEntity> entities = new List<TeamEntity>();

            try
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
                                TeamEntity entity = new TeamEntity();

                                entity.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                                entity.TeamName = reader.GetString(reader.GetOrdinal("TeamNaam"));
                                entity.ShortHandle = reader.GetString(reader.GetOrdinal("ShortHandle"));

                                entities.Add(entity);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
            return entities;
        }


        #endregion

    }
}
