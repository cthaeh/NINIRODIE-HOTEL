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
    public partial class BusquedaBajaCli : Form
    {
        int nro = 0;
        Cliente cliente_buscado;
        bool se_busco = false;

        public BusquedaBajaCli()
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

        private void textBoxdni_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (se_busco == false)
            {
                MessageBox.Show("Realice una busqueda", "ALERTA", MessageBoxButtons.OK);
            }
            else
            {
                //se debe preguntar por si hay algun elemento seleccionado en la grilla
                new BajaCli().ShowDialog(this);
            }
            
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            se_busco = true;

            if (textBoxap.Text == "" && textBoxdni.Text == "" && textBoxmail.Text == ""
    && textBoxnomb.Text == "")
            {
                MessageBox.Show("Debe ingresar algun campo", "ALERTA", MessageBoxButtons.OK);
            }
            else
            {
                if (textBoxdni.Text != "")
                {
                    nro = int.Parse(textBoxdni.Text);
                }

                cliente_buscado = RepositorioCliente.Instance.BuscarClienteD(textBoxap.Text, textBoxnomb.Text, textBoxmail.Text, nro);

                if (cliente_buscado.identificador == -1)
                {
                    MessageBox.Show("Usuario no existe", "ALERTA", MessageBoxButtons.OK);
                }

                //se debe completar la grilla con los datos en cliente_buscado
            }
        }
    }
}
