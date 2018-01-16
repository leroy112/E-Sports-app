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

        public void AddTeam(TeamEntity  entity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("INSERT INTO Team (TeamNaam, Shorthandle, Wachtwoord) " + "Values (" + entity.TeamName + ", " + entity.ShortHandle + ", " + entity.Password + ")", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void RemoveTeam(TeamEntity entity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("DELETE FROM Team Where ID = '" + entity.ID + "'", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetTeamName(TeamEntity entity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand mycommand = new SqlCommand("UPDATE Team SET Teamnaam = '" + entity.TeamName + "' WHERE ID = '" + entity.ID + "'; ", conn);
                    mycommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetShortHandle(TeamEntity entity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand mycommand = new SqlCommand("UPDATE Team SET Shorthandle = '" + entity.ShortHandle + "' WHERE ID = '" + entity.ID + "'; ", conn);
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

        public void AddMember(TeamEntity teamentity, UserEntity userentity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand mycommand = new SqlCommand("AddMember(" + userentity.Username + "," + teamentity.ID + "; ", conn);
                    mycommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void RemoveMember(TeamEntity teamentity, UserEntity userentity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand mycommand = new SqlCommand("AddMember(" + teamentity.ID + "," + userentity.Username + "; ", conn);
                    mycommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void AddTournament(TeamEntity teamentity, TournamentEntity tournamententity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand mycommand = new SqlCommand("AddTournament(" + teamentity.ID + "," + tournamententity.ID + "; ", conn);
                    mycommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void RemoveTournament(TeamEntity teamentity, TournamentEntity tournamententity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand mycommand = new SqlCommand("RemoveTournament(" + teamentity.ID + "," + tournamententity.ID+ "; ", conn);
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

        public List<TeamEntity> GetMyTeams(UserEntity userentity)
        {
            SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Test123");
            List<TeamEntity> entities = new List<TeamEntity>();

            try
            {
                using (conn)
                {
                    conn.Open();

                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "SELECT Teamnaam, Shorthandle FROM Team INNER JOIN Team_User ON Team.ID = Team_User.Team_ID WHERE Team_User.Username = '"+userentity.Username+"'";

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TeamEntity entity = new TeamEntity();
                                
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
