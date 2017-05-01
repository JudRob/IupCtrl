using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ctrlArchivos.Modelo;

namespace ctrlArchivos.vista
{
    public partial class archivo : System.Web.UI.Page
    {

        Producto obj = new Producto();

        Expediente miExp = new Expediente(); //from ctrlArchivos.Modelo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Validate initially to force asterisks
                // to appear before the first roundtrip.
                Validate();
                miExp.cargarDatosIniciales(
            ddlfondo,
            ddlidfondo,
            ddlseccion,
            ddlidseccion,
            ddlserie,
            ddlidserie,
            ddlnoexp,
            ddlaño,
            ddluadmva,
            ddlsubuadmva,
            ddlcargoresp,
            ddlrespCaptura
            );
            }
            

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            obj.Descripcion = TextBox2.Text;
            obj.Nombre = TextBox3.Text;
            int r = obj.altaProducto();
            if (r == 1)
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "registroProducto();", true);
            else if (r == 0)
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "erRegistroProducto();", true);
            else
                ClientScript.RegisterStartupScript(GetType(), "mostrar", "erRegistroProducto();", true);

        }

        protected void ddlfondo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblclasexp.Text = ddlidseccion.Text;
        }

        protected void ddlseccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblclasexp.Text = ddlidseccion.Text;
        }
    }
}