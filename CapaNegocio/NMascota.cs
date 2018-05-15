using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NMascota
    {
        public NMascota() { }
        public static string InsertarMascota(string nombre, string edad, string sexo, string peso, string descripcion, int idRaza, int idCliente, byte[] foto)
        {
            DMascota objMascota = new DMascota();
            objMascota.Nombre = nombre;
            objMascota.Edad = edad;
            objMascota.Sexo = sexo;
            objMascota.Peso = peso;
            objMascota.Descripcion = descripcion;
            objMascota.IdRaza = idRaza;
            objMascota.IdCliente = idCliente;
            objMascota.Foto = foto;
            return objMascota.InsertarMascota(objMascota);
        }
        public static string ActualizarMascota(int idMascota, string nombre, string edad, string sexo, string peso, string descripcion, int idRaza, int idCliente, byte[] foto)
        {
            DMascota objMascota = new DMascota();
            objMascota.IdMascota = idMascota;
            objMascota.Nombre = nombre;
            objMascota.Edad = edad;
            objMascota.Sexo = sexo;
            objMascota.Peso = peso;
            objMascota.Descripcion = descripcion;
            objMascota.IdRaza = idRaza;
            objMascota.IdCliente = idCliente;
            objMascota.Foto = foto;
            return objMascota.ActualzarMascota(objMascota);
        }
        public static string EliminarMascota(int idmascota)
        {
            DMascota objMascota = new DMascota();
            objMascota.IdMascota = idmascota;
            return objMascota.EliminarMascota(objMascota);
        }
        public static DataTable BuscarMascotaId(int idMascota)
        {
            DMascota objMascota = new DMascota();
            objMascota.IdMascota = idMascota;
            return objMascota.BuscarMascotaId(objMascota);
        }
        public static DataTable ListarMascota()
        {
            return new DMascota().ListarMascota();
        }
        public static DataTable BuscarMascota(string textoBuscar)
        {
            DMascota objMascota = new DMascota();
            objMascota.TextoBuscar = textoBuscar;
            return objMascota.BuscarMascota(objMascota);
        }
        public static void ListarGriv(DataGridView dgv, DataTable tabla)
        {
            int numRow = tabla.Rows.Count;
            if (numRow > 0)
            {
                dgv.Rows.Clear();
                for (int i = 0; i < numRow; i++)
                {
                    int idmascota = int.Parse(tabla.Rows[i]["idmascota"].ToString());
                    string codigo = tabla.Rows[i]["codigo"].ToString();
                    string mascota = tabla.Rows[i]["nombre"].ToString();
                    string edad = tabla.Rows[i]["edad"].ToString();
                    string sexo = tabla.Rows[i]["sexo"].ToString();
                    string peso = tabla.Rows[i]["peso"].ToString();
                    string especie = tabla.Rows[i]["especie"].ToString();
                    string raza = tabla.Rows[i]["raza"].ToString();
                    string cliente = tabla.Rows[i]["nombres"].ToString() +" "+tabla.Rows[i]["apellidos"].ToString();                    
                    string telefono = tabla.Rows[i]["telefono"].ToString();
                    string correo = tabla.Rows[i]["correo"].ToString();
                    string direccion = tabla.Rows[i]["direccion"].ToString();
                    int idraza = int.Parse(tabla.Rows[i]["idraza"].ToString());
                    int idcliente = int.Parse(tabla.Rows[i]["idcliente"].ToString());


                    dgv.Rows.Add(i + 1, idmascota,codigo, mascota, edad, peso, sexo, especie, raza, cliente,telefono,correo,direccion, "Editar", "Eliminar", "Ver",idraza,idcliente);
                }
            }
        }
        public void ListarBusquedaMascota(DataGridView dgv, string text)
        {
            var tabla = BuscarMascota(text);
            ListarGriv(dgv, tabla);
        }
        public void ListadoDgv(DataGridView dgv)
        {
            var tabla = ListarMascota();
            ListarGriv(dgv, tabla);
        }
    }
}
