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
    public partial class Utilitarios : Form
    {
        double cantDolares, cantPesos, cantEuros;
        
        public Utilitarios()
        {
            InitializeComponent();
            cboxTipoCambio.Items.Add("Pesos dominicanos a Dolares");
            cboxTipoCambio.Items.Add("Dolares a Pesos dominicanos");
            cboxTipoCambio.Items.Add("Dolares a Euros");
            cboxTipoCambio.Items.Add("Euros a Dolares");
            cboxTipoCambio.Items.Add("Pesos dominicanos a Euros");
            cboxTipoCambio.Items.Add("Euros a Pesos dominicanos");
        }

        private void btnConvertir_MouseClick(object sender, MouseEventArgs e)
        {
            lblResultado.Visible = true;
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            //Validacion Campos vacios
            if (string.IsNullOrEmpty(txtMoneda.Text))
            {
                MessageBox.Show("Introducza una cantidad para la conversion.");
            }
            else if (string.IsNullOrEmpty(cboxTipoCambio.Text))
            {
                MessageBox.Show("Seleccione la moneda de origen y de destino para realizar la conversion.");
            }
            else
            {
                cantPesos = Convert.ToDouble(txtMoneda.Text);
                cantDolares = Convert.ToDouble(txtMoneda.Text);
                cantEuros = Convert.ToDouble(txtMoneda.Text);
                try
                {
                    string CB = cboxTipoCambio.SelectedItem.ToString();

                    switch (CB)
                    {
                        case "Pesos dominicanos a Dolares":


                            lblResultado.Text = Convert.ToString(cantPesos * 0.019 + "RD$");

                            break;

                        case "Dolares a Pesos dominicanos":


                            lblResultado.Text = Convert.ToString(cantDolares * 52.8 + " $USD");

                            break;

                        case "Dolares a Euros":


                            lblResultado.Text = Convert.ToString(cantDolares * 0.91 + " €");

                            break;

                        case "Euros a Dolares":

                            lblResultado.Text = Convert.ToString(cantEuros * 1.10 + " $USD");

                            break;

                        case "Pesos dominicanos a Euros":

                            lblResultado.Text = Convert.ToString(cantPesos * 0.017 + " RD$");

                            break;

                        case "Euros a Pesos dominicanos":

                            lblResultado.Text = Convert.ToString(cantEuros * 58.2 + " €");

                            break;

                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }






            }

        }

        

        
    }
}
