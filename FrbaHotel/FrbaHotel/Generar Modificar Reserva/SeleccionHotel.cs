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
    public partial class SeleccionHotel : Form
    {
        Hotel hotel_seleccionado;

        public SeleccionHotel()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SeleccionHotel_Load(object sender, EventArgs e)
        {
            List<Hotel> hoteles_grilla = new List<Hotel>();
            hoteles_grilla = RepositorioHotel.Instance.BuscarHoteles();

            this.dataGridView1.DataSource = new List<Hotel>();
            this.dataGridView1.Refresh();
            this.dataGridView1.DataSource = hoteles_grilla;
            this.dataGridView1.Refresh();

            this.dataGridView1.Columns["identificador"].Visible = false;
            this.dataGridView1.Columns["habilitado"].Visible = false;
            this.dataGridView1.Columns["telefono"].Visible = false;
            this.dataGridView1.Columns["calle"].Visible = false;
            this.dataGridView1.Columns["creacion"].Visible = false;
            this.dataGridView1.Columns["nro_calle"].Visible = false;
            this.dataGridView1.Columns["recarga"].Visible = false;
            this.dataGridView1.Columns["mail"].Visible = false;

            this.dataGridView1.Columns["nombre"].ReadOnly = true;
            this.dataGridView1.Columns["categoria"].ReadOnly = true;
            this.dataGridView1.Columns["pais"].ReadOnly = true;
            this.dataGridView1.Columns["ciudad"].ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                hotel_seleccionado = (Hotel)this.dataGridView1.SelectedRows[0].DataBoundItem;
                new IngresarDatos(hotel_seleccionado).ShowDialog(this);
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un objeto", "Alerta", MessageBoxButtons.OK);
            }
        }
    }
}
