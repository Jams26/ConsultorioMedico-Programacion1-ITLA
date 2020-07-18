using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;

namespace Proyecto_Final
{
    public partial class Pacientes : Form
    {
        int id;
        string cedula, nombre, telefono, email, direccion;

        Paciente obj1 = new Paciente();

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(txtId.Text);

                obj1.Eliminar(id);

                MessageBox.Show("Paciente eliminado correctamente!");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            LlenarGrid();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtDireccion.Text = "";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Introduzca un ID.");
            }
            else if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Introduzca un nombre.");
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Introduzca una direccion.");
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Introduzca un email.");
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("Introduzca un teléfono.");
            }
            else if (string.IsNullOrEmpty(txtCedula.Text))
            {
                MessageBox.Show("Introduzca una cédula.");
            }
            else
            {
                try
                {
                    id = int.Parse(txtId.Text);
                    cedula = txtCedula.Text;
                    nombre = txtNombre.Text;
                    telefono = txtTelefono.Text;
                    email = txtEmail.Text;
                    direccion = txtDireccion.Text;

                    obj1.Actualizar(id, cedula, nombre, telefono, email, direccion);

                    MessageBox.Show("Paciente actualizado correctamente!");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                LlenarGrid();
            }
        }
        
        private void Pacientes_Resize(object sender, EventArgs e)
        {
            //groupBox1.Width = this.Width - 50;
            //dataGridViewPacientes = this.Width;
        }

        //LLENAR CAMPOS EN HERRAMIENTAS:
        private void dataGridViewPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewPacientes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridViewPacientes.CurrentRow.Selected = true;
                    txtId.Text = dataGridViewPacientes.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
                    txtCedula.Text = dataGridViewPacientes.Rows[e.RowIndex].Cells["Cédula"].FormattedValue.ToString();
                    txtNombre.Text = dataGridViewPacientes.Rows[e.RowIndex].Cells["Nombre"].FormattedValue.ToString();
                    txtTelefono.Text = dataGridViewPacientes.Rows[e.RowIndex].Cells["Teléfono"].FormattedValue.ToString();
                    txtEmail.Text = dataGridViewPacientes.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();
                    txtDireccion.Text = dataGridViewPacientes.Rows[e.RowIndex].Cells["Dirección"].FormattedValue.ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Pacientes_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validacion Campos vacios
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Introduzca un ID.");
            }
            else if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Introduzca un nombre.");
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Introduzca una direccion.");
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Introduzca un email.");
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("Introduzca un teléfono.");
            }
            else if (string.IsNullOrEmpty(txtCedula.Text))
            {
                MessageBox.Show("Introduzca una cédula.");
            }
            else
            {
                //Agregar paciente
                try
                {
                    
                    id = int.Parse(txtId.Text);
                    cedula = txtCedula.Text;
                    nombre = txtNombre.Text;
                    telefono = txtTelefono.Text;
                    email = txtEmail.Text;
                    direccion = txtDireccion.Text;

                    obj1.Guardar(id, cedula, nombre, telefono, email, direccion);

                    MessageBox.Show("Paciente agregado correctamente!");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                LlenarGrid();
            }
        }
        public Pacientes()
        {
            InitializeComponent();
        }
        public void LlenarGrid()
        {
            dataGridViewPacientes.DataSource = obj1.LlenarGrid();
        }
    }
}
