/*Elaborado por Roxana Rivera Espinoza*/
/*Ultima modificación:  04/03/2018*/

//liberias que se utilizaran
using Picachos.Backend.Negocio.EntidadesNegocio;
using Picachos.Backend.Negocio.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

//namespace con su ruta
namespace Picachos.Frontend.Vistas.Usuarios
{//abre namespace
    public partial class RegistrarUsuarios : System.Web.UI.Page
    {//abre clase registrar usuarios
        protected void Page_Load(object sender, EventArgs e)
        {//abre pageload

            /*valida la sesion*/
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (Session["new"] != null)
            {
                //Si existe la sesion continuara donde esta
            }
            else
            {
                Response.Redirect("/Vistas/Login/Login.aspx");
            }

        }

        protected void GuardarUsuario(object sender, EventArgs e)
        {
            /*Vista y validacion para guardar usuario*/
            if (IsPostBack && Page.IsValid)
            {

                string mensaje="";
                if (ReglasNegocioUsuario.GetInstancia().BuscarUsuario(txbNomUsua.Text))
                {
                    mensaje = "El Nombre de usuario ya existe";
                    MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    txbNomUsua.Text = "";
                }
                else
                {
                    var Usuario = new usuario
                    {
                        nombre = txbNombre.Text,
                        nombreUsuario = txbNomUsua.Text,
                        contrasena = txbContra.Text,
                        rol = ddlRolRU.SelectedItem.Value
                    };
                    ReglasNegocioUsuario.GetInstancia().AgregarUsuario(Usuario);

                        mensaje = "Usuario registrado";
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                        txbNombre.Text = "";
                        txbNomUsua.Text = "";
                        txbContra.Text = "";
                        txbConfContr.Text = "";

                }//fin else

            }//fin PostBack
            
        }//cierra clase de guardar usuario

        protected void CerrarSesion(object sender, EventArgs e)
        {

            Session["new"] = null;
            Response.Redirect("/Vistas/Login/Login.aspx");
        }//cierra cerrar sesion

        protected void Limpiar(object sender, EventArgs e)
        {

            txbNombre.Text = "";
            txbNomUsua.Text = "";
            txbContra.Text = "";
            txbConfContr.Text = "";
        }//cierra limpiar formato

        protected void SerValContrasena(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ReglasNegocioUsuario.ValidarContra(args.Value);

        }//ServerContrasena

        protected void Pregunta(object sender, ImageClickEventArgs e)
        {
            string mensaje="";

            mensaje = "Debe contener por lo menos seis caracteres, y debe incluir por lo menos una letra minuscula, una mayúscula y un número";
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

        }//cierra pregunta

    }//cierra clase de registrar usuario
}//cierra namespace