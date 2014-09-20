using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class AltaEmp : Form
    {
        bool salir = true;
        public AltaEmp()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxnomb_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
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

        private void textBoxap_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxdni_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxtel_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxcla.Text != textBoxrepcla.Text)
            {
                MessageBox.Show("Claves Diferentes", "Alerta", MessageBoxButtons.OK);
            }
            if (textBoxrepcla.Text == "" || textBoxtel.Text == "" || textBoxnombusu.Text == ""
                || textBoxnomb.Text == "" || textBoxmail.Text == "" || textBoxhot.Text == ""
                || textBoxdni.Text == "" || textBoxdir.Text == "" || textBoxcla.Text == ""
                || textBoxap.Text == "")
            {
                MessageBox.Show("No dejes campos vacios", "Alerta", MessageBoxButtons.OK);
                salir = false;
            }// si llega hasta aqui poner salir = true; e insertar en la base.
        }

    }
}
