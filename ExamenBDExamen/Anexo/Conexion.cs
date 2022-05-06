using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamenBDExamen.Anexo
{
    public class Conexion
    {
        public SqlConnection conect = new SqlConnection();
        public Conexion(string user, string password)
        {
            try
            {
                conect = new SqlConnection("Server=localhost; Database=BDExamen; UID=" + user + ";PWD=" + password);
                conect.Open();
            }
            catch
            {

            }
        }
        public Conexion()
        {

        }
        public int IdentificarUsuario(string user)
        {
            SqlConnection k = new SqlConnection("Server=localhost; Database=BDExamen; UID=UserExam; PWD=201299");
            SqlCommand prueba = new SqlCommand("sp_getrole", k);
            prueba.CommandType = CommandType.StoredProcedure;
            prueba.Parameters.AddWithValue("@username", user);
            prueba.Parameters.Add("@role", SqlDbType.Int).Direction = ParameterDirection.Output;
            k.Open();
            int t = prueba.ExecuteNonQuery();
            int y=4;
            if (prueba.Parameters["@role"].Value.ToString().Equals(""))
            {                
            }
            else
            {
                 y = Convert.ToInt32(prueba.Parameters["@role"].Value);
            }
            k.Close();
            return y;
        }  
        public DataTable ListarEntidades(string procedure)
        {
            DataTable entidades = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedure;
            cmd.Connection = conect;

            SqlDataAdapter adacter = new SqlDataAdapter(cmd);
            adacter.Fill(entidades);
            conect.Close();
            return entidades;
        }
        public void NuevaEntidad(string procedure, List<string> datos)
        {
            SqlCommand cmd = new SqlCommand();
            SqlParameter[] parametre = new SqlParameter[datos.Count];
            switch (procedure)
            {
                case "Ncliente":
                    parametre[0] = new SqlParameter("@PNombre", SqlDbType.NVarChar);
                    parametre[0].Value = datos[0];
                    parametre[1] = new SqlParameter("@SNombre", SqlDbType.NVarChar);
                    parametre[1].Value = datos[1];
                    parametre[2] = new SqlParameter("@PApell", SqlDbType.NVarChar);
                    parametre[2].Value = datos[2];
                    parametre[3] = new SqlParameter("@SApell", SqlDbType.NVarChar);
                    parametre[3].Value = datos[3];
                    parametre[4] = new SqlParameter("@Telc", SqlDbType.Char);
                    parametre[4].Value = datos[4];
                    break;
                case "Ncompra":
                    parametre[0] = new SqlParameter("@idprov", SqlDbType.Char);
                    parametre[0].Value = datos[0];
                    parametre[1] = new SqlParameter("@tipopago", SqlDbType.VarChar);
                    parametre[1].Value = datos[1];
                    break;
                case "NDetalleCompra":
                    parametre[0] = new SqlParameter("@idcompra", SqlDbType.Int);
                    parametre[0].Value = datos[0];
                    parametre[1] = new SqlParameter("@cod_producto", SqlDbType.Char);
                    parametre[1].Value = datos[1];
                    parametre[2] = new SqlParameter("@cantidad", SqlDbType.Int);
                    parametre[2].Value = datos[2];
                    parametre[3] = new SqlParameter("@precioCom", SqlDbType.Float);
                    parametre[3].Value = datos[3];
                    break;
                case "NProductos":
                    parametre[0] = new SqlParameter("@cod_arti", SqlDbType.Char);
                    parametre[0].Value = datos[0];
                    parametre[1] = new SqlParameter("@NombreP", SqlDbType.NVarChar);
                    parametre[1].Value = datos[1];
                    parametre[2] = new SqlParameter("@Desp", SqlDbType.NVarChar);
                    parametre[2].Value = datos[2];
                    parametre[3] = new SqlParameter("@precio", SqlDbType.Float);
                    parametre[3].Value = datos[3];
                    parametre[4] = new SqlParameter("@exist", SqlDbType.Int);
                    parametre[4].Value = datos[4];
                    parametre[5] = new SqlParameter("@id_Prov", SqlDbType.Char);
                    parametre[5].Value = datos[5];
                    parametre[6] = new SqlParameter("@id_TipoP", SqlDbType.Int);
                    parametre[6].Value = datos[6];
                    break;
                case "NProveedores":
                    parametre[0] = new SqlParameter("@id_prove", SqlDbType.Char);
                    parametre[0].Value = datos[0];
                    parametre[1] = new SqlParameter("@NombreProv", SqlDbType.NVarChar);
                    parametre[1].Value = datos[1];
                    parametre[2] = new SqlParameter("@Tel", SqlDbType.Char);
                    parametre[2].Value = datos[2];
                    parametre[3] = new SqlParameter("@Direccion", SqlDbType.NVarChar);
                    parametre[3].Value = datos[3];
                    parametre[4] = new SqlParameter("@CorreoP", SqlDbType.NVarChar);
                    parametre[4].Value = datos[4];
                    break;
                case "nueva_detalle_devolucion":
                    parametre[0] = new SqlParameter("@cod_pro", SqlDbType.Char);
                    parametre[0].Value = datos[0];
                    parametre[1] = new SqlParameter("@id_dev", SqlDbType.Int);
                    parametre[1].Value = datos[1];
                    parametre[2] = new SqlParameter("@cantidad", SqlDbType.Int);
                    parametre[2].Value = datos[2];
                    parametre[3] = new SqlParameter("@motivo", SqlDbType.NVarChar);
                    parametre[3].Value = datos[3];
                    break;
                case "nueva_dev":
                    parametre[0] = new SqlParameter("@id_compra", SqlDbType.Int);
                    if (datos[0].Length == 0)
                    {
                        parametre[0].Value = 0;
                    }
                    else
                    {
                        parametre[0].Value = datos[0];
                    }
                    parametre[1] = new SqlParameter("@id_venta", SqlDbType.Int);
                    if (datos[1].Length == 0)
                    {
                        parametre[1].Value = 0;
                    }
                    else
                    {
                        parametre[1].Value = datos[1];
                    }
                    break;
                case "Nventas":
                    parametre[0] = new SqlParameter("@id_Cliente", SqlDbType.Int);
                    parametre[0].Value = datos[0];
                    break;
                case "NDetalleVenta":
                    parametre[0] = new SqlParameter("@N_venta", SqlDbType.Int);
                    parametre[0].Value = datos[0];
                    parametre[1] = new SqlParameter("@cod_producto", SqlDbType.Char);
                    parametre[1].Value = datos[1];
                    parametre[2] = new SqlParameter("@cantidad", SqlDbType.Int);
                    parametre[2].Value = datos[2];
                    break;
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedure;
            cmd.Connection = conect;
            cmd.Parameters.AddRange(parametre);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);            
        }
        public void BajaEntidad(string procedure, List<string> datos)
        {
            SqlCommand cmd = new SqlCommand();
            SqlParameter[] parameter = new SqlParameter[datos.Count];
            switch (procedure)
            {
                case "":
                    parameter[0] = new SqlParameter("name´s datos", SqlDbType.VarChar);
                    parameter[0].Value = datos[0];
                    break;
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedure;
            cmd.Connection = conect;
            cmd.Parameters.AddRange(parameter);
            conect.Close();
        }
        public void ModificarEdintidad(string procedure, List<string> datos)
        {
            SqlCommand cmd = new SqlCommand();
            SqlParameter[] parameter = new SqlParameter[datos.Count];
            switch (procedure)
            {
                case "ActPProd":
                    break;
                case "Mcompra":
                    parameter[0] = new SqlParameter("@id_Compra", SqlDbType.Int);
                    parameter[0].Value = datos[0];
                    parameter[1] = new SqlParameter("@Tipopago", SqlDbType.VarChar);
                    parameter[1].Value = datos[1];
                    break;
                case "Mdetalle_devoluc":
                    parameter[0] = new SqlParameter("@id_detalledevol", SqlDbType.Int);
                    parameter[0].Value = datos[0];
                    parameter[1] = new SqlParameter("@descripcion", SqlDbType.VarChar);
                    parameter[1].Value = datos[1];
                    break;
                case "Mdevolucion":
                    parameter[0] = new SqlParameter("@id_devolucion", SqlDbType.Int);
                    parameter[0].Value = datos[0];
                    parameter[1] = new SqlParameter("@idcompra", SqlDbType.Int);
                    parameter[1].Value = datos[1];
                    parameter[2] = new SqlParameter("@nventa", SqlDbType.Int);
                    parameter[2].Value = datos[2];
                    break;
                case "ModificarCL":
                    parameter[0] = new SqlParameter("@ID_Cliente", SqlDbType.Int);
                    parameter[0].Value = datos[0];
                    parameter[1] = new SqlParameter("@TelC", SqlDbType.Char);
                    parameter[1].Value = datos[1];
                    break;
                case "modificarDetalle_Compras":
                    parameter[0] = new SqlParameter("@id_DetalleCompra", SqlDbType.Int);
                    parameter[0].Value = datos[0];
                    parameter[1] = new SqlParameter("@cod_producto", SqlDbType.Char);
                    parameter[1].Value = datos[1];
                    parameter[2] = new SqlParameter("@nuevacantidad", SqlDbType.Int);
                    parameter[2].Value = datos[2];
                    parameter[3] = new SqlParameter("@precio", SqlDbType.Float);
                    parameter[3].Value = datos[3];
                    parameter[4] = new SqlParameter("@accion", SqlDbType.VarChar);
                    parameter[4].Value = datos[4];
                    break;
                case "modificarDetalle_Venta":
                    parameter[0] = new SqlParameter("@id_detalleVenta", SqlDbType.Int);
                    parameter[0].Value = datos[0];
                    parameter[1] = new SqlParameter("@cod_produ", SqlDbType.Char);
                    parameter[1].Value = datos[1];
                    parameter[2] = new SqlParameter("@nuevacantidad", SqlDbType.Int);
                    parameter[2].Value = datos[2];
                    parameter[3] = new SqlParameter("@accion", SqlDbType.VarChar);
                    parameter[3].Value = datos[3];
                    break;
                case "ModificarProducto":
                    parameter[0] = new SqlParameter("@cod_Pro", SqlDbType.Char);
                    parameter[0].Value = datos[0];
                    parameter[1] = new SqlParameter("@nombrep", SqlDbType.NVarChar);
                    parameter[1].Value = datos[1];
                    parameter[2] = new SqlParameter("@precio", SqlDbType.Float);
                    parameter[2].Value = datos[2];
                    parameter[3] = new SqlParameter("@exits", SqlDbType.Int);
                    parameter[3].Value = datos[3];
                    parameter[4] = new SqlParameter("@id_tipop", SqlDbType.Int);
                    parameter[4].Value = datos[4];
                    break;
                case "ModificarProvee":
                    parameter[0] = new SqlParameter("@id_Provee", SqlDbType.Char);
                    parameter[0].Value = datos[0];
                    parameter[1] = new SqlParameter("@Telp", SqlDbType.Char);
                    parameter[1].Value = datos[1];
                    parameter[2] = new SqlParameter("@direcci", SqlDbType.NVarChar);
                    parameter[2].Value = datos[2];
                    parameter[3] = new SqlParameter("@correop", SqlDbType.NVarChar);
                    parameter[3].Value = datos[3];
                    break;
                case "ModificarVentas":
                    parameter[0] = new SqlParameter("@n_ventas", SqlDbType.Int);
                    parameter[0].Value = Convert.ToInt32(datos[0]);
                    parameter[1] = new SqlParameter("@id_cliente", SqlDbType.Int);
                    parameter[1].Value = Convert.ToInt32(datos[1]);
                    break;
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedure;
            cmd.Connection = conect;
            cmd.Parameters.AddRange(parameter);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
        public DataTable BuscarEntidad(string procedure, List<string> datos)
        {
            DataTable entidades = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlParameter[] parameter = new SqlParameter[datos.Count];
            switch (procedure)
            {
                case "BuscarCl":
                    parameter[0] = new SqlParameter("@id_cliente", SqlDbType.Int);
                    parameter[0].Value = datos[0];
                    break;
                case "BuscarCompra":
                    parameter[0] = new SqlParameter("@id_Compra", SqlDbType.Int);
                    parameter[0].Value = datos[0];
                    break;
                case "BuscarDetallecompra":
                    parameter[0] = new SqlParameter("@id_detallecomp", SqlDbType.Int);
                    parameter[0].Value = datos[0];
                    break;
                case "BuscardetalleDevolucion":
                    parameter[0] = new SqlParameter("@id_detadevolucion", SqlDbType.Int);
                    parameter[0].Value = datos[0];
                    break;
                case "BuscarDetalleVenta":
                    parameter[0] = new SqlParameter("@id_detalleve", SqlDbType.Int);
                    parameter[0].Value = datos[0];
                    break;
                case "BuscarDevolu":
                    parameter[0] = new SqlParameter("@id_devolucion", SqlDbType.Int);
                    parameter[0].Value = datos[0];
                    break;
                case "BuscarProduc":
                    parameter[0] = new SqlParameter("@cod_prod", SqlDbType.Char);
                    parameter[0].Value = datos[0];
                    break;
                case "BuscarProv":
                    parameter[0] = new SqlParameter("@id_proveedor", SqlDbType.Char);
                    parameter[0].Value = datos[0];
                    break;
                case "BuscarVentas":
                    parameter[0] = new SqlParameter("@n_ventas", SqlDbType.Int);
                    parameter[0].Value = Convert.ToInt32(datos[0]);
                    break;
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedure;
            cmd.Connection = conect;
            cmd.Parameters.AddRange(parameter);
            SqlDataAdapter adacter = new SqlDataAdapter(cmd);
            adacter.Fill(entidades);
            conect.Close();
            return entidades;
        }
        public DataTable Vistas(string vista)
        {
            DataTable entidades = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from " +vista;
            cmd.Connection = conect;

            SqlDataAdapter adacter = new SqlDataAdapter(cmd);
            adacter.Fill(entidades);
            conect.Close();
            return entidades;
        }
    }
}
