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

//namespace con su ruta
namespace Picachos.Frontend.Vistas.Productos
{//abre namespace

    /*Codigo para registrar producto terminado */


    public partial class RegistrarProductoTerminado : System.Web.UI.Page
    {//abre Registrar producto terminado
        PicachosEntidades db = new PicachosEntidades();
        protected void Page_Load(object sender, EventArgs e)
        {//abre page load
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
             
            if (Session["new"] != null)
            { //Si existe la sesion continuara donde esta
               

                ddlRegRegPT.Visible = false;
                btnAgregar.Visible = false;

                txbSelecUno.Visible = false;
                txbSelecDos.Visible = false;
                txbSelecTres.Visible = false;
              

                btnSelecUno.Visible = false;
                btnSelecDos.Visible = false;
                btnSelecTres.Visible = false;
                

                labCantidad.Visible = false;
                txbCant.Visible = false;



            }
            else
            {
                Response.Redirect("/Vistas/Login/Login.aspx");
            }

        }//cierra pageload

        protected void esUnitario(object sender, EventArgs e)
        {//abre es unitario

            
            ddlRegRegPT.Visible = true;
            btnAgregar.Visible = true;

            txbSelecUno.Visible = false;
            txbSelecDos.Visible = false;
            txbSelecTres.Visible = false;
           


            List<materiaPrima> mp = db.materiaPrima.ToList();
            if (mp.Count > 0)
            {
                ddlRegRegPT.DataValueField = "materiaPrimaID";
                ddlRegRegPT.DataTextField = "nombreMateria";
                ddlRegRegPT.DataSource = mp;
                ddlRegRegPT.DataBind();
            }

            ddlRegRegPT.Items.Insert(0, new ListItem { Value = "0", Text = "-Seleccione Materias-" });

                     


        }//cierra esUnitario
        protected void agregarLista(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txbSelecUno.Text))
            {
                txbSelecUno.Text = ddlRegRegPT.SelectedItem.ToString();

                btnSelecUno.Visible = true;
                btnSelecDos.Visible = false;
                btnSelecTres.Visible = false;

                ddlRegRegPT.Visible = true;
                btnAgregar.Visible = true;

                txbSelecUno.Visible = true;
                txbSelecDos.Visible = false;
                txbSelecTres.Visible = false;
               
             }else
            {
                if (string.IsNullOrEmpty(txbSelecDos.Text))
                {
                    txbSelecDos.Text = ddlRegRegPT.SelectedItem.ToString();

                    btnSelecUno.Visible = true;
                    btnSelecDos.Visible = true;
                    btnSelecTres.Visible = false;

                    ddlRegRegPT.Visible = true;
                    btnAgregar.Visible = true;

                    txbSelecUno.Visible = true;
                    txbSelecDos.Visible = true;
                    txbSelecTres.Visible = false;
                }else{
                    txbSelecTres.Text = ddlRegRegPT.SelectedItem.ToString();

                    btnSelecUno.Visible = true;
                    btnSelecDos.Visible = true;
                    btnSelecTres.Visible = true;


                    ddlRegRegPT.Visible = true;
                    btnAgregar.Visible = true;

                    txbSelecUno.Visible = true;
                    txbSelecDos.Visible = true;
                    txbSelecTres.Visible = true;
                }
                
            }
            
            
        }

        protected void botonUno(object sender, EventArgs e)
        {
            txbSelecUno.Text = "";
            btnSelecUno.Visible = false;
            btnSelecDos.Visible = false;
            btnSelecTres.Visible = false;


            ddlRegRegPT.Visible = true;
            btnAgregar.Visible = true;

            txbSelecUno.Visible = false;
            txbSelecDos.Visible = true;
            txbSelecTres.Visible = true;
        }
        protected void botonDos(object sender, EventArgs e)
        {
            txbSelecDos.Text = "";
            btnSelecUno.Visible = true;
            btnSelecDos.Visible = false;
            btnSelecTres.Visible = false;


            ddlRegRegPT.Visible = true;
            btnAgregar.Visible = true;

            txbSelecUno.Visible = true;
            txbSelecDos.Visible = false;
            txbSelecTres.Visible = true;
        }
        protected void botonTres(object sender, EventArgs e)
        {
            txbSelecTres.Text = "";
            btnSelecUno.Visible = true;
            btnSelecDos.Visible = true;
            btnSelecTres.Visible = false;


            ddlRegRegPT.Visible = true;
            btnAgregar.Visible = true;

            txbSelecUno.Visible = true;
            txbSelecDos.Visible = true;
            txbSelecTres.Visible = true;
        }

        /*
         * 
         * String nombreMpdos = ddlRegRegPT.SelectedItem.ToString();
                 txbSelecDos.Text = nombreMpdos;
                 if (string.IsNullOrEmpty(txbSelecDos.Text))
                 {
                     String nombreMpTres = ddlRegRegPT.SelectedItem.ToString();
                     txbSelecTres.Text = nombreMpTres;
                 }
         * 
         * protected void esEmpaquetado(object sender, EventArgs e)
         {//abre empaquetado

             txbSelecUno.Visible = false;
             btnSelecUno.Visible = false;

             ddlRegRegPT.Visible = true;
             btnAgregar.Visible = true;

           

             labCantidad.Visible = true;
             txbCant.Visible = true;
            
         }//cierra empaquetado*/

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txbNombrePT.Text="";
            txbDesc.Text="";
            txbSelecUno.Text = "";
            txbSelecDos.Text = "";
            txbSelecTres.Text = "";


            btnSelecUno.Visible = false;
            btnSelecDos.Visible = false;
            btnSelecTres.Visible = false;

        }

        protected void GuardarPT(object sender, EventArgs e)
        {

            int temp = 0;

            if (int.TryParse(txbNombrePT.Text, out temp)) //If para saber si el campo fue llenado con numeros
            {

                MessageBox.Show("Nombre Invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {

                if (IsPostBack && Page.IsValid)
                {
                    bool aux = ReglasNegocioProductosTerminados.GetInstancia().BusquedaProducto(txbNombrePT.Text);
                    string mensaje;
                    if (!aux)
                    {
                        var productoTerminado = new productoTerminado
                        {
                            /*ventaID = null,
                            nombreProducto = txbNombrePT.Text,
                            descripcionProducto = txbDesc.Text,
                            precioProducto = null,
                            cantidad = 0,
                            fechaEntrada = null,
                            fechaSalida = null,
                            observacion = null,
                            materiaPrimas = txbSelecTres,
                            pedidoes = null,
                            ventas = null,*/

                        };
                        ReglasNegocioProductosTerminados.GetInstancia().AgregarProducto(productoTerminado);

                        mensaje = "Producto Terminado registrado";
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                    }
                    else
                    {
                        txbNombrePT.Text = "";
                        MessageBox.Show("Nombre de Producto en Existencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                    }

                }//cierra if
            }

        }
    }//cierra producto terminado
}//cierra namespace