﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Empleado
{
    public partial class BusquedaBajaEmp : Form
    {
        public BusquedaBajaEmp()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxap.Text == "" && textBoxdni.Text == "" && textBoxmail.Text == ""
                && textBoxnomb.Text == "")
            {
                MessageBox.Show("Debe ingresar algun campo", "ALERTA", MessageBoxButtons.OK);
            }
            else
            {
                new BajaEmp().ShowDialog(this);
            }
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

        private void textBoxdni_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }


    }
}
