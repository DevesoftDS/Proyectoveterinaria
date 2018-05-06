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
    public class NEmpleado
    {
        public static string InsertarEmpleado(string nombre, string apellido, string dni, string sexo, string telefono, string correo, string direccion, byte[] foto)
        {
            DEmpleado objEmpleado = new DEmpleado();
            objEmpleado.Nombre = nombre;
            objEmpleado.Apellido = apellido;
            objEmpleado.Dni = dni;
            objEmpleado.Sexo = sexo;
            objEmpleado.Telefono = telefono;
            objEmpleado.Correo = correo;
            objEmpleado.Direccion = correo;
            objEmpleado.Foto = foto;
            return objEmpleado.InsertarEmpleado(objEmpleado);
        }
        public static string ModificarEmpleado(int idempleado, string nombre, string apellido, string dni, string sexo, string telefono, string correo, string direccion, byte[] foto)
        {
            DEmpleado objEmpleado = new DEmpleado();
            objEmpleado.IdEmpleado = idempleado;
            objEmpleado.Nombre = nombre;
            objEmpleado.Apellido = apellido;
            objEmpleado.Dni = dni;
            objEmpleado.Sexo = sexo;
            objEmpleado.Telefono = telefono;
            objEmpleado.Correo = correo;
            objEmpleado.Direccion = correo;
            objEmpleado.Foto = foto;
            return objEmpleado.ActualzarEmpleado(objEmpleado);
        }

        public static string EliminarEmpleado(int idEmpleado)
        {
            DEmpleado objCliente = new DEmpleado();
            objCliente.IdEmpleado = idEmpleado;
            return objCliente.EliminarEmpleado(objCliente);
        }

        public static DataTable BuscarEmpleadoId(int idEmpleado)
        {
            DEmpleado objEmpleado = new DEmpleado();
            objEmpleado.IdEmpleado = idEmpleado;
            return objEmpleado.BuscarempleadoId(objEmpleado);
        }

        public static DataTable ListarEmpleado()
        {
            return new DEmpleado().ListarEmpleado();
        }
        public static DataTable BuscarEmpleado(string textoBuscar)
        {
            DEmpleado objEmpleado = new DEmpleado();
            objEmpleado.TextoBuscar = textoBuscar;
            return objEmpleado.Buscarempleado(objEmpleado);
        }

        public static void ListarGriv(DataGridView dgv, DataTable tabla)
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

                    dgv.Rows.Add(i + 1,"Crear Cuenta" ,codigo, nombre, apellido, dni, sexo, telefono, correo, direccion, "Editar", "Eliminar", "Ver");
                }
            }
        }

        public void ListarBusquedaCliente(DataGridView dgv, string text)
        {
            var tabla = BuscarEmpleado(text);
            ListarGriv(dgv, tabla);
        }
        public void ListadoDgv(DataGridView dgv)
        {

            var tabla = ListarEmpleado();
            ListarGriv(dgv, tabla);
        }
    }
}
