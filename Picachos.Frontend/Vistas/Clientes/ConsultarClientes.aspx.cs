using Picachos.Backend.Negocio.EntidadesNegocio;
using Picachos.Backend.Negocio.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


//namespace ruta
namespace Picachos.Frontend.Vistas.Clientes
{//abre namespace
    public partial class ConsultarClientes : System.Web.UI.Page
    {//abre clase consultar Clientes
        protected void Page_Load(object sender, EventArgs e)
        {//abre page load
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                if (Session["New"] != null)
                {
                    //Si existe la sesion continuara donde esta
                    ExtDatTabCli();
                }//cierra if
                else
                {
                    Response.Redirect("/Vistas/Login/Login.aspx");
                }//cierra else
            }//cierra if
        }//cierra pageload
        private void ExtDatTabCli()
        {
            vgridClientes.DataSource = ReglasNegocioCliente.GetInstancia().getTablaCliente();
            vgridClientes.DataBind();
        }//cierra ExtDatTabUsua

        protected void CFCliente(object sender, GridViewCancelEditEventArgs e)
        {
            vgridClientes.EditIndex = -1;
            //Recargar tabla Clientes
            ExtDatTabCli();
        }//cierra CFClientes

        protected void BFCliente(object sender, GridViewDeleteEventArgs e)
        {
            int clienteID = Convert.ToInt32(vgridClientes.DataKeys[e.RowIndex].Values[0]);

            string mensaje = ReglasNegocioCliente.GetInstancia().EliminarCliente(clienteID);//recibe respuesta de borrar id que no sea el admin
            System.Windows.Forms.MessageBox.Show(mensaje, "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
            vgridClientes.EditIndex = -1;
            ExtDatTabCli();
        }//cierra BFCliente

        protected void EFCliente(object sender, GridViewEditEventArgs e)
        {
            vgridClientes.EditIndex = e.NewEditIndex;
            ExtDatTabCli();
        }//cierra EFCliente

        protected void AFCliente(object sender, GridViewUpdateEventArgs e)
        {//abre AFCliente

            /* Tabla para consultar Clientes*/
            GridViewRow fila = vgridClientes.Rows[e.RowIndex];
            int clienteID = Convert.ToInt32(vgridClientes.DataKeys[e.RowIndex].Values[0]);
            

            var Cliente = new cliente
            {
                nombre = (fila.FindControl("txbNom") as TextBox).Text,
                rfc = (fila.FindControl("txbRFC") as TextBox).Text,
                observaciones = (fila.FindControl("txbObs") as TextBox).Text,
                direccion= (fila.FindControl("txbDir")as TextBox).Text,
                telefono = (fila.FindControl("txbTel") as TextBox).Text
            };

            string nombreCliente = Cliente.nombre.ToString();//ControlNombre.getDatoNombre(clienteID);////para la validacion
            if (Cliente.nombre.Length == 0 || Cliente.rfc.Length == 0 || Cliente.direccion.Length == 0)//excepciones de campos vacios
            {
               
                System.Windows.Forms.MessageBox.Show("No se permite datos en blanco", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                if (ReglasNegocioCliente.GetInstancia().ValidacionRepcliente(nombreCliente, clienteID))//condicion de metodo de nommbre cliente repetido
                {
                    
                    string mensaje = ReglasNegocioCliente.GetInstancia().ValidarCampos(Cliente);
                    if (mensaje.Equals("OK"))
                    {
                        mensaje = ReglasNegocioCliente.GetInstancia().ActualizarCliente(Cliente, clienteID);
                        System.Windows.Forms.MessageBox.Show(mensaje, "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(mensaje, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
                else
                {
                    string mensaje = "Cuenta de existente";
                    System.Windows.Forms.MessageBox.Show(mensaje, "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            vgridClientes.EditIndex = -1;
            ExtDatTabCli();
        }//cierra AFCliente

    }//cierra clase
}//cierra namespace