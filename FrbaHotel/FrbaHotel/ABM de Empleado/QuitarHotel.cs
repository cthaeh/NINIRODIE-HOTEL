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

namespace FrbaHotel.ABM_de_Empleado
{
    public partial class QuitarHotel : Form
    {
        Personal personal_seleccionado;
        Hotel hotel_seleccionado;
        public QuitarHotel(Personal per)
        {
            personal_seleccionado = per;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Qui_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                hotel_seleccionado = (Hotel)this.dataGridView1.SelectedRows[0].DataBoundItem;

                RepositorioHotel.Instance.QuitarHotel(personal_seleccionado.codigo_usuario, hotel_seleccionado.identificador);
                MessageBox.Show("Se ha Quitado Correctamente", "Alerta", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void QuitarHotel_Load(object sender, EventArgs e)
        {
            List<Hotel> hoteles = RepositorioHotel.Instance.BuscarHoteles();
            List<Hotemp> hoteles_emp = RepositorioHotel.Instance.BuscarHotelesEmp(personal_seleccionado.codigo_usuario);

            List<Hotel> hoteles_grilla = new List<Hotel>();

            int n = 0;
            int j;
            bool encontro;

            while (n < hoteles.Count)
            {
                encontro = false;
                j = 0;
                while (j < hoteles_emp.Count)
                {
                    if (hoteles.ElementAt(n).identificador == hoteles_emp.ElementAt(j).identificador_hotel)
                    {
                        encontro = true;
                    }
                    j = j + 1;
                }
                if (encontro == true)
                {
                    hoteles_grilla.Add(hoteles.ElementAt(n));
                }
                n = n + 1;

            }

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
    }
}
