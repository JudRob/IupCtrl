using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
//using Proyecto.Modelo;
using ctrlArchivos.Modelo;
using System.Web.UI;



namespace ctrlArchivos.Modelo
{
    public class Usuario2
    {
        public String idUsuario { get; set; }
        public String Usuario { get; set; }
        public String Contraseña { get; set; }

        public Usuario2()
        {
            idUsuario = "";
            Usuario = "";
            Contraseña = "";

        }

        public Usuario2(String u, String c, String n)
        {
            idUsuario = u;
            Usuario = n;
            Contraseña = c;
        }


        public bool acceso(String usu, String contra)
        {

            servidor misvr = new servidor("bdiuppue.database.windows.net", "insunipue");
            
            SqlConnection miconexion = new SqlConnection("Data Source=" +
                misvr.Svractual + 
                "; Initial catalog="+
                misvr.Bdatos + 
                "; Integrated security=true");

            misvr.MyQuery = "select * from usuario where nombre_usr ='"+ usu + 
                "'and contra_usr = '" + contra + "'";

            miconexion.Open();
            //Datos conecta = new Datos();
            //conecta.Conectar();
            SqlCommand consulta = new SqlCommand(misvr.MyQuery, miconexion);
            SqlDataReader ejecuta = consulta.ExecuteReader();

            if (ejecuta.Read() == true)
            {
                
                
                miconexion.Close();
                return true;

            }
            else
            {
                
                miconexion.Close();
            }
            return false;
        }
      
        /// <summary>
        /// /esta es la implementacion de la clase
        /// </summary>
        /// <returns></returns>
      
        /*public int alta()
        {
            SqlCommand Comando;
            Datos inserta = new Datos();
            int regresa = 0;
            if (inserta.Conectar())
            {
                String comando = "Insert into Producto (Descripcion, NombreProd, StatusProd)" +
                "values ('" + Descripcion + "','" + Nombre + "','" + "Alta" + "')";
                Comando = inserta.construye_command(comando);
                if ((inserta.ejecutanonquery()) != 0)
                    regresa = 1;
                else
                    regresa = 0;
                Comando.Connection.Close();
                inserta.desconectar();
            }
            else
                regresa = -1;
            return regresa;
        }
        */
        public int cargar_DropDownListString(DropDownList cmb, string consulta)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;
            if (selecciona.Conectar())
            {
                selecciona.construye_reader(consulta);
                lector = selecciona.ejecuta_reader();
                while (lector.Read())
                    //cmb.Items.Add(lector.GetInt32(0).ToString());
                    cmb.Items.Add(lector.GetString(0));
                selecciona.desconectar();
                selecciona.dr.Close();
                return 1;
            }
            else
                return -1;
        }

