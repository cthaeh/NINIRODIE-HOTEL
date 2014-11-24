using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.NINIRODIE.Repositorios;
using FrbaHotel.NINIRODIE.Clases;

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
                MessageBox.Show("Ingrese un codigo de estadia", "Alerta", MessageBoxButtons.OK);
            }
            else
            {

                Decimal bandera = RepositorioEscoit.Instance.BuscarEscoit(Decimal.Parse(textBoxcod.Text));
                if (bandera == 0)
                {
                    MessageBox.Show("La estadia ingresada no existe o no se le han cargado los consumibles", "Alerta", MessageBoxButtons.OK);
                }
                else
                {

                    Decimal bandera2 = RepositorioFactura.Instance.BuscarFacturaXRes(Decimal.Parse(textBoxcod.Text));
                    if (bandera2 != 1)
                    {
                        MessageBox.Show("La estadia ingresada ya se ha facturado", "Alerta", MessageBoxButtons.OK);
                    }
                    else
                    {
                        Decimal tiene_checkout = RepositorioEstadia.Instance.tieneOut(Decimal.Parse(textBoxcod.Text));
                        if (tiene_checkout == 1)
                        {
                            Estadia est = RepositorioEstadia.Instance.BuscarEstadiaxCod(Decimal.Parse(textBoxcod.Text));
                            Reserva res = RepositorioReserva.Instance.BuscarReserva(est.codigoReserva);

                            if (res.identificador != 0)
                            {
                                Regimen regimen = RepositorioRegimen.Instance.BuscarRegimen(res.identificador_regimen);
                                Decimal monto_estadia = RepositorioReserva.Instance.BuscarMontoEstadia(res.identificador);

                                List<Escoit> items = RepositorioEscoit.Instance.BuscarEscoits(est.codigo);


                                Decimal recarga = 0;
                                Decimal costo_factura = 0;
                                int n = 0;
                                while (n < items.Count)
                                {
                                    Decimal monto_consu = RepositorioConsumibles.Instance.BuscarMonto(items.ElementAt(n).cod_consumible);
                                    Decimal monto = items.ElementAt(n).cantidad * monto_consu;
                                    costo_factura = costo_factura + monto;
                                    n++;
                                }
                                if (regimen.identificador == 120)
                                {
                                    recarga = costo_factura;
                                }

                                new Facturar(costo_factura, recarga, monto_estadia, items).ShowDialog(this); ;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("La Reserva Ingresada No Existe", "Alerta", MessageBoxButtons.OK);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("La estadia no fue checkouteada", "Alerta", MessageBoxButtons.OK);
                            this.Close();
                        }
                    }
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
