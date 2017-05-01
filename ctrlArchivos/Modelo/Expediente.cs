using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//using Proyecto.Modelo; //from Modelo.Metodo

using System.Web.UI.WebControls;

namespace ctrlArchivos.Modelo
{
    public class Expediente
    {
        Usuario2 obj1 = new Usuario2(); //from metodo
        
        public void cargarDatosIniciales(
            DropDownList ddlfondo,
            DropDownList ddlidfondo,
            DropDownList ddlseccion,
            DropDownList ddlidseccion,
            DropDownList ddlserie,
            DropDownList ddlidserie,
            DropDownList ddlnoexp,
            DropDownList ddlaño,
            DropDownList ddluadmva,
            DropDownList ddlsubuadmva,
            DropDownList ddlcargoresp,
            DropDownList ddlrespCaptura)
        {
            string consulta = "";
            
            consulta = "select nombre_fondo from fondo";
            obj1.cargar_DropDownListString(ddlfondo, consulta);

            consulta = "select id_fondo from fondo";
            obj1.cargar_DropDownListString(ddlidfondo, consulta);

            consulta = "select nombre_sec from seccion";
            obj1.cargar_DropDownListString(ddlseccion, consulta);

            consulta = "select id_seccion from seccion";
            obj1.cargar_DropDownListString(ddlidseccion, consulta);
            
            consulta = "select descripcion_serie from serie";
            obj1.cargar_DropDownListString(ddlserie, consulta);

            consulta = "select id_serie from serie";
            obj1.cargar_DropDownListString(ddlidserie, consulta);

            consulta = "select descripcion_serie from serie";
            ddlnoexp.Items.Add(Convert.ToString(1 + obj1.consultaRegresaInt(consulta)));

            GenerarAños(ddlaño);

            //cargar la unidad administrativa responsable
            consulta = "select nombre_unid_admva from unidad_admva";
            obj1.cargar_DropDownListString(ddluadmva, consulta);

            ///cargar las "sub" unidad administrativa responsable dependiendo de la que se 
            ///haya elegido en unidad administrativa
            ///
            ///aunque se hace con el evento del control mas adelante
            consulta = "select nombre_unid_admva from unidad_admva where Id_unid_admva_pertenencia = 'rctr001'";
            obj1.cargar_DropDownListString(ddlsubuadmva, consulta);

            //carga responsable de la sub unidad admninistrativa
            consulta = "select usuario.nombre_usr from usuario, "+
                "Empleado_unidadAdmva, unidad_admva " + 
                "where Id_unid_admva_pertenencia = unidad_admva.id_unid_admva and "+
                "unidad_admva.id_unid_admva = Empleado_unidadAdmva.id_unid_admva and "+
                "Empleado_unidadAdmva.id_emp = usuario.id_usr and "+
                "unidad_admva.id_unid_admva = 'rctr001'";

            obj1.cargar_DropDownListString(ddlcargoresp, consulta);

            //carga responsable de la captura del exp
            consulta = "select nombre_usr from usuario";

            obj1.cargar_DropDownListString(ddlrespCaptura, consulta);
            


        }

        public void GenerarAños(DropDownList ddlaño)
        {
            ddlaño.Items.Clear();
            for (int i= DateTime.Now.Year; i >= 1980; i--)
            {
                ddlaño.Items.Add(i.ToString());
            }
        } 

    }
}