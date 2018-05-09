using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCliente
    {
        
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public byte[] Foto { get; set; }

        public string TextoBuscar { get; set; }

        public DCliente()
        {

        }

        public DCliente(int idCliente)
        {
            this.IdCliente = idCliente;
        }

        public DCliente(string nombre, string apellido, string dni, string sexo, string telefono, string correo, string direccion, byte[] foto)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.Sexo = sexo;
            this.Telefono = telefono;
            this.Correo = correo;
            this.Direccion = direccion;
            this.Foto = foto;
        }

        public DCliente(int idCliente, string nombre, string apellido, string dni, string sexo, string telefono, string correo, string direccion, byte[] foto)
        {
            this.IdCliente = idCliente;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.Sexo = sexo;
            this.Telefono = telefono;
            this.Correo = correo;
            this.Direccion = direccion;
            this.Foto = foto;
        }

        public string InsertarCliente(DCliente cliente)
        {
            string rpta = "";
            string sql = "sp_insertar_cliente";
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql,cn))
                {
                    cmd.Parameters.AddWithValue("@nombres", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@apellidos", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@dni", cliente.Dni);
                    cmd.Parameters.AddWithValue("@sexo", cliente.Sexo);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@correo", cliente.Correo);
                    cmd.Parameters.AddWithValue("direccion", cliente.Direccion);
                    cmd.Parameters.AddWithValue("foto", cliente.Foto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    rpta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "Error al Registrar el Cliente";
                }
            }
            catch (Exception ex)
            {
                rpta= ex.Message.ToString();
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();                
            }
            return rpta;
        }

        public string ActualzarCliente(DCliente cliente)
        {
            string rpta = "";
            string sql = "sp_modificar_cliente";
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idcliente", cliente.IdCliente);
                    cmd.Parameters.AddWithValue("@nombres", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@apellidos", cliente.Apellido);
                    cmd.Parameters.AddWithValue("@dni", cliente.Dni);
                    cmd.Parameters.AddWithValue("@sexo", cliente.Sexo);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@correo", cliente.Correo);
                    cmd.Parameters.AddWithValue("direccion", cliente.Direccion);
                    cmd.Parameters.AddWithValue("foto", cliente.Foto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    rpta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "Error al Modificar el Cliente";
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message.ToString();
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return rpta;
        }

        public string EliminarCliente(DCliente cliente)
        {
            string rpta = "";
            string sql = "sp_eliminar_cliente";
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idcliente", cliente.IdCliente);
                    cmd.CommandType = CommandType.StoredProcedure;
                    rpta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "Error al Eliminar";
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message.ToString();
                throw;
            }
            finally
            {
                if (cn.State==ConnectionState.Open) cn.Close();
            }
            return rpta;
        }

        public DataTable ListarCliente()
        {
            string sql = "sp_listar_cliente";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(tabla);
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                tabla = null;
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return tabla;
        }

        public DataTable BuscarCliente(DCliente cliente)
        {
            string sql = "sp_buscar_cliente";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (var da = new SqlDataAdapter(sql, cn))                          
                {
                    da.SelectCommand.Parameters.AddWithValue("@buscar", cliente.TextoBuscar);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                tabla = null;
                ex.Message.ToString();
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return tabla;
        }

        public DataTable BuscarClienteId(DCliente cliente)
        {
            string sql = "sp_buscar_idcliente";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@idcliente", cliente.IdCliente);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                tabla = null;
                ex.Message.ToString();
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return tabla;
        }

    }
}
