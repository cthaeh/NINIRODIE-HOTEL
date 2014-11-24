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
        Decimal codigo_hotel_seleccionado;

        public IngresarReserva(Decimal cod_hot)
        {
            codigo_hotel_seleccionado = cod_hot;
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
            if (textBoxcod.Text == "")
            {
                MessageBox.Show("Ingrese un codigo de reserva", "Alerta", MessageBoxButtons.OK);
            }
            else
            {
             //   Decimal bandera = RepositorioFactura.Instance.BuscarFacturaXRes(Decimal.Parse(textBoxcod.Text));
            //    if (bandera != 1)
            //    {
            //        MessageBox.Show("La reserva ingresada ya ha sigo cargada", "Alerta", MessageBoxButtons.OK);
            //    }
            //    else
            //    {			
                    Reserva res = RepositorioReserva.Instance.BuscarReserva(Decimal.Parse(textBoxcod.Text));
					
					if(res.identificador != 0)
					{
					
						Regimen regimen = RepositorioRegimen.Instance.BuscarRegimen(res.identificador_regimen);
						Hotel hotel = RepositorioHotel.Instance.BuscarHotelxId(res.identificador_hotel);

                        if (res.identificador_estado == 4000 && res.identificador_estado == 4001)
                        {
                            MessageBox.Show("La Reserva Indicada Esta Cancelada", "Alerta", MessageBoxButtons.OK);
                        }
                        else
                        {
                            if (res.identificador_hotel == codigo_hotel_seleccionado)
                            {
                                if ((res.fechaDesde - FechaSistema.Instance.fecha).Days > 0)
                                {
                                    MessageBox.Show("La reserva ingresada es futura", "Alerta", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    new ElegirHabitacion(Decimal.Parse(textBoxcod.Text), hotel.categoria,
                                        regimen.precio).ShowDialog(this);

                                    this.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("La estadia no pertenece al Hotel al cual ha ingresado", "Alerta", MessageBoxButtons.OK);
                            }
                        }
					}else
					{
						MessageBox.Show("La Reserva Ingresada No Existe", "Alerta", MessageBoxButtons.OK);
						this.Close();
					}	
				//}
            }
        }
    }
}
