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

namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class BusquedaModHab : Form
    {
        bool banderanro = false, banderapiso = false, banderaper = false;
        bool seguir = true, se_busco = false;
        Decimal tipo = 0;
        Hotel hotel_seleccionado;
        Habitacion habitacion_seleccionada;

        public BusquedaModHab(Hotel hot)
        {
            hotel_seleccionado = hot;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void soloEscribeLetras(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
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

        private void textBoxnro_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxpis_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void textBoxper_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (se_busco == true)
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    habitacion_seleccionada = (Habitacion)this.dataGridView1.SelectedRows[0].DataBoundItem;
                    new ModificarHab(habitacion_seleccionada, hotel_seleccionado).ShowDialog(this);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Seleccione una elemente de la grilla", "Alerta", MessageBoxButtons.OK);
                    
                }
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            se_busco = true;
            banderapiso = false;
            banderanro = false;
            seguir = true;

            if (textBoxnro.Text == "")
            {
                banderanro = true;
            }

            if (textBoxpis.Text == "")
            {
                banderapiso = true;
            }

            if (textBoxnro.Text == "" && textBoxper.Text == "" && textBoxpis.Text == "")
            {
                MessageBox.Show("Debe ingresar algun campo", "ALERTA", MessageBoxButtons.OK);
                seguir = false;
            }
            else
            {

                if (banderanro != true)
                {
                    if (decimal.Parse(textBoxnro.Text) < 1)
                    {
                        MessageBox.Show("El numero debe ser mayor a 0", "ALERTA", MessageBoxButtons.OK);
                        seguir = false;
                    }
                }

                if (textBoxper.Text == "Simple")
                {
                    tipo = 1001;
                }
                else if (textBoxper.Text == "Doble")
                {
                    tipo = 1002;
                }
                else if (textBoxper.Text == "Triple")
                {
                    tipo = 1003;
                }
                else if (textBoxper.Text == "Cuadruple")
                {
                    tipo = 1004;
                }
                else if (textBoxper.Text == "King")
                {
                    tipo = 1005;
                }
                else if (textBoxper.Text == "")
                {
                    seguir = true;
                }
                else
                {
                    MessageBox.Show("El tipo de habitacion no es correcto", "Alerta", MessageBoxButtons.OK);
                    seguir = false;
                }

                if (banderapiso != true)
                {
                    if (Decimal.Parse(textBoxpis.Text) < 1)
                    {
                        MessageBox.Show("El piso debe ser mayor a 0", "ALERTA", MessageBoxButtons.OK);
                        seguir = false;
                    }
                    else { seguir = true; }
                }
            }
                    

            if (seguir == true)
            {
                List<Habitacion> habitacion_grilla = RepositorioHabitacion.Instance.BuscarHabitacion(textBoxnro.Text, textBoxpis.Text, tipo, hotel_seleccionado.identificador);

                this.dataGridView1.DataSource = new List<Habitacion>();
                this.dataGridView1.Refresh();
                this.dataGridView1.DataSource = habitacion_grilla;
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
        }

    }
}
