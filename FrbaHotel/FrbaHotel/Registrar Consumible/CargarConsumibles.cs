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

namespace FrbaHotel.Registrar_Consumible
{
    public partial class CargarConsumibles : Form
    {
        Decimal reserva, personas, categoria, precio_base;
        DataRow renglon;
        DataTable tabla = new DataTable();

        public CargarConsumibles(Decimal res, Decimal per, Decimal cat, Decimal pr)
        {
            reserva = res;
            personas = per;
            categoria = cat;
            precio_base = pr;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarConsumibles_Load(object sender, EventArgs e)
        {
            List<Consumibles> consu_grilla = RepositorioConsumibles.Instance.BuscarConsu();

            this.dataGridView1.DataSource = new List<Consumibles>();
            this.dataGridView1.Refresh();
            this.dataGridView1.DataSource = consu_grilla;
            this.dataGridView1.Refresh();

            this.dataGridView1.Columns["codigo"].Visible = false;

            this.dataGridView1.Columns["precio"].ReadOnly = true;
            this.dataGridView1.Columns["descripcion"].ReadOnly = true;

            tabla.Columns.Add(new DataColumn("precio"));
            tabla.Columns.Add(new DataColumn("descripcion"));
            tabla.Columns.Add(new DataColumn("cantidad"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consumibles consumible_seleccionado = (Consumibles)this.dataGridView1.SelectedRows[0].DataBoundItem;

            renglon = tabla.NewRow();
            renglon[0] = consumible_seleccionado.precio.ToString();
            renglon[1] = consumible_seleccionado.descripcion.ToString();;
            renglon[2] = "0";

            tabla.Rows.Add(renglon);
            dataGridView2.DataSource = tabla;


        }
    }
}
