using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DUsuario
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Pasword { get; set; }
        public string Tipo { get; set; }
        public int IdEmpleado { get; set; }
        public int Estado { get; set; }
        public string TextoBuscar { get; set; }

        public DUsuario() { }

        public DUsuario(int idUsuario)
        {
            this.IdUsuario = idUsuario;
        }

        public DUsuario(string userName, string pasword, string tipo, int idEmpleado)
        {
            this.UserName = userName;
            this.Pasword = pasword;
            this.Tipo = tipo;
            this.IdEmpleado = idEmpleado;
        }

        public DUsuario(int estado, int idUsuario)
        {
            this.Estado = estado;
            this.IdUsuario = idUsuario;

        }
        public DUsuario(string textoBuscar)
        {
            this.TextoBuscar = textoBuscar;
        }

        public DUsuario(int idUsuario, string userName, string pasword, string tipo, int idEmpleado)
        {
            this.IdUsuario = idUsuario;
            this.UserName = userName;
            this.Pasword = pasword;
            this.Tipo = tipo;
            this.IdEmpleado = idEmpleado;
        }

        public string CrearUsuario(DUsuario usuario)
        {
            string rpta = "";
            string sql = "sp_insertar_usuario";
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@username", usuario.UserName);
                    cmd.Parameters.AddWithValue("@pasword", usuario.Pasword);
                    cmd.Parameters.AddWithValue("@tipo", usuario.Tipo);
                    cmd.Parameters.AddWithValue("@idempleado", usuario.IdEmpleado);                  
                    cmd.CommandType = CommandType.StoredProcedure;
                    rpta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "Error al crear Cuenta";
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
        public string ActualizarCuenta(DUsuario usuario)
        {
            string rpta = "";
            string sql = "sp_actualizar_usuario";
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idusuario", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("username", usuario.UserName);
                    cmd.Parameters.AddWithValue("pasword", usuario.Pasword);
                    cmd.Parameters.AddWithValue("tipo", usuario.Tipo);
                    cmd.Parameters.AddWithValue("idempleado", usuario.IdEmpleado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    rpta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "Error al actualizar usuario";
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
        public bool ActualizarEstadoUsuario(DUsuario usuario)
        {
            string sql = "sp_actualizar_estado_usuario";
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;

                using (var cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@estado", usuario.Estado);
                    cmd.Parameters.AddWithValue("@idusuario", usuario.IdUsuario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    int rpta = cmd.ExecuteNonQuery();
                    cn.Close();
                    if (rpta == 1)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return false;
                throw;
            }

            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return false;
        }        
        public string Eliminar(DUsuario usuario)
        {
            string rpta = "";
            string sql = "sp_eliminar_usuario";
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql,cn))
                {
                    cmd.Parameters.AddWithValue("@idusuario", usuario.IdUsuario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    rpta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "Error al eliminar la cuenta de usuario";                   
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
        public DataTable ListarUsuario()
        {
            string sql = "sp_listar_usuario";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (var da = new SqlDataAdapter(sql,cn))
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
        public DataTable BuscarUsuarrio(DUsuario usuario)
        {
            string sql = "sp_buscar_usuario";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (var da = new SqlDataAdapter(sql,cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@buscar", usuario.TextoBuscar);
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
        public DataTable BuscarUsuarioId(DUsuario usuario)
        {
            string sql = "sp_buscar_idusuario";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (var da = new SqlDataAdapter(sql,cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@idusuario", usuario.IdUsuario);
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
        public DataTable BuscarUsuarioIdEmpleado(DUsuario usuario)
        {
            string sql = "sp_buscar_usuario_idempleado";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@idempleado", usuario.IdEmpleado);
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



    }
}
