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

namespace Picachos.Frontend.Vistas.Ventas
{
    public partial class RegistrarVenta : System.Web.UI.Page
    {
       
       
                 
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            PicachosEntidades db = new PicachosEntidades();
            if (!IsPostBack)
            {
               

                if (Session["New"] != null)
                {//Si existe la sesion continuara donde esta



                    List<cliente> cl = db.cliente.ToList();
                    if (cl.Count > 0)
                    {   
                        ddlRegVenta.DataValueField = "clienteID";
                        ddlRegVenta.DataTextField = "nombre";
                        ddlRegVenta.DataSource = cl;
                        ddlRegVenta.DataBind();
                    }
                    ddlRegVenta.Items.Insert(0, new ListItem { Value = "0", Text = "-Seleccion-" });



                    List<productoTerminado> pt = db.productoTerminado.ToList();
                    if (pt.Count > 0)
                    { 
                        ddlConceptoCero.DataValueField = "productoID";
                        ddlConceptoCero.DataTextField = "nombreProducto";
                        ddlConceptoCero.DataSource = pt;
                        ddlConceptoCero.DataBind();

                        ddlConceptoUno.DataValueField = "productoID";
                        ddlConceptoUno.DataTextField = "nombreProducto";
                        ddlConceptoUno.DataSource = pt;
                        ddlConceptoUno.DataBind();

                        ddlConceptoDos.DataValueField = "productoID";
                        ddlConceptoDos.DataTextField = "nombreProducto";
                        ddlConceptoDos.DataSource = pt;
                        ddlConceptoDos.DataBind();

                        ddlConceptoTres.DataValueField = "productoID";
                        ddlConceptoTres.DataTextField = "nombreProducto";
                        ddlConceptoTres.DataSource = pt;
                        ddlConceptoTres.DataBind();

                        ddlConceptoCuatro.DataValueField = "productoID";
                        ddlConceptoCuatro.DataTextField = "nombreProducto";
                        ddlConceptoCuatro.DataSource = pt;
                        ddlConceptoCuatro.DataBind();

                        ddlConceptoCinco.DataValueField = "productoID";
                        ddlConceptoCinco.DataTextField = "nombreProducto";
                        ddlConceptoCinco.DataSource = pt;
                        ddlConceptoCinco.DataBind();

                        ddlConceptoSeis.DataValueField = "productoID";
                        ddlConceptoSeis.DataTextField = "nombreProducto";
                        ddlConceptoSeis.DataSource = pt;
                        ddlConceptoSeis.DataBind();

                        ddlConceptoSiete.DataValueField = "productoID";
                        ddlConceptoSiete.DataTextField = "nombreProducto";
                        ddlConceptoSiete.DataSource = pt;
                        ddlConceptoSiete.DataBind();

                        ddlConceptoOcho.DataValueField = "productoID";
                        ddlConceptoOcho.DataTextField = "nombreProducto";
                        ddlConceptoOcho.DataSource = pt;
                        ddlConceptoOcho.DataBind();

                        ddlConceptoNueve.DataValueField = "productoID";
                        ddlConceptoNueve.DataTextField = "nombreProducto";
                        ddlConceptoNueve.DataSource = pt;
                        ddlConceptoNueve.DataBind();

                        ddlConceptoDiez.DataValueField = "productoID";
                        ddlConceptoDiez.DataTextField = "nombreProducto";
                        ddlConceptoDiez.DataSource = pt;
                        ddlConceptoDiez.DataBind();
                    }
                        ddlConceptoCero.Items.Insert(0, new ListItem { Value = "0", Text = "-Seleccion-" });
                        ddlConceptoUno.Items.Insert(0, new ListItem { Value = "0", Text = "-Seleccion-" });
                        ddlConceptoDos.Items.Insert(0, new ListItem { Value = "0", Text = "-Seleccion-" });
                        ddlConceptoTres.Items.Insert(0, new ListItem { Value = "0", Text = "-Seleccion-" });
                        ddlConceptoCuatro.Items.Insert(0, new ListItem { Value = "0", Text = "-Seleccion-" });
                        ddlConceptoCinco.Items.Insert(0, new ListItem { Value = "0", Text = "-Seleccion-" });
                        ddlConceptoSeis.Items.Insert(0, new ListItem { Value = "0", Text = "-Seleccion-" });
                        ddlConceptoSiete.Items.Insert(0, new ListItem { Value = "0", Text = "-Seleccion-" });
                        ddlConceptoOcho.Items.Insert(0, new ListItem { Value = "0", Text = "-Seleccion-" });
                        ddlConceptoNueve.Items.Insert(0, new ListItem { Value = "0", Text = "-Seleccion-" });
                        ddlConceptoDiez.Items.Insert(0, new ListItem { Value = "0", Text = "-Seleccion-" });
                }
                else
                {
                    Response.Redirect("/Vistas/Login/Login.aspx");
                }

            }
        }

       
        protected void buscar(object sender, EventArgs e)
        {
            
            PicachosEntidades db = new PicachosEntidades();
            labFechaSistema.Text = DateTime.Today.ToString();
            
            string cliente = ddlRegVenta.SelectedItem.ToString();
            txbDom.Text = ReglasNegocioVentas.GetInstancia().getDatosDireccion(cliente);
            txbRFC.Text = ReglasNegocioVentas.GetInstancia().getDatoRFC(cliente);

        



        }

