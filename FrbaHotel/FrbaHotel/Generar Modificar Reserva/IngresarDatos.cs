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

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class IngresarDatos : Form
    {
        Decimal codigo_reserva;
        String nombre_usuario;
 
        public IngresarDatos()
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "" & this.textBox2.Text != "")
            {
                Decimal codigoReserva = Decimal.Parse(this.textBox2.Text);
                Usuario usuario = RepositorioUsuario.Instance.BuscarCliente(this.textBox1.Text);
                Reserva ReservaBuscada = RepositorioReserva.Instance.BuscarReservaDeUsuario(codigoReserva, usuario);

                if (ReservaBuscada.identificador != -1)
                {
                    if (FechaSistema.Instance.CompararConFechaDelSistema(ReservaBuscada.fechaDesde) < 0)
                    {
                        Hotel hotel = RepositorioHotel.Instance.BuscarHotelxId(ReservaBuscada.identificador_hotel);
                        new ModificarReserva(usuario, ReservaBuscada, hotel).ShowDialog(this);
                        this.Close();
                    }
                    else
                        MessageBox.Show("No puede realizarse una modificación sobre la reserva indicada.\n" +
                                    "Las modificaciones pueden realizarse hasta\n" +
                                    "el día anterior al comienzo de la reserva.",
                                     "Atención", MessageBoxButtons.OK);
                }
                else
                    VerificarReservaCancelada(codigoReserva, usuario);
            }
            else
                MessageBox.Show("Debe ingresar todos los datos.", "Atención", MessageBoxButtons.OK);
            }

        private static void VerificarReservaCancelada(Decimal codReserva, Usuario user)
        {
            Cancelacion cancel = RepositorioReserva.Instance.VerificarCancelacion(codReserva, user);

            if(cancel.codigo != -1)
                MessageBox.Show("No se ha encontrado la Reserva correspondiente\n" +
                                "al Código de Usuario ingresado.\n" +
                                "Por favor, verifique los datos ingresados.", "Atención", MessageBoxButtons.OK);
            else
                MessageBox.Show("La reserva ya ha sido cancelada el día: " + cancel.fechaCancelacion.ToString() +
                               "\nEl código de cancelación es: " + cancel.codigo.ToString() + "."
                               , "Atención", MessageBoxButtons.OK);
        }
    
    }
}
