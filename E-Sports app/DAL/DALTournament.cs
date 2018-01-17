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
        


        #endregion

        #region Constructor

        public DALTournament()
        {

        }

        #endregion

        #region Methods

        public void SetName(TournamentEntity entity)
        {
            SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Test123");
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
            SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Test123");
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
            SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Test123");
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
            SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Test123");
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

        public void SetRules(TournamentEntity entity)
        {
            SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Test123");
            foreach (RuleEntity rule in entity.Rules)
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
            SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Test123");
            foreach (PriceEntity prize in entity.Prizes)
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
            SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Test123");
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
            SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Test123");
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
            SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Test123");
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
            SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Test123");
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

        public List<TournamentEntity> GetMyTournaments(UserEntity userentity)
        {
            SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Test123");
            List<TournamentEntity> entities = new List<TournamentEntity>();
            try
            {
                using (conn)
                {
                    conn.Open();

                    using (var cmd = new SqlCommand("GetMyTournaments '" + userentity.Username + "'", conn))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TournamentEntity entity = new TournamentEntity();

                                entity.ID = reader.GetInt32(reader.GetOrdinal("ID"));
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

        public List<RuleEntity> GetAllRules()
        {
            SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Test123");
            List<RuleEntity> entities = new List<RuleEntity>();
            try
            {
                using (conn)
                {
                    conn.Open();

                    using (var cmd = new SqlCommand("SELECT * FROM regel ORDER BY Tournament_ID", conn))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RuleEntity entity = new RuleEntity();

                                entity.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                                entity.TournamentID = reader.GetInt32(reader.GetOrdinal("Tournament_ID"));
                                entity.Rulestring = reader.GetString(reader.GetOrdinal("Regel"));

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

        public List<PriceEntity> GetAllPrices()
        {
            SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Test123");
            List<PriceEntity> entities = new List<PriceEntity>();
            try
            {
                using (conn)
                {
                    conn.Open();

                    using (var cmd = new SqlCommand("SELECT * FROM Prijs ORDER BY Tournament_ID", conn))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PriceEntity entity = new PriceEntity();

                                entity.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                                entity.TournamentID = reader.GetInt32(reader.GetOrdinal("Tournament_ID"));
                                entity.Pricestring = reader.GetString(reader.GetOrdinal("Regel"));

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
