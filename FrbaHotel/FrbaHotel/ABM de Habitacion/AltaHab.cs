using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class AltaHab : Form
    {
        bool interna = false;
        bool externa = false;

        public AltaHab()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void soloEscribeLetras(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public static void soloEscribeNumeros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxnro_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxpis_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxper_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void checkBoxext_CheckedChanged(object sender, EventArgs e)
        {
            if (externa == false)
            {
                externa = true;
                checkBoxint.Enabled = false;
                checkBoxext.Enabled = true;
            }
            else
            {
                externa = false;
                checkBoxint.Enabled = true;
            }
        }

        private void checkBoxint_CheckedChanged(object sender, EventArgs e)
        {
            if (interna == false)
            {
                interna = true;
                checkBoxext.Enabled = false;
                checkBoxint.Enabled = true;
            }
            else
            {
                interna = false;
                checkBoxext.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxhot.Text == "" || textBoxnro.Text == "" ||
                textBoxpis.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("No deje campos vacios", "ALERTA", MessageBoxButtons.OK);
            }else if (decimal.Parse(textBoxnro.Text) < 1)
            {
                MessageBox.Show("El numero de habitacion debe ser mayor a 0", "ALERTA",
                    MessageBoxButtons.OK);
            }
            else if (decimal.Parse(textBoxper.Text) < 1)
            {
                MessageBox.Show("La cantidad de personas debe ser mayor a 0", "ALERTA",
                    MessageBoxButtons.OK);
            }
            else if (decimal.Parse(textBoxpis.Text) < 1)
            {
                MessageBox.Show("El piso debe ser mayor a 0", "ALERTA",
                    MessageBoxButtons.OK);
            }
            else if (checkBoxext.Checked == false && checkBoxint.Checked == false)
            {
                MessageBox.Show("Seleccione una ubicacion", "ALERTA",
                    MessageBoxButtons.OK);
            }
        }

        private void AltaHab_Load(object sender, EventArgs e)
        {
            //Cargas el combo box "tipos" con los tipos de habitacion
        }
    }
}
