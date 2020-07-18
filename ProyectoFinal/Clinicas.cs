using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final
{
    public partial class Clinicas : Form
    {
        int id;
        string nombre, direccion;
        
        Datos dts = new Datos();
        public Clinicas()
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
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Introduzca una direccion.");
            }
            else
            {
                try
                {
                    id = int.Parse(txtId.Text);
                    nombre = txtNombre.Text;
                    direccion = txtDireccion.Text;

                    // obj3.Guardar(id, nombre, direccion);
                    dts.GuardarClinica(id, nombre, direccion);

                    MessageBox.Show("Clinica agregada correctamente!");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                LlenarGrid();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(txtId.Text);
                nombre = txtNombre.Text;
                direccion = txtDireccion.Text;

                //obj3.Actualizar(id, nombre, direccion);
                dts.ActualizarClinica(id, nombre, direccion);

                MessageBox.Show("Clinica actualizada correctamente!");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            LlenarGrid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(txtId.Text);

                // obj3.Eliminar(id);
                dts.EliminarClinica(id);

                MessageBox.Show("Clinica eliminada correctamente!");
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
            txtDireccion.Text = "";
        }

        private void Clinicas_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void dataGridViewClinicas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewClinicas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridViewClinicas.CurrentRow.Selected = true;
                    txtId.Text = dataGridViewClinicas.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
                    txtNombre.Text = dataGridViewClinicas.Rows[e.RowIndex].Cells["Nombre"].FormattedValue.ToString();
                    txtDireccion.Text = dataGridViewClinicas.Rows[e.RowIndex].Cells["Direccion"].FormattedValue.ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public void LlenarGrid()
        {
            dataGridViewClinicas.DataSource = dts.LlenarGridClinica();
        }
    }
}
