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
    public partial class ModificarHab : Form
    {
        bool interna = false;
        bool externa = false;

        public ModificarHab()
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

        private void ModificarHab_Load(object sender, EventArgs e)
        {
            //Se debe setear los checkbox segun la informacion que se trae de la base
            //Se deben completar los campos con los datos que se traen de la base
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Se debe golpear la base con los datos en los campos
        }
    }
}
