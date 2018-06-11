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

//using  System.Collections.ArrayList;


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
                    }
                    ddlConceptoCero.Items.Insert(0, new ListItem { Value = "0", Text = "-Seleccion-" });




                }
                else
                {
                    Response.Redirect("/Vistas/Login/Login.aspx");
                }

            }
        }
        //Importe
        protected void txbPrecio_TextChanged(object sender, EventArgs e)
        {
            LabImporte.Text = txbPrecio.Text;
        }


        protected void buscar(object sender, EventArgs e)
        {
            labFechaSistema.Text = DateTime.Today.ToString();

            string cliente = ddlRegVenta.SelectedItem.ToString();
            txbDom.Text = ReglasNegocioVentas.GetInstancia().getDatosDireccion(cliente);
            txbRFC.Text = ReglasNegocioVentas.GetInstancia().getDatoRFC(cliente);

        }
    }
}