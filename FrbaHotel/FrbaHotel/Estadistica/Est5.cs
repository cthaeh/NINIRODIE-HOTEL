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

namespace FrbaHotel.Estadistica
{
    public partial class Est5 : Form
    {
        int dia_inicio, dia_fin, mes_inicio, mes_fin;
        String año;

        public Est5(int d_i, int d_f, int m_i, int m_f, String añ)
        {
            año = añ;
            dia_inicio = d_i;
            dia_fin = d_f;
            mes_fin = m_f;
            mes_inicio = m_i;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Est5_Load(object sender, EventArgs e)
        {
            String f_fin, f_ini;
            List<Cliente> clientes_grilla = new List<Cliente>();
            if (mes_fin < 10)
            {
                f_fin = año + "0" + mes_fin.ToString() + dia_fin.ToString() + " 08:00:00 AM";
            }
            else
            {
                f_fin = año + mes_fin.ToString() + dia_fin.ToString() + " 08:00:00 AM";
            }
            if (mes_inicio < 10)
            {
                f_ini = año + "0" + mes_inicio.ToString() + "0" + dia_inicio.ToString() + " 08:00:00 AM";
            }
            else
            {
                f_ini = año + mes_inicio.ToString() + "0" + dia_inicio.ToString() + " 08:00:00 AM";
            }

            clientes_grilla = RepositorioCliente.Instance.Estadistica5(f_ini, f_fin);

            this.dataGridView1.DataSource = new List<Cliente>();
            this.dataGridView1.Refresh();
            this.dataGridView1.DataSource = clientes_grilla;
            this.dataGridView1.Refresh();

            this.dataGridView1.Columns["identificador"].Visible = false;
            this.dataGridView1.Columns["codigo_usuario"].Visible = false;
            this.dataGridView1.Columns["tipo_documento"].Visible = false;
            this.dataGridView1.Columns["mail"].Visible = false;
            this.dataGridView1.Columns["telefono"].Visible = false;
            this.dataGridView1.Columns["calle"].Visible = false;
            this.dataGridView1.Columns["nro_calle"].Visible = false;
            this.dataGridView1.Columns["piso"].Visible = false;
            this.dataGridView1.Columns["departamento"].Visible = false;
            this.dataGridView1.Columns["localidad"].Visible = false;
            this.dataGridView1.Columns["nacimiento"].Visible = false;
            this.dataGridView1.Columns["pais"].Visible = false;

            this.dataGridView1.Columns["nombre"].ReadOnly = true;
            this.dataGridView1.Columns["apellido"].ReadOnly = true;
            this.dataGridView1.Columns["numero_documento"].ReadOnly = true;
            this.dataGridView1.Columns["nacionalidad"].ReadOnly = true;
        }

    }
}
