using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BLLUsuario bLLUsuario = new BLLUsuario();


        void Mostrar(DataGridView dtgv, object pO) 
        { 
           dtgv.DataSource = null;
           dtgv.DataSource = pO;
        }


        void EnlazarUsuarios() 
        {
            Mostrar(dataGridView1, bLLUsuario.Listar());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                EnlazarUsuarios();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                int tempDNI;

                bool DNI_INT = int.TryParse(txtDNI.Text, out tempDNI);

                if (!DNI_INT)
                    throw new Exception("Formato DNI Incorrecto...");
                if (txtNombre.Text == string.Empty)
                    throw new Exception("Formato Nombre Incorrecto...");
                if (txtApellido.Text == string.Empty)
                    throw new Exception("Formato Apellido Incorrecto...");

                
                Usuario temp = new Usuario(bLLUsuario.GetID(), txtNombre.Text, txtApellido.Text, tempDNI);

                if (bLLUsuario.DNI_Registrado(temp))
                    throw new Exception($"{tempDNI} ya está registrado...");

                bLLUsuario.Alta(temp);

                EnlazarUsuarios();

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                    throw new Exception("No hay Seleccionados usuarios para dar de baja...\nSeleccioné un usuario primero.");
                

                Usuario temp = dataGridView1.CurrentRow.DataBoundItem as Usuario;

                bLLUsuario.Baja(temp);

                EnlazarUsuarios();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                    throw new Exception("No hay usuarios Seleccionados para modificar...\nSeleccioné un usuario primero.");

                Usuario temp = dataGridView1.CurrentRow.DataBoundItem as Usuario;

                if (txtNombre.Text == string.Empty)
                    throw new Exception("Formato Nombre Incorrecto...");
                if (txtApellido.Text == string.Empty)
                    throw new Exception("Formato Apellido Incorrecto...");

                temp.Nombre = txtNombre.Text;
                temp.Apellido = txtApellido.Text;

                bLLUsuario.Modificar(temp);

                EnlazarUsuarios();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
