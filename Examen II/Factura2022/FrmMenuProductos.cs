using Datos.Accesos;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factura2022
{
    public partial class FrmMenuProductos : Form
    {
        public FrmMenuProductos()
        {
            InitializeComponent();
        }

        UsuarioDA usuarioDA = new UsuarioDA();
        string operacion = string.Empty;
        Usuario user = new Usuario();

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void ListarUsuarios()
        {
            UsuariosDataGridView.DataSource = usuarioDA.Productos();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void HabilitarControles()
        {
            precioTextBox.Enabled = true;
            nombreTextBox.Enabled = true;
            codigotextBox.Enabled = true;
            existenciatextBox.Enabled = true;

            NuevoButton.Enabled = false;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;


        }

        private void DesabilitarControles()
        {
            precioTextBox.Enabled = false;
            nombreTextBox.Enabled = false;
           codigotextBox.Enabled = false;
           existenciatextBox.Enabled = false;
 

            NuevoButton.Enabled = true;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;


        }

        private void LimpiarControles()
        {
            precioTextBox.Clear();
            nombreTextBox.Text = "";
            codigotextBox.Text = " ";
            existenciatextBox.Text="";
       
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            user.Codigo = codigotextBox.Text;
            user.Nombre = nombreTextBox.Text;
            user.Precio = precioTextBox.Text;
            user.Existencia = existenciatextBox.Text;
    



            if (operacion == "Nuevo")
            {
                bool inserto = usuarioDA.InsertarUsuario(user);

                if (inserto)
                {
                    MessageBox.Show("Menu Creado");
                    ListarUsuarios();
                    LimpiarControles();
                    DesabilitarControles();
                }
                else
                {
                    MessageBox.Show("Menu no se pudo Crear");
                }
            }
            else if (operacion == "Modificar")
            {
                bool modifico = usuarioDA.ModificarUsuario(user);
                if (modifico)
                {
                    MessageBox.Show("Menu Modificado");
                    ListarUsuarios();
                    LimpiarControles();
                    DesabilitarControles();
                }
                else
                {
                    MessageBox.Show("Menu no se pudo Modificar");
                }
            }
            

        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            operacion = "Modificar";

            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                precioTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                nombreTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                codigotextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Precio"].Value.ToString();
                existenciatextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Existencia"].Value.ToString();
                HabilitarControles();
            }

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = usuarioDA.EliminarUsuario(UsuariosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString());
                if (elimino)
                {
                    MessageBox.Show("Menu Eliminado");
                    ListarUsuarios();
                }
                else
                {
                    MessageBox.Show("Menu no se pudo Eliminar");
                }

            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DesabilitarControles();
            LimpiarControles();
        }

       
    }
}
