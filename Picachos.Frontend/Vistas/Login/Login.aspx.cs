//liberias que se utilizaran
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Picachos.Backend.Negocio.EntidadesNegocio;
using Picachos.Backend.Negocio.LogicaNegocio;
using System.Windows.Forms;
using System.Data.SqlClient;

//namespace con su ruta
namespace Picachos.Frontend.Vistas.Login 
{//abre namespace
    public partial class Login : System.Web.UI.Page
    {//abre clase de login
        protected void Page_Load(object sender, EventArgs e)
        {//abre pageload
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

        }//fin Page_Load

      protected void ClickBotonEntrar(object sender, EventArgs e)
        {
                /*codigo apra entra al dar clic en el boton de entrar validando la sesion*/
            EventArgs texto = new EventArgs();
            if (ReglasNegocioUsuario.GetInstancia().ValidarSesion(txbNomUsuario.Text, txbContrasena.Text))
            {
                Session["new"] = txbNomUsuario.Text;
                Response.Redirect("/Vistas/Principal/Principal.aspx");
            } //  if 
            else
            {
                string mensaje = "Nombre de usuario o contraseña incorrecto";
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            } //fin else
            txbNomUsuario.Text = "";
            txbContrasena.Text = "";
        }// fin ClickBotonEntrar*/
    }//cierra clase de login
}//cierra namespace