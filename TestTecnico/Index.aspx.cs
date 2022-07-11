using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using Controlador;
using System.Web.Services;
using System.Text;

namespace TestTecnico
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Create New Task
        /// </summary>
        /// <param name="name"></param>
        /// <returns>bool value </returns>
        [WebMethod]
        public static bool InsertCola(String id,String nombre)
        {
            Cola objCola = new Cola();
            bool response = false;
            bool dato_cargado = false;
            try
            {

                objCola.nombre = nombre;
                objCola.Id = Convert.ToInt32(id);
                dato_cargado = ColaController.getInstance().ValidarRegistro(objCola.Id);
                if (dato_cargado)
                {
                    throw new Exception("El Cliente ya esta registrado en el sistema");
                }
                else
                {
                    response = ColaController.getInstance().InsertCola(objCola);                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return response;
        }

        [WebMethod]
        public static string ActualizarColas(string idcola)
        {

            string response = "";
            int cola=Convert.ToInt32(idcola);
            try
            {
                List<Cola> ListarCola = new List<Cola>();
                ListarCola = ListCola(idcola);
                response = RenderizarTabla(ListarCola, cola);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }


        private static string RenderizarTabla(List<Cola> ListCola,int? cola)
        {
            string retorno = "";
            StringBuilder htmlTable = new StringBuilder();
            htmlTable.Append("<div class='table-responsive'>");
            htmlTable.Append("<table id='dtColas' class='table'border='1'>");
            htmlTable.Append("<thead>");
            //htmlTable.Append("<th></th>");
            htmlTable.Append("</thead>");
            htmlTable.Append("<tbody style='overflow-y: auto;'>");
            try
            {
                if (ListCola.Count() > 0)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td > Cola " + cola.ToString().Trim() + "</td>");
                    foreach (var item in ListCola)
                    {
                       
                        htmlTable.Append("<td>" + item.Id.ToString().Trim() + "</td>");
                        
                    }
                    htmlTable.Append("</tr>");
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    htmlTable.Append("</div>");
                    retorno = htmlTable.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }


        /// <summary>
        /// List all tasks loaded in the database
        /// </summary>
        /// <returns></returns>
        public static List<Cola> ListCola(string idcola)
        {
            int cola = Convert.ToInt32(idcola);
            List<Cola> ListCola= null;
            try
            {
                ListCola = ColaController.getInstance().ListCola(cola);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListCola;
        }



    }
}