        public int consultaRegresaInt(string consulta)
        {
            Datos selecciona = new Datos();

            SqlDataAdapter adaptador;

            DataRow fila;

            if (selecciona.Conectar())
            {
                try
                {
                    adaptador = selecciona.construye_adapter(consulta);
                    fila = selecciona.extrae_registro(adaptador, "resultado");
                    if (fila == null)
                    {
                        return 0;
                    }
                    else{
                        return Convert.ToInt32(fila["dato"]);
                    }
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("No se encuentra el codigo");
                    return 0;
                }
            }
            else
                return 0;
        }

    }

    /// <summary>
    /// ///////////////////////Producto
    /// </summary>
 
    public class Producto
    {
        public int idProducto { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Status { get; set; }


        public Producto()
        {
            idProducto = 0;
            Descripcion = "";
            Nombre = "";
            Status = "";
        }
        public Producto(int i, string d, string n, string s)
        {
            idProducto = i;
            Descripcion = d;
            Nombre = n;
            Status=s;
        }

        public int altaProducto()
        {
            SqlCommand Comando;
            Datos inserta = new Datos();
            int regresa = 0;
            if (inserta.Conectar())
            {
                String comando = "Insert into Producto (Descripcion, NombreProd, StatusProd)" +
                "values ('" + Descripcion + "','"+Nombre+"','"+"Alta"+"')";
                Comando = inserta.construye_command(comando);
                if ((inserta.ejecutanonquery()) != 0)
                    regresa = 1;
                else
                    regresa = 0;
                Comando.Connection.Close();
                inserta.desconectar();
            }
            else
                regresa = -1;
            return regresa;
        }
    


        public int cargar_productos(DropDownList cmb)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;
            if (selecciona.Conectar())
            {
                selecciona.construye_reader("select idProducto from Producto");
                lector = selecciona.ejecuta_reader();
                while (lector.Read())
                    cmb.Items.Add(lector.GetInt32(0).ToString());
                selecciona.desconectar();
                selecciona.dr.Close();
                return 1;
            }
            else
                return -1;
        }
        public int cargar_nombre_productos(DropDownList cmb)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;
            if (selecciona.Conectar())
            {
                selecciona.construye_reader("select NombreProd from Producto");
                lector = selecciona.ejecuta_reader();
                while (lector.Read())
                    cmb.Items.Add(lector.GetString(0).ToString());
                selecciona.desconectar();
                selecciona.dr.Close();
                return 1;
            }
            else
                return -1;
        }

        public Producto busca_producto(String nom)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;
            if (selecciona.Conectar())
            {
                selecciona.construye_reader("select * from Producto");
                lector = selecciona.ejecuta_reader();
                while (lector.Read())
                {
                    if (lector.GetString(1).ToString() == nom)
                    {
                        idProducto = Convert.ToInt32(lector.GetInt32(0).ToString());
                        Descripcion = lector.GetString(1).ToString();
                        Nombre = lector.GetString(2).ToString();
                        return this;
                    }
                }
                selecciona.desconectar();
                selecciona.dr.Close();
            }
            return null;
        }

        public int carga_nombres(DropDownList cmb)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;
            if (selecciona.Conectar())
            {
                selecciona.construye_reader("select Nombre from Producto");
                lector = selecciona.ejecuta_reader();
                while (lector.Read())
                    cmb.Items.Add(lector.GetString(0).ToString());
                selecciona.desconectar();
                selecciona.dr.Close();
                return 1;
            }
            else
                return -1;
        }

        internal int muestra_idProductos(System.Web.UI.WebControls.DropDownList DDLisy)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;
            if (selecciona.Conectar())
            {
                selecciona.construye_reader("select * from Producto");
                lector = selecciona.ejecuta_reader();
                while (lector.Read())
                    DDLisy.Items.Add(lector.GetInt32(0).ToString());
                selecciona.desconectar();
                selecciona.dr.Close();
                return 1;
            }
            else
                return -1;
        }
        /*public string regresa_nombre(int codigo)
        {
            Datos selecciona = new Datos();
            SqlDataAdapter adaptador;
            DataRow fila;
            if (selecciona.Conectar())
            {
                try
                {
                    adaptador = selecciona.construye_adapter("select nombre Producto where " +
                        " idProducto=" + codigo);
                    fila = selecciona.extrae_registro(adaptador, "Producto");
                    return fila["Nombre"].ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se encuentra el nombre");
                    return "";
                }
            }
            else
                return "";
        }*/
       

       /* public int baja(int cod)
        {
            SqlCommand Comando;
            Datos inserta = new Datos();
            int regresa = 0;
            if (inserta.Conectar())
            {
                string comando = "update Producto set StatusProd = 'Baja' where Codigo=" + cod;
                Comando = inserta.construye_command(comando);
                if (inserta.ejecutanonquery() != 0)  //Regresa el numero de registros insertados
                    regresa = 1;
                else
                    regresa = 0;
                Comando.Connection.Close();
                inserta.desconectar();
            }
            else
                regresa = -1;
            return regresa;
        }
*/

           public int baja(int codigo)
        {

            SqlCommand comando;
            Datos elimina = new Datos();
            int regresa = 0;
            if (elimina.Conectar())
            {
                comando = elimina.construye_command("delete from Producto where idProducto=" + codigo);
                if (elimina.ejecutanonquery() != 0)
                    regresa = 0;
                else
                    regresa = 1;
            }
            else
                regresa = -1;
            return regresa;
    }

        public int actualiza_producto()
        {
            SqlCommand Comando;
            Datos actualiza = new Datos();
            int regresa = 0;
            if (actualiza.Conectar())
            {
                Comando = actualiza.construye_command("update Producto set Descripcion= '" + Descripcion + "',NombreProd= '" + Nombre + "', StatusProd = '"+Status+"' where idProducto= " + idProducto);
                if (actualiza.ejecutanonquery() != 0)
                    regresa = 1;
                else
                    regresa = 0;
                Comando.Connection.Close();
                actualiza.desconectar();
            }
            else
                return -1;
            return regresa;
        }

        public String regresa_nombre(int cod)
        {
            Datos selecciona = new Datos();
            SqlDataAdapter adaptador;
            DataRow fila;
            if (selecciona.Conectar())
            {
                try
                {
                    adaptador = selecciona.construye_adapter("select NombreProd from Producto" +
                    " where idProducto=" + cod);
                    fila = selecciona.extrae_registro(adaptador, "Producto");
                    return fila["NombreProd"].ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se encuentra el codigo");
                    return "";
                }
            }
            else
                return "";
        }

        public String regresa_descripcion(int cod)
        {
            Datos selecciona = new Datos();
            SqlDataAdapter adaptador;
            DataRow fila;
            if (selecciona.Conectar())
            {
                try
                {
                    adaptador = selecciona.construye_adapter("select Descripcion from Producto" +
                    " where idProducto=" + cod);
                    fila = selecciona.extrae_registro(adaptador, "Producto");
                    return fila["Descripcion"].ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se encuentra el codigo");
                    return "";
                }
            }
            else
                return "";
        }

        public int regresa_id(int cod)
        {
            Datos selecciona = new Datos();
            SqlDataAdapter adaptador;
            DataRow fila;
            if (selecciona.Conectar())
            {
                try
                {
                    adaptador = selecciona.construye_adapter("select idProducto from Producto" +
                    " where idProducto=" + cod);
                    fila = selecciona.extrae_registro(adaptador, "Producto");
                    return Convert.ToInt32(fila["idProducto"]);
                }
                catch (Exception)
                {
                    MessageBox.Show("No se encuentra el codigo");
                    return 0;
                }
            }
            else
                return 0;
        }

        public String regresa_status(int cod)
        {
            Datos selecciona = new Datos();
            SqlDataAdapter adaptador;
            DataRow fila;
            if (selecciona.Conectar())
            {
                try
                {
                    adaptador = selecciona.construye_adapter("select StatusProd from Producto" +
                    " where idProducto=" + cod);
                    fila = selecciona.extrae_registro(adaptador, "Producto");
                    return fila["StatusProd"].ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se encuentra el codigo");
                    return "";
                }
            }
            else
                return "";
        }
    }

                                //Producto terminado
    public class ProductoTer
    {
        public Empleado emp { get; set; }
        public Producto prod { get; set; }

        public int idEmpleado { get; set; }
        public int idProducto { get; set; }
        public int Cantidad { get; set; }
        public string Fecha { get; set; }
        public string pzasDefec { get; set; }
        public string pzasBEstado { get; set; }
        public int Stock { get; set; }


        public ProductoTer()
        {
            emp = null;
            prod = null;
            idEmpleado = 0;
            idProducto = 0;
            Cantidad = 0;
            Fecha = "";
            pzasDefec = "";
            pzasBEstado = "";
            Stock = 0;
        }
        public ProductoTer(Empleado e, Producto p, int ie, int ip, int c, string f, string pd, string pb, int s)
        {
            emp = e;
            prod = p;
            idEmpleado = ie;
            idProducto = ip;
            Cantidad = c;
            Fecha = f;
            pzasDefec = pd;
            pzasBEstado = pb;
            Stock = s;
        }

        public int altaProductoTer()
        {
            SqlCommand Comando;
            Datos inserta = new Datos();
            int regresa = 0;
            if (inserta.Conectar())
            {
                String comando = "Insert into ProdctTer (idEmpleado, idProducto, Cantidad, Fecha, pzasDefec, pzasBEstado, Stock)" +
                "values (" + Convert.ToInt32(idEmpleado) + ","+Convert.ToInt32(idProducto)+","+Convert.ToInt32(Cantidad)+",'" + Fecha + "','" + pzasDefec + "','" + pzasBEstado+ "'," +Convert.ToInt32(Stock) + ")";
                Comando = inserta.construye_command(comando);
                if ((inserta.ejecutanonquery()) != 0)
                    regresa = 1;
                else
                    regresa = 0;
                Comando.Connection.Close();
                inserta.desconectar();
            }
            else
                regresa = -1;
            return regresa;
        }
        public void ConsultaProdcto(GridView gv, DateTime fi, DateTime ff)
        {

            Datos consulta = new Datos();
            SqlDataReader lector;
            if (consulta.Conectar())
            {
                consulta.construye_reader("SELECT Descripcion, Cantidad,pzasBEstado,pzasDefec,Fecha,Stock FROM  Persona INNER JOIN Empleado on Empleado.idEmpleado = Persona.idPersona INNER JOIN ProdctTer on ProdctTer.idEmpleado= Empleado.idEmpleado INNER JOIN Producto on Producto.idProducto = ProdctTer.idProducto WHERE Fecha BETWEEN '"+Convert.ToDateTime(fi).ToShortDateString()+"'AND'"+Convert.ToDateTime(ff).ToShortDateString()+"'");
                lector = consulta.ejecuta_reader();
                gv.DataSource = lector;
                gv.DataBind();
                consulta.dr.Close();
                consulta.desconectar();
            }
        }
    }

  }
    public class Persona
    {
        public int idPersona { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String RFC { get; set; }
        public String FNacimiento { get; set; }



        public Persona()
        {
            idPersona = 0;
            Nombre = "";
            ApellidoPaterno = "";
            ApellidoMaterno = "";
            RFC = "";
            FNacimiento = "";
        }
        public Persona(int i, String n, String ap, String am, String r, String f)
        {
            idPersona = i;
            Nombre = n;
            ApellidoPaterno = ap;
            ApellidoMaterno = am;
            RFC = r;
            FNacimiento = f;
        }

        public int altaPersona()
        {
            SqlCommand Comando;
            Datos inserta = new Datos();
            int regresa = 0;
            if (inserta.Conectar())
            {
                String comando = "Insert into Persona (Nombre, ApellidoPaterno, ApellidoMaterno, RFC, FNacimiento)" +
                "values ('" + Nombre + "','" + ApellidoPaterno + "','" + ApellidoMaterno + "','" + RFC + "','" + FNacimiento + "')";
                
                Comando = inserta.construye_command(comando);
                if ((inserta.ejecutanonquery()) != 0)
                    regresa = 1;
                else
                    regresa = 0;
                Comando.Connection.Close();
                inserta.desconectar();
            }
            else
                regresa = -1;
            return regresa;
        }

        public int actualiza_persona()
        {
            SqlCommand Comando;
            Datos actualiza = new Datos();
            int regresa = 0;
            if (actualiza.Conectar())
            {
                Comando = actualiza.construye_command("update Persona set Nombre= '" +Nombre + "',ApellidoPaterno= '" +ApellidoPaterno + "',ApellidoMaterno ='"+ApellidoMaterno+"',RFC= '"+RFC+"',FNacimiento = '"+FNacimiento+"' where idPersona= " + idPersona);
                if (actualiza.ejecutanonquery() != 0)
                    regresa = 1;
                else
                    regresa = 0;
                Comando.Connection.Close();
                actualiza.desconectar();
            }
            else
                return -1;
            return regresa;
        }

        public int carga_idPersona(DropDownList cmb)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;
            if (selecciona.Conectar())
            {
                selecciona.construye_reader("select * from Persona");
                lector = selecciona.ejecuta_reader();
                while (lector.Read())
                    cmb.Items.Add(lector.GetInt32(0).ToString());
                selecciona.desconectar();
                selecciona.dr.Close();
                return 1;
            }
            else
                return -1;
        }
        public int cargar_persona(DropDownList cmb)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;
            if (selecciona.Conectar())
            {
                selecciona.construye_reader("select idPersona from Persona");
                lector = selecciona.ejecuta_reader();
                while (lector.Read())
                    cmb.Items.Add(lector.GetInt32(0).ToString());
                selecciona.desconectar();
                selecciona.dr.Close();
                return 1;
            }
            else
                return -1;
        }
        public int carga_persona_nombre(DropDownList cmb)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;
            if (selecciona.Conectar())
            {
                selecciona.construye_reader("select Nombre from Persona");
                lector = selecciona.ejecuta_reader();
                while (lector.Read())
                    cmb.Items.Add(lector.GetString(0).ToString());
                selecciona.desconectar();
                selecciona.dr.Close();
                return 1;
            }
            else
                return -1;

        }

        public String regresa_nombre(int cod)
        {
            Datos selecciona = new Datos();
            SqlDataAdapter adaptador;
            DataRow fila;
            if (selecciona.Conectar())
            {
                try
                {
                    adaptador = selecciona.construye_adapter("select Nombre from Persona" +
                    " where idPersona=" + cod);
                    fila = selecciona.extrae_registro(adaptador, "Persona");
                    return fila["Nombre"].ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se encuentra el codigo");
                    return "";
                }
            }
            else
                return "";
        }

        public String regresa_apePa(int cod)
        {
            Datos selecciona = new Datos();
            SqlDataAdapter adaptador;
            DataRow fila;
            if (selecciona.Conectar())
            {
                try
                {
                    adaptador = selecciona.construye_adapter("select ApellidoPaterno from Persona" +
                    " where idPersona=" + cod);
                    fila = selecciona.extrae_registro(adaptador, "Persona");
                    return fila["ApellidoPaterno"].ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se encuentra el codigo");
                    return "";
                }
            }
            else
                return "";
        }
        public String regresa_apeMa(int cod)
        {
            Datos selecciona = new Datos();
            SqlDataAdapter adaptador;
            DataRow fila;
            if (selecciona.Conectar())
            {
                try
                {
                    adaptador = selecciona.construye_adapter("select ApellidoMaterno from Persona" +
                    " where idPersona=" + cod);
                    fila = selecciona.extrae_registro(adaptador, "Persona");
                    return fila["ApellidoMaterno"].ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se encuentra el codigo");
                    return "";
                }
            }
            else
                return "";
        }
        public String regresa_rfc(int cod)
        {
            Datos selecciona = new Datos();
            SqlDataAdapter adaptador;
            DataRow fila;
            if (selecciona.Conectar())
            {
                try
                {
                    adaptador = selecciona.construye_adapter("select RFC from Persona" +
                    " where idPersona=" + cod);
                    fila = selecciona.extrae_registro(adaptador, "Persona");
                    return fila["RFC"].ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se encuentra el codigo");
                    return "";
                }
            }
            else
                return "";
        }

        public String regresa_fnac(int cod)
        {
            Datos selecciona = new Datos();
            SqlDataAdapter adaptador;
            DataRow fila;
            if (selecciona.Conectar())
            {
                try
                {
                    adaptador = selecciona.construye_adapter("select FNacimiento from Persona" +
                    " where idPersona=" + cod);
                    fila = selecciona.extrae_registro(adaptador, "Persona");
                    return fila["FNacimiento"].ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se encuentra el codigo");
                    return "";
                }
            }
            else
                return "";
        }
        public Persona busca_persona(String nom)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;
            if (selecciona.Conectar())
            {
                selecciona.construye_reader("select * from Producto");
                lector = selecciona.ejecuta_reader();
                while (lector.Read())
                {
                    if (lector.GetString(1).ToString() == nom)
                    {
                        idPersona = Convert.ToInt32(lector.GetInt32(0).ToString());
                        Nombre = lector.GetString(1).ToString();
                        ApellidoPaterno = lector.GetString(2).ToString();
                        ApellidoMaterno = lector.GetString(3).ToString();
                        RFC = lector.GetString(4).ToString();
                        FNacimiento = lector.GetString(5).ToString();
                        return this;
                    }
                }
                selecciona.desconectar();
                selecciona.dr.Close();
            }
            return null;
        }
        
        public int bajaPersona(int codigo)
        {

            SqlCommand comando;
            Datos elimina = new Datos();
            int regresa = 0;
            if (elimina.Conectar())
            {
                comando = elimina.construye_command("delete from Persona where idPersona=" + codigo);
                if (elimina.ejecutanonquery() != 0)
                    regresa = 0;
                else
                    regresa = 1;
            }
            else
                regresa = -1;
            return regresa;
        }

    }

    //Empleado
    public class Empleado
    {
        public int idEmpleado { get; set; }
        public int idPersona { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Status { get; set; }

        public Empleado()
        {
            idEmpleado = 0;
            idPersona = 0;
            Usuario = "";
            Contraseña = "";
            Status = "";
        }
        public Empleado(int e, int p, string u, string c, string s)
        {
            idEmpleado = e;
            idPersona = p;
            Usuario = u;
            Contraseña = c;
            Status = s;
        }

        public int altaEmpleado()
        {
            SqlCommand Comando;
            Datos inserta = new Datos();
            int regresa = 0;
            if (inserta.Conectar())
            {
                String comando = "Insert into Empleado (idPersona, Estatus, Usuario, Contraseña)" +
                "values (" + Convert.ToInt32(idPersona)+ ",'"+"Alta"+"','"+Usuario+"','"+Contraseña+"')";

                Comando = inserta.construye_command(comando);
                if ((inserta.ejecutanonquery()) != 0)
                    regresa = 1;
                else
                    regresa = 0;
                Comando.Connection.Close();
                inserta.desconectar();
            }
            else
                regresa = -1;
            return regresa;
        }

        public int carga_idEmpleado(DropDownList cmb)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;
            if (selecciona.Conectar())
            {
                selecciona.construye_reader("select * from Empleado");
                lector = selecciona.ejecuta_reader();
                while (lector.Read())
                    cmb.Items.Add(lector.GetInt32(0).ToString());
                selecciona.desconectar();
                selecciona.dr.Close();
                return 1;
            }
            else
                return -1;
        }



        public int carga_empleado_nombre(ComboBox cmb)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;
            if (selecciona.Conectar())
            {
                selecciona.construye_reader("select Nombre from Persona");
                lector = selecciona.ejecuta_reader();
                while (lector.Read())
                    cmb.Items.Add(lector.GetString(0).ToString());
                selecciona.desconectar();
                selecciona.dr.Close();
                return 1;
            }
            else
                return -1;
        }


        public Empleado busca_empleado(int id)
        {
            Datos selecciona = new Datos();
            SqlDataReader lector;
            if (selecciona.Conectar())
            {
                selecciona.construye_reader("select * from Empleado");
                lector = selecciona.ejecuta_reader();
                while (lector.Read())
                {
                    if (lector.GetInt32(0) == id)
                    {
                        idEmpleado = (lector.GetInt32(0));
                        idPersona = (lector.GetInt32(1));
                        
                        return this;
                    }
                }
                selecciona.desconectar();
                selecciona.dr.Close();
            }
            return null;
        }

       /*/ public int bajaEmpleado(int cod)
        {
            SqlCommand Comando;
            Datos inserta = new Datos();
            int regresa = 0;
            if (inserta.Conectar())
            {
                string comando = "update Empleado set Estatus = 'Baja' where idEmpleado=" + cod;
                Comando = inserta.construye_command(comando);
                if (inserta.ejecutanonquery() != 0)  //Regresa el numero de registros insertados
                    regresa = 1;
                else
                    regresa = 0;
                Comando.Connection.Close();
                inserta.desconectar();
            }
            else
                regresa = -1;
            return regresa;
        }
/*/

        public int bajaEmpleado(int codigo)
        {

            SqlCommand comando;
            Datos elimina = new Datos();
            int regresa = 0;
            if (elimina.Conectar())
            {
                comando = elimina.construye_command("delete from Empleado where idEmpleado=" + codigo);
                if (elimina.ejecutanonquery() != 0)
                    regresa = 0;
                else
                    regresa = 1;
            }
            else
                regresa = -1;
            return regresa;
        }
        public int actualiza_empleado()
        {
            SqlCommand Comando;
            Datos actualiza = new Datos();
            int regresa = 0;
            if (actualiza.Conectar())
            {
                Comando = actualiza.construye_command("update Empleado set Estatus= '" + Status + "',Usuario= '" + Usuario + "', Contraseña = '" + Contraseña + "' where idEmpleado= " + idEmpleado);
                if (actualiza.ejecutanonquery() != 0)
                    regresa = 1;
                else
                    regresa = 0;
                Comando.Connection.Close();
                actualiza.desconectar();
            }
            else
                return -1;
            return regresa;
        }
        public String regresa_usuario(int cod)
        {
            Datos selecciona = new Datos();
            SqlDataAdapter adaptador;
            DataRow fila;
            if (selecciona.Conectar())
            {
                try
                {
                    adaptador = selecciona.construye_adapter("select Usuario from Empleado" +
                    " where idEmpleado=" + cod);
                    fila = selecciona.extrae_registro(adaptador, "Empleado");
                    return fila["Usuario"].ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se encuentra el codigo");
                    return "";
                }
            }
            else
                return "";
        }

        public String regresa_contraseña(int cod)
        {
            Datos selecciona = new Datos();
            SqlDataAdapter adaptador;
            DataRow fila;
            if (selecciona.Conectar())
            {
                try
                {
                    adaptador = selecciona.construye_adapter("select Contraseña from Empleado" +
                    " where idEmpleado=" + cod);
                    fila = selecciona.extrae_registro(adaptador, "Empleado");
                    return fila["Contraseña"].ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se encuentra el codigo");
                    return "";
                }
            }
            else
                return "";
        }

        public String regresa_status(int cod)
        {
            Datos selecciona = new Datos();
            SqlDataAdapter adaptador;
            DataRow fila;
            if (selecciona.Conectar())
            {
                try
                {
                    adaptador = selecciona.construye_adapter("select Estatus from Empleado" +
                    " where idEmpleado=" + cod);
                    fila = selecciona.extrae_registro(adaptador, "Empleado");
                    return fila["Estatus"].ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se encuentra el codigo");
                    return "";
                }
            }
            else
                return "";
        }
    }


    //Turno
    public class Turno
    {
        public int idEmpleado { get; set; }
        public int idTurno { get; set; }

        public int idPersona { get; set; }
        public string turno { get;set; }
        public string HoraEntrada { get; set;}
        public string HoraSalida { get; set; }


        public Turno()
        {
            idEmpleado = 0;
            idTurno = 0;
            idPersona = 0;
            turno = "";
            HoraEntrada = "";
            HoraSalida = "";
        }
        public Turno(int e, int p, int i, string t, string he,string hs)
        {
            idEmpleado = e;
            idTurno = p;
            idPersona = i;
            turno = t;
            HoraEntrada = he;
            HoraSalida = hs;
        }

        public int altaTurno()
        {
            SqlCommand Comando;
            Datos inserta = new Datos();
            int regresa = 0;
            if (inserta.Conectar())
            {
                String comando = "INSERT INTO Turno (idEmpleado,Turno,HoraEntrada,HoraSalida)" +
                "values (" + Convert.ToInt32(idEmpleado) + ", '" + turno + "','" + HoraEntrada + "','" + HoraSalida + "')";

                Comando = inserta.construye_command(comando);
                if ((inserta.ejecutanonquery()) != 0)
                    regresa = 1;
                else
                    regresa = 0;
                Comando.Connection.Close();
                inserta.desconectar();
            }
            else
                regresa = -1;
            return regresa;
        }

    }
