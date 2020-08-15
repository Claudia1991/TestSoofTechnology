using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace SooftApi.Data
{
    public static class Conection
    {
        #region Properties
        private static SqlConnection currentConnection;
        #endregion

        #region Methods
        public static SqlConnection GetConection()
        {
            if (currentConnection == null)
            {
                currentConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSooft"].ConnectionString);
            }
            return currentConnection;
        }
        #endregion


    }
}
