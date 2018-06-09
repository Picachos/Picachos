//librerias que se utilizaran
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//namespace con su ruta
namespace Picachos.Frontend.Vistas.Productos
{//abre namespace
    public partial class ConsultarProductosTerminados : System.Web.UI.Page
    {//abre clase para consultar productos terminados
        protected void Page_Load(object sender, EventArgs e)
        {//abre pageload

            /*validacion de sesion*/
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (Session["new"] != null)
            {
                //Si existe la sesion continuara donde esta
            }
            else
            {
                Response.Redirect("/Vistas/Login/Login.aspx");
            }

        }//cierra pageload

        protected void Consultar(object sender, EventArgs e)
        {

        }//cierra consultar
    }//cierra clase de consultar productos terminados
}//cierra namespace