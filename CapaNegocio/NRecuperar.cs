using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class NRecuperar
    {
        public static string RecuperarPassword(string dni)
        {
            DRecuperar objDR = new DRecuperar();
            objDR.Dni = dni;
            return objDR.RecuperarContraseña(objDR);
        }
    }
}
