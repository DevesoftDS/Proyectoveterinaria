using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DEmpleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public byte[] Foto { get; set; }

        public string TextoBuscar { get; set; }

        public DEmpleado() { }

        public DEmpleado(int idEmpleado)
        {
            this.IdEmpleado = idEmpleado;
        }
        public DEmpleado(string nombre, string apellido, string dni, string sexo, string telefono, string correo, string direccion, byte[] foto)
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
        public DEmpleado(int idEmpleado, string nombre, string apellido, string dni, string sexo, string telefono, string correo, string direccion, byte[] foto) : this(idEmpleado)
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

        public DEmpleado(string textoBuscar)
        {
            this.TextoBuscar = textoBuscar;
        }


        public string InsertarEmpleado(DEmpleado empleado)
        {
            string rpta = "";
            string sql = "sp_insertar_empleado";
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombres", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@apellidos", empleado.Apellido);
                    cmd.Parameters.AddWithValue("@dni", empleado.Dni);
                    cmd.Parameters.AddWithValue("@sexo", empleado.Sexo);
                    cmd.Parameters.AddWithValue("@telefono", empleado.Telefono);
                    cmd.Parameters.AddWithValue("@correo", empleado.Correo);
                    cmd.Parameters.AddWithValue("@direccion", empleado.Direccion);
                    cmd.Parameters.AddWithValue("@foto", empleado.Foto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    rpta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "Error al Registrar empleado";
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

        public string ActualzarEmpleado(DEmpleado empleado)
        {
            string rpta = "";
            string sql = "sp_modificar_empleado";
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idempleado", empleado.IdEmpleado);
                    cmd.Parameters.AddWithValue("@nombres", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@apellidos", empleado.Apellido);
                    cmd.Parameters.AddWithValue("@dni", empleado.Dni);
                    cmd.Parameters.AddWithValue("@sexo", empleado.Sexo);
                    cmd.Parameters.AddWithValue("@telefono", empleado.Telefono);
                    cmd.Parameters.AddWithValue("@correo", empleado.Correo);
                    cmd.Parameters.AddWithValue("@direccion", empleado.Direccion);
                    cmd.Parameters.AddWithValue("@foto", empleado.Foto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    rpta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "Error al modificar  empleado";
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

        public string EliminarEmpleado(DEmpleado empleado)
        {
            string rpta = "";
            string sql = "sp_eliminar_empleado";
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idempleado", empleado.IdEmpleado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    rpta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "Error al Eliminar empleado";
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

        public DataTable ListarEmpleado()
        {
            string sql = "sp_listar_empleado";
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

        public DataTable Buscarempleado(DEmpleado empleado)
        {
            string sql = "sp_buscar_empleado";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@buscar", empleado.TextoBuscar);
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

        public DataTable BuscarempleadoId(DEmpleado empleado)
        {
            string sql = "sp_buscar_idempleado";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@idempleado", empleado.IdEmpleado);
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
