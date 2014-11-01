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
    public partial class RegistrarIngresoEgreso : Form
    {
        public Usuario usuario { get; set; }
        public Reserva reserva { get; set; }
        public Decimal cantHuespedes { get; set; }
        public ModoApertura modoApertura { get; set; }
        public List<Habitacion> habitaciones { get; set; }
        public Hotel hotelSeleccionado { get; set; }
        public Decimal precio { get; set; }

        public RegistrarIngresoEgreso(Usuario user, Reserva reserv, ModoApertura modoApert, Hotel hotelSelecc)
        {
            InitializeComponent();
            usuario = user;
            reserva = reserv;
            modoApertura = modoApert;
            hotelSeleccionado = hotelSelecc;
            precio = 0;
            PopularGrillas();
            
            ModificarBotonesSegunTipoRegistro();
            if (ModoApertura.CHECKIN == modoApertura)
                MessageBox.Show("Recuerde ingresar los datos de todos los huéspedes.", "Atención", MessageBoxButtons.OK);
            
        }

        private void ModificarBotonesSegunTipoRegistro()
        {
            if (modoApertura == ModoApertura.CHECKOUT)
            {
                this.Text = "Registrar Egreso";
                this.BuscarClienteBoton.Dispose();
                this.GenericoBoton.Text = "Salir";
                this.RegistrarBoton.Text = "Registrar Egreso";

                this.RegistrarBoton.Click += new EventHandler(RegistrarEgresoBoton_Click);
                this.GenericoBoton.Click += new EventHandler(Salir_Click);
            }
            else
            {
                this.RegistrarBoton.Text = "Registrar Ingreso";
                this.RegistrarBoton.Click += new EventHandler(RegistrarIngresoBoton_Click);
                this.GenericoBoton.Text = "Nuevo Cliente";
                this.GenericoBoton.Click += new EventHandler(NuevoClienteBoton_Click);
            }
        }

        void RegistrarEgresoBoton_Click(object sender, EventArgs e)
        {
            Estadia estadia = RepositorioEstadia.Instance.BuscarEstadia(reserva);
            estadia.fechaHasta = FechaSistema.Instance.fecha;

            estadia.CalcularDiasAlojados();
            estadia.CalcularDiasNoAlojados(reserva.fechaHasta);
            estadia.precio = precio * (estadia.diasAlojados + estadia.diasNoAlojados);

            RepositorioEstadia.Instance.RegistrarEgreso(estadia);

            MessageBox.Show("El egreso se ha registrado.", "Informe", MessageBoxButtons.OK);

            this.Close();
        }

        private void PrecioPorHabitaciones()
        {
            Regimen regimen = RepositorioRegimen.Instance.BuscarRegimen(reserva.identificador_regimen);
            
            foreach (Habitacion habitacion in (List<Habitacion>)this.HabitacionesDataGrid.DataSource)
            {
                habitacion.cantidadPersonas = RepositorioHabitacion.Instance.CantidadPersonasParaHabitacion(habitacion);

                habitacion.precio = (regimen.precio * habitacion.cantidadPersonas) + hotelSeleccionado.recarga;
                precio += habitacion.precio; 
            }
            this.HabitacionesDataGrid.Refresh();
            
        }

        void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
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

            this.PrecioPorHabitaciones();
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
            Estadia estadia = RepositorioEstadia.Instance.BuscarEstadia(reserva);

            if (estadia.codigo == 0)
                RepositorioEstadia.Instance.RegistrarEstadia(reserva);
            else
                RepositorioEstadia.Instance.ActualizarIngreso(reserva);

            RepositorioReserva.Instance.ActualizarEstadoReserva(reserva, 4005); //CodigoReservaEfectivizada
            
            MessageBox.Show("El ingreso se ha registrado.", "Informe", MessageBoxButtons.OK);
            this.Close();
        }
    }
}
