//Creado por Robles Alvarado Sonia , ultima modificacion 08-06-18


//librerias que se utilizaran
using Picachos.Backend.Negocio.EntidadesNegocio;
using Picachos.Backend.Negocio.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

//namespace con ruta
namespace Picachos.Frontend.Vistas.Clientes
{//abre namespace
    public partial class RegistrarClientes : System.Web.UI.Page
    {//abre registrar clientes
        protected void Page_Load(object sender, EventArgs e)
        {//abre pageload
            /*valida la sesion*/
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (Session["new"] != null) //sesion para ingresar
            {
                //Si existe la sesion continuara donde esta
            }
            else
            {
                Response.Redirect("/Vistas/Login/Login.aspx"); //redirecciona a login
            }

        }//cierra pageload

        protected void GuardarCliente(object sender, EventArgs e)
        {
			ReglasNegocioCliente client = new ReglasNegocioCliente();//instanciar desde reglas de negocio
            /*Vista y validacion para guardar cliente*/
            if (IsPostBack && Page.IsValid)
            {

                string mensaje = "";
                if (ReglasNegocioCliente.GetInstancia().BuscarCliente(txbRazonSocial.Text))
                {
                    mensaje = "Esta Razon Social ya existe";
                    MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    txbRazonSocial.Text = "";
                }
                else
                {
					 //Validaciones
                    string checkrfc = txbRFC.Text;
                    string checktelefono = txbTelefono.Text;
                    var Cliente = new cliente 
                    {
                       nombre = txbRazonSocial.Text,
                       rfc = txbRFC.Text,
                       observaciones= txbObservacion.Text,
                       direccion= TextDireccion.Text,
                       telefono= txbTelefono.Text,
                    
                    };
                   
                    if (client.ValidarTel(checktelefono)==true||client.ValidarRFC(checkrfc)==true) {
                        mensaje = "Cantidad de caracteres o dígitos, incorrectos";
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        txbRazonSocial.Text = "";
                        txbRFC.Text = "";
                        TextDireccion.Text = "";
                        txbObservacion.Text = "";
                        txbTelefono.Text = "";

                    } else {
                        ReglasNegocioCliente.GetInstancia().AgregarCliente(Cliente);

                        mensaje = "Cliente registrado";
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                        txbRazonSocial.Text = "";
                        txbRFC.Text = "";
                        TextDireccion.Text = "";
                        txbObservacion.Text = "";
                        txbTelefono.Text = "";

                    }
                    txbRazonSocial.Text = "";
                    txbRFC.Text = "";
                    TextDireccion.Text = "";
                    txbObservacion.Text = "";
                    txbTelefono.Text = "";

                }//fin else

            }//fin PostBack

        }//cierra clase de guardar cliente

        protected void Limpiar(object sender, EventArgs e)
        {

            txbRazonSocial.Text = "";
            txbRFC.Text = "";
            TextDireccion.Text = "";
            txbObservacion.Text = "";
            txbTelefono.Text = "";
        }//cierra limpiar formato

       
    }//cierra registrar clientes
}//cierra namespace