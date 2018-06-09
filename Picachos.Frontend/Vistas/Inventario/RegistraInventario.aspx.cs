/*Elaborado por Roxana Rivera Espinoza*/
/*Ultima modificación:  04/junio/2018*/


//liberias a utulizar
using Picachos.Backend.Negocio.EntidadesNegocio;
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
    public partial class RegistraInventario : System.Web.UI.Page
    {//abre clase de registrar inventario
        protected void Page_Load(object sender, EventArgs e)
        {//abre pageload

            /*validacion de sesion*/
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (Session["new"] != null)
            {
                //Si existe la sesion continuara donde esta
            }
            else
            {
                Response.Redirect("/Vistas/Login/Login.aspx");
            }
        }//cierra pageload


        protected void Limpiar(object sender, EventArgs e)
        {

            txbNombreMP.Text = "";
            txbDesc.Text = "";

        }//cierra limpiar campos del formato

        protected void GuardarMP(object sender, EventArgs e)
        {
            /*guarda materia prima y valida segun lo requerido*/
            int temp = 0;

            if (int.TryParse(txbNombreMP.Text, out temp)) //If para saber si el campo fue llenado con numeros
            {

                MessageBox.Show("Nombre de Materia Prima invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {

                if (IsPostBack && Page.IsValid)
                {
                   Boolean aux=ReglasNegocioMateriaPrima.GetInstancia().BusquedaInventarioNombre(txbNombreMP.Text);
                   string mensaje;
                   if (!aux)
                   {
                       var materiaPrima = new materiaPrima
                       {
                           productoID = null,
                           nombreMateria = txbNombreMP.Text,
                           existencia = 0,
                           descripcion = txbDesc.Text,
                           entradasalidaMateriaprima= null,

                       };
                       ReglasNegocioMateriaPrima.GetInstancia().AgregarInventario(materiaPrima);

                       mensaje = "Materia Prima registrada";
                       MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                   }
                   else {
                       MessageBox.Show("Nombre de Materia Prima Existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                   }
                    txbNombreMP.Text = "";
                    txbDesc.Text = "";

                }//cierra if
            }

        }//cierra guardarMP

        



    }//cierra clase de registar
}//cierra namespace