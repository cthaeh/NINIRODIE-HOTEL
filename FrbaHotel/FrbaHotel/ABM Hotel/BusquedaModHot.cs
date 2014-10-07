using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_Hotel
{
    public partial class BusquedaModHot : Form
    {
        decimal banderacat = 0;
        bool seguir = false;

        public BusquedaModHot()
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

        private void button1_Click(object sender, EventArgs e)
        {
            banderacat = 0;
            seguir = true;

            if (textBoxcat.Text == "")
            {
                banderacat = 1000;
                seguir = true;
            }
            if (textBoxcat.Text == "" && textBoxciu.Text == "" && textBoxnomb.Text == ""
                && textBoxpa.Text == "")
            {
                MessageBox.Show("Debe ingresar algun campo", "ALERTA", MessageBoxButtons.OK);
                seguir = false;
            }

            if (banderacat != 1000)
            {
                if (decimal.Parse(textBoxcat.Text) < 1 || decimal.Parse(textBoxcat.Text) > 5)
                {
                    MessageBox.Show("La categoria debe ser entre 1 y 5", "ALERTA", MessageBoxButtons.OK);
                    seguir = false;
                }
            }
            if (seguir == true)
            {
            }
        }

        private void textBoxnomb_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxcat_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxciu_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxpa_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            banderacat = 0;
            if (textBoxcat.Text == "")
            {
                banderacat = 1000;
                seguir = true;
            }
            if (banderacat != 1000)
            {
                if (decimal.Parse(textBoxcat.Text) < 1 || decimal.Parse(textBoxcat.Text) > 5)
                {
                    MessageBox.Show("La categoria debe ser entre 1 y 5", "ALERTA", MessageBoxButtons.OK);
                    seguir = false;
                }
            }
            if (seguir == true)
            {
                new ModificarHot().ShowDialog(this);
            }
        
        }
    }
}
