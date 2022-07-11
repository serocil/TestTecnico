using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
   public  class Conexion
    {
        #region "Patron Singlenton"
        private static Conexion conexion = null;

        private Conexion() { }

        public static Conexion getInstance()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }

            return conexion;
        }

        #endregion

        public SqlConnection ConexionBD()
        {

            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = GetConnectionString();
            return conexion;

        }


        public String GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }
    }
}
