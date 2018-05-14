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

                        Mensaje = "Estimado Sr(a). " + Nombres + " , la contraseña fue enviada a su correo: " + Email + " : verifique su entrada de bandeja";
                        leer.Close();
                    }
                    else
                    {
                        Mensaje = "No existe datos ....";
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
            correo.From = new MailAddress("devesoft23@gmail.com");
            correo.To.Add(Email);
            correo.Subject = ("RECUPERAR CONTRASEÑA SOFVET");
            correo.Body = "HOLA " + Nombres + " usted solicito recuperar recuperar su contraseña - su contraseña es: " + Password + "etc ......";
            correo.Priority = MailPriority.Normal;

            //SMTP

            SmtpClient serverMail = new SmtpClient();
            serverMail.Credentials = new NetworkCredential("devesoft23@gmail.com", "encinas123");
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
