/*Elaborado por Roxana Rivera Espinoza*/
/*Ultima modificación: 09/06/2018 */
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
namespace Picachos.Frontend.Vistas.Productos
{//abre namespace
    public partial class ConsultarProductosTerminados : System.Web.UI.Page
    {//abre clase para consultar productos terminados
        protected void Page_Load(object sender, EventArgs e)
        {//abre pageload

            /*validacion de sesion*/
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {

                if (Session["new"] != null)
                {
                    //Si existe la sesion continuara donde esta
                    ExtDatTabPT();

                }
                else
                {
                    Response.Redirect("/Vistas/Login/Login.aspx");
                }
            }
        }//cierra pageload
        private void ExtDatTabPT()
        {
            /*obtiene las instancias de productos termiandos para tablas*/
            vgridProductos.DataSource = ReglasNegocioProductosTerminados.GetInstancia().getTablaGeneral();
            vgridProductos.DataBind();
        }
        protected void CFProductos(object sender, GridViewCancelEditEventArgs e)
        {
           
            vgridProductos.EditIndex = -1;
            //Recargar tabla productos terminados
            ExtDatTabPT();
        }
        protected void BFProductos(object sender, GridViewDeleteEventArgs e)
        {
            /*Borrado de inventario*/
            int productoID = Convert.ToInt32(vgridProductos.DataKeys[e.RowIndex].Values[0]);
            string mensaje = "!Producto Terminado Eliminado!";
            ReglasNegocioProductosTerminados.GetInstancia().EliminarProducto(productoID);
            System.Windows.Forms.MessageBox.Show(mensaje, "Información", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
            vgridProductos.EditIndex = -1;
            ExtDatTabPT();
        }
        protected void EFProductos(object sender, GridViewEditEventArgs e)
        {
           /*tablas para productos termiandos*/
            vgridProductos.EditIndex = e.NewEditIndex;
            ExtDatTabPT();
        }

        protected void AFProductos(object sender, GridViewUpdateEventArgs e)
        {
            /*Tabla para visualizar nombre, exitencia y descripcion*/
            GridViewRow fila = vgridProductos.Rows[e.RowIndex];
            int productoID = Convert.ToInt32(vgridProductos.DataKeys[e.RowIndex].Values[0]);
            
            var ProductoTerminado = new productoTerminado
            {

                nombreProducto = (fila.FindControl("txbNom") as TextBox).Text,
                descripcionProducto = (fila.FindControl("txbDescripcion") as TextBox).Text,
                materiales = (fila.FindControl("txbMateriales") as TextBox).Text,
                tipo = (fila.FindControl("txbTipo") as TextBox).Text,
                existencia = Convert.ToInt32((fila.FindControl("txbExistencia") as TextBox).Text),
                

            };

            string nombrePT = ProductoTerminado.nombreProducto.ToString();

            if (ProductoTerminado.nombreProducto.Length == 0)//excepciones de campos vacios
            {
                System.Windows.Forms.MessageBox.Show("No se permite datos en blanco", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {

                String mensaje = ReglasNegocioProductosTerminados.GetInstancia().ActualizarPT(ProductoTerminado, productoID);
                System.Windows.Forms.MessageBox.Show(mensaje, "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

            }
            vgridProductos.EditIndex = -1;
            ExtDatTabPT();
        }//cierra AFProductos
    }//cierra clase de consultar productos terminados
}//cierra namespace