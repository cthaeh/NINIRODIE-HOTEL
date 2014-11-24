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
        Decimal reserva, categoria, precio_base;
        DataRow renglon;
        DataTable tabla = new DataTable();
        List<Consumibles> consu_grilla;
        List<Escoit> escoits;
        int cantidad = 0;
        Decimal cod_hab;

        public CargarConsumibles(Decimal res, Decimal cat, Decimal pr, Decimal hab)
        {
            cod_hab = hab;
            reserva = res;
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
            consu_grilla = RepositorioConsumibles.Instance.BuscarConsu();

            this.dataGridView1.DataSource = new List<Consumibles>();
            this.dataGridView1.Refresh();
            this.dataGridView1.DataSource = consu_grilla;
            this.dataGridView1.Refresh();

            this.dataGridView1.Columns["codigo"].Visible = false;

            this.dataGridView1.Columns["precio"].ReadOnly = true;
            this.dataGridView1.Columns["descripcion"].ReadOnly = true;

            tabla.Columns.Add(new DataColumn("codigo"));
            tabla.Columns.Add(new DataColumn("precio"));
            tabla.Columns.Add(new DataColumn("descripcion"));
            tabla.Columns.Add(new DataColumn("cantidad"));

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                cantidad = cantidad + 1;

                Consumibles consumible_seleccionado = (Consumibles)this.dataGridView1.SelectedRows[0].DataBoundItem;

                renglon = tabla.NewRow();
                renglon[0] = consumible_seleccionado.codigo.ToString();
                renglon[1] = consumible_seleccionado.precio.ToString();
                renglon[2] = consumible_seleccionado.descripcion.ToString(); ;
                renglon[3] = "0";

                tabla.Rows.Add(renglon);
                dataGridView2.DataSource = tabla;

                this.dataGridView2.Columns["codigo"].Visible = false;

                this.dataGridView2.Columns["precio"].ReadOnly = true;
                this.dataGridView2.Columns["descripcion"].ReadOnly = true;


                int n = 0, m = 0;
                while (n < consu_grilla.Count)
                {

                    if (consu_grilla.ElementAt(n).descripcion == consumible_seleccionado.descripcion)
                    {
                        m = n;
                    }
                    n = n + 1;
                }

                consu_grilla.RemoveAt(m);

                this.dataGridView1.DataSource = new List<Consumibles>();
                this.dataGridView1.Refresh();
                this.dataGridView1.DataSource = consu_grilla;
                this.dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Seleccione un consumible", "Alerta", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cantidad = 0;

            consu_grilla = RepositorioConsumibles.Instance.BuscarConsu();

            this.dataGridView1.DataSource = new List<Consumibles>();
            this.dataGridView1.Refresh();
            this.dataGridView1.DataSource = consu_grilla;
            this.dataGridView1.Refresh();

            tabla = new DataTable();

            tabla.Columns.Add(new DataColumn("codigo"));
            tabla.Columns.Add(new DataColumn("precio"));
            tabla.Columns.Add(new DataColumn("descripcion"));
            tabla.Columns.Add(new DataColumn("cantidad"));

            this.dataGridView2.Columns["codigo"].Visible = false;
            
            dataGridView2.DataSource = tabla;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            escoits = new List<Escoit>();

            Reserva rese = RepositorioReserva.Instance.BuscarReserva(reserva);
            Estadia estad = RepositorioEstadia.Instance.BuscarEstadia(rese);

            int n = 0;
            bool salir = false;
            bool convirtio;
            while (n < cantidad && salir == false)
            {
                Decimal codigo_consu = Decimal.Parse(dataGridView2.Rows[n].Cells[0].Value.ToString());
                Decimal precio = Decimal.Parse(dataGridView2.Rows[n].Cells[1].Value.ToString());
                Decimal cant;
                    
                convirtio = Decimal.TryParse(dataGridView2.Rows[n].Cells[3].Value.ToString(),out cant);
                
                if (convirtio == false)
                {
                    MessageBox.Show("Las cantidades deben ser un número positivo", "Alerta", MessageBoxButtons.OK);
                    salir = true;
                }
                else
                {
                    if (cant > 0)
                    {
                        Escoit escoi = new Escoit(0, codigo_consu, estad.codigo, cod_hab, 0, cant);
                        escoits.Add(escoi);
                        n = n + 1;
                    }
                    else
                    {
                        MessageBox.Show("Las cantidades deben ser positivas", "Alerta", MessageBoxButtons.OK);
                    }
                }
            }
            if (salir == false)
            {
                int j = 0;
                if (rese.identificador == 0)
                {
                    MessageBox.Show("No se encuentra una reserva con ese codigo", "Alerta", MessageBoxButtons.OK);
                }
                else
                {
                    if (estad.codigo == 0)
                    {
                        MessageBox.Show("No se encuentra estadia para la reserva ingresada", "Alerta", MessageBoxButtons.OK);
                    }
                    else
                    {

                        Decimal usuario = RepositorioReserva.Instance.BuscarUsuario(reserva);

                        Decimal cod_facutra = RepositorioFactura.Instance.BuscarFacturaXRes(estad.codigo);

                        while (j < escoits.Count)
                        {
                            RepositorioEscoit.Instance.InsertarEscoit(escoits.ElementAt(j).cod_consumible, escoits.ElementAt(j).cod_estadia, escoits.ElementAt(j).cantidad, escoits.ElementAt(j).cod_habitacion);
                            j++;
                        }
                        RepositorioEscoit.Instance.InsertarEstadia(escoits.ElementAt(j-1).cod_estadia);

                        MessageBox.Show("Los consumibles se cargaron exitosamente", "Alerta", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
            }   
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
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
    }
}
