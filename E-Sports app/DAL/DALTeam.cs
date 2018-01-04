using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DALTeam
    {
        #region Fields

        SqlConnection conn = new SqlConnection("Server = mssql.fhict.local; Database = dbi346272; User Id = dbi346272; Password = Mandy1969");

        #endregion

        #region Constructor

        public DALTeam()
        {

        }

        #endregion

        #region Methods

        public void AddTeam(string TeamName, string Shorthandle, string Wachtwoord)
        {
            SqlCommand myCommand = new SqlCommand("INSERT INTO Team (TeamNaam, Shorthandle, Wachtwoord) " +
                                     "Values ("+TeamName+", "+Shorthandle+", "+Wachtwoord+")", conn);
        }

        public void RemoveTeam(string TeamName)
        {
            SqlCommand myCommand = new SqlCommand("DELETE FROM Team Where Teamnaam = '"+TeamName+"'", conn);
        }

        #endregion
        
    }
}
