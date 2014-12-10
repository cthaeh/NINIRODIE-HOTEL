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
    public partial class Est4 : Form
    {
        int dia_inicio, dia_fin, mes_inicio, mes_fin;
        String año;

        public Est4(int d_i, int d_f, int m_i, int m_f, String añ)
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

        private void Est4_Load(object sender, EventArgs e)
        {
            String f_fin, f_ini;
            List<Habitacion> habitaciones_grilla = new List<Habitacion>();
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
            habitaciones_grilla = RepositorioHabitacion.Instance.Estadistica4(f_ini, f_fin);

            this.dataGridView1.DataSource = new List<Habitacion>();
            this.dataGridView1.Refresh();
            this.dataGridView1.DataSource = habitaciones_grilla;
            this.dataGridView1.Refresh();

            this.dataGridView1.Columns["identificador"].Visible = false;
            this.dataGridView1.Columns["codigo_tipo"].Visible = false;
            this.dataGridView1.Columns["descripcion"].Visible = false;
            this.dataGridView1.Columns["habilitada"].Visible = false;

            this.dataGridView1.Columns["numero"].ReadOnly = true;
            this.dataGridView1.Columns["codigo_hotel"].ReadOnly = true;
            this.dataGridView1.Columns["piso"].ReadOnly = true;
            this.dataGridView1.Columns["ubicacion"].ReadOnly = true;
        }


    }
}
