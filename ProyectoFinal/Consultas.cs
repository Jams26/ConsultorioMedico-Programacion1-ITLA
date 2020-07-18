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
    public partial class Consultas : Form
    {
        string pnombre, email, mnombre,  exequatur, cnombre, cexequatur;
        Datos dts = new Datos();
        Paciente dtpac = new Paciente();
        Medico dtmed = new Medico();

        public Consultas()
        {
            InitializeComponent();

            cboxPaciente.Items.Add("Nombre");
            cboxPaciente.Items.Add("Email");
            cboxMedico.Items.Add("Nombre");
            cboxMedico.Items.Add("Exequatur");
            cboxCita.Items.Add("Nombre del Medico");
            cboxCita.Items.Add("Exequatur del Medico");
        }

        private void checkPaciente_CheckedChanged(object sender, EventArgs e)
        {

            LlenarGridPaciente();

            if (checkPaciente.Checked == true)
            {
                btnLimpiar.Enabled = true;
                btnBuscar.Enabled = true;
                cboxPaciente.Enabled = true;
                txtPaciente.Enabled = true;
                btnBuscar2.Enabled = false;
                btnBuscar3.Enabled = false;
                cboxMedico.Enabled = false;
                cboxCita.Enabled = false;
                checkMedico.Enabled = false;
                checkCita.Enabled = false;
                txtMedico.Enabled = false;
                txtCita.Enabled = false;
            }
            else 
            {
                btnLimpiar.Enabled = false;
                btnBuscar.Enabled = false;
                cboxMedico.Enabled = false;
                cboxCita.Enabled = false;
                checkMedico.Enabled = true;
                checkCita.Enabled = true;
                txtMedico.Enabled = false;
                txtCita.Enabled = false;
                cboxPaciente.Enabled = false;
                txtPaciente.Enabled = false;
                btnBuscar2.Enabled = false;
                btnBuscar3.Enabled = false;
            }
            
        }

        private void checkMedico_CheckedChanged(object sender, EventArgs e)
        {

            LlenarGridMedico();

            if (checkMedico.Checked == true)
            {
                btnBuscar2.Enabled = true;
                btnLimpiar.Enabled = true;
                btnBuscar.Enabled = true;
                cboxMedico.Enabled = true;
                txtMedico.Enabled = true;
                cboxPaciente.Enabled = false;
                cboxCita.Enabled = false;
                checkPaciente.Enabled = false;
                checkCita.Enabled = false;
                txtPaciente.Enabled = false;
                txtCita.Enabled = false;
                btnBuscar3.Enabled = false;
                btnBuscar.Enabled = false;
            }
            else
            {
                btnBuscar2.Enabled = false;
                btnLimpiar.Enabled = false;
                btnBuscar.Enabled = false;
                cboxPaciente.Enabled = false;
                cboxCita.Enabled = false;
                checkPaciente.Enabled = true;
                checkCita.Enabled = true;
                txtPaciente.Enabled = false;
                txtCita.Enabled = false;
                cboxMedico.Enabled = false;
                btnBuscar3.Enabled = false;
                btnBuscar.Enabled = false;
            }
        }

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            //Consultar Medico
            try
            {
                string CBO = cboxMedico.SelectedItem.ToString();

                switch (CBO)
                {
                    case "Nombre":

                        mnombre = txtMedico.Text;
                        dataGridView1.DataSource = dts.ConsultarMedicoNombre(mnombre);

                        break;
                    case "Exequatur":
                        exequatur = txtMedico.Text;
                        dataGridView1.DataSource = dts.ConsultarMedicoExequatur(exequatur);

                        break;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnBuscar3_Click(object sender, EventArgs e)
        {
            //Consultar Cita Medica
            try
            {
                string CBO = cboxCita.SelectedItem.ToString();
                switch (CBO)
                {
                    case "Nombre del Medico":

                        cnombre = txtCita.Text;
                        dataGridView1.DataSource = dts.ConsultarCitaNombre(cnombre);
                        break;

                    case "Exequatur del Medico":

                        cexequatur = txtCita.Text;
                        dataGridView1.DataSource = dts.ConsultarCitaExequatur(cexequatur);
                        break;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void checkCita_CheckedChanged(object sender, EventArgs e)
        {

            LlenarGridCitaMedica();

            if (checkCita.Checked == true)
            {
                btnLimpiar.Enabled = true;
                btnBuscar.Enabled = true;
                cboxCita.Enabled = true;
                txtCita.Enabled = true;
                cboxPaciente.Enabled = false;
                cboxMedico.Enabled = false;
                checkPaciente.Enabled = false;
                checkMedico.Enabled = false;
                txtMedico.Enabled = false;
                txtPaciente.Enabled = false;
                btnBuscar.Enabled = false;
                btnBuscar3.Enabled = true;
            }
            else
            {
                btnLimpiar.Enabled = false;
                btnBuscar.Enabled = false;
                cboxPaciente.Enabled = false;
                cboxMedico.Enabled = false;
                checkPaciente.Enabled = true;
                checkMedico.Enabled = true;
                txtMedico.Enabled = false;
                txtPaciente.Enabled = false;
                cboxCita.Enabled = false;
                txtCita.Enabled = false;
                btnBuscar.Enabled = false;
                btnBuscar3.Enabled = false;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPaciente.Text = "";
            txtMedico.Text = "";
            txtCita.Text = "";
            cboxCita.Text = "";
            cboxMedico.Text = "";
            cboxPaciente.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           // Consultar Paciente
            try
            {
                string CB = cboxPaciente.SelectedItem.ToString();

                switch (CB)
                {
                    case "Nombre":

                        pnombre = txtPaciente.Text;
                        dataGridView1.DataSource = dts.ConsultarPacienteNombre(pnombre);
                        break;
                    case "Email":
                        email = txtPaciente.Text;
                        dataGridView1.DataSource = dts.ConsultarPacienteEmail(email);
                        break;
                }
             }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }
        //Llenar grid con checkbox para PACIENTE
        public void LlenarGridPaciente()
        {
            dataGridView1.DataSource = dtpac.LlenarGrid();
        }

        //Llenar grid con checkbox para MEDICO
        public void LlenarGridMedico()
        {
            dataGridView1.DataSource = dtmed.LlenarGrid();
        }

        //Llenar grid con checkbox para Cita Medica
        public void LlenarGridCitaMedica()
        {
            dataGridView1.DataSource = dts.LlenarGridCita();
        }
    }
}
