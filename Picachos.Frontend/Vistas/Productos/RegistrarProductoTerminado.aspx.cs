/*Elaborado por Roxana Rivera Espinoza*/
/*Ultima modificación: 10/06/2018 */
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
                btnAgregarEmpaquetado.Visible = false;
                btnAgregarUnitario.Visible = false;

                txbSelecUno.Visible = false;
                txbSelecDos.Visible = false;
                txbSelecTres.Visible = false;
                txbSelecCuatro.Visible = false;


                btnGuardarUnitario.Visible = false;
                btnGuardarEmpaquetado.Visible = false;


                btnSelecUno.Visible = false;
                btnSelecDos.Visible = false;
                btnSelecTres.Visible = false;
                btnSelecCuatro.Visible = false;


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

            btnAgregarUnitario.Visible = true;
            btnGuardarUnitario.Visible = true;

            txbSelecUno.Visible = false;
            txbSelecDos.Visible = false;
            txbSelecTres.Visible = false;
            txbSelecCuatro.Visible = false;

            btnGuardarEmpaquetado.Visible = false;
            btnAgregarEmpaquetado.Visible = false;
            btnSelecCuatro.Visible = false;


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
        protected void agregarListaUni(object sender, EventArgs e)
        {
            btnAgregarUnitario.Visible = true;
            btnGuardarUnitario.Visible = true;

            btnGuardarEmpaquetado.Visible = false;
            btnAgregarEmpaquetado.Visible = false;
            btnSelecCuatro.Visible = false;
            txbSelecCuatro.Visible = false;


            if (string.IsNullOrEmpty(txbSelecUno.Text))
            {
                txbSelecUno.Text = ddlRegRegPT.SelectedItem.ToString();

                btnSelecUno.Visible = true;
                btnSelecDos.Visible = false;
                btnSelecTres.Visible = false;

                ddlRegRegPT.Visible = true;
                btnAgregarUnitario.Visible = true;

                txbSelecUno.Visible = true;
                txbSelecDos.Visible = false;
                txbSelecTres.Visible = false;


            }
            else
            {
                if (string.IsNullOrEmpty(txbSelecDos.Text))
                {
                    txbSelecDos.Text = ddlRegRegPT.SelectedItem.ToString();

                    btnSelecUno.Visible = true;
                    btnSelecDos.Visible = true;
                    btnSelecTres.Visible = false;

                    ddlRegRegPT.Visible = true;
                    btnAgregarUnitario.Visible = true;

                    txbSelecUno.Visible = true;
                    txbSelecDos.Visible = true;
                    txbSelecTres.Visible = false;
                }
                else
                {
                    txbSelecTres.Text = ddlRegRegPT.SelectedItem.ToString();

                    btnSelecUno.Visible = true;
                    btnSelecDos.Visible = true;
                    btnSelecTres.Visible = true;


                    ddlRegRegPT.Visible = true;
                    btnAgregarUnitario.Visible = true;

                    txbSelecUno.Visible = true;
                    txbSelecDos.Visible = true;
                    txbSelecTres.Visible = true;
                }

            }


        }
        protected void agregarListaEmp(object sender, EventArgs e)
        {
            btnGuardarUnitario.Visible = false;
            btnGuardarEmpaquetado.Visible = true;

            txbSelecCuatro.Text = ddlRegRegPT.SelectedItem.ToString();

            btnSelecUno.Visible = false;
            btnSelecDos.Visible = false;
            btnSelecCuatro.Visible = true;
            btnSelecTres.Visible = false;

            ddlRegRegPT.Visible = true;
            btnAgregarEmpaquetado.Visible = true;

            txbSelecUno.Visible = false;
            txbSelecDos.Visible = false;
            txbSelecCuatro.Visible = true;
            txbSelecTres.Visible = false;

            labCantidad.Visible = true;
            txbCant.Visible = true;


        }

        protected void botonUno(object sender, EventArgs e)
        {
            txbSelecUno.Text = "";
            btnSelecUno.Visible = false;

            ddlRegRegPT.Visible = true;
            btnAgregarUnitario.Visible = true;

            txbSelecUno.Visible = false;
            txbSelecDos.Visible = true;
            txbSelecTres.Visible = true;
        }
        protected void botonDos(object sender, EventArgs e)
        {
            txbSelecDos.Text = "";
            btnSelecDos.Visible = false;

            ddlRegRegPT.Visible = true;
            btnAgregarUnitario.Visible = true;

            txbSelecUno.Visible = true;
            txbSelecDos.Visible = false;
            txbSelecTres.Visible = true;
        }
        protected void botonTres(object sender, EventArgs e)
        {
            txbSelecTres.Text = "";
            btnSelecTres.Visible = false;

            ddlRegRegPT.Visible = true;
            btnAgregarUnitario.Visible = true;

            txbSelecUno.Visible = true;
            txbSelecDos.Visible = true;
            txbSelecTres.Visible = false;
        }

        protected void botonCuatro(object sender, EventArgs e)
        {
            txbSelecCuatro.Text = "";
            btnSelecCuatro.Visible = false;

            ddlRegRegPT.Visible = true;
            btnAgregarEmpaquetado.Visible = true;
            txbCant.Visible = true;
            labCantidad.Visible = true;
            btnGuardarEmpaquetado.Visible = true;

            txbSelecUno.Visible = false;
            txbSelecDos.Visible = false;
            txbSelecTres.Visible = false;

            btnSelecUno.Visible = false;
            btnSelecDos.Visible = false;
            btnSelecTres.Visible = false;
        }



        protected void esEmpaquetado(object sender, EventArgs e)
        {//abre empaquetado
            ddlRegRegPT.Visible = true;

            btnAgregarUnitario.Visible = false;
            btnAgregarEmpaquetado.Visible = true;
            txbSelecUno.Visible = false;
            txbSelecDos.Visible = false;
            txbSelecTres.Visible = false;

            btnGuardarEmpaquetado.Visible = true;
            labCantidad.Visible = true;
            txbCant.Visible = true;


            List<productoTerminado> pt = db.productoTerminado.ToList();
            if (pt.Count > 0)
            {
                ddlRegRegPT.DataValueField = "productoID";
                ddlRegRegPT.DataTextField = "nombreProducto";
                ddlRegRegPT.DataSource = pt;
                ddlRegRegPT.DataBind();
            }

            ddlRegRegPT.Items.Insert(0, new ListItem { Value = "0", Text = "-Seleccione Productos-" });

        }//cierra empaquetado

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txbNombrePT.Text = "";
            txbDesc.Text = "";
            txbSelecUno.Text = "";
            txbSelecDos.Text = "";
            txbSelecTres.Text = "";
            txbSelecCuatro.Text = "";



            btnSelecUno.Visible = false;
            btnSelecDos.Visible = false;
            btnSelecTres.Visible = false;
            btnSelecCuatro.Visible = false;

        }

        protected void GuardarUnitario(object sender, EventArgs e)
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
                            ventaID = null,
                            pedidoID = null,
                            nombreProducto = txbNombrePT.Text,
                            tipo = "UNITARIO",
                            existencia = 0,

                            materiales = txbSelecUno.Text + "," + txbSelecDos.Text + "," + txbSelecTres.Text,
                            descripcionProducto = txbDesc.Text,
                            venta = null,
                        };
                        ReglasNegocioProductosTerminados.GetInstancia().AgregarProducto(productoTerminado);

                        mensaje = "Producto Unitario Registrado";
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        txbNombrePT.Text = "";
                        txbDesc.Text = "";

                        ddlRegRegPT.Visible = false;
                        btnAgregarEmpaquetado.Visible = false;
                        btnAgregarUnitario.Visible = false;

                        txbSelecUno.Visible = false;
                        txbSelecDos.Visible = false;
                        txbSelecTres.Visible = false;
                        txbSelecCuatro.Visible = false;


                        btnGuardarUnitario.Visible = false;
                        btnGuardarEmpaquetado.Visible = false;


                        btnSelecUno.Visible = false;
                        btnSelecDos.Visible = false;
                        btnSelecTres.Visible = false;
                        btnSelecCuatro.Visible = false;


                        labCantidad.Visible = false;
                        txbCant.Visible = false;
                    }
                    else
                    {
                        txbNombrePT.Text = "";
                        txbDesc.Text = "";
                        MessageBox.Show("Nombre de Producto en Existencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        ddlRegRegPT.Visible = true;
                        btnAgregarUnitario.Visible = true;


                        btnGuardarUnitario.Visible = true;
                    }

                }//cierra if
            }//cierra primer else
        }//cierra guardarUnitario

        protected void GuardarEmpaquetado(object sender, EventArgs e)
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
                            ventaID = null,
                            pedidoID = null,
                            nombreProducto = txbNombrePT.Text,
                            tipo = "EMPAQUETADO",
                            existencia = 0,
                            materiales = txbCant.Text + "  Piezas de " + txbSelecCuatro.Text,
                            descripcionProducto = txbDesc.Text,
                            venta = null,
                        };
                        ReglasNegocioProductosTerminados.GetInstancia().AgregarProducto(productoTerminado);

                        mensaje = "Producto Empaquetado Registrado";
                        MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        txbNombrePT.Text = "";
                        txbDesc.Text = "";

                        ddlRegRegPT.Visible = false;
                        btnAgregarEmpaquetado.Visible = false;
                        btnAgregarUnitario.Visible = false;

                        txbSelecUno.Visible = false;
                        txbSelecDos.Visible = false;
                        txbSelecTres.Visible = false;
                        txbSelecCuatro.Visible = false;


                        btnGuardarUnitario.Visible = false;
                        btnGuardarEmpaquetado.Visible = false;


                        btnSelecUno.Visible = false;
                        btnSelecDos.Visible = false;
                        btnSelecTres.Visible = false;
                        btnSelecCuatro.Visible = false;


                        labCantidad.Visible = false;
                        txbCant.Visible = false;
                    }
                    else
                    {
                        txbNombrePT.Text = "";
                        MessageBox.Show("Nombre de Producto en Existencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                }//cierra if
            }
        }//cierra guardarEmpaquetado
    }//cierra producto terminado
}//cierra namespace