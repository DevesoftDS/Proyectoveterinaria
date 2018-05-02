using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DPresentacion
    {
        private DConexion cn = new DConexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public int Idpresentacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public DPresentacion()
        {

        }
        public DPresentacion(int idpresentacion, string nombre, string descripcion)
        {
            this.Idpresentacion = idpresentacion;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public DPresentacion(string nombre, string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public DataTable Mostrar()
        {
            //code here
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "select *from categoria";
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            cn.CerrarConexion();
            return tabla;

        }

        public void Insertar(DPresentacion presentacion)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "sp_insertar_categoria";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", presentacion.Nombre);
            cmd.Parameters.AddWithValue("@descripcion", presentacion.Descripcion);
            cmd.ExecuteNonQuery();
            cn.CerrarConexion();
        }
    }
}
