using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Modelo;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace Controlador
{
    public class ColaController
    {
        #region "Patron Singlenton"
        private static ColaController objCola = null;
        private ColaController() { }
        public static ColaController getInstance()
        {
            if (objCola == null)
            {
                objCola = new ColaController();
            }
            return objCola;
        }
        #endregion


        /// <summary>
        /// List all tasks loaded in the database
        /// </summary>
        /// <returns></returns>
        public List<Cola> ListCola(int cola)
        {
            try
            {
                return ModeloCola.getInstance().ListCola(cola);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


       
        public bool InsertCola(Cola objCola)
        {
            try
            {
                return ModeloCola.getInstance().InsertCola(objCola);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool ValidarRegistro(int id)
        {
            try
            {
                return ModeloCola.getInstance().ValidarRegistro(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
