using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DMascota
    {
        

        public int IdMascota { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public string Peso { get; set; }
        public string Descripcion { get; set; }
        public int IdRaza { get; set; }
        public int IdCliente { get; set; }
        public byte[] Foto { get; set; }
        public string TextoBuscar { get; set; }

        public DMascota()
        {

        }
        public DMascota(int idMascota)
        {
            this.IdMascota = idMascota;
        }

        public DMascota(string textoBuscar)
        {
            this.TextoBuscar = textoBuscar;
        }

        public DMascota(string nombre, string edad, string sexo, string peso, string descripcion, int idRaza, int idCliente, byte[] foto)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.Sexo = sexo;
            this.Peso = peso;
            this.Descripcion = descripcion;
            this.IdRaza = idRaza;
            this.IdCliente = idCliente;
            this.Foto = foto;
        }

        public DMascota(int idMascota, string nombre, string edad, string sexo, string peso, string descripcion, int idRaza, int idCliente, byte[] foto) : this(idMascota)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.Sexo = sexo;
            this.Peso = peso;
            this.Descripcion = descripcion;
            this.IdRaza = idRaza;
            this.IdCliente = idCliente;
            this.Foto = foto;
        }
        public string InsertarMascota(DMascota mascota)
        {
            string rpta = "";
            string sql = "sp_insertar_mascota";
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", mascota.Nombre);
                    cmd.Parameters.AddWithValue("@edad", mascota.Edad);
                    cmd.Parameters.AddWithValue("@sexo", mascota.Sexo);
                    cmd.Parameters.AddWithValue("@peso", mascota.Peso);
                    cmd.Parameters.AddWithValue("@descripcion", mascota.Descripcion);
                    cmd.Parameters.AddWithValue("@idraza", mascota.IdRaza);
                    cmd.Parameters.AddWithValue("@idcliente", mascota.IdCliente);
                    cmd.Parameters.AddWithValue("@foto", mascota.Foto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    rpta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "Error al la mascota";
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

        public string ActualzarMascota(DMascota mascota)
        {
            string rpta = "";
            string sql = "sp_modificar_mascota";
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idmascota", mascota.IdMascota);
                    cmd.Parameters.AddWithValue("@nombre", mascota.Nombre);
                    cmd.Parameters.AddWithValue("@edad", mascota.Edad);
                    cmd.Parameters.AddWithValue("@sexo", mascota.Sexo);
                    cmd.Parameters.AddWithValue("@peso", mascota.Peso);
                    cmd.Parameters.AddWithValue("@descripcion", mascota.Descripcion);
                    cmd.Parameters.AddWithValue("@idraza", mascota.IdRaza);
                    cmd.Parameters.AddWithValue("@idcliente", mascota.IdCliente);
                    cmd.Parameters.AddWithValue("@foto", mascota.Foto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    rpta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "Error al actualizar datos de la mascota";
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

        public string EliminarMascota(DMascota mascota)
        {
            string rpta = "";
            string sql = "sp_eliminar_mascota";
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idmascota", mascota.IdMascota);
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
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return rpta;
        }

        public DataTable ListarMascota()
        {
            string sql = "sp_listar_mascota";
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

        public DataTable BuscarMascota(DMascota mascota)
        {
            string sql = "sp_buscar_mascota";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@buscar", mascota.TextoBuscar);
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

        public DataTable BuscarMascotaId(DMascota mascota)
        {
            string sql = "sp_buscar_idmascota";
            DataTable tabla = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@idmascota", mascota.IdMascota);
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
