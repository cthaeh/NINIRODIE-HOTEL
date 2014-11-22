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
    public partial class BusquedaBajaEmp : Form
    {
        Personal empleado_seleccionado;
        bool se_busco = false;
        Decimal nro = 0;
        List<Personal> empleados_buscados;

        public BusquedaBajaEmp()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (se_busco == true)
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    empleado_seleccionado = (Personal)this.dataGridView1.SelectedRows[0].DataBoundItem;
                    new BajaEmp(empleado_seleccionado).ShowDialog(this);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario", "Alerta", MessageBoxButtons.OK);
                }
            }
                
        
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

        private void buscar_Click(object sender, EventArgs e)
        {
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

                empleados_buscados = RepositorioEmpleado.Instance.BuscarEmpleadoD(textBoxap.Text, textBoxmail.Text, textBoxnomb.Text, nro);


                if (empleados_buscados.Count == 0)
                {
                    MessageBox.Show("Usuario no existe", "ALERTA", MessageBoxButtons.OK);
                }

                this.dataGridView1.DataSource = new List<Personal>();
                this.dataGridView1.Refresh();
                this.dataGridView1.DataSource = empleados_buscados;
                this.dataGridView1.Refresh();

                this.dataGridView1.Columns["identificador"].Visible = false;
                this.dataGridView1.Columns["codigo_usuario"].Visible = false;
                this.dataGridView1.Columns["tipo_documento"].Visible = false;
                this.dataGridView1.Columns["telefono"].Visible = false;
                this.dataGridView1.Columns["direccion"].Visible = false;
                this.dataGridView1.Columns["nacimiento"].Visible = false;

                this.dataGridView1.Columns["nombre"].ReadOnly = true;
                this.dataGridView1.Columns["apellido"].ReadOnly = true;
                this.dataGridView1.Columns["numero_documento"].ReadOnly = true;
                this.dataGridView1.Columns["mail"].ReadOnly = true;
            }

            se_busco = true;
        }

        private void textBoxmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloEscribeLetras(e);
        }


    }
}
