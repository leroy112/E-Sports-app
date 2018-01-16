using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace DAL
{
    public class DALTournament
    {
        #region fields

        SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database=dbi346272;User Id = dbi346272 Password=Test123;");

        #endregion

        #region Constructor

        public DALTournament()
        {

        }

        #endregion

        #region Methods

        public void SetName(TournamentEntity entity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("UPDATE toernooi SET Naam = '" + entity.Name + "' WHERE ID = '" + entity.ID + "')", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetGame(TournamentEntity entity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("UPDATE toernooi SET Game = '" + entity.Game.ToString() + "' WHERE ID = '" + entity.ID + "')", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetStartDate(TournamentEntity entity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("UPDATE toernooi SET Datum = '" + entity.StartDate + "' WHERE ID = '" + entity.ID + "')", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetDescription(TournamentEntity entity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("UPDATE toernooi SET Beschrijving = '" + entity.Description + "' WHERE ID = '" + entity.ID + "')", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetAdmin(TournamentEntity entity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("UPDATE toernooi SET Admin_Username = '" + entity.Admin + "' WHERE ID = '" + entity.ID + "')", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void SetRules(TournamentEntity entity)
        {
            foreach (string rule in entity.Rules)
            {
                try
                {
                    using (conn)
                    {
                        conn.Open();
                        SqlCommand myCommand = new SqlCommand("INSERT INTO regel (Tournament_ID, Regel) Values ('" + entity.ID + "', '" + rule + "') ", conn);
                        myCommand.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (SqlException)
                {

                }
            }
        }

        public void SetPrizes(TournamentEntity entity)
        {
            foreach (string prize in entity.Prizes)
            {
                try
                {
                    using (conn)
                    {
                        conn.Open();
                        SqlCommand myCommand = new SqlCommand("INSERT INTO prijs (Tournament_ID, prijs) Values ('" + entity.ID + "', '" + prize + "') ", conn);
                        myCommand.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (SqlException)
                {

                }
            }
        }

        public void AddTeam(TeamEntity teamentity, TournamentEntity tournamententity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("INSERT INTO Team_Toernooi (Team_ID, Toernooi_ID) Values ('" + teamentity.ID + "', '" + tournamententity.ID + "') ", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void RemoveTeam(TeamEntity teamentity, TournamentEntity tournamententity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("REMOVE Team_Toernooi WHERE Team_ID = '"+teamentity.ID+"' and Toernooi_ID = '"+tournamententity.ID+"'" , conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public void AddMatch(TeamEntity Team1entity, TeamEntity Team2entity, TournamentEntity tournamententity)
        {
            try
            {
                using (conn)
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("INSERT INTO Wedstrijd (Toernooi_ID, Team1_ID, Team2_ID) Values('" + tournamententity.ID + "', '" + Team1entity.ID + "', '" + Team2entity.ID + "')", conn);
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (SqlException)
            {

            }
        }

        public List<TournamentEntity> GetAllTournaments()
        {

            List<TournamentEntity> entities = new List<TournamentEntity>();
            try
            {
                using (conn)
                {
                    conn.Open();

                    using (var cmd = new SqlCommand("SELECT * FROM [Toernooi] ORDER BY[datum]", conn))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TournamentEntity entity = new TournamentEntity();

                                entity.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                                entity.Admin.Username = reader.GetString(reader.GetOrdinal("Admin_Username"));
                                entity.Name = reader.GetString(reader.GetOrdinal("Naam"));
                                entity.SetGame(reader.GetString(reader.GetOrdinal("Game")));
                                entity.StartDate = reader.GetDateTime(reader.GetOrdinal("Datum"));
                                entity.Description = reader.GetString(reader.GetOrdinal("Beschrijving"));

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
