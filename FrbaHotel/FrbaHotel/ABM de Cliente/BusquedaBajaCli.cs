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

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class BusquedaBajaCli : Form
    {
        Decimal nro = 0;
        List<Cliente> clientes_buscados;
        Cliente cliente_seleccionado;
        bool se_busco = false;

        public BusquedaBajaCli()
        {
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

        private void textBoxnomb_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxap_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }

        private void textBoxdni_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeNumeros(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (se_busco == false)
            {
                MessageBox.Show("Realice una busqueda", "ALERTA", MessageBoxButtons.OK);
            }
            else
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    cliente_seleccionado = (Cliente)this.dataGridView1.SelectedRows[0].DataBoundItem;
                    new BajaCli(cliente_seleccionado).ShowDialog(this);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Seleccione un empleado", "Alerta", MessageBoxButtons.OK);
                }
            }
            
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            se_busco = true;

            if (textBoxap.Text == "" && textBoxdni.Text == "" && textBoxmail.Text == ""
    && textBoxnomb.Text == "")
            {
                MessageBox.Show("Debe ingresar algun campo", "ALERTA", MessageBoxButtons.OK);
            }
            else
            {
                if (textBoxdni.Text != "")
                {
                    nro = Decimal.Parse(textBoxdni.Text);
                }

                clientes_buscados = RepositorioCliente.Instance.BuscarClienteD(textBoxap.Text, textBoxnomb.Text, textBoxmail.Text, nro);


                this.dataGridView1.DataSource = new List<Cliente>();
                this.dataGridView1.Refresh();
                this.dataGridView1.DataSource = clientes_buscados;
                this.dataGridView1.Refresh();

                this.dataGridView1.Columns["identificador"].Visible = false;
                this.dataGridView1.Columns["codigo_usuario"].Visible = false;
                this.dataGridView1.Columns["tipo_documento"].Visible = false;
                this.dataGridView1.Columns["telefono"].Visible = false;
                this.dataGridView1.Columns["nacimiento"].Visible = false;
                this.dataGridView1.Columns["calle"].Visible = false;
                this.dataGridView1.Columns["nro_calle"].Visible = false;
                this.dataGridView1.Columns["piso"].Visible = false;
                this.dataGridView1.Columns["departamento"].Visible = false;
                this.dataGridView1.Columns["nacionalidad"].Visible = false;
                this.dataGridView1.Columns["pais"].Visible = false;
                this.dataGridView1.Columns["localidad"].Visible = false;

                this.dataGridView1.Columns["nombre"].ReadOnly = true;
                this.dataGridView1.Columns["apellido"].ReadOnly = true;
                this.dataGridView1.Columns["numero_documento"].ReadOnly = true;
                this.dataGridView1.Columns["mail"].ReadOnly = true;
            }
        }
    }
}
