/*Elaborado por Roxana Rivera Espinoza*/
/*Ultima modificación:  09/junio/2018*/

//liberias que se utilizaran
using Picachos.Backend.Negocio.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

//namespace con su ruta
namespace Picachos.Frontend.Vistas.Inventario
{//abre namespace
    public partial class Reportes : System.Web.UI.Page
    {//abre clase reportes
        protected void Page_Load(object sender, EventArgs e)
        {//abre pageload

            /*validacion de sesion*/

            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {

                if (Session["New"] != null)
                {

                    //Si existe la sesion continuara donde esta
 
                }
                else
                {
                    Response.Redirect("/Vistas/Login/Login.aspx");
                }
            }
        }
        public void ExtTablaGeneralMP()
        {
            vgridEntySal.DataSource = ReglasNegocioEntradaSalidaMP.GetInstancia().getTablaEntrada();
            vgridEntySal.DataBind();
        }//cierra tabla general de materia prima

        public void ExtTablaSalidaMP()
        {
            vgridEntySal.DataSource = ReglasNegocioEntradaSalidaMP.GetInstancia().getTablaSalida();
            vgridEntySal.DataBind();
        }//cierra tabla de salida de materia prima

        public void ExtTablaEntradaMP()
        {
            vgridEntySal.DataSource = ReglasNegocioEntradaSalidaMP.GetInstancia().getTablaGeneral();
            vgridEntySal.DataBind();
        }//cierra tabla de entrada de materia prima

        protected void CFTablas(object sender, GridViewCancelEditEventArgs e)//Recargar tablas de entradas y salidas
        {

            vgridEntySal.EditIndex = -1;
            ExtTablaGeneralMP();
            ExtTablaSalidaMP();
            ExtTablaEntradaMP();

        }

        protected void GenerarReporte(object sender, EventArgs e) //GENERA EL REPORTE DEPENDIENDO DE EL TIPO DE REPORTE SELCCIONADO
        {

            
            string aux = ddlTipoRep.SelectedItem.ToString();
            if (aux.Equals("Entradas"))
            {
                ExtTablaEntradaMP();
               
            }

            if (aux.Equals("Salidas"))
            {
                ExtTablaSalidaMP();

            }
            if (aux.Equals("General"))
            {

                ExtTablaGeneralMP();
            }

        }//cierra generar reportes
    }//cierra clase de reportes
}//cierra namespace