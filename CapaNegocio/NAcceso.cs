using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NAcceso
    {
        public static DataTable Acceso(string username, string pasword)
        {
            DAcceso objDA = new DAcceso();
            objDA.UserName = username;
            objDA.Password = pasword;

            return objDA.Acceso(objDA);
            
        }
    }
}
