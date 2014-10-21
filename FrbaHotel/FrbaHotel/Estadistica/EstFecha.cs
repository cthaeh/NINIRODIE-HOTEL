using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Estadistica
{
    public partial class EstFecha : Form
    {
        public EstFecha()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int dia_inicio = 1, dia_fin = 0, mes_inicio = 0, mes_fin = 0;
            bool seguir = true;
            if (textBoxaño.Text == "" || Decimal.Parse(textBoxaño.Text) < 1)
            {
                MessageBox.Show("Ingrese un año mayor a 0", "Alerta", MessageBoxButtons.OK);
                seguir = false;
            }
            else
            {
                if (checkBox1.Checked == false && checkBox2.Checked == false &&
                    checkBox3.Checked == false && checkBox4.Checked == false)
                {
                    MessageBox.Show("Seleccione un trimestre", "Alerta", MessageBoxButtons.OK);
                    seguir = false;
                }
            }

            if (seguir == true)
            {
                if (checkBox1.Checked == true)
                {
                    mes_inicio = 1;
                    mes_fin = 3;
                    dia_fin = 31;
                }
                if (checkBox2.Checked == true)
                {
                    mes_inicio = 4;
                    mes_fin = 6;
                    dia_fin = 30;
                }
                if (checkBox3.Checked == true)
                {
                    mes_inicio = 7;
                    mes_fin = 9;
                    dia_fin = 30;
                }
                if (checkBox4.Checked == true)
                {
                    mes_inicio = 10;
                    mes_fin = 12;
                    dia_fin = 31;
                }

                new EstMenu(dia_inicio, dia_fin, mes_inicio, mes_fin).ShowDialog(this);
                this.Close();
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox2.Enabled = false;
                checkBox1.Enabled = false;
                checkBox4.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = true;
                checkBox1.Enabled = true;
                checkBox4.Enabled = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox1.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox1.Enabled = true;
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

        private void textBoxaño_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }
    }
}
