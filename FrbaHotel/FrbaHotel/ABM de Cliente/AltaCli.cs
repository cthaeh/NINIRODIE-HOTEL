using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.NINIRODIE.Clases;
using FrbaHotel.NINIRODIE.Repositorios;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class AltaCli : Form
    {
        bool salir = false;

        public AltaCli()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxcalle.Text == "" || textBoxdir.Text == "" || textBoxloc.Text == ""
                || textBoxmail.Text == "" || textBoxnac.Text == "" || textBoxnomb.Text == ""
                || textBoxnro.Text == "" || textBoxpa.Text == "" || textBoxtel.Text == ""
                || textBoxtipo.Text == "" || textBoxap.Text == "" || textBoxdep.Text == "" || textBoxpis.Text == "")
            {
                MessageBox.Show("No dejar campos vacios", "Alerta", MessageBoxButtons.OK);
            }//insertar en la base
            
            Cliente cli = new Cliente(textBoxnomb.Text, textBoxap.Text, textBoxtipo.Text, Decimal.Parse(textBoxnro.Text),
                textBoxmail.Text, Decimal.Parse(textBoxtel.Text), textBoxcalle.Text, Decimal.Parse(textBoxdir.Text),
                Decimal.Parse(textBoxpis.Text), Decimal.Parse(textBoxdep.Text), (dateTimePicker1.Value),
                textBoxloc.Text, textBoxpa.Text, textBoxnac.Text);

            RepositorioCliente.Instance.InsertarCliente(cli);
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
            soloEscribeNumeros(e);
        }

        private void textBoxpa_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxnac_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxpis_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxdep_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }
    }
}
