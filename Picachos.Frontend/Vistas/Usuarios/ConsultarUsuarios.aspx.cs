/*Elaborado por Roxana Rivera Espinoza*/
/*Ultima modificación:  04/03/2018*/

//librerias que se utilizaran
using Picachos.Backend.Negocio.EntidadesNegocio;
using Picachos.Backend.Negocio.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//namespace ruta
namespace Picachos.Frontend.Vistas.Usuarios
{//abre namespace
    public partial class ConsultarUsuarios : System.Web.UI.Page
    {//abre clase consultar usuarios
        protected void Page_Load(object sender, EventArgs e)
        {//abre page load
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                if (Session["New"] != null)
                {
                    //Si existe la sesion continuara donde esta
                    ExtDatTabUsua();
                }//cierra if
                else
                {
                    Response.Redirect("Login.aspx");
                }//cierra else
            }//cierra if
        }//cierra pageload
        private void ExtDatTabUsua()
        {
            vgridUsuario.DataSource = ReglasNegocioUsuario.GetInstancia().getTablaUsuario();
            vgridUsuario.DataBind();
        }//cierra ExtDatTabUsua

        protected void CFUsuario(object sender, GridViewCancelEditEventArgs e)
        {
            vgridUsuario.EditIndex = -1;
            //Recargar tabla usuario
            ExtDatTabUsua();
        }//cierra CFUsuario

        protected void BFUsuario(object sender, GridViewDeleteEventArgs e)
        {
            int usuarioID = Convert.ToInt32(vgridUsuario.DataKeys[e.RowIndex].Values[0]);
            
            string mensaje = ReglasNegocioUsuario.GetInstancia().EliminarUsuario(usuarioID);//recibe respuesta de borrar id que no sea el admin
            System.Windows.Forms.MessageBox.Show(mensaje, "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
            vgridUsuario.EditIndex = -1;
            ExtDatTabUsua();
        }//cierra BFUsuario

        protected void EFUsuario(object sender, GridViewEditEventArgs e)
        {
            vgridUsuario.EditIndex = e.NewEditIndex;
            ExtDatTabUsua();
        }//cierra EFUsuario

        protected void AFUsuario(object sender, GridViewUpdateEventArgs e)
        {//abre AFUsuario

            /* Tabla para consultar usuarios*/
            GridViewRow fila = vgridUsuario.Rows[e.RowIndex];
            int usuarioID = Convert.ToInt32(vgridUsuario.DataKeys[e.RowIndex].Values[0]);
            string contrasena = ReglasNegocioUsuario.GetInstancia().GetContrasena(usuarioID);

            var Usuario = new usuario
            {
                nombre = (fila.FindControl("txbNom") as TextBox).Text,
                nombreUsuario = (fila.FindControl("txbNomUsu") as TextBox).Text,
                contrasena = (fila.FindControl("txbContra") as TextBox).Text,
                rol = (fila.FindControl("ddlRol") as DropDownList).Text
            };
            
            string nombreUsuario = Usuario.nombreUsuario.ToString();//ControlUsuario.getDatoNombre(usuarioID);////para la validacion
            if (Usuario.nombre.Length == 0 || Usuario.nombreUsuario.Length == 0)//excepciones de campos vacios
            {
                Usuario.contrasena = contrasena;//se mantiene la misma contraseña
                System.Windows.Forms.MessageBox.Show("No se permite datos en blanco", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                if (ReglasNegocioUsuario.GetInstancia().ValidacionRepusuario(nombreUsuario,usuarioID))//condicion de metodo de nommbre usuario repeido
                {
                    if (Usuario.contrasena.Length == 0 || Usuario.contrasena==null)
                        Usuario.contrasena = contrasena;
                    string mensaje = ReglasNegocioUsuario.GetInstancia().ValidarCampos(Usuario);
                    if (mensaje.Equals("OK"))
                    {
                        mensaje = ReglasNegocioUsuario.GetInstancia().ActualizarUsuario(Usuario, usuarioID, contrasena);
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
            vgridUsuario.EditIndex = -1;
            ExtDatTabUsua();
        }//cierra AFUsuario

    }//cierra clase
}//cierra namespace