using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.LA_REVANCHA.Repositorios;
using FrbaHotel.LA_REVANCHA.Clases;

namespace FrbaHotel.Estadistica
{
    public partial class Est3 : Form
    {
        int dia_inicio, dia_fin, mes_inicio, mes_fin;
        String año;

        public Est3(int d_i, int d_f, int m_i, int m_f, String añ)
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

        private void Est3_Load(object sender, EventArgs e)
        {
            String f_fin, f_ini;
            List<Hotel> hoteles_grilla = new List<Hotel>();
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
            hoteles_grilla = RepositorioEstadistica3.Instance.Estadistica3(f_ini, f_fin);

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
