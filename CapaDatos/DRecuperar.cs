using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data;

namespace CapaDatos
{
    public class DRecuperar
    {
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mensaje { get; set; }


        public string RecuperarContraseña(DRecuperar recuperar)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                // code here 
                cn.ConnectionString = Conexion.conectar;
                cn.Open();
                string cadena = "sp_recuperar_contraseña";
                SqlDataReader leer;

                using (SqlCommand cmd = new SqlCommand(cadena, cn))
                {
                    cmd.Parameters.AddWithValue("@dni", recuperar.Dni);
                    cmd.CommandType = CommandType.StoredProcedure;
                    leer = cmd.ExecuteReader();
                    if (leer.Read() == true)
                    {
                        Email = leer["correo"].ToString();
                        Nombres = leer["nombres"].ToString() + " " + leer["apellidos"].ToString();
                        Password = leer["pasword"].ToString();
                        EnviarEmail();

                        Mensaje = "Estimado Sr(a). " + Nombres + " , la contraseña fue enviada a su correo: " + Email + " : verifique bandeja de entrada (O_O)";
                        leer.Close();
                    }
                    else
                    {
                        Mensaje = "Datos no encontrados en la base de datos. Consulte con su administrador para poder acceder al sistema SOFVET";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ..!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Mensaje;
                throw;
            }
            return Mensaje;
        }

        public void EnviarEmail()
        {
            //correo
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("sofvet2018@gmail.com");
            correo.To.Add(Email);
            correo.Subject = ("RECUPERAR CONTRASEÑA SOFVET");
            correo.Body = "HOLA " + Nombres + " usted ha solicitado recuperar su contraseña para poder acceder al sistema, obvie y elimine este mensaje. (O_O) - SU CONTRASEÑA ES: " + Password + " Gracias el equipo de SofVet";
            correo.Priority = MailPriority.Normal;

            //SMTP

            SmtpClient serverMail = new SmtpClient();
            serverMail.Credentials = new NetworkCredential("sofvet2018@gmail.com", "sistemasofvet2018");
            serverMail.Host = "smtp.gmail.com";
            serverMail.Port = 587;
            serverMail.EnableSsl = true;

            try
            {
                serverMail.Send(correo);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ..!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
            correo.Dispose();
        }      
    }
}
