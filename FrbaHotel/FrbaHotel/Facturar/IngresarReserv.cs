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
    public partial class IngresarReserv : Form
    {
        public IngresarReserv()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void textBoxcod_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void IngresarReserv_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxcod.Text == "")
            {
                MessageBox.Show("Ingrese un codigo de reserva", "Alerta", MessageBoxButtons.OK);
            }

            Decimal bandera = RepositorioFactura.Instance.BuscarFacturaXRes(Decimal.Parse(textBoxcod.Text));
            if (bandera == 1)
            {
                MessageBox.Show("La reserva ingresada no existe o no se le han cargado los consumibles", "Alerta", MessageBoxButtons.OK);
            }

            Decimal bandera2 = RepositorioFactura.Instance.BuscarMontoFacxRes(Decimal.Parse(textBoxcod.Text));
            if (bandera2 == 0)
            {
                MessageBox.Show("La reserva ingresada ya se ha facturado", "Alerta", MessageBoxButtons.OK);
            }
        }
    }
}
