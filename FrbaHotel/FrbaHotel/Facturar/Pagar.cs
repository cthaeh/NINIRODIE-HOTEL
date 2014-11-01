using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.NINIRODIE.Repositorios;

namespace FrbaHotel.Facturar
{
    public partial class Pagar : Form
    {
        Decimal factura, monto;

        public Pagar(Decimal cod_factura, Decimal mon)
        {
            monto = mon;
            factura = cod_factura;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("No deje campos vacios", "Alerta", MessageBoxButtons.OK);
            }
            else
            {
                if (checkBox1.Checked == false && checkBox2.Checked == false)
                {
                    MessageBox.Show("Seleccione una forma de pago", "Alerta", MessageBoxButtons.OK);
                }
                else
                {
                    bool seguir = true;
                    Decimal nro_tarjeta = 0;
                    String forma = "Efectivo";
                    if (checkBox2.Checked == true)
                    {
                        if (textBox3.Text == "")
                        {
                            seguir = false;
                            MessageBox.Show("Ingrese numero de tarjeta", "Alerta", MessageBoxButtons.OK);
                        }
                        else
                        {
                            forma = "Tarjeta";
                            nro_tarjeta = Decimal.Parse(textBox3.Text);
                        }
                    }
                    if(seguir == true)
                    {
                        RepositorioFactura.Instance.InsertarFormaPago(textBox1.Text, textBox2.Text, nro_tarjeta, forma);
                        Decimal cod_pago = RepositorioFactura.Instance.BuscarPago(textBox1.Text, textBox2.Text, nro_tarjeta, forma);

                        RepositorioFactura.Instance.CompletarFactura(factura, cod_pago, monto);

                        MessageBox.Show("Se ha facturado correctamente", "Alerta", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void Pagar_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            textBox3.Visible = false;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
            soloEscribeNumeros(e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Enabled = false;
                label4.Visible = false;
                textBox3.Visible = false;
            }
            else
            {
                checkBox2.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Enabled = false;
                label4.Visible = true;
                textBox3.Visible = true;
            }
            else
            {
                checkBox1.Enabled = true;
                label4.Visible = false;
                textBox3.Visible = false;
            }
        }

    }
}
