//liberias que se utilizaran
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Picachos.Backend.Negocio.EntidadesNegocio;
using Picachos.Backend.Negocio.LogicaNegocio;

//namespace con su ruta
namespace Picachos.Frontend.Vistas
{//abre namespace
    public partial class Picachos : System.Web.UI.MasterPage
    {//abre clase picachos master
        protected void Page_Load(object sender, EventArgs e)
        {//abre pageload

            //Crea el objeto UnobtrusiveValidationMode para realizar validaciones predefinidas por ASP
            //this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (Session["New"] != null)
            {
                labUsuario.Text = ReglasNegocioUsuario.GetInstancia().GetNombre(Session["New"].ToString());
                labUsuario.Text = labUsuario.Text.ToUpper();

                labUsuarioID.Text = "000" + ReglasNegocioUsuario.GetID(Session["New"].ToString());

                labRol.Text = ReglasNegocioUsuario.GetInstancia().GetRol(Session["New"].ToString());
                labRol.Text = labRol.Text.ToUpper();

                if ((labRol.Text.ToUpper().EndsWith("REPATIDOR")) || (labRol.Text.ToUpper().EndsWith("DESPACHADOR")))
                {
                    imgMenuUsua.Visible = false;
                    hyperRegistrar.Visible = false;
                    hyperConsultar.Visible = false;

                }
                //Si existe la sesion continuara donde esta
            }
            else
            {
                Response.Redirect("/Vistas/Login/Login.aspx");
            }

        }//cierra pageload

        protected void cerrarSesion(object sender, EventArgs e)
        {
            Session["New"] = null;
            Response.Redirect("/Vistas/Login/Login.aspx");
        }//cierra sesion


    }//cierra clase picachos master
}//cierra namespace