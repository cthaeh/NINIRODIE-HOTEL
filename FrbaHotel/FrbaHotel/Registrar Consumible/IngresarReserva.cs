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

namespace FrbaHotel.Registrar_Consumible
{
    public partial class IngresarReserva : Form
    {
        public IngresarReserva()
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

        private void button1_Click(object sender, EventArgs e)
        {
            Decimal cant_personas = 0;
            if (textBoxcod.Text == "")
            {
                MessageBox.Show("Ingrese un codigo de reserva", "Alerta", MessageBoxButtons.OK);
            }
            else
            {
                Reserva res = RepositorioReserva.Instance.BuscarReserva(Decimal.Parse(textBoxcod.Text));
                Decimal cod_hab = RepositorioReserva.Instance.BuscarHabitacion(Decimal.Parse(textBoxcod.Text));

                Habitacion habitacion = RepositorioHabitacion.Instance.BuscarHab(cod_hab);
                Regimen regimen = RepositorioRegimen.Instance.BuscarRegimen(res.identificador_regimen);
                Hotel hotel = RepositorioHotel.Instance.BuscarHotelxId(res.identificador_hotel);

                if (res.identificador_estado != 4005)
                {
                    MessageBox.Show("La Reserva Indicada No Esta Finalizada", "Alerta", MessageBoxButtons.OK);
                }
                else
                {
                    if (habitacion.codigo_tipo == 1001)
                    {
                        cant_personas = 1;
                    }
                    else if (habitacion.codigo_tipo == 1002)
                    {
                        cant_personas = 2;
                    }
                    else if (habitacion.codigo_tipo == 1003)
                    {
                        cant_personas = 3;
                    }
                    else if (habitacion.codigo_tipo == 1004)
                    {
                        cant_personas = 4;
                    }
                    else
                    {
                        cant_personas = 5;
                    }

                    new CargarConsumibles(res.identificador, cant_personas, hotel.categoria,
                        regimen.precio).ShowDialog(this);

                    this.Close();
                }
            }
        }
    }
}
