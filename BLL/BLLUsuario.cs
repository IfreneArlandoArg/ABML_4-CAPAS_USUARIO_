using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLLUsuario
    {
        DALUsuario dalUsuario = new DALUsuario();
        public void Alta(Usuario pUsuario)
        {
            dalUsuario.Alta(pUsuario);
        }

        public void Baja(Usuario pUsuario)
        {
            dalUsuario.Baja(pUsuario);
        }

        public void Modificar(Usuario pUsuario)
        {
            dalUsuario.Modificar(pUsuario);
        }

        public List<Usuario> Listar()
        {
            return dalUsuario.Listar();
        }

        public bool DNI_Registrado( Usuario pUsuario)
        {
            List<Usuario> plstUsers = dalUsuario.Listar();
            
            bool DNIRegistrado = false;

            foreach (Usuario p in plstUsers) 
            { 
                if(p.DNI == pUsuario.DNI)
                    DNIRegistrado = true;
            }

            return DNIRegistrado;
        }

        public int GetID()
        {
            List<Usuario> plstUsers = dalUsuario.Listar();

            int ID = 0;

            ID = plstUsers.Count == 0 ? ID++ : plstUsers[plstUsers.Count - 1].ID + 1;


            return ID;
        }

        public bool FormatoDNICorrecto(string pDNI)
        {
            Regex DNIRegex = new Regex(@"^[0-9]{8}$");

            return DNIRegex.IsMatch(pDNI);
        }
    }
}
