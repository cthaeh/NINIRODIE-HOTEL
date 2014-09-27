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
    public partial class ModificarHot : Form
    {
        bool cerrar = false;

        public ModificarHot()
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

        private void textBoxnomb_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxtel_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxciud_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxpa_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxcat_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void ModificarHot_Load(object sender, EventArgs e)
        {
            //Se deben setear los checkbox con los datos que se traen de la base
            //Se deben completar los campos con los datos que se traen de la base
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Se debe golpear la base con los datos en los campos
        }

        private void textBoxnrocal_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }
    }
}
