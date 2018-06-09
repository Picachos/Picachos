/*Elaborado por Roxana Rivera Espinoza*/
/*Ultima modificación:  04/junio/2018*/

//liberias que se utilizaran
using Picachos.Backend.Negocio.EntidadesNegocio;
using Picachos.Backend.Negocio.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


//namespace con su ruta
namespace Picachos.Frontend.Vistas.Inventario
{//abre namespace
    public partial class CosultarInventario : System.Web.UI.Page
    {//abre clase consultar inventario
        protected void Page_Load(object sender, EventArgs e)
        {//abre page load
            

            /*Codigo para la la vusta de consultar inventario*/

            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
              
                if (Session["New"] != null)
                {
                   
                    //Si existe la sesion continuara donde esta
                   ExtDatTabMP();
                   
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }//cierra pageload
        private void ExtDatTabMP()
        {
            /*obtiene las instancias de materia prima para tablas*/
            vgridInventario.DataSource = ReglasNegocioMateriaPrima.GetInstancia().getTablaMP();
            vgridInventario.DataBind();
        }
        protected void CFInventario(object sender, GridViewCancelEditEventArgs e)
        {
           
            vgridInventario.EditIndex = -1;
            //Recargar tabla inventario
            ExtDatTabMP();
        }
        protected void BFInventario(object sender, GridViewDeleteEventArgs e)
        {
            /*Borrado de inventario*/
            int materiaPrimaID = Convert.ToInt32(vgridInventario.DataKeys[e.RowIndex].Values[0]);
            string mensaje = "!Materia Prima Eliminada!";
           ReglasNegocioMateriaPrima.GetInstancia().EliminarInventario(materiaPrimaID);//recibe respuesta de borrar id que no sea el admin
            System.Windows.Forms.MessageBox.Show(mensaje, "Información", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
            vgridInventario.EditIndex = -1;
            ExtDatTabMP();
        }
        protected void EFInventario(object sender, GridViewEditEventArgs e)
        {
           /*tablas para inventario*/
            vgridInventario.EditIndex = e.NewEditIndex;
            ExtDatTabMP();
        }

        protected void AFInventario(object sender, GridViewUpdateEventArgs e)
        {
            /*Tabla para visualizar nombre, exitencia y descripcion*/
            GridViewRow fila = vgridInventario.Rows[e.RowIndex];
            int materiaPrimaID = Convert.ToInt32(vgridInventario.DataKeys[e.RowIndex].Values[0]);
            int productoID = Convert.ToInt32(vgridInventario.DataKeys[e.RowIndex].Values[0]);

            var MateriaPrima = new materiaPrima
            {

                nombreMateria = (fila.FindControl("txbNom") as TextBox).Text,
                existencia = Convert.ToInt32((fila.FindControl("txbExistencia") as TextBox).Text),
                descripcion = (fila.FindControl("txbDescripcion") as TextBox).Text

            };

            string nombreMP = MateriaPrima.nombreMateria.ToString();

            if (MateriaPrima.nombreMateria.Length == 0)//excepciones de campos vacios
            {
                System.Windows.Forms.MessageBox.Show("No se permite datos en blanco", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {

                String mensaje = ReglasNegocioMateriaPrima.GetInstancia().ActualizarInventario(MateriaPrima, materiaPrimaID);
                System.Windows.Forms.MessageBox.Show(mensaje, "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

            }
            vgridInventario.EditIndex = -1;
            ExtDatTabMP();
        }//cierra AFInventario

    }//cierra clase de consultar inventario
}//cierra namespace
