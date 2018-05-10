using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Windows.Forms;
using System.Data;
using System.IO;


namespace CapaNegocio
{
    public class NCliente
    {
        
        public static string InsertarCliente(string nombre, string apellido, string dni, string sexo, string telefono, string correo, string direccion, byte[] foto)
        {
            DCliente objCliente = new DCliente();
            objCliente.Nombre = nombre;
            objCliente.Apellido = apellido;
            objCliente.Dni = dni;
            objCliente.Sexo = sexo;
            objCliente.Telefono = telefono;
            objCliente.Correo = correo;
            objCliente.Direccion = direccion;
            objCliente.Foto = foto;
            return objCliente.InsertarCliente(objCliente);
        }
        public static string ModificarCliente(int idCliente ,string nombre, string apellido, string dni, string sexo, string telefono, string correo, string direccion, byte[] foto)
        {
            DCliente objCliente = new DCliente();
            objCliente.IdCliente = idCliente;
            objCliente.Nombre = nombre;
            objCliente.Apellido = apellido;
            objCliente.Dni = dni;
            objCliente.Sexo = sexo;
            objCliente.Telefono = telefono;
            objCliente.Correo = correo;
            objCliente.Direccion = direccion;
            objCliente.Foto = foto;
            return objCliente.ActualzarCliente(objCliente);
        }
        public static string EliminarCliente(int idCliente)
        {
            DCliente objCliente = new DCliente();
            objCliente.IdCliente = idCliente;
            return objCliente.EliminarCliente(objCliente);
        }
        public static DataTable BuscarClienteId(int idCliente)
        {
            DCliente objCliente = new DCliente();
            objCliente.IdCliente = idCliente;
            return objCliente.BuscarClienteId(objCliente);
        }
        public static DataTable ListarCliente()
        {
            return new DCliente().ListarCliente();
        }
        public static DataTable BuscarCliente(string textoBuscar)
        {
            DCliente objCliente = new DCliente();
            objCliente.TextoBuscar = textoBuscar;
            return objCliente.BuscarCliente(objCliente);
        }                      
        public static void ListarGriv(DataGridView dgv , DataTable tabla)
        {
            int numRow = tabla.Rows.Count;
            if (numRow > 0)
            {
                dgv.Rows.Clear();
                for (int i = 0; i < numRow; i++)
                {
                    int codigo = int.Parse(tabla.Rows[i]["codigo"].ToString());
                    string nombre = tabla.Rows[i]["nombres"].ToString();
                    string apellido = tabla.Rows[i]["apellidos"].ToString();
                    string dni = tabla.Rows[i]["dni"].ToString();
                    string sexo = tabla.Rows[i]["sexo"].ToString();
                    string telefono = tabla.Rows[i]["telefono"].ToString();
                    string correo = tabla.Rows[i]["correo"].ToString();
                    string direccion = tabla.Rows[i]["direccion"].ToString();                 
                                                          
                    dgv.Rows.Add(i + 1, codigo, nombre, apellido, dni, sexo, telefono, correo,direccion,"Editar","Eliminar","Ver");
                }
            }
        }
        public void ListarBusquedaCliente(DataGridView dgv, string text)
        {
            var tabla = BuscarCliente(text);
            ListarGriv(dgv, tabla);
        }
        public void ListadoDgv(DataGridView dgv)
        {

            var tabla = ListarCliente();
            ListarGriv(dgv, tabla);
        }

    }
}
