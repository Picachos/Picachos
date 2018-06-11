/*Elaborado por Roxana Rivera Espinoza*/
/*Ultima modificación:  10/junio/2018*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Picachos.Backend.Negocio.EntidadesNegocio;
using Picachos.Backend.Negocio.LogicaNegocio;
using System.Windows.Forms;
//namespace con su ruta
namespace Picachos.Frontend.Vistas.Productos
{//abre namespace

    /*El siguiente codigo es para el registro la entrada a inventario de materia prima*/
    public partial class EntradasYsalidas : System.Web.UI.Page
    {//abre clase

        protected void Page_Load(object sender, EventArgs e)
        {//abre page load
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            PicachosEntidades db = new PicachosEntidades();
            if (!IsPostBack)
            {

                if (Session["New"] != null)
                {//Si existe la sesion continuara donde esta
                    List<productoTerminado> pt = db.productoTerminado.ToList();
                    if (pt.Count > 0)
                    {

                        ddlEySPT.DataValueField = "productoID";
                        ddlEySPT.DataTextField = "nombreProducto";
                        ddlEySPT.DataSource = pt;
                        ddlEySPT.DataBind();
                    }

                    ddlEySPT.Items.Insert(0, new ListItem { Value = "0", Text = "-Seleccione Productos-" });


                }
                else
                {
                    Response.Redirect("/Vistas/Login/Login.aspx");
                }
            }//cierra if Ispostback
        }//cierra pageload



        protected void ValidarOpcion(object sender, EventArgs e)
        {//abre validacion de opcion

            /*Muestra la validacion de la opcion que se escogera por medio de instancias y segun la opcion que se escoja*/
            string nombreProducto = ddlEySPT.SelectedItem.ToString();
            string aux = radio.SelectedItem.ToString();
            if (radio.SelectedItem.ToString().Equals(null)) { 
                 String mensaje = "Seleccione Opcion de Registro";
                            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                       
            }

            if (aux.Equals("Entrada"))
            {
                int existe = ReglasNegocioEySProductos.GetInstancia().getProductoID(nombreProducto);
                if (existe > 0)
                {
                    int productoID = existe;
                    int AuxExistencia = ReglasNegocioEySProductos.GetInstancia().GetCantidad(nombreProducto);
                   
                    int tept = 0;

                    if (!int.TryParse(txbCantidad.Text, out tept)) //If para saber si el capto fue llenado con numeros
                    {

                        MessageBox.Show("Agrege valor Numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {
                        var entrada = new productoTerminadoES
                        {
                           productoID = existe,
                            observacion = txbObservacion.Text,
                           fechaES = DateTime.Now,
                            cantidadES = Convert.ToInt32(txbCantidad.Text),

                        };
                        if (Convert.ToInt32(txbCantidad.Text) > 0)
                        {

                           
                           
                            var productos = new productoTerminado
                            {
                                productoID = existe,
                                nombreProducto = ddlEySPT.SelectedItem.ToString(),
                                materiales = ReglasNegocioProductosTerminados.GetInstancia().getMateriales(nombreProducto),
                                tipo = ReglasNegocioProductosTerminados.GetInstancia().getTipo(nombreProducto),
                                existencia = AuxExistencia + (Convert.ToInt32(txbCantidad.Text)),
                                descripcionProducto = ReglasNegocioEySProductos.GetInstancia().getDescripcionPT(nombreProducto),
                            };
                            if (productos.tipo.Equals("UNITARIO"))
                            {

                                String MaterialesAux = ReglasNegocioProductosTerminados.GetInstancia().getMateriales(nombreProducto);

                                Char delimiter = ',';
                                String[] substrings = MaterialesAux.Split(delimiter);
                                for (int x = 0; x < 3; x++)
                                {
                                    if (substrings[x] != null)
                                    {
                                        int ID = ReglasNegocioMateriaPrima.GetInstancia().getDatoID(substrings[x]);
                                        int ExtMateriaP = ReglasNegocioMateriaPrima.GetInstancia().getDatoCantidad(substrings[x]);

                                        var materiaPrima = new materiaPrima
                                        {
                                            productoID = null,
                                            nombreMateria = substrings[x],
                                            existencia = ExtMateriaP - (Convert.ToInt32(txbCantidad.Text)),
                                            descripcion = ReglasNegocioMateriaPrima.GetInstancia().getDescripcionMP(substrings[x]),
                                        };

                                        ReglasNegocioMateriaPrima.GetInstancia().ActualizarInventario(materiaPrima, ID);
                                    
                                      }
                                }
                                ReglasNegocioProductosTerminados.GetInstancia().ActualizarPT(productos, productoID);
                                ReglasNegocioEySProductos.GetInstancia().AgregarEntrada(entrada);


                                String mensaje = "Entrada Exitosa";
                                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            }
                            else { 
                                     String MaterialesAux= ReglasNegocioProductosTerminados.GetInstancia().getMateriales(nombreProducto);
                           
                                    Char delimiter = ' ';
                                    String[] substrings = MaterialesAux.Split(delimiter);

                                            int ID = ReglasNegocioProductosTerminados.GetInstancia().getDatoID(substrings[3]);
                                            int ExtPT = ReglasNegocioProductosTerminados.GetInstancia().getDatoCantidad(substrings[3]);
                                            int ARestar = Convert.ToInt32(substrings[0]) * Convert.ToInt32(txbCantidad.Text);
                                            
                                            var producto = new productoTerminado
                                            {
                                                productoID = existe,
                                                nombreProducto = substrings[3],
                                                materiales = ReglasNegocioProductosTerminados.GetInstancia().getMateriales(nombreProducto),
                                                tipo = "UNITARIO",
                                                existencia = ExtPT + (Convert.ToInt32("-" + ARestar)),
                                                descripcionProducto = ReglasNegocioEySProductos.GetInstancia().getDescripcionPT(nombreProducto),
                                            };
                                    
                                            ReglasNegocioProductosTerminados.GetInstancia().ActualizarPT(producto, ID);
                                       
                                    ReglasNegocioProductosTerminados.GetInstancia().ActualizarPT(productos, productoID);
                                    ReglasNegocioEySProductos.GetInstancia().AgregarEntrada(entrada);


                                    String mensajess = "Entrada Exitosa";
                                    MessageBox.Show(mensajess, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                                    }
                     }else
                        {
                            String mensaje = "No permite registros Negativos";
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }
                    }

                }
                txbCantidad.Text = "";
                txbObservacion.Text = "";

            }//cierra opcion de entrada



            if (aux.Equals("Salida"))
            {

                int existe = ReglasNegocioEySProductos.GetInstancia().getProductoID(nombreProducto);
                if (existe > 0)
                {
                    int productoID = existe;
                    int AuxExistencia = ReglasNegocioEySProductos.GetInstancia().GetCantidad(nombreProducto);
                    int temp = 0;

                    if (!int.TryParse(txbCantidad.Text, out temp)) //If para saber si el campo fue llenado con numeros
                    {

                        MessageBox.Show("Agrege valor Numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {

                        var salida = new productoTerminadoES
                        {
                            productoID = existe,
                            observacion = txbObservacion.Text,
                            fechaES = DateTime.Now,
                            cantidadES = -Convert.ToInt32(txbCantidad.Text),


                        };
                        if (AuxExistencia >= (Convert.ToInt32(txbCantidad.Text)) && Convert.ToInt32(txbCantidad.Text) > 0)
                        {
                            ReglasNegocioEySProductos.GetInstancia().AgregarSalida(salida);
                            var productos = new productoTerminado
                            {
                                productoID = existe,
                                nombreProducto = ddlEySPT.SelectedItem.ToString(),
                                materiales = ReglasNegocioProductosTerminados.GetInstancia().getMateriales(nombreProducto),
                                tipo = ReglasNegocioProductosTerminados.GetInstancia().getTipo(nombreProducto),
                                existencia = AuxExistencia + (Convert.ToInt32("-" + txbCantidad.Text)),
                                descripcionProducto = ReglasNegocioEySProductos.GetInstancia().getDescripcionPT(nombreProducto),
                            };
                            ReglasNegocioProductosTerminados.GetInstancia().ActualizarPT(productos, productoID);
                            String mensaje = "Salida Exitosa";
                            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                        }
                        if (Convert.ToInt32(txbCantidad.Text) <= 0)
                        {
                            String mensaje = "No permite registros Negativos o Nulos";
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }
                        if (AuxExistencia < (Convert.ToInt32(txbCantidad.Text)))
                        {
                            String mensaje = "!La cantidad de salida es mayor que la cantidad en existencia!\n \t CANTIDAD EXISTENTE: " + AuxExistencia;
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }
                    }
                }

                txbCantidad.Text = "";
                txbObservacion.Text = "";
            }//cierra opcion de salida
            if (nombreProducto.Equals("-Seleccion-"))
            {
                String mensaje = "Seleccione Producto";
                MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }

        }//cierra validar opcion

        protected void Limpiar(object sender, EventArgs e)
        {
            txbObservacion.Text = "";
            txbCantidad.Text = "";
            
        }//cierra limpiar

    }//cierra registrar entrada inventario
}//cierra namespace