﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class ModificarCli : Form
    {
        public ModificarCli()
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

        private void textBoxap_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxtipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxnro_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxtel_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxdir_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxpa_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxnac_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //se debe golpear la base con los datos en los campos
        }

        private void ModificarCli_Load(object sender, EventArgs e)
        {
            //se debe cargar los campos con los datos que ya estan en la tabla
        }
    }
}
