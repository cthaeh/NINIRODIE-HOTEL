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

namespace FrbaHotel.ABM_de_Rol
{
    public partial class BusquedaModRol : Form
    {
        Rol rol_seleccionado;

        public BusquedaModRol()
        {
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
                rol_seleccionado = (Rol)this.dataGridView1.SelectedRows[0].DataBoundItem;
                new ModificarRol(rol_seleccionado).ShowDialog(this);

                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione una elemente de la grilla", "Alerta", MessageBoxButtons.OK);

            }
        }

        private void BusquedaModRol_Load(object sender, EventArgs e)
        {
            List<Rol> rol_grilla = RepositorioRol.Instance.BuscarRoles();

            this.dataGridView1.DataSource = new List<Rol>();
            this.dataGridView1.Refresh();
            this.dataGridView1.DataSource = rol_grilla;
            this.dataGridView1.Refresh();

            this.dataGridView1.Columns["identificador"].Visible = false;
            this.dataGridView1.Columns["habilitado"].Visible = false;

            this.dataGridView1.Columns["descripcion"].ReadOnly = true;
        }
    }
}
