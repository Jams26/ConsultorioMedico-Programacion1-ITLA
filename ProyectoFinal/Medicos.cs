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
    public partial class Medicos : Form
    {
        int id;
        string cedula, nombre, telefono, email, exequatur, clinicas;

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(txtId.Text);

                obj2.Eliminar(id);

                MessageBox.Show("Medico eliminado correctamente!");
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
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtExequatur.Text = "";
            txtEmail.Text = "";
            txtClinica.Text = "";
            txtCedula.Text = "";
        }

        private void Medicos_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void dataGridViewMedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewMedicos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridViewMedicos.CurrentRow.Selected = true;
                    txtId.Text = dataGridViewMedicos.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
                    txtCedula.Text = dataGridViewMedicos.Rows[e.RowIndex].Cells["Cédula"].FormattedValue.ToString();
                    txtExequatur.Text = dataGridViewMedicos.Rows[e.RowIndex].Cells["Exequátur"].FormattedValue.ToString();
                    txtNombre.Text = dataGridViewMedicos.Rows[e.RowIndex].Cells["Nombre"].FormattedValue.ToString();
                    txtTelefono.Text = dataGridViewMedicos.Rows[e.RowIndex].Cells["Teléfono"].FormattedValue.ToString();
                    txtEmail.Text = dataGridViewMedicos.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();
                    txtClinica.Text = dataGridViewMedicos.Rows[e.RowIndex].Cells["Clínicas"].FormattedValue.ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(txtId.Text);
                cedula = txtCedula.Text;
                exequatur = txtExequatur.Text;
                nombre = txtNombre.Text;
                telefono = txtTelefono.Text;
                email = txtEmail.Text;
                clinicas = txtClinica.Text;

                obj2.Actualizar(id, cedula, exequatur, nombre, telefono, email, clinicas);

                MessageBox.Show("Medico actualizado correctamente!");

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            LlenarGrid();
        }

        Medico obj2 = new Medico();

        public Medicos()
        {
            InitializeComponent();
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
            else if (string.IsNullOrEmpty(txtExequatur.Text))
            {
                MessageBox.Show("Introduzca un Exequatur.");
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
            else if (string.IsNullOrEmpty(txtClinica.Text))
            {
                MessageBox.Show("Introduzca una clinica en que labora el medico.");
            }
            else
            {
                try
                {
                    //Agregar Medico
                    id = int.Parse(txtId.Text);
                    cedula = txtCedula.Text;
                    exequatur = txtExequatur.Text;
                    nombre = txtNombre.Text;
                    telefono = txtTelefono.Text;
                    email = txtEmail.Text;
                    clinicas = txtClinica.Text;

                    obj2.Guardar(id, cedula, exequatur, nombre, telefono, email, clinicas);

                    MessageBox.Show("Medico agregado correctamente!");

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                LlenarGrid();
            }
        }

        public void LlenarGrid()
        {
            dataGridViewMedicos.DataSource = obj2.LlenarGrid();
        }
    }
}
