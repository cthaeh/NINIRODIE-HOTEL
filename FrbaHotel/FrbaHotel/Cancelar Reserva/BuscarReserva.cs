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

namespace FrbaHotel.Cancelar_Reserva
{
    public partial class BuscarReserva : Form
    {

        public Reserva reservaACancelar { get; set; }
        public Boolean puedeCancelarse { get; set; }
        public Usuario usuario { get; set; }

        public BuscarReserva(Usuario user)
        {
            InitializeComponent();
            usuario = user;

            MessageBox.Show("El código de reserva solo debe contener Números", "Atención", MessageBoxButtons.OK);

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!Char.IsDigit(e.KeyChar) & !Char.IsControl(e.KeyChar));
        }

        private void BuscarBoton_Click(object sender, EventArgs e)
        {
            if (codigoReservaTextBox.Text != "")
            {
                Decimal codigoReserva = Decimal.Parse(this.codigoReservaTextBox.Text);
                if (usuario.tipo != "CLIENTE")
                    reservaACancelar = RepositorioReserva.Instance.BuscarReserva(codigoReserva);
                else
                    reservaACancelar = RepositorioReserva.Instance.BuscarReservaDeUsuario(codigoReserva, usuario);


                if (reservaACancelar.identificador != -1)
                {
                    this.compararFechaReservaConActual();

                    if (puedeCancelarse)
                        new CancelarReserva(usuario, reservaACancelar).ShowDialog(this);
                    else
                        MessageBox.Show("No puede realizarse la cancelación.\n" +
                                        "Las cancelaciones pueden realizarse hasta\n" +
                                        "el día anterior al comienzo de la reserva.",
                                        "Atención", MessageBoxButtons.OK);
                    this.Close();
                }
                else
                {
                    VerificarQueNoEsteCancelada();
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un Código de Reserva.", "Atención", MessageBoxButtons.OK);
            }
           
        }

        private void VerificarQueNoEsteCancelada()
        {
            Decimal codigoReserva = Decimal.Parse(this.codigoReservaTextBox.Text);
            Cancelacion cancel = RepositorioReserva.Instance.VerificarCancelacion(codigoReserva, usuario);
            if (cancel.codigo < 0)
                MessageBox.Show("La reserva no ha sido encontrada o usted no es el resposable de la misma.\n" +
                            "Asegurese de ingresar el código correctamente.\n", "Atención", MessageBoxButtons.OK);
            else
            {
                MessageBox.Show("La reserva ya ha sido cancelada el día: " + cancel.fechaCancelacion.ToString() +
                                "\nEl código de cancelación es: " + cancel.codigo.ToString() + "."
                                , "Atención", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private bool compararFechaReservaConActual()
        {
            puedeCancelarse = FechaSistema.Instance.fecha.CompareTo(reservaACancelar.fechaDesde) < 0;

            return puedeCancelarse;
        }

        private void CancelarBoton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
