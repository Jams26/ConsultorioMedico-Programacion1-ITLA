using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Proyecto_Final
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
        //MOVER VENTANA
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void btnMantenimientos_MouseMove(object sender, MouseEventArgs e)
        {
            SubMenuMantenimientos.Visible = true;
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            SubMenuMantenimientos.Visible = true;
            //Declarando como nuevo objeto pacientes, abrir el form en el panel
            AbirForm(new Pacientes()); 
        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {
            SubMenuMantenimientos.Visible = true;
            AbirForm(new Medicos());
        }

        private void btnClinicas_Click(object sender, EventArgs e)
        {
            SubMenuMantenimientos.Visible = true;
            AbirForm(new Clinicas());
        }

        private void btnProcesos_MouseMove(object sender, MouseEventArgs e)
        {
            SubMenuProcesos.Visible = true;
        }

        private void btnCitaMedica_Click(object sender, EventArgs e)
        {
            SubMenuProcesos.Visible = true;
            AbirForm(new CitaMedica());
        }
        //Abrir los formularios en el Panel Contenedor
        private void AbirForm(object form)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form fm = form as Form;
            fm.TopLevel = false; //Será un formulario secundario
            fm.Dock = DockStyle.Fill; //Se ajustará al tamaño del panel contenedor
            this.PanelContenedor.Controls.Add(fm);
            this.PanelContenedor.Tag = fm;
            fm.Show();
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            AbirForm(new Consultas());
        }

        private void btnUtilitarios_Click(object sender, EventArgs e)
        {
            AbirForm(new Utilitarios());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbirForm(new FormPrincipalFondo());
        }
    }
}
