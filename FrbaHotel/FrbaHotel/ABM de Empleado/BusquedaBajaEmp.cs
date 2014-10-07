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

namespace FrbaHotel.ABM_de_Empleado
{
    public partial class BusquedaBajaEmp : Form
    {
        bool se_busco = false;
        Decimal nro = 0;
        Personal empleado_buscado;

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

                new BajaEmp().ShowDialog(this);
        
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

        private void buscar_Click(object sender, EventArgs e)
        {
            if (textBoxap.Text == "" && textBoxdni.Text == "" && textBoxmail.Text == ""
    && textBoxnomb.Text == "")
            {
                MessageBox.Show("Debe ingresar algun campo", "ALERTA", MessageBoxButtons.OK);
            }
            else
            {
                if (textBoxdni.Text != "")
                {
                    nro = Decimal.Parse(textBoxdni.Text);
                }

                empleado_buscado = RepositorioEmpleado.Instance.BuscarEmpleadoD(textBoxap.Text, textBoxmail.Text, textBoxnomb.Text, nro);


                if (empleado_buscado.identificador == -1)
                {
                    MessageBox.Show("Usuario no existe", "ALERTA", MessageBoxButtons.OK);
                }

                //se debe completar la grilla
            }

            se_busco = true;
        }


    }
}
