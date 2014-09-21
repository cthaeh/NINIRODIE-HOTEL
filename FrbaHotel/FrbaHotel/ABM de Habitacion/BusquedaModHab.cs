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
    public partial class BusquedaModHab : Form
    {
        bool banderanro = false, banderapiso = false, banderaper = false;
        bool seguir = true;

        public BusquedaModHab()
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

        private void button1_Click(object sender, EventArgs e)
        {
            banderapiso = false;
            banderaper = false;
            banderanro = false;
            seguir = true;

            if (textBoxnro.Text == "")
            {
                banderanro = true;
            }
            if (textBoxper.Text == "")
            {
                banderaper = true;
            }
            if (textBoxpis.Text == "")
            {
                banderapiso = true;
            }

            if (textBoxhot.Text == "" && textBoxnro.Text == "" && textBoxper.Text == ""
                && textBoxpis.Text == "")
            {
                MessageBox.Show("Debe ingresar algun campo", "ALERTA", MessageBoxButtons.OK);
                seguir = false;
            }
            if (banderanro != true)
            {
                if (decimal.Parse(textBoxnro.Text) < 1)
                {
                    MessageBox.Show("El numero debe ser mayor a 0", "ALERTA", MessageBoxButtons.OK);
                    seguir = false;
                }
                else { seguir = true; }
            }

            if (banderaper != true)
            {
                if (decimal.Parse(textBoxper.Text) < 1)
                {
                    MessageBox.Show("La cantidad de personas debe ser mayor a 0", "ALERTA", MessageBoxButtons.OK);
                    seguir = false;
                }
                else { seguir = true; }
            }

            if (banderapiso != true)
            {
                if (decimal.Parse(textBoxpis.Text) < 1)
                {
                    MessageBox.Show("El piso debe ser mayor a 0", "ALERTA", MessageBoxButtons.OK);
                    seguir = false;
                }
                else { seguir = true; }
            }

            if (seguir == true)
            {
                //se llama a modificar
            }
        }

    }
}
