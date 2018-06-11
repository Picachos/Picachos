/*Elaborado por Roxana Rivera Espinoza*/
/*Ultima modificación: 10/06/2018 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Picachos.Backend.Negocio.LogicaNegocio;
using Picachos.Backend.Negocio.EntidadesNegocio;
using System.Windows.Forms;

namespace Picachos.Frontend.Vistas.Productos
{
    public partial class ReportesPT : System.Web.UI.Page
    {
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
        public void ExtTablaEntradaPT()
        {
            vgridConsultaES.DataSource = ReglasNegocioEySProductos.GetInstancia().getTablaEntrada();
            vgridConsultaES.DataBind();
        }//cierra tabla general de materia prima

        public void ExtTablaSalidaPT()
        {
            vgridConsultaES.DataSource = ReglasNegocioEySProductos.GetInstancia().getTablaSalida();
            vgridConsultaES.DataBind();
        }//cierra tabla de salida de materia prima

        public void ExtTablaGeneralPT()
        {
            vgridConsultaES.DataSource = ReglasNegocioEySProductos.GetInstancia().getTablaGeneral();
            vgridConsultaES.DataBind();
        }//cierra tabla de entrada de materia prima

        protected void CFTablas(object sender, GridViewCancelEditEventArgs e)//Recargar tablas de entradas y salidas
        {

            vgridConsultaES.EditIndex = -1;
            ExtTablaGeneralPT();
            ExtTablaSalidaPT();
            ExtTablaEntradaPT();

        }


        protected void radio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radio.SelectedItem.Text == "Entrada")
                 ExtTablaEntradaPT();

            if (radio.SelectedItem.Text == "Salida")
                ExtTablaSalidaPT();

            if (radio.SelectedItem.Text == "General")
                ExtTablaGeneralPT();
               
            
        }

    }//cierra clase de reportes
}//cierra namespace