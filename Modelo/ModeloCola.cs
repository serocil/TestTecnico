using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace Modelo
{
    public class ModeloCola
    {
        #region "PATRON SINGLETON"
        private static ModeloCola modeloCola = null;
        private ModeloCola() { }
        public static ModeloCola getInstance()
        {
            if (modeloCola == null)
            {
                modeloCola = new ModeloCola();

            }
            return modeloCola;
        }
        #endregion

        /// <summary>
        /// Lista toda las colas cargadas en la BD en funcion del Id
        /// </summary>
        /// <param name="cola"></param>
        /// <returns></returns>
        public List<Cola> ListCola(int cola)
        {
            List<Cola> List = new List<Cola>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("sp_ListCola", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cola", cola);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cola objCola = new Cola();
                    objCola.Id = Convert.ToInt32(dr["id"].ToString());
                    List.Add(objCola);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return List;
        }


        /// <summary>
        /// Agrega un registro a cualquiera de las dos colas
        /// </summary>
        /// <param name="objCola"></param>
        /// <returns></returns>
        public bool InsertCola(Cola objCola)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            int rows = 0;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("sp_InsertCola", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", objCola.Id);
                cmd.Parameters.AddWithValue("@nombre", objCola.nombre);
                con.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows > 0) response = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
         
            return response;
        }
        /// <summary>
        /// Valida si existe registro previamente cargados en la Tabla Cola
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ValidarRegistro(int id)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            int count = 0;
            try
            {
                con = Conexion.getInstance().ConexionBD(); 
                cmd = new SqlCommand("sp_ValidarRegistro", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                count = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                if(count > 0) response = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

            return response;

        }

   }
}
