using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int DNI { get; set; }

        public Usuario(string pID, string pNombre, string pApellido, string pDNI) 
        { 
           ID = int.Parse(pID);
           Nombre = pNombre;
           Apellido = pApellido;
           DNI = int.Parse(pDNI);
        }

        public Usuario(int pID, string pNombre, string pApellido, int pDNI)
        {
            ID = pID;
            Nombre = pNombre;
            Apellido = pApellido;
            DNI = pDNI;
        }
    }
}