        protected void multiplicarCero(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantCero.Text)) && (!string.IsNullOrEmpty(txbPrecioCero.Text)) && (ddlConceptoCero.Text!="0"))
            {
                if (Convert.ToInt32(txbCantCero.Text) > 0 && Convert.ToInt32(txbPrecioCero.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantCero.Text)) * (Convert.ToInt32(txbPrecioCero.Text));
                    txbImporteCero.Text = total.ToString();
                  
                    labResultado.Text = total.ToString();
                   
                    txbCantUno.Enabled = true;
                    ddlConceptoUno.Enabled = true;
                    txbPrecioUno.Enabled = true;
                }
                else {
                    System.Windows.Forms.MessageBox.Show("Los datos no pueden contener 0", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Faltan datos por llenar", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        protected void multiplicarCeroCant(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantCero.Text)) && (!string.IsNullOrEmpty(txbPrecioCero.Text)) && (ddlConceptoCero.Text != "0"))
            {
                if (Convert.ToInt32(txbCantCero.Text) > 0 && Convert.ToInt32(txbPrecioCero.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantCero.Text)) * (Convert.ToInt32(txbPrecioCero.Text));
                    txbImporteCero.Text = total.ToString();
                    
                    labResultado.Text = total.ToString();
                   
                    txbCantUno.Enabled = true;
                    ddlConceptoUno.Enabled = true;
                    txbPrecioUno.Enabled = true;
                }
            }
        }


        protected void multiplicarUno(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantUno.Text)) && (!string.IsNullOrEmpty(txbPrecioUno.Text)) && (ddlConceptoUno.Text != "0"))
            {
                if (Convert.ToInt32(txbCantUno.Text) > 0 && Convert.ToInt32(txbPrecioUno.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantUno.Text)) * (Convert.ToInt32(txbPrecioUno.Text));
                    txbImporteUno.Text = total.ToString();

                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) + (Convert.ToInt32(txbImporteUno.Text))).ToString();

                    txbCantDos.Enabled = true;
                    ddlConceptoDos.Enabled = true;
                    txbPrecioDos.Enabled = true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Los datos no pueden contener 0", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Faltan datos por llenar", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        protected void multiplicarUnoCant(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantUno.Text)) && (!string.IsNullOrEmpty(txbPrecioUno.Text)) && (ddlConceptoUno.Text != "0"))
            {
                if (Convert.ToInt32(txbCantUno.Text) > 0 && Convert.ToInt32(txbPrecioUno.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantUno.Text)) * (Convert.ToInt32(txbPrecioUno.Text));
                    txbImporteUno.Text = total.ToString();

                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) + (Convert.ToInt32(txbImporteUno.Text))).ToString();

                    txbCantDos.Enabled = true;
                    ddlConceptoDos.Enabled = true;
                    txbPrecioDos.Enabled = true;
                }
            }
        }

        protected void multiplicarDos(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantDos.Text)) && (!string.IsNullOrEmpty(txbPrecioDos.Text)) && (ddlConceptoDos.Text != "0"))
            {
                if (Convert.ToInt32(txbCantDos.Text) > 0 && Convert.ToInt32(txbPrecioDos.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantDos.Text)) * (Convert.ToInt32(txbPrecioDos.Text));
                    txbImporteDos.Text = total.ToString();

                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) + (Convert.ToInt32(txbImporteUno.Text))+(Convert.ToInt32(txbImporteDos.Text))).ToString();

                    txbCantTres.Enabled = true;
                    ddlConceptoTres.Enabled = true;
                    txbPrecioTres.Enabled = true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Los datos no pueden contener 0", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Faltan datos por llenar", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        protected void multiplicarDosCant(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantDos.Text)) && (!string.IsNullOrEmpty(txbPrecioDos.Text)) && (ddlConceptoDos.Text != "0"))
            {
                if (Convert.ToInt32(txbCantDos.Text) > 0 && Convert.ToInt32(txbPrecioDos.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantDos.Text)) * (Convert.ToInt32(txbPrecioDos.Text));
                    txbImporteDos.Text = total.ToString();

                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) + (Convert.ToInt32(txbImporteUno.Text)) + (Convert.ToInt32(txbImporteDos.Text))).ToString();

                    txbCantTres.Enabled = true;
                    ddlConceptoTres.Enabled = true;
                    txbPrecioTres.Enabled = true;
                }
            }
        }

        protected void multiplicarTres(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantTres.Text)) && (!string.IsNullOrEmpty(txbPrecioTres.Text)) && (ddlConceptoTres.Text != "0"))
            {
                if (Convert.ToInt32(txbCantTres.Text) > 0 && Convert.ToInt32(txbPrecioTres.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantTres.Text)) * (Convert.ToInt32(txbPrecioTres.Text));
                    txbImporteTres.Text = total.ToString();

                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) +
                                         (Convert.ToInt32(txbImporteUno.Text)) + 
                                         (Convert.ToInt32(txbImporteDos.Text)) + 
                                         (Convert.ToInt32(txbImporteTres.Text))).ToString();

                    txbCantCuatro.Enabled = true;
                    ddlConceptoCuatro.Enabled = true;
                    txbPrecioCuatro.Enabled = true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Los datos no pueden contener 0", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Faltan datos por llenar", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        protected void multiplicarTresCant(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantTres.Text)) && (!string.IsNullOrEmpty(txbPrecioTres.Text)) && (ddlConceptoTres.Text != "0"))
            {
                if (Convert.ToInt32(txbCantTres.Text) > 0 && Convert.ToInt32(txbPrecioTres.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantTres.Text)) * (Convert.ToInt32(txbPrecioTres.Text));
                    txbImporteTres.Text = total.ToString();

                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) +
                                         (Convert.ToInt32(txbImporteUno.Text)) +
                                         (Convert.ToInt32(txbImporteDos.Text)) +
                                         (Convert.ToInt32(txbImporteTres.Text))).ToString();

                    txbCantCuatro.Enabled = true;
                    ddlConceptoCuatro.Enabled = true;
                    txbPrecioCuatro.Enabled = true;
                }
            }
        }

        protected void multiplicarCuatro(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantCuatro.Text)) && (!string.IsNullOrEmpty(txbPrecioCuatro.Text)) && (ddlConceptoCuatro.Text != "0"))
            {
                if (Convert.ToInt32(txbCantCuatro.Text) > 0 && Convert.ToInt32(txbPrecioCuatro.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantCuatro.Text)) * (Convert.ToInt32(txbPrecioCuatro.Text));
                    txbImporteCuatro.Text = total.ToString();

                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) +
                                         (Convert.ToInt32(txbImporteUno.Text)) +
                                         (Convert.ToInt32(txbImporteDos.Text)) +
                                         (Convert.ToInt32(txbImporteTres.Text)) +
                                         (Convert.ToInt32(txbImporteCuatro.Text))).ToString();

                    txbCantCinco.Enabled = true;
                    ddlConceptoCinco.Enabled = true;
                    txbPrecioCinco.Enabled = true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Los datos no pueden contener 0", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Faltan datos por llenar", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        protected void multiplicarCuatroCant(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantCuatro.Text)) && (!string.IsNullOrEmpty(txbPrecioCuatro.Text)) && (ddlConceptoCuatro.Text != "0"))
            {
                if (Convert.ToInt32(txbCantCuatro.Text) > 0 && Convert.ToInt32(txbPrecioCuatro.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantCuatro.Text)) * (Convert.ToInt32(txbPrecioCuatro.Text));
                    txbImporteCuatro.Text = total.ToString();

                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) +
                                         (Convert.ToInt32(txbImporteUno.Text)) +
                                         (Convert.ToInt32(txbImporteDos.Text)) +
                                         (Convert.ToInt32(txbImporteTres.Text)) +
                                         (Convert.ToInt32(txbImporteCuatro.Text))).ToString();

                    txbCantCinco.Enabled = true;
                    ddlConceptoCinco.Enabled = true;
                    txbPrecioCinco.Enabled = true;
                }
            }
        }


        protected void multiplicarCinco(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantCinco.Text)) && (!string.IsNullOrEmpty(txbPrecioCinco.Text)) && (ddlConceptoCinco.Text != "0"))
            {
                if (Convert.ToInt32(txbCantCinco.Text) > 0 && Convert.ToInt32(txbPrecioCinco.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantCinco.Text)) * (Convert.ToInt32(txbPrecioCinco.Text));
                    txbImporteCinco.Text = total.ToString();

                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) +
                                         (Convert.ToInt32(txbImporteUno.Text)) +
                                         (Convert.ToInt32(txbImporteDos.Text)) +
                                         (Convert.ToInt32(txbImporteTres.Text)) +
                                         (Convert.ToInt32(txbImporteCuatro.Text)) +
                                         (Convert.ToInt32(txbImporteCinco.Text))).ToString();

                    txbCantSeis.Enabled = true;
                    ddlConceptoSeis.Enabled = true;
                    txbPrecioSeis.Enabled = true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Los datos no pueden contener 0", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Faltan datos por llenar", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        protected void multiplicarCincoCant(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantCinco.Text)) && (!string.IsNullOrEmpty(txbPrecioCinco.Text)) && (ddlConceptoCinco.Text != "0"))
            {
                if (Convert.ToInt32(txbCantCinco.Text) > 0 && Convert.ToInt32(txbPrecioCinco.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantCinco.Text)) * (Convert.ToInt32(txbPrecioCinco.Text));
                    txbImporteCinco.Text = total.ToString();

                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) +
                                         (Convert.ToInt32(txbImporteUno.Text)) +
                                         (Convert.ToInt32(txbImporteDos.Text)) +
                                         (Convert.ToInt32(txbImporteTres.Text)) +
                                         (Convert.ToInt32(txbImporteCuatro.Text)) +
                                         (Convert.ToInt32(txbImporteCinco.Text))).ToString();

                    txbCantSeis.Enabled = true;
                    ddlConceptoSeis.Enabled = true;
                    txbPrecioSeis.Enabled = true;
                }
            }
        }

        protected void multiplicarSeis(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantSeis.Text)) && (!string.IsNullOrEmpty(txbPrecioSeis.Text)) && (ddlConceptoSeis.Text != "0"))
            {
                if (Convert.ToInt32(txbCantSeis.Text) > 0 && Convert.ToInt32(txbPrecioSeis.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantSeis.Text)) * (Convert.ToInt32(txbPrecioSeis.Text));
                    txbImporteSeis.Text = total.ToString();
                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) + 
                                         (Convert.ToInt32(txbImporteUno.Text)) + 
                                         (Convert.ToInt32(txbImporteDos.Text)) + 
                                         (Convert.ToInt32(txbImporteTres.Text)) + 
                                         (Convert.ToInt32(txbImporteCuatro.Text)) + 
                                         (Convert.ToInt32(txbImporteCinco.Text)) + 
                                         (Convert.ToInt32(txbImporteSeis.Text))).ToString();
                    txbCantSiete.Enabled = true;
                    ddlConceptoSiete.Enabled = true;
                    txbPrecioSiete.Enabled = true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Los datos no pueden contener 0", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Faltan datos por llenar", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        protected void multiplicarSeisCant(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantSeis.Text)) && (!string.IsNullOrEmpty(txbPrecioSeis.Text)) && (ddlConceptoSeis.Text != "0"))
            {
                if (Convert.ToInt32(txbCantSeis.Text) > 0 && Convert.ToInt32(txbPrecioSeis.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantSeis.Text)) * (Convert.ToInt32(txbPrecioSeis.Text));
                    txbImporteSeis.Text = total.ToString();

                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) +
                     (Convert.ToInt32(txbImporteUno.Text)) +
                     (Convert.ToInt32(txbImporteDos.Text)) +
                     (Convert.ToInt32(txbImporteTres.Text)) +
                     (Convert.ToInt32(txbImporteCuatro.Text)) +
                     (Convert.ToInt32(txbImporteCinco.Text)) +
                     (Convert.ToInt32(txbImporteSeis.Text))).ToString();

                    txbCantSiete.Enabled = true;
                    ddlConceptoSiete.Enabled = true;
                    txbPrecioSiete.Enabled = true;
                }
            }
        }

        ///SIETE
        protected void multiplicarSiete(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantSiete.Text)) && (!string.IsNullOrEmpty(txbPrecioSiete.Text)) && (ddlConceptoSiete.Text != "0"))
            {
                if (Convert.ToInt32(txbCantSiete.Text) > 0 && Convert.ToInt32(txbPrecioSiete.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantSiete.Text)) * (Convert.ToInt32(txbPrecioSiete.Text));
                    txbImporteSiete.Text = total.ToString();
                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) +
                                        (Convert.ToInt32(txbImporteUno.Text)) + 
                                        (Convert.ToInt32(txbImporteDos.Text)) + 
                                        (Convert.ToInt32(txbImporteTres.Text)) + 
                                        (Convert.ToInt32(txbImporteCuatro.Text)) + 
                                        (Convert.ToInt32(txbImporteCinco.Text)) + 
                                        (Convert.ToInt32(txbImporteSeis.Text)) + 
                                        (Convert.ToInt32(txbImporteSiete.Text))).ToString();
                    txbCantOcho.Enabled = true;
                    ddlConceptoOcho.Enabled = true;
                    txbPrecioOcho.Enabled = true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Los datos no pueden contener 0", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Faltan datos por llenar", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        protected void multiplicarSieteCant(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantSiete.Text)) && (!string.IsNullOrEmpty(txbPrecioSiete.Text)) && (ddlConceptoSiete.Text != "0"))
            {
                if (Convert.ToInt32(txbCantSiete.Text) > 0 && Convert.ToInt32(txbPrecioSiete.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantSiete.Text)) * (Convert.ToInt32(txbPrecioSiete.Text));
                    txbImporteSiete.Text = total.ToString();

                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) +
                                        (Convert.ToInt32(txbImporteUno.Text)) +
                                        (Convert.ToInt32(txbImporteDos.Text)) +
                                        (Convert.ToInt32(txbImporteTres.Text)) +
                                        (Convert.ToInt32(txbImporteCuatro.Text)) +
                                        (Convert.ToInt32(txbImporteCinco.Text)) +
                                        (Convert.ToInt32(txbImporteSeis.Text)) +
                                        (Convert.ToInt32(txbImporteSiete.Text))).ToString();

                    txbCantOcho.Enabled = true;
                    ddlConceptoOcho.Enabled = true;
                    txbPrecioOcho.Enabled = true;
                }
            }
        }
        ///Ocho
        protected void multiplicarOcho(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantOcho.Text)) && (!string.IsNullOrEmpty(txbPrecioOcho.Text)) && (ddlConceptoOcho.Text != "0"))
            {
                if (Convert.ToInt32(txbCantOcho.Text) > 0 && Convert.ToInt32(txbPrecioOcho.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantOcho.Text)) * (Convert.ToInt32(txbPrecioOcho.Text));
                    txbImporteOcho.Text = total.ToString();
                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) + 
                                        (Convert.ToInt32(txbImporteUno.Text)) + 
                                        (Convert.ToInt32(txbImporteDos.Text)) + 
                                        (Convert.ToInt32(txbImporteTres.Text)) + 
                                        (Convert.ToInt32(txbImporteCuatro.Text)) + 
                                        (Convert.ToInt32(txbImporteCinco.Text)) + 
                                        (Convert.ToInt32(txbImporteSeis.Text)) + 
                                        (Convert.ToInt32(txbImporteSiete.Text)) +
                                        (Convert.ToInt32(txbImporteOcho.Text))).ToString();

                    txbCantNueve.Enabled = true;
                    ddlConceptoNueve.Enabled = true;
                    txbPrecioNueve.Enabled = true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Los datos no pueden contener 0", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Faltan datos por llenar", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        protected void multiplicarOchoCant(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantOcho.Text)) && (!string.IsNullOrEmpty(txbPrecioOcho.Text)) && (ddlConceptoOcho.Text != "0"))
            {
                if (Convert.ToInt32(txbCantOcho.Text) > 0 && Convert.ToInt32(txbPrecioOcho.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantOcho.Text)) * (Convert.ToInt32(txbPrecioOcho.Text));
                    txbImporteOcho.Text = total.ToString();

                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) + 
                                         (Convert.ToInt32(txbImporteUno.Text)) + 
                                         (Convert.ToInt32(txbImporteDos.Text)) + 
                                         (Convert.ToInt32(txbImporteTres.Text)) + 
                                         (Convert.ToInt32(txbImporteCuatro.Text)) + 
                                         (Convert.ToInt32(txbImporteCinco.Text)) + 
                                         (Convert.ToInt32(txbImporteSeis.Text)) + 
                                         (Convert.ToInt32(txbImporteSiete.Text)) +
                                         (Convert.ToInt32(txbImporteOcho.Text)) ).ToString();

                    txbCantNueve.Enabled = true;
                    ddlConceptoNueve.Enabled = true;
                    txbPrecioNueve.Enabled = true;
                }
            }
        }
        /// 

        ///Nueve
        protected void multiplicarNueve(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantNueve.Text)) && (!string.IsNullOrEmpty(txbPrecioNueve.Text)) && (ddlConceptoNueve.Text != "0"))
            {
                if (Convert.ToInt32(txbCantNueve.Text) > 0 && Convert.ToInt32(txbPrecioNueve.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantNueve.Text)) * (Convert.ToInt32(txbPrecioNueve.Text));
                    txbImporteNueve.Text = total.ToString();

                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) + 
                                         (Convert.ToInt32(txbImporteUno.Text)) + 
                                         (Convert.ToInt32(txbImporteDos.Text)) + 
                                         (Convert.ToInt32(txbImporteTres.Text)) + 
                                         (Convert.ToInt32(txbImporteCuatro.Text)) + 
                                         (Convert.ToInt32(txbImporteCinco.Text)) + 
                                         (Convert.ToInt32(txbImporteSeis.Text)) + 
                                         (Convert.ToInt32(txbImporteSiete.Text)) +
                                         (Convert.ToInt32(txbImporteOcho.Text)) + 
                                         (Convert.ToInt32(txbImporteNueve.Text)) ).ToString();
                    txbCantDiez.Enabled = true;
                    ddlConceptoDiez.Enabled = true;
                    txbPrecioDiez.Enabled = true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Los datos no pueden contener 0", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Faltan datos por llenar", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        protected void multiplicarNueveCant(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantNueve.Text)) && (!string.IsNullOrEmpty(txbPrecioNueve.Text)) && (ddlConceptoNueve.Text != "0"))
            {
                if (Convert.ToInt32(txbCantNueve.Text) > 0 && Convert.ToInt32(txbPrecioNueve.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantNueve.Text)) * (Convert.ToInt32(txbPrecioNueve.Text));
                    txbImporteNueve.Text = total.ToString();

                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) +
                                         (Convert.ToInt32(txbImporteUno.Text)) +
                                         (Convert.ToInt32(txbImporteDos.Text)) +
                                         (Convert.ToInt32(txbImporteTres.Text)) +
                                         (Convert.ToInt32(txbImporteCuatro.Text)) +
                                         (Convert.ToInt32(txbImporteCinco.Text)) +
                                         (Convert.ToInt32(txbImporteSeis.Text)) +
                                         (Convert.ToInt32(txbImporteSiete.Text)) +
                                         (Convert.ToInt32(txbImporteOcho.Text)) +
                                         (Convert.ToInt32(txbImporteNueve.Text))).ToString();

                    txbCantDiez.Enabled = true;
                    ddlConceptoDiez.Enabled = true;
                    txbPrecioDiez.Enabled = true;
                }
            }
        }
        /// 
        ///Diez
        protected void multiplicarDiez(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantDiez.Text)) && (!string.IsNullOrEmpty(txbPrecioDiez.Text)) && (ddlConceptoDiez.Text != "0"))
            {
                if (Convert.ToInt32(txbCantDiez.Text) > 0 && Convert.ToInt32(txbPrecioDiez.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantDiez.Text)) * (Convert.ToInt32(txbPrecioDiez.Text));
                    txbImporteDiez.Text = total.ToString();

                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) + 
                                         (Convert.ToInt32(txbImporteUno.Text)) + 
                                         (Convert.ToInt32(txbImporteDos.Text)) + 
                                         (Convert.ToInt32(txbImporteTres.Text)) + 
                                         (Convert.ToInt32(txbImporteCuatro.Text)) + 
                                         (Convert.ToInt32(txbImporteCinco.Text)) + 
                                         (Convert.ToInt32(txbImporteSeis.Text)) + 
                                         (Convert.ToInt32(txbImporteSiete.Text)) +
                                         (Convert.ToInt32(txbImporteOcho.Text)) + 
                                         (Convert.ToInt32(txbImporteNueve.Text)) + 
                                         (Convert.ToInt32(txbImporteDiez.Text))).ToString();

                  
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Los datos no pueden contener 0", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Faltan datos por llenar", "Informacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, System.Windows.Forms.MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);

            }
        }

        protected void multiplicarDiezCant(object sender, EventArgs e)
        {

            if ((!string.IsNullOrEmpty(txbCantDiez.Text)) && (!string.IsNullOrEmpty(txbPrecioDiez.Text)) && (ddlConceptoDiez.Text != "0"))
            {
                if (Convert.ToInt32(txbCantDiez.Text) > 0 && Convert.ToInt32(txbPrecioDiez.Text) > 0)
                {
                    int total = (Convert.ToInt32(txbCantDiez.Text)) * (Convert.ToInt32(txbPrecioDiez.Text));
                    txbImporteDiez.Text = total.ToString();

                    labResultado.Text = ((Convert.ToInt32(txbImporteCero.Text)) +
                                           (Convert.ToInt32(txbImporteUno.Text)) +
                                           (Convert.ToInt32(txbImporteDos.Text)) +
                                           (Convert.ToInt32(txbImporteTres.Text)) +
                                           (Convert.ToInt32(txbImporteCuatro.Text)) +
                                           (Convert.ToInt32(txbImporteCinco.Text)) +
                                           (Convert.ToInt32(txbImporteSeis.Text)) +
                                           (Convert.ToInt32(txbImporteSiete.Text)) +
                                           (Convert.ToInt32(txbImporteOcho.Text)) +
                                           (Convert.ToInt32(txbImporteNueve.Text)) +
                                           (Convert.ToInt32(txbImporteDiez.Text))).ToString();


                }
            }
        }



        protected void Guardar(object sender, EventArgs e)
        {

        }
        


    }
}