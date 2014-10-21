using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Estadistica
{
    public partial class EstMenu : Form
    {
        int dia_inicio, dia_fin, mes_inicio, mes_fin;

        public EstMenu(int d_i, int d_f, int m_i, int m_f)
        {
            dia_inicio = d_i;
            dia_fin = d_f;
            mes_fin = m_f;
            mes_inicio = m_i;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Est1(dia_inicio, dia_fin, mes_inicio, mes_fin).ShowDialog(this);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Est2(dia_inicio, dia_fin, mes_inicio, mes_fin).ShowDialog(this);
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Est3(dia_inicio, dia_fin, mes_inicio, mes_fin).ShowDialog(this);
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Est4(dia_inicio, dia_fin, mes_inicio, mes_fin).ShowDialog(this);
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Est5(dia_inicio, dia_fin, mes_inicio, mes_fin).ShowDialog(this);
            this.Close();
        }
    }
}
