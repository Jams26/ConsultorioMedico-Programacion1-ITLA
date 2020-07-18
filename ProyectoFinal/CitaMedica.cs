using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Proyecto_Final
{
    public partial class CitaMedica : Form
    {
        int id, idpaciente, idmedico, idclinica;
        string fecha, hora, causa;

        Datos dts = new Datos();

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCausa.Text))
            {
                MessageBox.Show("Introduzca una causa de la visita.");
            }
            else if (string.IsNullOrEmpty(cboxClinica.Text))
            {
                MessageBox.Show("Introduzca la clinica.");
            }
            else if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Introduzca el codigo de la cita.");
            }
            else if (string.IsNullOrEmpty(txtFecha.Text))
            {
                MessageBox.Show("Introduzca la fecha de consulta.");
            }
            else if (string.IsNullOrEmpty(txtHora.Text))
            {
                MessageBox.Show("Introduzca la hora de consulta.");
            }
            else if (string.IsNullOrEmpty(cboxMedico.Text))
            {
                MessageBox.Show("Introduzca el medico.");
            }
            else if (string.IsNullOrEmpty(cboxPaciente.Text))
            {
                MessageBox.Show("Introduzca el paciente.");
            }
            else
            {
                try
                {
                    id = int.Parse(txtId.Text);
                    DataSet ds = dts.getId("Id", "Pacientes", cboxPaciente);
                    idpaciente = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    ds = dts.getId("Id", "Medicos", cboxMedico);
                    idmedico = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    ds = dts.getId("Id", "Clínicas", cboxClinica);
                    idclinica = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    fecha = txtFecha.Text;
                    hora = txtHora.Text;
                    causa = txtCausa.Text;

                    dts.ActualizarCita(id, idpaciente, idmedico, idclinica, fecha, hora, causa);

                    MessageBox.Show("Cita medica actualizada correctamente!");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                LlenarGrid();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(txtId.Text);

                dts.EliminarCita(id);

                MessageBox.Show("Cita medica eliminada correctamente!");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            LlenarGrid();
        }

        private void dataGridViewCitaMedica_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewCitaMedica.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridViewCitaMedica.CurrentRow.Selected = true;
                    txtId.Text = dataGridViewCitaMedica.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
                    txtHora.Text = dataGridViewCitaMedica.Rows[e.RowIndex].Cells["Hora"].FormattedValue.ToString();
                    txtFecha.Text = dataGridViewCitaMedica.Rows[e.RowIndex].Cells["Fecha"].FormattedValue.ToString();
                    txtCausa.Text = dataGridViewCitaMedica.Rows[e.RowIndex].Cells["Causa"].FormattedValue.ToString();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtHora.Text = "";
            txtFecha.Text = "";
            txtCausa.Text = "";
            cboxClinica.Text = "";
            cboxMedico.Text = "";
            cboxPaciente.Text = "";
        }

       // DatosCitaMedica obj4 = new DatosCitaMedica();

        public CitaMedica()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCausa.Text))
            {
                MessageBox.Show("Introduzca una causa de la visita.");
            }
            else if (string.IsNullOrEmpty(cboxClinica.Text))
            {
                MessageBox.Show("Introduzca la clinica.");
            }
            else if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Introduzca el codigo de la cita.");
            }
            else if (string.IsNullOrEmpty(txtFecha.Text))
            {
                MessageBox.Show("Introduzca la fecha de consulta.");
            }
            else if (string.IsNullOrEmpty(txtHora.Text))
            {
                MessageBox.Show("Introduzca la hora de consulta.");
            }
            else if (string.IsNullOrEmpty(cboxMedico.Text))
            {
                MessageBox.Show("Introduzca el medico.");
            }
            else if (string.IsNullOrEmpty(cboxPaciente.Text))
            {
                MessageBox.Show("Introduzca el paciente.");
            }
            else
            {
                try
                {
                    id = int.Parse(txtId.Text);
                    DataSet ds = dts.getId("Id", "Pacientes", cboxPaciente);
                    idpaciente = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    ds = dts.getId("Id", "Medicos", cboxMedico);
                    idmedico = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    ds = dts.getId("Id", "Clínicas", cboxClinica);
                    idclinica = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    fecha = txtFecha.Text;
                    hora = txtHora.Text;
                    causa = txtCausa.Text;

                    dts.GuardarCita(id, idpaciente, idmedico, idclinica, fecha, hora, causa);

                    MessageBox.Show("Cita medica agregada correctamente!");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                LlenarGrid();
            }
        }

        private void CitaMedica_Load(object sender, EventArgs e)
        {
            LlenarGrid();

            SqlConnection con = new SqlConnection("Data Source=LATITUDE-PC;Initial Catalog=ProyectoFinal;Integrated Security=True");
            //Consulta 
            string query1 = "select * from Pacientes";
            string query2 = "select * from Medicos";
            string query3 = "select * from Clínicas";

            //Combobox Pacientes
            try
            {
                SqlDataAdapter data = new SqlDataAdapter(query1,con);
                DataTable tabla = new DataTable();
                data.Fill(tabla);
                cboxPaciente.DisplayMember = "Nombre";
                cboxPaciente.ValueMember = "Id";
                cboxPaciente.DataSource = tabla;
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }

            //Combobox Medicos
            try
            {
                SqlDataAdapter data = new SqlDataAdapter(query2,con);
                DataTable tabla1 = new DataTable();
                data.Fill(tabla1);
                cboxMedico.DisplayMember = "Nombre";
                cboxMedico.ValueMember = "Id";
                cboxMedico.DataSource = tabla1;
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }

            //Combobox Clinicas
            try
            {
                SqlDataAdapter data = new SqlDataAdapter(query3,con);
                DataTable tabla2 = new DataTable();
                data.Fill(tabla2);
                cboxClinica.DisplayMember = "Nombre";
                cboxClinica.ValueMember = "Id";
                cboxClinica.DataSource = tabla2;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public void LlenarGrid()
        {
            dataGridViewCitaMedica.DataSource = dts.LlenarGridCita();
        }
    }
}
