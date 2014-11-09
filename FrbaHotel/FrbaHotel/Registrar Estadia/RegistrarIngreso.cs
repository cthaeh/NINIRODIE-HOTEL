using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.NINIRODIE.Clases;
using FrbaHotel.ABM_de_Cliente;
using FrbaHotel.Generar_Modificar_Reserva;
using FrbaHotel.NINIRODIE.Repositorios;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class RegistrarIngreso : Form
    {
        public Usuario usuario { get; set; }
        public Reserva reserva { get; set; }
        public Decimal cantHuespedes { get; set; }

        public RegistrarIngreso(Usuario user, Reserva reserv)
        {
            InitializeComponent();
            usuario = user;
            reserva = reserv;
            PopularGrillas();
            MessageBox.Show("Recuerde ingresar los datos de todos los huéspedes.", "Atención", MessageBoxButtons.OK);
        }

        private void PopularGrillas()
        {
            this.ReservaDataGrid.DataSource = new List<Reserva>() {reserva};
            this.ReservaDataGrid.Columns["identificador_hotel"].Visible = false;
            this.ReservaDataGrid.Columns["identificador_regimen"].Visible = false;
            this.ReservaDataGrid.Columns["identificador_estado"].Visible = false;
            this.ReservaDataGrid.Refresh();

            List<Habitacion> habitaciones = RepositorioHabitacion.Instance.HabitacionesReserva(reserva);
            cantHuespedes = habitaciones.Sum(habitacion => habitacion.cantidadPersonas);

            this.HabitacionesDataGrid.DataSource = habitaciones;
            this.HabitacionesDataGrid.Columns["identificador"].Visible = false;
            this.HabitacionesDataGrid.Columns["codigo_hotel"].Visible = false;
            this.HabitacionesDataGrid.Columns["codigo_tipo"].Visible = false;
            this.HabitacionesDataGrid.Columns["habilitada"].Visible = false;
            this.HabitacionesDataGrid.Refresh();
        }

        private void NuevoClienteBoton_Click(object sender, EventArgs e)
        {
            new AltaCli().ShowDialog(this);
            cantHuespedes--;
        }

        private void BuscarClienteBoton_Click(object sender, EventArgs e)
        {
            DialogResult resultado = new BuscarCliente().ShowDialog(this);
            if (resultado == DialogResult.OK)
                cantHuespedes--;
            else
            {
                MessageBox.Show("No se ha encontrado al Cliente.\n" +
                                "Debe generar un nuevo Cliente.", "Reporte", MessageBoxButtons.OK);
                this.NuevoClienteBoton_Click(sender, e);
            }
        }

        private void RegistrarIngresoBoton_Click(object sender, EventArgs e)
        {
            RespositorioEstadia.Instance.RegistrarEstadia(reserva);
            RepositorioReserva.Instance.ActualizarEstadoReserva(reserva, 4005); //CodigoReservaEfectivizada
            
            MessageBox.Show("El ingreso se ha registrado.", "Informe", MessageBoxButtons.OK);
            this.Close();
        }
    }
}
