using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.LA_REVANCHA.Clases;
using FrbaHotel.LA_REVANCHA.Repositorios;

namespace FrbaHotel.Login
{
    public partial class SeleccionHot : Form
    {
        public string tipo;
        public Usuario usuario;
        Hotel hotel_seleccionado;
        public SeleccionHot(String tipousuario, Usuario usu)
        {
            tipo = tipousuario;
            usuario = usu;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                hotel_seleccionado = (Hotel)this.dataGridView1.SelectedRows[0].DataBoundItem;

                new Panel(tipo, usuario, hotel_seleccionado).ShowDialog(this);
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un objeto", "Alerta", MessageBoxButtons.OK);
            }
        }

        private void SeleccionHot_Load(object sender, EventArgs e)
        {
            List<Hotel> hoteles_grilla = new List<Hotel>();
            if (tipo == "pulenta")
            {
                hoteles_grilla = RepositorioHotel.Instance.BuscarHoteles();
            }
            else if (tipo == "CLIENTE")
            {
                hoteles_grilla = BuscarHotelDeCli(usuario.codigo);
            }
            else
            {
                List<Hotel> hoteles = RepositorioHotel.Instance.BuscarHoteles();
                List<Hotemp> hoteles_emp = RepositorioHotel.Instance.BuscarHotelesEmp(usuario.codigo);

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

        public List<Hotel> BuscarHotelDeCli(Decimal cod_usuario)
        {
            List<Reserva> reservas = RepositorioReserva.Instance.BuscarReservas();
            List<Hotel> hoteles = RepositorioHotel.Instance.BuscarHoteles();
            List<Resusu> res_usu = RepositorioReserva.Instance.BuscarReservasDeUsu(cod_usuario);
            List<Hotel> hoteles_grilla = new List<Hotel>();
            List<Reserva> reservas_usuario = new List<Reserva>();

            int n = 0;
            int j;
            bool encontro;

            while (n < reservas.Count)
            {
                encontro = false;
                j = 0;
                while (j < res_usu.Count)
                {
                    if (reservas.ElementAt(n).identificador == res_usu.ElementAt(j).identificador_reserva)
                    {
                        encontro = true;
                    }
                    j = j + 1;
                }
                if (encontro == true)
                {
                    reservas_usuario.Add(reservas.ElementAt(n));
                }
                n = n + 1;

            }

            n = 0;

            while (n < hoteles.Count)
            {
                encontro = false;
                j = 0;
                while (j < reservas_usuario.Count)
                {
                    if (hoteles.ElementAt(n).identificador == reservas_usuario.ElementAt(j).identificador_hotel)
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

            return hoteles_grilla;
        }
    }
}
