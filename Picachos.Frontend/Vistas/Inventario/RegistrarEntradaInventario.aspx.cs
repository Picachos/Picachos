/*Elaborado por Roxana Rivera Espinoza*/
/*Ultima modificación:  04/junio/2018*/

//liberias que se utilizaran
using Picachos.Backend.Negocio.EntidadesNegocio;
using Picachos.Backend.Negocio.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Data;

//namespace con su ruta
namespace Picachos.Frontend.Vistas.Inventario
{//abre namespace

    /*El siguiente codigo es para el registro la entrada a inventario de materia prima*/
    public partial class RegistrarEntradaInventario : System.Web.UI.Page
    {//abre clase

        protected void Page_Load(object sender, EventArgs e)
        {//abre page load
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            PicachosEntidades db = new PicachosEntidades();
            if (!IsPostBack)
            {

                if (Session["New"] != null)
                {//Si existe la sesion continuara donde esta
                    List<materiaPrima> mp = db.materiaPrima.ToList();
                    if (mp.Count > 0)
                    {
                        ddlRegEySInv.DataValueField = "materiaPrimaID";
                        ddlRegEySInv.DataTextField = "nombreMateria";
                        ddlRegEySInv.DataSource = mp;
                        ddlRegEySInv.DataBind();
                    }
                    
                    ddlRegEySInv.Items.Insert(0,new ListItem{Value ="0", Text="-Seleccion-"});
                   
                    
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }//cierra if Ispostback
        }//cierra pageload

        

        protected void ValidarOpcion(object sender, EventArgs e)
        {//abre validacion de opcion

            /*Muestra la validacion de la opcion que se escogera por medio de instancias y segun la opcion que se escoja*/
            string nombreMateria = ddlRegEySInv.SelectedItem.ToString();
            string aux = ddlEoSInv.SelectedItem.ToString();
          
            if(aux.Equals("Entrada")){
               int existe=ReglasNegocioEntradaSalidaMP.GetInstancia().getMateriaID(nombreMateria);
                if (existe > 0)
                {
                    int materiaPrimaID = existe;
                    int AuxExistencia = ReglasNegocioEntradaSalidaMP.GetInstancia().GetCantidad(nombreMateria);
                    int temp = 0;

                    if (!int.TryParse(txbCant.Text, out temp)) //If para saber si el campo fue llenado con numeros
                    {

                        MessageBox.Show("Agrege valor Numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {
                        var entrada = new entradasalidaMateriaprima
                       {
                           materiaPrimaID = existe,
                           observacion = txbDesc.Text,
                           fecha = DateTime.Today,
                           cantidadES = Convert.ToInt32(txbCant.Text),

                       };
                        if (Convert.ToInt32(txbCant.Text) > 0)
                        {

                            ReglasNegocioEntradaSalidaMP.GetInstancia().AgregarEntrada(entrada);
                            var materiaPrima = new materiaPrima
                            {
                                productoID = null,
                                nombreMateria = ddlRegEySInv.SelectedItem.ToString(),
                                existencia = AuxExistencia + (Convert.ToInt32(txbCant.Text)),
                                descripcion = ReglasNegocioMateriaPrima.GetInstancia().getDescripcionMP(nombreMateria),

                            };
                            ReglasNegocioMateriaPrima.GetInstancia().ActualizarInventario(materiaPrima, materiaPrimaID);
                            String mensaje = "Entrada Exitosa";
                            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }
                        else
                        {
                            String mensaje = "No permite registros Negativos";
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }
                    }
                    
                }
                txbDesc.Text = "";
                txbCant.Text = "";
                
            }//cierra opcion de entrada

            if (aux.Equals("Salida")){
               
                int existe = ReglasNegocioEntradaSalidaMP.GetInstancia().getMateriaID(nombreMateria);
                if (existe > 0)
                {
                    int materiaPrimaID = existe;
                    int AuxExistencia = ReglasNegocioEntradaSalidaMP.GetInstancia().GetCantidad(nombreMateria);
                    int temp = 0;

                    if (!int.TryParse(txbCant.Text, out temp)) //If para saber si el campo fue llenado con numeros
                    {

                        MessageBox.Show("Agrege valor Numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {

                        var entrada = new entradasalidaMateriaprima
                        {
                            materiaPrimaID = existe,
                            observacion = txbDesc.Text,
                            fecha = DateTime.Today,
                            cantidadES = Convert.ToInt32(txbCant.Text),

                        };
                        if (existe >= (Convert.ToInt32(txbCant.Text)) && Convert.ToInt32(txbCant.Text) > 0)
                        {
                            ReglasNegocioEntradaSalidaMP.GetInstancia().AgregarEntrada(entrada);
                            var materiaPrima = new materiaPrima
                            {
                                productoID = null,
                                nombreMateria = ddlRegEySInv.SelectedItem.ToString(),
                                existencia = AuxExistencia + (Convert.ToInt32("-" + txbCant.Text)),
                                descripcion = ReglasNegocioMateriaPrima.GetInstancia().getDescripcionMP(nombreMateria),
                            };
                            ReglasNegocioMateriaPrima.GetInstancia().ActualizarInventario(materiaPrima, materiaPrimaID);
                            String mensaje = "Salida Exitosa";
                            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                        }
                        if (Convert.ToInt32(txbCant.Text) <= 0)
                        {
                            String mensaje = "No permite registros Negativos";
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }
                        if (existe < (Convert.ToInt32(txbCant.Text)))
                        {
                            String mensaje = "!La cantidad de salida es mayor que la cantidad en existencia!\n \t CANTIDAD EXISTENTE: " + AuxExistencia;
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }
                    }
                }
                txbDesc.Text = "";
                txbCant.Text = "";
                
            }//cierra opcion de salida
            if (nombreMateria.Equals("-Seleccion-"))
            {
                String mensaje = "Seleccione Materia Prima";
                MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
           

        }//cierra validar opcion

        protected void Limpiar(object sender, EventArgs e)
        {
            txbCant.Text = "";
            txbDesc.Text ="";
        }//cierra limpiar
  
    }//cierra registrar entrada inventario
}//cierra namespace