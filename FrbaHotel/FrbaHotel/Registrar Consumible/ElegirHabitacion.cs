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
    public partial class ElegirHabitacion : Form
    {
        Decimal reserva, personas, categoria, precio_base;

        public ElegirHabitacion(Decimal res, Decimal cat, Decimal pr)
        {
            reserva = res;
            categoria = cat;
            precio_base = pr;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ElegirHabitacion_Load(object sender, EventArgs e)
        {
            List<Decimal> codigohab = new List<decimal>();
            codigohab = RepositorioReserva.Instance.BuscarHabitaciones(reserva);
            List<Habitacion> hab_grilla = new List<Habitacion>();

            int n = 0;
            while (n < codigohab.Count)
            {
                Habitacion habi = RepositorioHabitacion.Instance.BuscarHab(codigohab.ElementAt(n));
                hab_grilla.Add(habi);
                n = n + 1;
            }

            this.dataGridView1.DataSource = new List<Habitacion>();
            this.dataGridView1.Refresh();
            this.dataGridView1.DataSource = hab_grilla;
            this.dataGridView1.Refresh();

            this.dataGridView1.Columns["identificador"].Visible = false;
            this.dataGridView1.Columns["codigo_hotel"].Visible = false;
            this.dataGridView1.Columns["codigo_tipo"].Visible = false;
            this.dataGridView1.Columns["habilitada"].Visible = false;

            this.dataGridView1.Columns["numero"].ReadOnly = true;
            this.dataGridView1.Columns["piso"].ReadOnly = true;
            this.dataGridView1.Columns["ubicacion"].ReadOnly = true;
            this.dataGridView1.Columns["descripcion"].ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {

                new CargarConsumibles(reserva, categoria, precio_base).ShowDialog(this);
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione una elemento de la grilla", "Alerta", MessageBoxButtons.OK);

            }
        }
    }
}
