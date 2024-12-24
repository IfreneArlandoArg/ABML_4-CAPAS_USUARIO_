using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class DALUsuario
    {
        string ConnectionString = " Integrated Security = SSPI; Data Source = .; Initial Catalog = CHR_PRACT ; ";
        public void Alta(Usuario pUsuario)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString) ) 
            { 
              SqlCommand cmd = new SqlCommand("Alta_Usuario",conn);

              cmd.CommandType = CommandType.StoredProcedure;
                
              cmd.Parameters.Add(new SqlParameter("@ID", pUsuario.ID));
              cmd.Parameters.Add(new SqlParameter("@NOMBRE", pUsuario.Nombre));
              cmd.Parameters.Add(new SqlParameter("@APELLIDO", pUsuario.Apellido));
              cmd.Parameters.Add(new SqlParameter("@DNI", pUsuario.DNI));

              conn.Open();

              cmd.ExecuteNonQuery();

            }
        }

        public void Baja(Usuario pUsuario)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Baja_Usuario", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ID", pUsuario.ID));
                
                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public void Modificar(Usuario pUsuario)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Modificar_Usuario", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ID", pUsuario.ID));
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", pUsuario.Nombre));
                cmd.Parameters.Add(new SqlParameter("@APELLIDO", pUsuario.Apellido));
                

                conn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public List<Usuario> Listar()
        {
            List<Usuario> lstUsuarioTemp = new List<Usuario>();


            using (SqlConnection conn = new SqlConnection(ConnectionString)) 
            {
                SqlCommand cmd = new SqlCommand("Listar_Usuarios", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) 
                { 
                    Usuario temp = new Usuario(reader["ID_USUARIO"].ToString(), reader["NOMBRE"].ToString(), reader["APELLIDO"].ToString(), reader["DNI"].ToString() );

                    lstUsuarioTemp.Add(temp);
                }
            }


            return lstUsuarioTemp;
        }
    }
}
