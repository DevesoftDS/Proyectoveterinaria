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
    public class NUsusario
    {
        public static string CrearCuentaUsuario(string userName, string pasword, string tipo, int idEmpleado)
        {

            DUsuario objUsuario = new DUsuario();
            objUsuario.UserName = userName;
            objUsuario.Pasword = pasword;
            objUsuario.Tipo = tipo;
            objUsuario.IdEmpleado = idEmpleado;
            return objUsuario.CrearUsuario(objUsuario);
        }
        public static string ActualizarCuenta(int idUsuario, string userName, string pasword, string tipo, int idEmpleado)
        {
            DUsuario objUsuario = new DUsuario();
            objUsuario.IdUsuario = idUsuario;
            objUsuario.UserName = userName;
            objUsuario.Pasword = pasword;
            objUsuario.Tipo = tipo;
            objUsuario.IdEmpleado = idEmpleado;
            return objUsuario.ActualizarCuenta(objUsuario);
        }
        public static bool ActualizarEstadoUsuario(int estado,int idUsuario)
        {
            DUsuario objUsuario = new DUsuario();
            objUsuario.Estado = estado;
            objUsuario.IdUsuario = idUsuario;
          
            return objUsuario.ActualizarEstadoUsuario(objUsuario);
        }
        public static string EliminarUsuario(int idUsuario)
        {
            DUsuario objUsuario = new DUsuario();
            objUsuario.IdUsuario = idUsuario;
            return objUsuario.Eliminar(objUsuario);
        }

        public static DataTable BuscarUsuarioId(int idUsuario)
        {
            DUsuario objUser = new DUsuario();
            objUser.IdUsuario = idUsuario;
            return objUser.BuscarUsuarioId(objUser);
        }

        public static DataTable ListarUsuario()
        {
            return new DUsuario().ListarUsuario();

        }
        public static DataTable BuscarUsuario(string textoBuscar)
        {
            DUsuario objUser = new DUsuario();
            objUser.TextoBuscar = textoBuscar;
            return objUser.BuscarUsuarrio(objUser);
        }
       public static string estado;
        public static void ListarGriv(DataGridView dgv, DataTable tabla)
        {
            
            int numRow = tabla.Rows.Count;
            if (numRow > 0)
            {
                dgv.Rows.Clear();
                for (int i = 0; i < numRow; i++)
                {
                    int codigoUser = int.Parse(tabla.Rows[i]["idusuario"].ToString());
                    string personal = tabla.Rows[i]["personal"].ToString();
                    string usuario = tabla.Rows[i]["usuario"].ToString();
                    string password = DSeguridad.Encriptar(tabla.Rows[i]["pasword"].ToString());
                    string tipo = tabla.Rows[i]["tipo"].ToString();
                    int idempleado = int.Parse(tabla.Rows[i]["idempleado"].ToString());
                    int capturaEstado = int.Parse(tabla.Rows[i]["estado"].ToString());
                    if (capturaEstado == 1) estado = "Desactivar";
                    else estado = "Activar";

                    dgv.Rows.Add(i + 1, codigoUser, personal, usuario, password, tipo, idempleado, estado, "Editar", "Eliminar", "Ver");
                }
            }
        }

        public void ListarBusquedaUsuario(DataGridView dgv, string text)
        {
            var tabla = BuscarUsuario(text);
            ListarGriv(dgv, tabla);
        }
        public void ListadoDgv(DataGridView dgv)
        {
            var tabla = ListarUsuario();
            ListarGriv(dgv, tabla);
        }

        public static string DesencriptarPass(string text)
        {
            return DSeguridad.DesEncriptar(text);
        }
    }
}
